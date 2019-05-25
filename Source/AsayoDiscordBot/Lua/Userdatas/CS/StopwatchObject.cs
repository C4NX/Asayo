using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas.CS
{
    [MoonSharpUserData]
    public class StopwatchObject
    {
        Stopwatch stw;

        public StopwatchObject()
        {
            stw = new Stopwatch();
        }

        public void start()
        {
            stw.Start();
        }

        public void stop()
        {
            stw.Stop();
        }

        public DynValue ms()
        {
            return DynValue.NewNumber(stw.ElapsedMilliseconds);
        }
    }
}
