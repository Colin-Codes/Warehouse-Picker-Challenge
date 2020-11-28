using System;
using System.Collections.Generic;

namespace Rainforest_Robot {

        class PickList {

            Feeder feeder;
            
            Robot robot;
        
            List<Crate> crates;
            
            string instructions;

            List<string> output;
            
            public PickList(Feeder _feeder, Robot _robot, List<Crate> _crates, string _instructions) {
                feeder = _feeder;
                robot = _robot;
                crates = _crates;
                instructions = _instructions;
            }

            public void Execute() {
                foreach (Char instruction in instructions) {
                    switch (instruction) {
                        case 'N':
                            robot.goNorth();
                            break;
                        case 'S':
                            robot.goSouth();
                            break;
                        case 'E':
                            robot.goEast();
                            break;
                        case 'W':
                            robot.goWest();
                            break;
                        case 'P':
                            int pickedBags = -1;
                            foreach (Crate crate in crates) {
                                if (robot.hasReachedCrate(crate.X, crate.Y)) {
                                    pickedBags = crate.giveBag();
                                    break;
                                }
                            }
                            robot.pickBags(pickedBags);
                            break;
                        case 'D':
                            break;    
                        default:
                            throw new System.ArgumentException("The following instruction is not recognised: " + instruction);                   
                    }
                }
                //output.Add(feeder.Quantity);
            }

            public void Report() {
                // For debugging purposes
                Console.WriteLine("Feeder: " + feeder.Report());
                Console.WriteLine("Robot: " + robot.Report());
                foreach (Crate crate in crates) {
                    Console.WriteLine("Crate: " + crate.Report());
                }
                Console.WriteLine("Instructions: " + instructions);

            }

        }

}