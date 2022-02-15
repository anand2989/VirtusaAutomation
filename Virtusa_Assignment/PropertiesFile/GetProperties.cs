using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Virtusa_Assignment.PropertiesFile
{
    public class GetProperties
    {
        protected static Dictionary<String, String> _envProperties;
       
        protected void LoadPropertiesFromFile()
        {
            string[] configFiles = Directory.GetFiles(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "/Configuration/");

            foreach (var configProp in configFiles)
            {
                try
                {
                    if (configProp.Contains("environment"))
                    {
                        _envProperties = new Dictionary<string, string>();
                        var envproperties = File.ReadAllLines(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "/Configuration/" + "environment" + ".properties");
                        foreach (var prop in envproperties)
                        {
                            var keyValue = prop.Split(new[] { '=' }, 2);
                            if (_envProperties.ContainsKey(keyValue[0]))
                            {
                                throw new Exception("an item with the same key already exists in the dictionary : " + keyValue);
                            }
                            else
                            {
                                _envProperties.Add(keyValue[0].Trim(), keyValue[1].Trim());
                            }      
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Arguments exception found and ignored : " + ex.Message);

                    continue;
                }
            }
        }
    }
}