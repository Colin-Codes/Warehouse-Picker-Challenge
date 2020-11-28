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
            implementInstructions(testMode:testMode, humanMode:humanMode, dirs:dirs);
        }

        static void implementInstructions(bool testMode, bool humanMode, List<string> dirs) {
            if (dirs.Capacity == 0) {
                // Get data by user input
                string feederCoords = fetchInput("Enter feeder co-ords in the format: x y");
                string robotCoords = fetchInput("Enter robot co-ords in the format: x y");
                string crateData = fetchInput("Enter crate data in the format: x y q, x1 y1 q1 etc");
                Console.WriteLine(feederCoords);
                Console.WriteLine(robotCoords);
                Console.WriteLine(crateData);
            }
            foreach (string dir in dirs) {
                Console.WriteLine(dir);

            }

        }

        static string fetchInput(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine();
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
