using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Commands
{
    /// <summary>
    /// Simple ICommand who send logger info when executed
    /// </summary>
    public class TestCommand : ICommand
    {
        public string Name { get; set; }
        public bool Private { get; set; } = false;

        public CommandSystem Parent { get; set; }

        public event EventHandler<CommandErrorEventArgs> OnError;

        Logger _l;

        public TestCommand(string name)
        {
            Name = name;
            _l = Logger.GetLogger<TestCommand>();
        }

        public void Execute(CommandContext context)
        {
            _l.Info("======TestCommand======");
            context.Respond("test");
        }
    }
}
