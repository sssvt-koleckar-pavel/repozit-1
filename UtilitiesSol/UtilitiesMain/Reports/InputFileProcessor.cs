using System;
using System.IO;

namespace UtilitiesMain.Reports
{
    public class InputFileProcessor
    {

        public const int MaxNumberOfDataLines = 1000;

        public string filePath;

        public InputFileProcessor(string filePath)
        {
            this.filePath = filePath;
        }

        public DataLine[] ProcessFile()
        {
            StreamReader sr = null;
            DataLine[] dataLines = new DataLine[InputFileProcessor.MaxNumberOfDataLines];
            int lineCounter = 0;
            try
            {
                sr = new StreamReader(this.filePath);
                while ( ! sr.EndOfStream )
                {
                    string line = sr.ReadLine();
                    dataLines[lineCounter] = ConvertStringToDataLine(line);
                    lineCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            Array.Resize(ref dataLines, lineCounter);
            return dataLines;
        }

        private DataLine ConvertStringToDataLine(string line)
        {
            // Kateřina Malá,AJ,15.9.2020,4
            string[] values = line.Split(',');

            // value[0]: "Kateřina Malá"
            // value[1]: "AJ"
            // value[2]: "15.9.2020"
            // value[3]: "4"
            DataLine dataLine = new DataLine();
            dataLine.studentName = values[0];
            dataLine.subjectAcronym = values[1];
            dataLine.date = Convert.ToDateTime(values[2]);
            dataLine.grade = Convert.ToInt32(values[3]);

            return dataLine;
        }

    }
}
