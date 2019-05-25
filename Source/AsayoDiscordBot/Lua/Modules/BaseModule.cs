using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Modules
{
    [MoonSharpModule()]
    public class BaseModule
    {
        [MoonSharpModuleMethod(Name = "instance")]
        public static DynValue instance(ScriptExecutionContext ctx,CallbackArguments args)
        {
            return UserData.Create(new Userdatas.AsayoObject());
        }

        [MoonSharpModuleMethod(Name = "logger")]
        public static DynValue logger(ScriptExecutionContext ctx, CallbackArguments args)
        {
            return UserData.Create(Logger.GlobalLogger);
        }

        [MoonSharpModuleMethod(Name = "try")]
        public static DynValue _try(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var func = args.AsType(0, "try", DataType.Function, false);

            try
            {
                return func.Function.Call(args.GetArray(1));
            }
            catch (Exception)
            {
                return DynValue.Nil;
            }
        }

        [MoonSharpModuleMethod(Name = "Or")]
        public static DynValue _or(ScriptExecutionContext ctx, CallbackArguments args)
        {
            if (args.Count != 2) return DynValue.Nil;
            if (args[0].IsNil()) return args[1]; else return args[0];
        }

        [MoonSharpModuleMethod(Name = "event")]
        public static DynValue _event(ScriptExecutionContext ctx, CallbackArguments args)
        {
            return UserData.Create(new Userdatas.EventObject());
        }

        [MoonSharpModuleMethod(Name = "import")]
        public static DynValue _import(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var file = args.AsType(0, "import", DataType.String);
            if (!File.Exists(file.String)) return DynValue.Nil;
            try
            {
                return ctx.OwnerScript.DoFile(file.String);
            }
            catch (Exception ex)
            {
                LuaScript.ShowErrorWindows(ctx.OwnerScript, ex);
                return DynValue.Nil;
            }
        }

        [MoonSharpModuleMethod(Name = "csformat")]
        public static DynValue _csformat(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var str = args.AsType(0, "csformat", DataType.String);
            List<string> _a = new List<string>();
            foreach (var item in args.GetArray(1))
            {
                _a.Add(item.CastToString());
            }
            return DynValue.NewString(string.Format(str.String,_a.ToArray()));
        }

        [MoonSharpModuleMethod(Name = "isPrefix")]
        public static DynValue _isPrefix(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var str = args.AsType(0, "isPrefix", DataType.String);
            var prefix = args.AsType(1, "isPrefix", DataType.String);
            return DynValue.NewBoolean(str.String.TrimStart().StartsWith(prefix.String));
        }

        [MoonSharpModuleMethod(Name = "removePrefix")]
        public static DynValue _removePrefix(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var str = args.AsType(0, "isPrefix", DataType.String);
            var prefix = args.AsType(1, "isPrefix", DataType.String);
            var _str = str.String.TrimStart();
            var i = _str.IndexOf(prefix.String ?? "");
            if (i == -1) return DynValue.Nil;
            return DynValue.NewString(_str.Substring(i + prefix.String.Length));
        }

        [MoonSharpModuleMethod(Name = "files")]
        public static DynValue _files(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var path = args.AsType(0, "files", DataType.String);
            var format = args.AsType(1, "isPrefix", DataType.String,true);
            var table = DynValue.NewPrimeTable();
            var forma = "";
            if (format.IsNotNil()) forma = format.String;
            foreach (var item in System.IO.Directory.GetFiles(path.String, forma))
            {
                table.Table.Append(DynValue.NewString(item));
            }
            return table;
        }

        [MoonSharpModuleMethod(Name = "jparse")]
        public static DynValue _jparse(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var str = args.AsType(0, "jparse", DataType.String);
            try{
				return DynValue.NewTable(MoonSharp.Interpreter.Serialization.Json.JsonTableConverter.JsonToTable(str.String));
            }catch(Exception){
            	return DynValue.NewPrimeTable();
            }
        }

        [MoonSharpModuleMethod(Name = "embed")]
        public static DynValue _embed(ScriptExecutionContext ctx, CallbackArguments args)
        {
            if (args.Count != 0)
            {
                var t = args.AsUserData<Userdatas._DSharpPlus.DiscordEmbedObject>(0, "embed");
                return UserData.Create(new Userdatas._DSharpPlus.DiscordEmbedObject(t.Embed));
            }
            else
            {
                return UserData.Create(new Userdatas._DSharpPlus.DiscordEmbedObject());
            }
        }

        [MoonSharpModuleMethod(Name = "guildData_set")]
        public static DynValue _gdata_set(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var guild = (ulong)args.AsType(0, "guildData_set", DataType.Number).Number;
            var name = args.AsType(1, "guildData_set", DataType.String);
            var value = args[2];
            Asayo.Instance.GuildVars.RawSet(guild, name.String, value.ToObject());
            return DynValue.True;
        }

        [MoonSharpModuleMethod(Name = "guildData_exset")]
        public static DynValue _gdata_excreate(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var guild = (ulong)args.AsType(0, "guildData_exset", DataType.Number).Number;
            var name = args.AsType(1, "guildData_exset", DataType.String);
            var value = args[2];
            if (!Asayo.Instance.GuildVars.VarExist(guild, name.String))
            {
                Asayo.Instance.GuildVars.RawSet(guild, name.String, value.ToObject());
            }
            return DynValue.True;
        }

        [MoonSharpModuleMethod(Name = "guildData_get")]
        public static DynValue _gdata_get(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var guild = (ulong)args.AsType(0, "guildData_get", DataType.Number).Number;
            var name = args.AsType(1, "guildData_get", DataType.String);
            return Asayo.Instance.GuildVars.Get(ctx.OwnerScript, guild, name.String);
        }

        [MoonSharpModuleMethod(Name = "stopwatch")]
        public static DynValue _stopwatch(ScriptExecutionContext ctx, CallbackArguments args)
        {
            return UserData.Create(new Userdatas.CS.StopwatchObject());
        }
    }
}
