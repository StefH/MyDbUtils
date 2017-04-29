using System;
using System.IO;
using System.Windows.Forms;

namespace MyDbUtils.Business
{
    public static class SqlStatementHelper
    {
        public static string Copyright()
        {
            return "/* Created by " + Application.ProductName + " - " + Application.ProductVersion + " at " + DateTime.Now + " */";
        }

        public static string UseDatabaseStatement(string db)
        {
            return "USE [" + db + "]" + Environment.NewLine + "GO";
        }

        public static string Statement(string type, string name, string scheme, string text, GenerateMode mode)
        {
            var sw = new StringWriter();

            string fullName = string.Format("[{0}].[{1}]", scheme, name);

            switch (mode)
            {
                case GenerateMode.Create:
                    Create(sw, text);
                    break;

                case GenerateMode.CreateOrAlter:
                    CreateOrAlter(sw, type, fullName, text);
                    break;

                case GenerateMode.DeleteAndCreate:
                    DeleteAndCreate(sw, type, fullName, text);
                    break;
            }

            return sw.ToString();
        }

        private static void Create(StringWriter sw, string text)
        {
            sw.WriteLine("{0}\r\nGO", text);
        }

        private static void Alter(StringWriter sw, string text)
        {
            int index = text.IndexOf("CREATE", 0, StringComparison.OrdinalIgnoreCase);

            text = "ALTER" + text.Substring(index + "CREATE".Length);

            sw.WriteLine("{0}\r\nGO", text);
        }

        private static void CreateOrAlter(StringWriter sw, string type, string fullName, string text)
        {
            if (type.Contains("P"))
            {
                sw.WriteLine(NotExistsProc(fullName));
                sw.WriteLine(CreatePlaceholderProc(fullName));
                Alter(sw, text);
            }
            if (type.Contains("V"))
            {
                sw.WriteLine(NotExistsView(fullName));
                sw.WriteLine(CreatePlaceholderView(fullName));
                Alter(sw, text);
            }
            if (type.Contains("F"))
            {
                sw.WriteLine(NotExistsFunc(fullName));
                sw.WriteLine(CreatePlaceholderFunc(fullName));
                Alter(sw, text);
            }
            if (type.Contains("TR"))
            {
                DeleteAndCreate(sw, type, fullName, text);
            }
        }

        private static void DeleteAndCreate(StringWriter sw, string type, string fullName, string text)
        {
            if (type.Contains("P"))
            {
                sw.WriteLine(ExistsProc(fullName));
                sw.WriteLine(DeleteProc(fullName));
                Create(sw, text);
            }
            if (type.Contains("V"))
            {
                sw.WriteLine(ExistsView(fullName));
                sw.WriteLine(DeleteView(fullName));
                Create(sw, text);
            }
            if (type.Contains("F"))
            {
                sw.WriteLine(ExistsFunc(fullName));
                sw.WriteLine(DeleteFunc(fullName));
                Create(sw, text);
            }
            if (type.Contains("TR"))
            {
                sw.WriteLine(ExistsTrigger(fullName));
                sw.WriteLine(DeleteTrigger(fullName));
                Create(sw, text);
            }
        }

        private static string NotExistsProc(string name)
        {
            return ExistsProc(name, true);
        }

        private static string ExistsProc(string name, bool negate = false)
        {
            return string.Format("IF {0} EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{1}') AND type = N'P') ", negate ? "NOT" : "", name);
        }

        private static string NotExistsFunc(string name)
        {
            return ExistsFunc(name, true);
        }

        private static string ExistsFunc(string name, bool negate = false)
        {
            return string.Format("IF {0} EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{1}') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')) ", negate ? "NOT" : "", name);
        }

        private static string NotExistsView(string name)
        {
            return ExistsView(name, true);
        }

        private static string ExistsView(string name, bool negate = false)
        {
            return string.Format("IF {0} EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'{1}')) ", negate ? "NOT" : "", name);
        }

        private static string NotExistsTrigger(string name)
        {
            return ExistsTrigger(name, true);
        }

        private static string ExistsTrigger(string name, bool negate = false)
        {
            return string.Format("IF {0} EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'{1}')) ", negate ? "NOT" : "", name);
        }

        private static string DeleteProc(string name)
        {
            return "DROP PROCEDURE " + name + Environment.NewLine + "GO";
        }

        private static string CreatePlaceholderProc(string name)
        {
            return string.Format("exec('CREATE PROCEDURE {0} AS BEGIN SET NOCOUNT ON; END')\r\nGO", name);
        }

        private static string DeleteFunc(string name)
        {
            return "DROP FUNCTION " + name + Environment.NewLine + "GO";
        }

        private static string CreatePlaceholderFunc(string name)
        {
            return string.Format("exec('CREATE FUNCTION {0} ( ) RETURNS int AS BEGIN RETURN 0 END')\r\nGO", name);
        }

        private static string DeleteView(string name)
        {
            return "DROP VIEW " + name + Environment.NewLine + "GO";
        }

        private static string CreatePlaceholderView(string name)
        {
            return string.Format("exec('CREATE VIEW {0} AS SELECT 0 AS X')\r\nGO", name);
        }

        private static string DeleteTrigger(string name)
        {
            return "DROP TRIGGER " + name + Environment.NewLine + "GO";
        }
    }
}