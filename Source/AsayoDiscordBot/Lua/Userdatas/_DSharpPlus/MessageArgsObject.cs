using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas._DSharpPlus
{
    [MoonSharpUserData()]
    public class MessageArgsObject
    {
        DSharpPlus.EventArgs.MessageCreateEventArgs _e;

        public MessageArgsObject(DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            _e = e;
        }

        public string message()
        {
            return _e.Message.Content;
        }

        public DynValue channel_Id()
        {
            return DynValue.NewNumber(_e.Message.ChannelId);
        }

        public void respond(string str)
        {
            _e.Message.RespondAsync(str).GetAwaiter().GetResult();
        }

        public void respond(string str,DiscordEmbedObject discordEmbed)
        {
            _e.Message.RespondAsync(str,embed:discordEmbed.Embed).GetAwaiter().GetResult();
        }

        public bool isSelf()
        {
            return Asayo.Instance.Client.CurrentUser.Id == _e.Author.Id;
        }

        public bool isBot()
        {
            return _e.Author.IsBot;
        }

        public DynValue user()
        {
            return UserData.Create(new Userdatas._DSharpPlus.UserObject(_e.Author));
        }

        [MoonSharpUserDataMetamethod("__tostring")]
        public string tostr()
        {
            return "MessageArgs Object";
        }
    }
}
