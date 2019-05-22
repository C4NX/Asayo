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

        public static void ShowErrorWindows(Script s,Exception ex)
        {
            Form _form = new Form();
            _form.Size = new System.Drawing.Size(700, 400);

            _form.Text = "Opps, Lua Error as Handled";
            TextBox tb = new TextBox() {Name="tb",Text="",Dock=DockStyle.Fill,Multiline=true};

            if (ex is MoonSharp.Interpreter.SyntaxErrorException)
            {
                var _ex = (MoonSharp.Interpreter.SyntaxErrorException)ex;
                tb.Text = _ex.DecoratedMessage + "\n";

                if (_ex.CallStack != null)
                {
                    foreach (var item in _ex.CallStack)
                    {
                        tb.Text += "\nCall Stack : \n";
                        tb.Text += item.ToString() + "\n";
                    }
                }

                tb.Text += "\nSource : " + _ex.Source;

                /*try
                {
                    tb.Text += "\nLine : " + File.ReadAllLines(fn)[_ex.]
                }
                catch (Exception)
                {
                }*/
            }
            else if (ex is MoonSharp.Interpreter.ScriptRuntimeException)
            {
                var _ex = (MoonSharp.Interpreter.ScriptRuntimeException)ex;
                tb.Text = _ex.DecoratedMessage + "\n";

                if (_ex.CallStack != null)
                {
                    foreach (var item in _ex.CallStack)
                    {
                        tb.Text += "\nCall Stack : \n";
                        tb.Text += item.ToString() + "\n";
                    }
                }

                tb.Text += "\nSource : " + _ex.Source;

                /*try
                {
                    tb.Text += "\nLine : " + File.ReadAllLines(fn)[_ex.]
                }
                catch (Exception)
                {
                }*/
            }
            else
            {
                tb.Text = ex.ToString();
            }


            Button OK = new Button() { Dock = DockStyle.Bottom};
            OK.DialogResult = DialogResult.OK;

            _form.Controls.Add(tb);
            _form.Controls.Add(OK);
            _form.ShowDialog();
        }
    }
}
