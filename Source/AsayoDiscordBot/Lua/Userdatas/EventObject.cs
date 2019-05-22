using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas
{
    [MoonSharpUserData]
    public class EventObject
    {
        List<AsayoLuaEvent> events;

        public EventObject()
        {
            events = new List<AsayoLuaEvent>();
        }

        public DynValue add(DynValue func)
        {
            events.Add(new AsayoLuaEvent(func.Function));
            return DynValue.True;
        }

        public DynValue invoke(CallbackArguments args)
        {
            foreach (var item in events)
            {
                item.Call(args.GetArray());
            }
            return DynValue.Nil;
        }

        public DynValue remove(DynValue func)
        {
            foreach (var item in events)
            {
                if (item.Is(func.Function))
                {
                    events.Remove(item);
                }
            }
            return DynValue.True;
        }

        public int count()
        {
            return events.Count;
        }

        [MoonSharpUserDataMetamethod("__tostring")]
        public string tostr()
        {
            return "Event Object; Count: " + events.Count;
        }
    }
}
