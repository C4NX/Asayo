using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot
{
    public class ConfigurationJson
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "log_format")]
        public string LoggerFormat { get; set; } = Logger.LogFormat;

        [Newtonsoft.Json.JsonProperty(PropertyName = "enable_console")]
        public bool EnableConsole { get; set; } = true;

        public static ConfigurationJson Read(string filename)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigurationJson>(File.ReadAllText(filename));
            }
            catch (Exception)
            {
                Logger.GlobalLogger.Fatal("Configuration File Error");
                throw;
            }
        }

        public static void Save(ConfigurationJson configuration,string filename)
        {
            try
            {
                File.WriteAllText(filename, Newtonsoft.Json.JsonConvert.SerializeObject(configuration));
            }
            catch (Exception)
            {
                Logger.GlobalLogger.Fatal("Configuration Writing Error");
            }
        }
    }
}
