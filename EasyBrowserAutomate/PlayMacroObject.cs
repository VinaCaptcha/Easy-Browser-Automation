using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.Threading;

namespace EasyBrowserAutomation
{
    public class PlayMacroObject
    {
        public static bool IsPlaying { set; get; }
        public static string MacroScript { set; get; }


        public static void Stop()
        {
            IsPlaying = false;
        }
        
        public static void Play()
        {
            IsPlaying = true;


            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.ReferencedAssemblies.Add("EasyBrowserAutomation.exe"); //Reference Main Appication.exe
            parameters.ReferencedAssemblies.Add("EBASetting.dll"); //Reference Library dll


            // True - memory generation, false - external file generation
            parameters.GenerateInMemory = true;
            // True - exe file generation, false - dll file generation
            parameters.GenerateExecutable = false;

            // Input C# code
            StringBuilder CSharpCode = new StringBuilder();
            CSharpCode.AppendLine("using System;");
            CSharpCode.AppendLine("using EasyBrowserAutomation;");
            CSharpCode.AppendLine("using EBASetting;");
            CSharpCode.AppendLine("namespace MyMacroApp {");
            CSharpCode.AppendLine("public class MyMainClass : EasyBrowserAutomation.MyMacros {");
            CSharpCode.AppendLine("public static void Run() {");
            CSharpCode.AppendLine(MacroScript);
            CSharpCode.AppendLine("}}}");

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, CSharpCode.ToString());

            if (results.Errors.HasErrors)
            {
                Program.fmain.UpdateStatus("Error", "Error Line: " + (results.Errors[0].Line - 5) + ", " + results.Errors[0].ErrorText);
            }
            else
            {
                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("MyMacroApp.MyMainClass");
                MethodInfo method = program.GetMethod("Run");

                method.Invoke(null, null);
            }

            Program.fmain.StopMacro();
        }
    }
}
