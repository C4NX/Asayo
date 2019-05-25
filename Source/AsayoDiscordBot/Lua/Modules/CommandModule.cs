using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Modules
{
    [MoonSharpModule(Namespace = "commands")]
    public class CommandModule
    {
        [MoonSharpModuleMethod(Name = "add")]
        public static DynValue _add(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var name = args.AsType(0, "add", DataType.String);
            var func = args.AsType(1, "add", DataType.Function);
            Asayo.Instance.CommandManager.Register(new Commands.LuaCommand(name.String, func.Function));
            return DynValue.Nil;
        }

        [MoonSharpModuleMethod(Name = "remove")]
        public static DynValue _remove(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var name = args.AsType(0, "remove", DataType.String);
            Asayo.Instance.CommandManager.Remove(name.String);
            return DynValue.True;
        }

        [MoonSharpModuleMethod(Name = "disable")]
        public static DynValue _disable(ScriptExecutionContext ctx, CallbackArguments args)
        {
            Asayo.Instance.CommandManager.Disable();
            return DynValue.True;
        }

        [MoonSharpModuleMethod(Name = "enable")]
        public static DynValue _enable(ScriptExecutionContext ctx, CallbackArguments args)
        {
            Asayo.Instance.CommandManager.Enable();
            return DynValue.True;
        }
    }
}
