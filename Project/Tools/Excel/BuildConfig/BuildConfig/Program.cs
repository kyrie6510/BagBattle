using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace BuildConfig
{
    internal class Program
    {
        static void Compile(string pathFlatDll, string csPath,  string output)
        {
            var c = new CSharpCodeProvider();
            var cp = new CompilerParameters();
            var netstandard = Assembly.Load("netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
            cp.ReferencedAssemblies.Add(netstandard.Location);
            cp.ReferencedAssemblies.Add(pathFlatDll);
            cp.CompilerOptions = "/t:library";
            cp.OutputAssembly = output;
            var csFileList = Directory.GetFiles( csPath, "*.cs", SearchOption.TopDirectoryOnly);
            CompilerResults cr = c.CompileAssemblyFromFile(cp, csFileList);

            string log = "";
            if (cr.Errors.Count > 0)
            {
                string error = "";
                foreach (CompilerError CompErr in cr.Errors)
                {
                    error += "Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";" ;
                }
                log += "\r\nCS编译出错！！！！！";
                log += "\r\n " + error;

            }
            else
            {
                log += "\r\nCS编译成功";
            }
            Console.Write(log);
        }
        public static void Main(string[] args)
        {
           // Console.WriteLine(args[0]);
           // Console.WriteLine(args[1]);
           // Console.WriteLine(args[2]);
           // Compile(args[0],args[1],args[2]);
            Compile(Environment.CurrentDirectory+"/FlatBuffers.dll",Environment.CurrentDirectory +"/csharp","config-flat.dll");
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine("当前项目文件夹路径：" + currentDirectory);
            Console.ReadKey();
        }
    }
}