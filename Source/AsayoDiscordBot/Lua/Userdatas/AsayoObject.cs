using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace AsayoDiscordBot.Lua.Userdatas
{
    [MoonSharpUserData]
    public class AsayoObject
    {
        public static List<AsayoLuaEvent> OnMessageEvents = new List<AsayoLuaEvent>();
        public static List<AsayoLuaEvent> OnReloadEvents = new List<AsayoLuaEvent>();

        public DynValue logger()
        {
            return UserData.Create(new Userdatas.LoggerObject(new Logger(typeof(LuaScript))));
        }

        public DynValue onmessage(DynValue handler)
        {
            try
            {
                OnMessageEvents.Add(new AsayoLuaEvent(handler.Function));
                return DynValue.True;
            }
            catch (Exception)
            {
                return DynValue.False;
            }
        }

        public DynValue onreload(DynValue handler)
        {
            try
            {
                OnReloadEvents.Add(new AsayoLuaEvent(handler.Function));
                return DynValue.True;
            }
            catch (Exception)
            {
                return DynValue.False;
            }
        }

        [MoonSharpUserDataMetamethod("__tostring")]
        public string tostr()
        {
            return "Asayo Object";
        }
    }

    public class AsayoLuaEvent
    {
        Closure _c;

        public AsayoLuaEvent(Closure c)
        {
            _c = c;
        }

        public DynValue Call()
        {
            try
            {
                return _c.Call();
            }
            catch (Exception ex)
            {
                LuaScript.ShowErrorWindows(_c.OwnerScript, ex);
                return DynValue.Nil;
            }
        }

        public DynValue Call(params object[] args)
        {
            try
            {
                return _c.Call(args);
            }
            catch (Exception ex)
            {
                LuaScript.ShowErrorWindows(_c.OwnerScript, ex);
                return DynValue.Nil;
            }
        }

        public DynValue Call(params DynValue[] args)
        {
            try
            {
                return _c.Call(args);
            }
            catch (Exception ex)
            {
                LuaScript.ShowErrorWindows(_c.OwnerScript, ex);
                return DynValue.Nil;
            }
        }

        public bool Is(Closure c)
        {
            return _c.ReferenceID == c.ReferenceID;
        }

        public Closure GetClosure()
        {
            return _c;
        }

        public static void CallOnMessage(params DynValue[] _params)
        {
            foreach (var item in AsayoObject.OnMessageEvents)
            {
                try
                {
                    //Console.WriteLine("called " + item._c.ReferenceID);
                    item.Call(_params);
                }
                catch (Exception ex)
                {
                    LuaScript.ShowErrorWindows(null, ex);
                }
            }
        }

        public static void CallReload(params DynValue[] _params)
        {
            foreach (var item in AsayoObject.OnReloadEvents)
            {
                try
                {
                    //Console.WriteLine("called " + item._c.ReferenceID);
                    item.Call(_params);
                }
                catch (Exception ex)
                {
                    LuaScript.ShowErrorWindows(null, ex);
                }
            }
        }
    }
}
