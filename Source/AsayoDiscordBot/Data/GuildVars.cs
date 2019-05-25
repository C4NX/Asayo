using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Data
{
    public class GuildVars
    {
        Dictionary<ulong, Dictionary<string, object>> Objects;

        public int GuildCount { get { return Objects.Count; } }

        public long FullCount
        {
            get
            {
                long count = 0;
                foreach (var item in Objects)
                {
                    count += item.Value.Count;
                }
                return count;
            }
        }

        public GuildVars()
        {
            Objects = new Dictionary<ulong, Dictionary<string, object>>();
        }

        public void RawSet(ulong guild,string name,object value)
        {
            if (!GuildExist(guild))
            {
                Objects[guild] = new Dictionary<string, object>();
            }
            Objects[guild][name] = value;
        }

        public object RawGet(ulong guild, string name)
        {
            return Objects[guild][name];
        }

        public bool VarExist(ulong guild, string name)
        {
            if (Objects.ContainsKey(guild))
            {
                if (Objects[guild].ContainsKey(name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GuildExist(ulong guild)
        {
            if (Objects.ContainsKey(guild))
            {
                return true;
            }
            return false;
        }

        public object Get(ulong guild,string name)
        {
            if (!Objects.ContainsKey(guild))
            {
                Objects.Add(guild, new Dictionary<string, object>());
                return null;
            }
            var v = Objects[guild];
            if (v.ContainsKey(name))
            {
                return v[name];
            }
            else
            {
                return null;
            }
        }

        public DynValue Get(Script s, ulong guild, string name)
        {
            try
            {
                return DynValue.FromObject(s, Get(guild, name));
            }
            catch (Exception)
            {
                return DynValue.Nil;
            }
        }
    }
}
