using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyDbUtils.Business
{
	public class MyInfo : ICloneable, IEquatable<MyInfo>
	{
		public MyInfo(string scheme, string xtype, string name, string text, int colId, bool check)
		{
			Scheme = scheme;
			Type = xtype;
			Name = name;
			Text = text;
			ColId = colId;
			Checked = check;
			Depends = new List<string>();
			Children = new List<MyInfo>();
			Dependencies = new List<MyInfo>();
			Processed = false;
		}

		public MyInfo()
			: this("-", "-", "-", "", 0, false)
		{
		}

		public bool Checked { set; get; }

		public string Type { private set; get; }

		public string Name { private set; get; }

		public string Text { get; set; }

		public int ColId { get; set; }

		public string Scheme { private set; get; }

		public List<string> Depends { set; get; }

		public List<MyInfo> Children { set; get; }

		public List<MyInfo> Dependencies { set; get; }

		public bool Processed { set; get; }

		public MyInfo Root { get; set; }  // keep track of the root for each node

		public object Clone()
		{
			return MemberwiseClone();
		}

		public bool Equals(MyInfo other)
		{
			return other != null && Scheme == other.Scheme && Name == other.Name && Type == other.Type;
		}

		public override string ToString()
		{
			return Type + " " + Scheme + "." + Name;
		}
	}

	public class MyDatabaseUtil
	{
		private readonly SqlConnection _connection;

		public string DataSource
		{
			get
			{
				return _connection != null ? _connection.DataSource : "n/a";
			}
		}

		public string Database
		{
			get
			{
				return _connection != null ? _connection.Database : "n/a";
			}
		}

		public MyDatabaseUtil(string connectionString)
		{
			_connection = new SqlConnection(connectionString);
		}

		/// <summary>
		/// Gets Database info about:
		/// 'Functions'
		/// 'Views'
		/// 'Procedures'
		/// 'Tables'
		/// 'Triggers'
		/// </summary>
		/// <param name="setSelected">The selected object names.</param>
		/// <returns>List</returns>
		public List<MyInfo> GetInfo(IEnumerable<string> setSelected)
		{
			var list = new List<MyInfo>();

			try
			{
				_connection.Open();

				using (IDbCommand cmd = new SqlCommand(@"
					SELECT
					s.name AS [scheme],
					CONVERT(nchar(2), o.type) AS xtype,
					o.name,
					c.text,
					--c.encrypted,
					--DATALENGTH(c.text) AS [length],
					CONVERT(INT, c.colid) AS ColId,
					dep.name AS DependsOn,
					CASE dep.xtype
						WHEN 'FN' THEN 'Function'
						WHEN 'V' THEN 'View'
						WHEN 'P' THEN 'Procedure'
						WHEN 'U' THEN 'Table'
						WHEN 'TR' THEN 'Trigger'
						ELSE NULL
					END AS DependsType,
					scd.name AS DependsScheme

					FROM syscomments c

					JOIN sys.objects o ON o.object_id = c.id
					JOIN sys.schemas s ON o.schema_id = s.schema_id
					LEFT JOIN sysdepends sd ON o.Object_id = sd.id
					LEFT JOIN sysobjects dep ON sd.depid = dep.id
					LEFT JOIN sys.objects od ON od.object_id = dep.id
					LEFT JOIN sys.schemas scd ON od.schema_id = scd.schema_id
					WHERE o.type IN ('P', 'TF', 'FN', 'FS', 'FT', 'V', 'TR')
						AND o.name NOT IN ('fn_diagramobjects', 'sp_alterdiagram', 'sp_creatediagram', 'sp_dropdiagram', 'sp_helpdiagramdefinition', 'sp_helpdiagrams', 'sp_renamediagram', 'sp_upgraddiagrams', 'sysdiagrams')
					GROUP BY s.name, o.type, o.name, c.text, c.colid, dep.name, dep.xtype, scd.name
					ORDER BY o.type, o.name, c.colid
					", _connection))
				{
					using (IDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							string scheme = dr.GetString(0);
							string type = dr.GetString(1).Trim();
							string name = dr.GetString(2);
							string text = dr.GetString(3);
							int colId = dr.GetInt32(4);
							string dependsOn = dr[5] as string;
							string dependsType = dr[6] as string;
							string dependsScheme = dr[7] as string;

							var info = list.SingleOrDefault(i => i.Scheme == scheme && i.Name == name);

							if (info == null)
							{
								info = new MyInfo(scheme, type, name, text, colId, setSelected != null && setSelected.Contains(name));
								list.Add(info);
							}

							// Update text (only when new ColId)
							if (info.ColId != colId)
							{
								info.ColId = colId;
								info.Text += text;
							}

							// Add dependencies
							if (dependsScheme != null && dependsOn != null && dependsType != "Table")
							{
								string depKey = dependsScheme + "." + dependsOn;
								if (!info.Depends.Contains(depKey))
								{
									info.Depends.Add(depKey);
								}
							}
						}
					}
				}

				_connection.Close();
			}
			catch
			{
				// ignore errors
			}

			foreach (var info in list)
			{
				FindChildren(list, info);
			}

			return list
				.OrderBy(i => i.Scheme)
				.ThenBy(i => i.Type)
				.ThenBy(i => i.Name)
				.ToList();
		}

		private void FindChildren(List<MyInfo> list, MyInfo info)
		{
			if (info.Processed)
			{
				return;
			}

			foreach (var depend in info.Depends)
			{
				string[] split = depend.Split('.');
				string scheme = split[0];
				string name = split[1];

				var parent = list.SingleOrDefault(x => x.Name == name && x.Scheme == scheme);
				if (parent != null)
				{
					parent.Processed = true;
					parent.Children.Add(info);

					info.Dependencies.Add(parent);

					FindChildren(list, parent);
				}
			}
		}
	}
}