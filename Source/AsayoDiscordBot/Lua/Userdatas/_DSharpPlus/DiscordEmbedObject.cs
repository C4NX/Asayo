using DSharpPlus.Entities;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Lua.Userdatas._DSharpPlus
{
    [MoonSharpUserData()]
    public class DiscordEmbedObject
    {
        internal DiscordEmbedBuilder Embed;

        public DiscordEmbedObject()
        {
            Embed = new DiscordEmbedBuilder();
        }

        public DiscordEmbedObject(DiscordEmbed embed)
        {
            Embed = new DiscordEmbedBuilder(embed);
        }

        public void description(string str) => Embed.Description = str;
        public void title(string str) => Embed.Title = str;
        public void image(string url) => Embed.ImageUrl = url;
        public void thumbnail(string url) => Embed.ThumbnailUrl = url;
        public void author(string name,string url,string iconurl) => Embed.Author = new DiscordEmbedBuilder.EmbedAuthor() {Name=name,Url=url,IconUrl=iconurl};
        public void color(string color) => Embed.Color = new DiscordColor(color);
    }
}
