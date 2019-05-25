using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Commands
{
    public interface ICommand
    {
        string Name { get; set; }
        bool Private { get; set; }
        CommandSystem Parent { get; set; }

        void Execute(CommandContext context);

        event EventHandler<CommandErrorEventArgs> OnError;
    }

    public class CommandErrorEventArgs
    {
        public ErrorType ErrorType { get; private set; }
        public Exception InnerException { get; private set; }

        public ICommand Command { get; private set; } 

        public static CommandErrorEventArgs CreateInternalError(Exception exception)
        {
            return new CommandErrorEventArgs() { InnerException = exception, ErrorType = ErrorType.InternalError };
        }

        public static CommandErrorEventArgs CreateLuaError(ICommand command, Exception exception)
        {
            return new CommandErrorEventArgs() { Command=command, InnerException = exception, ErrorType = ErrorType.LuaError };
        }

        public static CommandErrorEventArgs CreateCommandNotFound(string rawstr,string name)
        {
            return new CommandErrorEventArgs() { ErrorType = ErrorType.CommandNotFound };
        }
    }

    public enum ErrorType
    {
        CommandNotFound,
        LuaError,
        InternalError
    }
}
