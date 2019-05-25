using AsayoDiscordBot.Commands;
using AsayoDiscordBot.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot
{
    public class Asayo
    {
        public DSharpPlus.DiscordClient Client { get; private set; }

        public Logger Logger { get; set; }

        public ConfigurationJson Configuration { get; set; }

        public static Asayo Instance { get; private set; }

        public Data.BanList BannedUser { get; set; }

        public CommandSystem CommandManager { get; set; }

        public GuildVars GuildVars { get; set; }

        public Asayo()
        {
            Logger = Logger.GetLogger<Asayo>();
            Logger.SaveFileLog = true;
            BannedUser = new Data.BanList();
            CommandManager = new CommandSystem("!!");
            GuildVars = new GuildVars();
            Instance = this;
        }

        public void Start()
        {
            Run(false).GetAwaiter().GetResult();
        }

        public void Save()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            ConfigurationJson.Save(Configuration, "conf.json");

            stopwatch.Stop();
            Logger.Info("Saved in " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public void Reload()
        {
            Logger.Info("Reload...");
            Lua.Userdatas.AsayoLuaEvent.CallReload();
            Lua.Userdatas.AsayoObject.OnMessageEvents.Clear();
            Lua.Userdatas.AsayoObject.OnReloadEvents.Clear();
            CommandManager.RemoveAll();
            foreach (var item in Lua.LuaScript.ScriptsInstances)
            {
                item.Reload(true);
            }
        }

        async Task Run(bool loop)
        {
            Client = new DSharpPlus.DiscordClient(new DSharpPlus.DiscordConfiguration() { Token = Configuration.Token,LogLevel=DSharpPlus.LogLevel.Debug });
            if(Configuration.LoggerFormat != null)Logger.LogFormat = Configuration.LoggerFormat;
            Client.DebugLogger.LogMessageReceived += (sender,e)=> 
            {
                Logger.Info(e.Message);
            };
            Client.MessageCreated += Client_MessageCreated;
            CommandManager.Register(new TestCommand("test"));

            await Client.ConnectAsync();

            if (loop) await Task.Delay(-1);
        }

        private Task Client_MessageCreated(DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            if (BannedUser.IsBan(e.Author.Id))
            {
                e.Message.RespondAsync("Sorry but you are banned");
                return Task.Delay(0);
            }
            //Lua Callback
            var table = MoonSharp.Interpreter.DynValue.NewPrimeTable();
            foreach (var item in e.Message.Content.Split(' '))
            {
                table.Table.Append(MoonSharp.Interpreter.DynValue.NewString(item));
            }
            Lua.Userdatas.AsayoLuaEvent.CallOnMessage(table, MoonSharp.Interpreter.UserData.Create(new Lua.Userdatas._DSharpPlus.MessageArgsObject(e)));
            
            CommandManager.Call(CommandManager.CreateContext(e));//Command manager call

            return Task.Delay(0);
        }
    }
}
