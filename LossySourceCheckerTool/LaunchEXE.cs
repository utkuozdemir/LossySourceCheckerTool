using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LossySourceCheckerTool
{
    class LaunchEXE
    {
        internal static string Run(string exeName, string argsLine, int timeoutSeconds)
        {
            StreamReader outputStream = StreamReader.Null;
            string output = "";
            bool success = false;

            try
            {
                Process newProcess = new Process();
                newProcess.StartInfo.FileName = exeName;
                newProcess.StartInfo.Arguments = argsLine;
                newProcess.StartInfo.UseShellExecute = false;
                newProcess.StartInfo.CreateNoWindow = true;
                newProcess.StartInfo.RedirectStandardOutput = true;
                newProcess.Start();

                if (0 == timeoutSeconds)
                {
                    newProcess.WaitForExit();
                    success = true;
                }
                else
                {
                    success = newProcess.WaitForExit(timeoutSeconds * 1000);

                }
                if (success)
                {
                    outputStream = newProcess.StandardOutput;
                    output = outputStream.ReadToEnd();
                }
                else
                {
                    output = "Timed out at " + timeoutSeconds + " seconds waiting for " + exeName + " to exit.";
                }

            }
            catch (Exception e)
            {
                throw (new Exception("An error occurred running " + exeName + ".", e));
            }
            finally
            {
                outputStream.Close();
            }

            return "\t" + output;
        }
    }
}
