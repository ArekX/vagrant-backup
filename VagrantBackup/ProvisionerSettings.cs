using System;
using System.Collections;
using Newtonsoft.Json;

namespace VagrantBackup
{
    public class ProvisionerSettings
    {
        public string provisionerName;
        public Hashtable config;

        public ProvisionerSettings()
        {
            config = new Hashtable();
        }

        public void Set(string key, object data)
        {
            if (config.ContainsKey(key)) {
                config[key] = data;
            }

            config.Add(key, data);
        }

        public object Get(string key, object defaultValue = null)
        {
            if (config.ContainsKey(key)) {
                return config[key];
            }

            return defaultValue;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ProvisionerSettings ReadFromJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<ProvisionerSettings>(jsonString);
        }
    }
}
