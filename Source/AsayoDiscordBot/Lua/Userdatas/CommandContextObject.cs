using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas
{
    [MoonSharpUserData]
    public class CommandContextObject
    {
        Commands.CommandContext context;
        public CommandContextObject(Commands.CommandContext ctx)
        {
            context = ctx;
        }

        public string message()
        {
            return context.Message.Content;
        }

        public DynValue channelId()
        {
            return DynValue.NewNumber(context.Message.ChannelId);
        }

        public DynValue guildId()
        {
            return DynValue.NewNumber(context.Guild.Id);
        }

        public void respond(string str)
        {
            context.Respond(str);
        }

        public void respond(string str, _DSharpPlus.DiscordEmbedObject discordEmbed)
        {
            context.Respond(str, embed: discordEmbed.Embed);
        }

        public bool isSelf()
        {
            return Asayo.Instance.Client.CurrentUser.Id == context.User.Id;
        }

        public bool isBot()
        {
            return context.User.IsBot;
        }

        public DynValue user()
        {
            return UserData.Create(new Userdatas._DSharpPlus.UserObject(context.User));
        }

        [MoonSharpUserDataMetamethod("__tostring")]
        public string tostr()
        {
            return "CommandContextObject";
        }
    }
}
