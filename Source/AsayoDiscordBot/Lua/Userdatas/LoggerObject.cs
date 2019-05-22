using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas
{
    [MoonSharpUserData()]
    public class LoggerObject
    {
        Logger _logger;

        public LoggerObject(Logger logger)
        {
            _logger = logger;
        }

        public DynValue info(ScriptExecutionContext ctx, CallbackArguments args)
        {
            _logger.Info(args[0].CastToString());
            return DynValue.True;
        }

        public DynValue warn(ScriptExecutionContext ctx, CallbackArguments args)
        {
            _logger.Warning(args[0].CastToString());
            return DynValue.True;
        }

        public DynValue debug(ScriptExecutionContext ctx, CallbackArguments args)
        {
            _logger.Debug(args[0].CastToString());
            return DynValue.True;
        }

        public DynValue error(ScriptExecutionContext ctx, CallbackArguments args)
        {
            _logger.Error(args[0].CastToString());
            return DynValue.True;
        }

        public DynValue fatal(ScriptExecutionContext ctx, CallbackArguments args)
        {
            _logger.Fatal(args[0].CastToString());
            return DynValue.True;
        }

        [MoonSharpUserDataMetamethod("__tostring")]
        public string tostr()
        {
            return "Logger Object";
        }
    }
}
