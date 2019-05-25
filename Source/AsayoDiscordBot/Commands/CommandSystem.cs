using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Commands
{
    public class CommandSystem
    {
        List<ICommand> commands;

        List<string> prefixs;

        bool enable = true;

        public int Count { get { return commands.Count; } }

        ~CommandSystem()
        {
            commands = new List<ICommand>();
            prefixs = new List<string>();
        }

        public CommandSystem(string prefix)
        {
            commands = new List<ICommand>();
            prefixs = new List<string>();
            prefixs.Add(prefix);
        }

        public void Register(ICommand command)
        {
            command.Parent = this;
            commands.Add(command);
        }

        public List<ICommand> GetCommands()
        {
            return commands;
        }

        public CommandContext CreateContext(DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            return new CommandContext() { Message = e.Message, User = e.Author,Channel=e.Channel,Guild=e.Guild };
        }

        public void AddPrefix(string prefix)
        {
            prefixs.Add(prefix);
        }

        public void Enable()
        {
            enable = true;
        }

        public void Disable()
        {
            enable = false;
        }

        public bool Remove(ICommand command)
        {
            return commands.Remove(command);
        }

        public void RemoveAll()
        {
            commands.Clear();
        }

        public bool Remove(string name)
        {
            foreach (var item in commands)
            {
                if (item.Name == name) { commands.Remove(item); return true; }
            }
            return false;
        }

        public void Call(CommandContext ctx)
        {
            if (!enable) return;
            var str = ctx.Message.Content;
            foreach (var item in prefixs)
            {
                str = str.TrimStart();
                bool haveprefix = str.StartsWith(item);
                if (haveprefix)
                {
                    var i = str.IndexOf(item);
                    if (i == -1) return;
                    string command_str = str.Substring(i + item.Length);
                    var args = command_str.Split(' ');
                    if(args.Length > 0)
                    {
                        var name = args[0];
                        foreach (var item2 in commands)
                        {
                            if (item2.Name == name)
                            {
                                item2.Execute(ctx);
                            }
                        }
                    }
                    return;
                }
            }
        }
    }
}
