using AsayoDiscordBot.Lua.Userdatas.WEB;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Modules
{
    [MoonSharpModule(Namespace = "api")]
    public class ApiModule
    {
        static System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient();

        [MoonSharpModuleMethod(Name = "get")]
        public static DynValue get_request(ScriptExecutionContext ctx, CallbackArguments args)
        {
            var url = args.AsType(0, "get", DataType.String);
            var result = _client.GetAsync(url.String).GetAwaiter().GetResult();
            return UserData.Create(new HttpResultObject(result));
        }
    }
}
