using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Commands
{
    public class CommandContext
    {
        public DiscordUser User { get; internal set; }
        public DiscordMessage Message { get; internal set; }
        public DiscordGuild Guild { get; internal set; }
        public DiscordChannel Channel { get; internal set; }

        public DiscordMessage Respond(string content = null,bool tts = false,DiscordEmbed embed = null)
        {
            return Message.RespondAsync(content,tts,embed).GetAwaiter().GetResult();
        }

        public Task<DiscordMessage> RespondAsync(string content = null, bool tts = false, DiscordEmbed embed = null)
        {
            return Message.RespondAsync(content, tts, embed);
        }
    }
}
