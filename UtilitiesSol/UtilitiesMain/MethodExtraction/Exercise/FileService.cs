using System;
using System.IO;



namespace UtilitiesMain.MethodExtraction.Exercise
{



    /// <summary>
    /// Exposes methods to help process files.
    /// </summary>
    public class FileService
    {



        /// <summary>
        /// Merges the contents of four given text files and displays them on the console.
        /// </summary>
        /// <param name="fileA">First file.</param>
        /// <param name="fileB">Second file</param>
        /// <param name="fileC">Third file.</param>
        /// <param name="fileD">Fourth file.</param>
        public void MergeFiles(string fileA, string fileB, string fileC, string fileD)
        {

            // Prepare a 2D-array to store the contents of the given files.
            // Row index corresponds to the file.
            // Column index corresponds to a row in the file.
            string[,] fileContents = new string[4, 10];

            // Load the contents of the fileA.
            StreamReader streamReader = null;
            int rowCounter;
            try
            {
                streamReader = new StreamReader(fileA);
                rowCounter = 0;
                while ( ! streamReader.EndOfStream )
                {
                    string line = streamReader.ReadLine();
                    fileContents[0, rowCounter] = line;
                    rowCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }

            // Load the contents of the fileB.
            streamReader = null;
            try
            {
                streamReader = new StreamReader(fileB);
                rowCounter = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    fileContents[1, rowCounter] = line;
                    rowCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }

            // Load the contents of the fileC.
            streamReader = null;
            try
            {
                streamReader = new StreamReader(fileC);
                rowCounter = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    fileContents[2, rowCounter] = line;
                    rowCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }

            // Load the contents of the fileD.
            streamReader = null;
            try
            {
                streamReader = new StreamReader(fileD);
                rowCounter = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    fileContents[3, rowCounter] = line;
                    rowCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }

            // Display the contents of those files.
            // Display the first lines of the files on the first line.
            // Display the second lines of the files on the second line.
            // Etc.
            for (rowCounter = 0; rowCounter < fileContents.GetLength(1); rowCounter++)
            {
                // A row from fileA.
                if (fileContents[0, rowCounter] != null)
                {
                    Console.Write(fileContents[0, rowCounter] + " ");
                }

                // A row from fileB.
                if (fileContents[1, rowCounter] != null)
                {
                    Console.Write(fileContents[1, rowCounter] + " ");
                }

                // A row from fileC.
                if (fileContents[2, rowCounter] != null)
                {
                    Console.Write(fileContents[2, rowCounter] + " ");
                }

                // A row from fileD.
                if (fileContents[3, rowCounter] != null)
                {
                    Console.Write(fileContents[3, rowCounter] + " ");
                }

                // New line.
                Console.WriteLine();
            }

        }



    }



}
