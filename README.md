# Warehouse-Robot-Challenge

## Quickstart
Open a Command Prompt window
Navigate to ~\Rainforest_Robot\bin\Debug\net5.0
execute the command: Rainforest_Robot.exe --test test
Watch the tests run.

## Build
I wrote and built this in VS Code, using the C# extension (https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp). 
Navigate to ~\Rainforest_Robot
To compile and xecute tests: dotnet run --test test 

## Instructions
Call the executable with the following arguments, which can be given in any order:
* no args *
Program will request initialisation data, either via the console or if specified, txt files within given directories. Exceution will then proceed and an output generated.
--test or --TEST 
Activates test mode. In addition to the routine above, output data will be reuqested and a message returned if the test outputs match the achieved outputs.
dir1 dir2 dir3 dirN
Any number of directories can be specified. Any files within, having the .txt extension will be read as input. The console will log inputs and outputs as if entered manually. If test output data is included, and --test is not specified, this will be ignored. 
--human or --HUMAN
Executes the picklist with a human operator - not yet implmented.

## Assumptions
Robot cannot start with a quantity higher than 0
If insufficient bags are available, then carry on regardless

## Developer notes
I have attempted to break the problem into layers. CLIHandler for instance:
    1. Main - Processes the CLI arguments
    2. implementInput - Takes further input from the user or files as required
    3. processInput - Turns input into objects and processes output
Otherwise, I have attempted create abstractions and decoupling to allow for future development and maintenance.
For instance, the PickList object was not strictly necessary but decoupled the operation of the robot from processing of the inputs.
    This object could also be serialized for future reference, or could even be scheduled for the future by serializing before the the execute command is called.
    I wanted to add an IPicker interface so that I could inject human pickers into this class, but unfortunately I ran out of time. 
Admittedly, CLIHandler does not feel easy to read. Additional commenting and whitespace would help, and the first few lines of processInput could be 'DRY'-er.

## Future developments
Feeder could start with non-zero Quantity in future
Crates ought to be checked that they are not co-located
Human pickers could be added by using an interface such as IPicker instead of Robot in the PickList signature.
