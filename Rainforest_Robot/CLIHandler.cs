using System;

namespace Rainforest_Robot
{
    class CLIHandler
    {
        static void Main(string[] args)
        {
            bool testMode = false;
            bool humanMode = false;
            foreach (string arg in args) {
                if (arg == "--TEST") {
                    testMode = true;
                }
                else if (arg == "--HUMAN") {
                    humanMode = true;
                }
            }
            // Interpret command line arguments
            Console.WriteLine("Hello World!");
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
