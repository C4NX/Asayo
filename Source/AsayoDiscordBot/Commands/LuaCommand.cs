using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Commands
{
    public class LuaCommand : ICommand
    {
        public string Name { get; set; }

        public Closure Closure { get; private set; }
        public bool Private { get; set; } = false;

        public CommandSystem Parent { get; set; }

        public event EventHandler<CommandErrorEventArgs> OnError;

        public LuaCommand(string name,Closure function)
        {
            Name = name;
            Closure = function;
        }

        public void Execute(CommandContext context)
        {
            try
            {
                Closure.Call(new Lua.Userdatas.CommandContextObject(context));//test
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, CommandErrorEventArgs.CreateLuaError(this, ex));
                Lua.LuaScript.ShowErrorWindows(Closure.OwnerScript, ex);
            }
        }
    }
}
