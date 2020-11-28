using System;
using System.IO;
using System.Collections.Generic;

namespace Rainforest_Robot
{
    class CLIHandler
    {
        static void Main(string[] args) {
            // Interpret command line arguments
            bool testMode = false;
            bool humanMode = false;
            try {
                List<string> dirs = new List<string>();
                foreach (string arg in args) {
                    if (arg.ToUpper() == "--TEST") {
                        testMode = true;
                    }
                    else if (arg.ToUpper() == "--HUMAN") {
                        humanMode = true;
                    }
                    else {
                        dirs.Add(arg);
                    }
                }
                implementInput(testMode:testMode, humanMode:humanMode, dirs:dirs);
            } catch (Exception ex) {
                Console.WriteLine("The program has crashed:");
                Console.WriteLine(ex);
            }
        }

        static void implementInput(bool testMode, bool humanMode, List<string> dirs) {
            if (dirs.Capacity == 0) {
                // Get data by user input
                try {
            
                    string feederCoords = fetchInput("Enter feeder co-ords in the format: x y");
                    string robotCoords = fetchInput("Enter robot co-ords in the format: x y");
                    string crateString = fetchInput("Enter crate data in the format: x y q, x1 y1 q1 etc");
                    string instructions = fetchInput("Enter instructions as a continuous string:");
                    implementInput(feederCoords, robotCoords, crateString, instructions);
                } catch (Exception ex) {
                    Console.WriteLine("The instuctions were invalid:");
                    Console.WriteLine(ex);
                }
            }
            foreach (string dir in dirs) {
                try {                                     
                    DirectoryInfo directory = new DirectoryInfo(dir);
                    if (directory.Exists == false) {
                        Console.WriteLine("The directory " + dir + " does not exist.");
                        continue;
                    }
                    foreach (FileInfo file in directory.GetFiles("*.txt")) {
                        System.IO.StreamReader Reader = new System.IO.StreamReader(file.FullName); 
                        string line; 
                        List<string> input = new List<string>();
                        while ((line = Reader.ReadLine()) != null) { 
                            input.Add(line);
                        }  
                        implementInput(input[0], input[1], input[2], input[3]);
                    }
                } catch (Exception ex) {
                    Console.WriteLine("The instuctions were invalid:");
                    Console.WriteLine(ex);
                };
            }

        }

        static string fetchInput(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine().Trim();
        }

        static void implementInput(string _feederCoords, string _robotCoords, string _crateString, string _instructions) { 

            int[] feederCoords = Array.ConvertAll(_feederCoords.Split(" "), s => int.Parse(s));
            Feeder feeder = new Feeder(feederCoords[0], feederCoords[1]);
            int[] robotCoords = Array.ConvertAll(_robotCoords.Split(" "), s => int.Parse(s));
            Robot robot = new Robot(robotCoords[0], robotCoords[1]);
            string[] crateStrings = _crateString.Split(",");
            List<Crate> crates = new List<Crate>();
            foreach (string crateString in crateStrings) {
                int[] crateInts = Array.ConvertAll(crateString.Trim().Split(" "), s => int.Parse(s));
                Crate crate = new Crate(crateInts[0], crateInts[1], crateInts[2]);
                crates.Add(crate);
            }
            string instructions = _instructions;
            PickList pickList = new PickList(feeder, robot, crates, instructions);
            pickList.Execute();
            foreach(string line in pickList.Output) {
                Console.WriteLine(line);
            }
        }
    }
}


// Robot picks up one at a time from crate
// Drops all at once into feeder

// Instructions one at a time
// Robot moves NSEW one at a time
// Pick up - P
//   If not at a crate, it falls over
// Drop off - D
//  If not at a feeder it falls over
