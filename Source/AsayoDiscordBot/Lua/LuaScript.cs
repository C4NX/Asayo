using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsayoDiscordBot.Lua
{
    public class LuaScript
    {
        internal Script Script { get; set; }

        public string Filename { get { return fn; } }

        string fn;

        internal static List<LuaScript> ScriptsInstances = new List<LuaScript>();

        public int ID { get { return ScriptsInstances.IndexOf(this); } }

        public LuaScript(string filename)
        {
            Script = Init();

            fn = filename;
            ScriptsInstances.Add(this);
        }

        protected LuaScript()
        {

        }

        static Script Init()
        {
            Script s = new Script(CoreModules.Preset_Complete);
            s.Globals.RegisterModuleType<Lua.Modules.BaseModule>();
            s.Globals.RegisterModuleType<Lua.Modules.ApiModule>();
            s.Globals.RegisterModuleType<Lua.Modules.CommandModule>();
            return s;
        }

        public void Execute()
        {
            try
            {
                Script.DoFile(fn);
            }
            catch (Exception ex)
            {
                new System.Threading.Thread(() => { ShowErrorWindows(Script,ex); }).Start();
            }
            //Script.Globals[""] = DynValue.NewString("token");
        }

        public static Script CreateScriptWithLuaScript()
        {
            Script s = null;
            s = Init();
            return s;
        }

        public void Reload(bool exec = false)
        {
            Script = Init();//Re init script
            if(exec) Execute();
        }

        static string TString(DynValue v)
        {
            switch (v.Type)
            {
                case DataType.Nil:
                    return "Nil";
                case DataType.Void:
                    return "Void";
                case DataType.Boolean:
                    return v.Boolean.ToString();
                case DataType.Number:
                    return v.Number.ToString();
                case DataType.String:
                    return v.String;
                case DataType.Function:
                    return "Function:" + v.Function.ReferenceID;
                case DataType.Table:
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in v.Table.Pairs)
                    {
                        sb.AppendLine(TString(item.Key) + " : " + TString(item.Value));
                    }
                    return sb.ToString();
                case DataType.Tuple:
                    StringBuilder _sb = new StringBuilder();
                    foreach (var item in v.Table.Pairs)
                    {
                        _sb.AppendLine(TString(item.Value));
                    }
                    return _sb.ToString();
                case DataType.UserData:
                    return v.ToString();
                case DataType.Thread:
                    return v.ToString();
                case DataType.ClrFunction:
                    return v.Callback.Name;
                case DataType.TailCallRequest:
                    return v.TailCallData.ToString();
                case DataType.YieldRequest:
                    return v.YieldRequest.ToString();
                default:
                    return v.ToString();
            }
        }

        public static void ShowErrorWindows(Script s,Exception ex)
        {
            Form _form = new Form();
            _form.Size = new System.Drawing.Size(700, 400);

            _form.Text = "Opps, Lua Error as Handled";
            TextBox tb = new TextBox() {Name="tb",Text="",Dock=DockStyle.Fill,Multiline=true};

            StringBuilder sb = new StringBuilder();
            /*
            sb.AppendLine("GLOBAL : ");
            sb.AppendLine(MoonSharp.Interpreter.Serialization.Json.JsonTableConverter.TableToJson(s.Globals));
            */

            /*sb.AppendLine("GLOBAL : ");
            foreach (var item in s.Globals.Pairs)
            {
                sb.AppendLine(TString(item.Key) + " : " + TString(item.Value));
            }*/

            sb.AppendLine("Exception : ");
            if (ex is InterpreterException)
            {
                var _ex = (InterpreterException)ex;
                sb.AppendLine("Normal Message : " + _ex.Message);
                sb.AppendLine("Message : " + _ex.DecoratedMessage);
            }
            else if (ex is ScriptRuntimeException)
            {
                var _ex = (ScriptRuntimeException)ex;
                sb.AppendLine("Normal Message : " + _ex.Message);
                sb.AppendLine("Message : " + _ex.DecoratedMessage);
            }
            else
            {
                sb.AppendLine("Message : " + ex.Message);
            }

            sb.AppendLine("Exception Type : " + ex.GetType().FullName);

            tb.Text = sb.ToString();

            Button OK = new Button() { Dock = DockStyle.Bottom};
            OK.DialogResult = DialogResult.OK;

            _form.Controls.Add(tb);
            _form.Controls.Add(OK);
            _form.ShowDialog();
        }
    }
}
