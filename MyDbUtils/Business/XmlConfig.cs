//
// Based on http://www.codeproject.com/KB/XML/xmlconfig.aspx from Michael Chao
// Updated by stefh
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace MyDbUtils.Business
{
    // Singleton pattern...
    public sealed class XmlConfig : AppSettingsReader
    {
        private static XmlConfig _instance;
        private XmlNode _node;

        public static XmlConfig Instance
        {
            get { return _instance ?? (_instance = new XmlConfig()); }
        }

        public string ConfigFile { get; set; }

        public bool ElementExists(string path)
        {
            var doc = new XmlDocument();
            LoadDoc(doc);

            // retrieve the selected node
            try
            {
                return (doc.SelectSingleNode(path) != null);
            }
            catch
            {
                return false;
            }
        }

        // Example : Format="//Test//AnotherTest"
        public bool CreateElement(string path)
        {
            var doc = new XmlDocument();
            LoadDoc(doc);

            // retrieve the selected node
            try
            {
                if (doc.SelectSingleNode(path) == null)
                {
                    XmlElement el = doc.CreateElement(path);
                    SaveDoc(doc, ConfigFile);
                    return true;
                }
            }
            catch
            {
                // ignore error
            }

            return false;
        }

        public List<string> GetChildElements(string path, string attribute)
        {
            var list = new List<string>();
            var doc = new XmlDocument();
            LoadDoc(doc);

            // retrieve the selected node
            try
            {
                var node = doc.SelectSingleNode(path);

                if (node != null)
                {
                    list.AddRange(from XmlNode childNode in node.ChildNodes select childNode.Attributes[attribute].Value);
                }
            }
            catch
            {
                // ignore error
            }

            return list;
        }

        public List<string> GetChildElements(string path)
        {
            return GetChildElements(path, "key");
        }

        public string GetValue(string key)
        {
            return Convert.ToString(GetValue(key, typeof(string)));
        }

        public new object GetValue(string key, Type sType)
        {
            var doc = new XmlDocument();
            object ro = string.Empty;
            LoadDoc(doc);
            string sNode = key.Substring(0, key.LastIndexOf("//"));
            // retrieve the selected node
            try
            {
                _node = doc.SelectSingleNode(sNode);
                if (_node != null)
                {
                    // Xpath selects element that contains the key
                    XmlElement targetElem = (XmlElement)_node.SelectSingleNode(key);
                    if (targetElem != null)
                    {
                        ro = targetElem.GetAttribute("value");
                    }
                }

                if (sType == typeof(string))
                {
                    return Convert.ToString(ro);
                }
                if (sType == typeof(bool))
                {
                    return (ro.Equals("True") || ro.Equals("False")) && Convert.ToBoolean(ro);
                }
                if (sType == typeof(int))
                {
                    return Convert.ToInt32(ro);
                }
                if (sType == typeof(double))
                {
                    return Convert.ToDouble(ro);
                }
                if (sType == typeof(DateTime))
                {
                    return Convert.ToDateTime(ro);
                }

                return Convert.ToString(ro);
            }
            catch
            {
                return String.Empty;
            }
        }

        public bool SetValue(string key, string val)
        {
            var doc = new XmlDocument();
            LoadDoc(doc);
            try
            {
                // retrieve the target node
                string sNode = key.Substring(0, key.LastIndexOf("//"));
                _node = doc.SelectSingleNode(sNode);
                if (_node == null)
                {
                    return false;
                }
                // Set element that contains the key
                var targetElem = (XmlElement)_node.SelectSingleNode(key);
                if (targetElem != null)
                {
                    // set new value
                    targetElem.SetAttribute("value", val);
                }
                // create new element with key/value pair and add it
                else
                {
                    sNode = key.Substring(key.LastIndexOf("//") + 2);

                    var entry = doc.CreateElement(sNode.Substring(0, sNode.IndexOf("[@")).Trim());
                    sNode = sNode.Substring(sNode.IndexOf("'") + 1);

                    entry.SetAttribute("key", sNode.Substring(0, sNode.IndexOf("'")));

                    entry.SetAttribute("value", val);
                    _node.AppendChild(entry);
                }

                SaveDoc(doc, ConfigFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SaveDoc(XmlDocument doc, string docPath)
        {
            // save document
            // choose to ignore if web.config since it may cause server sessions interruptions
            if (ConfigFile.Equals("web.config"))
            {
                return;
            }

            try
            {
                var writer = new XmlTextWriter(docPath, null)
                {
                    Formatting = Formatting.Indented
                };
                doc.WriteTo(writer);
                writer.Flush();
                writer.Close();
            }
            catch
            {
                // ignore
            }
        }

        public bool RemoveElement(string key)
        {
            var doc = new XmlDocument();
            LoadDoc(doc);
            try
            {
                string sNode = key.Substring(0, key.LastIndexOf("//"));
                // retrieve the appSettings node
                _node = doc.SelectSingleNode(sNode);
                if (_node == null)
                {
                    return false;
                }

                // XPath select setting "add" element that contains this key to remove
                XmlNode nd = _node.SelectSingleNode(key);
                if (nd != null) _node.RemoveChild(nd);
                SaveDoc(doc, ConfigFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void LoadDoc(XmlDocument doc)
        {
            // check for type of config file being requested
            /*
            if(  this._cfgFile.Equals("app.config"))
            {
                // use default app.config
                this._cfgFile = ((Assembly.GetEntryAssembly()).GetName()).Name+".exe.config";
            }
            else
                if(  this._cfgFile.Equals("web.config"))
            {
                // use server web.config
                this._cfgFile = System.Web.HttpContext.Current.Server.MapPath("web.config");
            }
            */
            // load the document

            doc.Load(ConfigFile);
        }
    }
}