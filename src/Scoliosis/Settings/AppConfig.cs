/*
 * Código desenvolvido por Peter A. Bromberg.
 * http://www.eggheadcafe.com/articles/20030907.asp
 * 
 * Classe para gravar configurações no arquivo App.config ou Web.config.
 * 
 * */

using System;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Diagnostics;

namespace Scoliosis.Settings
{
    public enum ConfigFileType
    {
        WebConfig,
        AppConfig
    }

    public class AppConfig : System.Configuration.AppSettingsReader
    {
        public string docName = String.Empty;
        private XmlNode node = null;

        private ConfigFileType _configType = ConfigFileType.AppConfig;

        public ConfigFileType ConfigType
        {
            get
            {
                return _configType;
            }
            set
            {
                _configType = value;
            }
        }

        public bool SetValue(string key, string value)
        {
            XmlDocument cfgDoc = new XmlDocument();
            loadConfigDoc(cfgDoc);
            // retrieve the appSettings node 
            node = cfgDoc.SelectSingleNode("//appSettings");

            if (node == null)
            {
                throw new System.InvalidOperationException("appSettings section not found");
            }

            try
            {
                // XPath select setting "add" element that contains this key    
                XmlElement addElem = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
                if (addElem != null)
                {
                    addElem.SetAttribute("value", value);
                }
                // not found, so we need to add the element, key and value
                else
                {
                    XmlElement entry = cfgDoc.CreateElement("add");
                    entry.SetAttribute("key", key);
                    entry.SetAttribute("value", value);
                    node.AppendChild(entry);
                }
                //save it
                saveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void saveConfigDoc(XmlDocument cfgDoc, string cfgDocPath)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(cfgDocPath, null);
                writer.Formatting = Formatting.Indented;
                cfgDoc.WriteTo(writer);
                writer.Flush();
                writer.Close();
                return;
            }
            catch
            {
                throw;
            }
        }

        public bool removeElement(string elementKey)
        {
            try
            {
                XmlDocument cfgDoc = new XmlDocument();
                loadConfigDoc(cfgDoc);
                // retrieve the appSettings node 
                node = cfgDoc.SelectSingleNode("//appSettings");
                if (node == null)
                {
                    throw new System.InvalidOperationException("appSettings section not found");
                }
                // XPath select setting "add" element that contains this key to remove   
                node.RemoveChild(node.SelectSingleNode("//add[@key='" + elementKey + "']"));

                saveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private XmlDocument loadConfigDoc(XmlDocument cfgDoc)
        {
            // load the config file 
            if (_configType == ConfigFileType.AppConfig)
            {
                docName = (Assembly.GetEntryAssembly()).Location;
                docName += ".config";
            }
            else
            {
                docName = System.Web.HttpContext.Current.Server.MapPath("web.config");
            }
            cfgDoc.Load(docName);
            return cfgDoc;
        }
    }
}
