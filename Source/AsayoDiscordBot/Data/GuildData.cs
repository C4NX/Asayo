using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Data
{
    public class GuildData
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "data")]
        public Dictionary<string,object> Datas { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "stats")]
        public GuildStats Stats { get; set; }
    }
}
