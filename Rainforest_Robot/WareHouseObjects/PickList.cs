using System;
using System.Collections.Generic;

namespace Rainforest_Robot {

        class PickList {

            Feeder feeder;
            
            Robot robot;
        
            List<Crate> crates;
            
            string instructions;
            
            public PickList(Feeder _feeder, Robot _robot, List<Crate> _crates, string _instructions) {
                feeder = _feeder;
                robot = _robot;
                crates = _crates;
                instructions = _instructions;
            }

            public void Report() {
                Console.WriteLine("Feeder: " + feeder.Report());
                Console.WriteLine("Robot: " + robot.Report());
                foreach (Crate crate in crates) {
                    Console.WriteLine("Crate: " + crate.Report());
                }
                Console.WriteLine("Instructions: " + instructions);

            }

        }

}