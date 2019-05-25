using AsayoDiscordBot.Lua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot
{
    class Program
    {
        public static string Version { get; set; } = "Asayo BETA 1.02";

        static void Main(string[] args)
        {
            Console.WriteLine("Asayo Discord Bot [NX]");

            if (args.Length != 0)
            {
                if (args[0] == "clear")
                {
                    int count = 0;
                    var current_dir = Directory.GetCurrentDirectory();
                    foreach (var item in Directory.GetFiles(current_dir,"*.log"))
                    {
                        try
                        {
                            File.Delete(item);
                            count++;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    Console.WriteLine(count + " File Cleared");
                    Console.ReadKey();
                    return;
                }
            }

            Asayo asayo = new Asayo();
            MoonSharp.Interpreter.UserData.RegisterAssembly();
            foreach (var item in Directory.GetFiles(Directory.GetCurrentDirectory(),"*.lua"))
            {
                new Lua.LuaScript(item).Execute();
            }
            if (!File.Exists("conf.json"))
            {
                Console.WriteLine("Welcome to Asayo Discord Bot Configuration !!");
                Console.WriteLine("Press any key to start configure the bot...");
                Console.ReadKey(true);
                Console.Write("Bot Token : ");
                var token = Console.ReadLine();
                Console.WriteLine();
                /*Console.Write("");*/
                asayo.Configuration = new ConfigurationJson() {Token=token};
                ConfigurationJson.Save(asayo.Configuration, "conf.json");
                Console.Clear();
            }
            if(asayo.Configuration == null)
            {
                asayo.Configuration = ConfigurationJson.Read("conf.json");
            }

            asayo.Start();

            bool exit = false;
            while (!exit)
            {
                var command = Console.ReadLine();
                if (command.ToLower() == "exit") exit = true;
                if (command.ToLower() == "test") Console.WriteLine("Application is Up");
                if (command.ToLower() == "save") asayo.Save();
                if (command.ToLower() == "reload") asayo.Reload();

                if (command.ToLower() == "commands")
                {
                    Console.WriteLine("Command Count : " + Asayo.Instance.CommandManager.Count);
                    foreach (var item in Asayo.Instance.CommandManager.GetCommands())
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                if (command.ToLower() == "stats")
                {
                    Console.WriteLine("LuaScript Instance : " + Lua.LuaScript.ScriptsInstances.Count);
                    Console.WriteLine("Command Count : " + asayo.CommandManager.Count);
                    Console.WriteLine("Guild in GuildVars Count: " + asayo.GuildVars.FullCount);
                    Console.WriteLine("Guild Variables Count : " + asayo.GuildVars.FullCount);
                }
                if (command.ToLower() == "luas")
                {
                    Console.WriteLine(LuaScript.ScriptsInstances.Count + " LuaScript Instance");
                    foreach (var item in LuaScript.ScriptsInstances)
                    {
                        Console.WriteLine(item.ID + " | " + item.Filename);
                    }
                }
                if (command.ToLower() == "lua")
                {
                    MoonSharp.Interpreter.Script s = LuaScript.CreateScriptWithLuaScript();
                    LuaConsole(s);
                }
                if (command.StartsWith("load "))
                {
                    var fn = command.Replace("load ", "").TrimStart(' ');
                    new LuaScript(fn).Execute();
                }

                if (command.StartsWith("lua "))
                {
                    var id = int.Parse(command.Replace("lua ", "").Trim(' '));
                    var script = LuaScript.ScriptsInstances[id];
                    LuaConsole(script.Script);
                }
                if (command.StartsWith("ban "))
                {
                    var id = ulong.Parse(command.Replace("ban ", "").Trim(' '));
                    Asayo.Instance.BannedUser.Add(id);
                    Console.WriteLine(id + "is now banned");
                }
                if (command.StartsWith("unban "))
                {
                    var id = ulong.Parse(command.Replace("unban ", "").Trim(' '));
                    Asayo.Instance.BannedUser.Remove(id);
                    Console.WriteLine(id + "is now unbanned");
                }
                if (command.ToLower() == "help")
                {
                    Console.WriteLine(Version + " [Console-Help]");
                    Console.WriteLine("\thelp : Show console help");
                    Console.WriteLine("\tload <file> : Load lua script");
                    Console.WriteLine("\tlua [id] : Open lua interpreter (id can be not exit)");
                    Console.WriteLine("\tluas : Show loaded script with id");
                    Console.WriteLine("\tcommands : Show a list of reg commands");
                    Console.WriteLine("\tstats : Show Asayo Statistic");
                    Console.WriteLine("\tban <id> : Ban user to use your bot");
                    Console.WriteLine("\tunban <id> : Un-Ban user to use your bot");
                    Console.WriteLine("\treload : Reload the bot");
                    Console.WriteLine("\tsave : Save the bot");
                    Console.WriteLine("\texit : Quit the bot");
                }
            }
        }

        static void LuaConsole(MoonSharp.Interpreter.Script s)
        {
            bool lua_exit = false;
            Console.WriteLine("Starting Lua Console...");
            Console.WriteLine("Disabling Console Out...");
            Console.WriteLine("=============LUA-CONSOLE=============");
            Logger.GlobalWriteConsoleLog = false;
            while (!lua_exit)
            {
                Console.WriteLine();
                Console.Write("lua>");
                var r = Console.ReadLine();
                if (r == "exit") lua_exit = true; else try { Console.WriteLine(s.DoString(r).ToString()); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            Logger.GlobalWriteConsoleLog = true;
            Console.WriteLine("============LUA-CONSOLE-END===========");
        }
    }
}
