using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas.WEB
{
    [MoonSharpUserData]
    public class HttpResultObject
    {
        System.Net.Http.HttpResponseMessage msg;
        public HttpResultObject(System.Net.Http.HttpResponseMessage message)
        {
            msg = message;
        }

        public bool isSuccess()
        {
            return msg.IsSuccessStatusCode;
        }

        public string readstring()
        {
            return msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
