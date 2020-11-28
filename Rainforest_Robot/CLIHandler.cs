using System;
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
                    int[] feederCoords = Array.ConvertAll(fetchInput("Enter feeder co-ords in the format: x y").Split(" "), s => int.Parse(s));
                    Feeder feeder = new Feeder(feederCoords[0], feederCoords[1]);
                    int[] robotCoords = Array.ConvertAll(fetchInput("Enter robot co-ords in the format: x y").Split(" "), s => int.Parse(s));
                    Robot robot = new Robot(robotCoords[0], robotCoords[1]);
                    string[] crateStrings = fetchInput("Enter crate data in the format: x y q, x1 y1 q1 etc").Split(",");
                    List<Crate> crates = new List<Crate>();
                    foreach (string crateString in crateStrings) {
                        int[] crateInts = Array.ConvertAll(crateString.Split(" "), s => int.Parse(s));
                        Crate crate = new Crate(crateInts[0], crateInts[1], crateInts[2]);
                        crates.Add(crate);
                    }
                    string instructions = fetchInput("Enter instructions as a continuous string:");
                    PickList pickList = new PickList(feeder, robot, crates, instructions);
                    pickList.Report();
                } catch (Exception ex) {
                    Console.WriteLine("The instuctions were invalid:");
                    Console.WriteLine(ex);
                }
            }
            foreach (string dir in dirs) {
                try {
                    Console.WriteLine(dir);
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
