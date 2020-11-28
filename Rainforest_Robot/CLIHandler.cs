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
            Console.WriteLine(testMode);
            Console.WriteLine(humanMode);
            foreach (string dir in dirs) {
                Console.WriteLine(dir);

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
