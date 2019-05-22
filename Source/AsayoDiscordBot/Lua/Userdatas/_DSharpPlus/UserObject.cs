using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas._DSharpPlus
{
    [MoonSharpUserData]
    public class UserObject
    {
        DSharpPlus.Entities.DiscordUser user;
        public UserObject(DSharpPlus.Entities.DiscordUser _user)
        {
            user = _user;
        }

        public string nick()
        {
            return user.Username ?? "";
        }

        public string discriminator()
        {
            return user.Discriminator ?? "";
        }

        public string mention()
        {
            return user.Mention ?? "";
        }

        public string avatar(int size)
        {
            return user.GetAvatarUrl(DSharpPlus.ImageFormat.Png, (ushort)size);
        }

        public bool isuser(UserObject obj)
        {
            return user == obj.user;
        }

        public ulong id()
        {
            return user.Id;
        }

        public bool bot()
        {
            return user.IsBot;
        }

        [MoonSharpUserDataMetamethod("__tostring")]
        public string tostr()
        {
            return user.ToString();
        }
    }
}
