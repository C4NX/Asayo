using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Data
{
    public class GuildList
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "guilds")]
        public Dictionary<ulong,GuildData> Guilds { get; set; }

        public GuildList()
        {

        }
    }
}
