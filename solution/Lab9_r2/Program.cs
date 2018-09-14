/// When Testing Locally prior to KAtis Submission Do Define
/// On Submit To Katis Website Comment out the #define NOKATIS
//#define NOTREADYTOUPLOADTOKATIS
using System;
using System.IO;
using System.Collections.Generic;


namespace Lab9_r2
{

    public class KatiseStub
    {

        static StreamWriter writer = null;

        public static int Main(string[] args)
        {

            if (args.Length == 2)
                OpenNoKatis(args[0], args[1]);
            else
                OpenNoKatis();

            List<string> lstInputLines = new List<string>();


            string line;
            while ((line = Console.ReadLine()) != null)
            {
                lstInputLines.Add(line);
            }
            SolveKatisFromInput(lstInputLines);
            CloseNoKatis();
            return 0;
        }

        private static void SolveKatisFromInput(List<string> lstInputLines)
        {

            string NumString = lstInputLines[0];
            string[] nums = NumString.Split(new char[] { ' ' });
            short r1;
            short mean;

            if (short.TryParse(nums[0], out r1) && short.TryParse(nums[1], out mean))
            {

                short r2 = (short)((mean * 2) - r1);
                Console.WriteLine(r2.ToString());

            }

        }

        private static void OpenNoKatis(string arg0 = @"..\..\Input.txt",
                                        string arg1 = @"..\..\Output.txt")
        {
#if NOTREADYTOUPLOADTOKATIS

            try
            {

                writer = new StreamWriter(arg1);
                // Redirect standard output from the console to the output file.
                Console.SetOut(writer);
                // Redirect standard input from the console to the input file.
                if (!File.Exists(arg0))
                {
                    var f = File.CreateText(arg0);
                    f.WriteLine("EMPTY INPUTFILE");
                    f.Flush();
                    f.Close();
                    Console.WriteLine($"It would be better if You put some input in {arg0}");

                }

                Console.SetIn(new StreamReader(arg0));
            }
            catch (IOException e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
            }
#endif
        }

        private static void CloseNoKatis()
        {
#if NOTREADYTOUPLOADTOKATIS
            writer.Close();
            // Recover the standard output stream so that a 
            // completion message can be displayed.
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
#endif
        }
    }
}
