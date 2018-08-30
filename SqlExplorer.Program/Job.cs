using System;
using System.Collections.Generic;
using SqlExplorer.Program.Commands;
using SqlExplorer.Program.Commands.Models;
using Newtonsoft.Json;
using System.IO;

namespace SqlExplorer.Program
{
    /// Main app program handles the 
    public class Job
    {
        public IList<ICommand> commands;

        // Main method, big bang
        static void Main(string[] args)
        {
            var program = new Job();
            program.commands = program.SetupCommands();
            if (args.Length < 2)
            { Console.WriteLine("Expected 2 args"); }
            else
            {
                Console.WriteLine("arg: " +  args[0]);
                Console.WriteLine("arg: " +  args[1]);
                var result = program.Run(args[0], args[1]);
                File.WriteAllText("output.txt",JsonConvert.SerializeObject(result));
                Console.WriteLine("output.txt file created");
                Console.WriteLine("Go to https://www.csvjson.com/json2csv to CSV format");
            }
        }

        // Setups a list of commands to be executed
        public IList<ICommand> SetupCommands()
        {
            var result = new List<ICommand>();
            result.Add(new ConfigurationCommand());
            result.Add(new FileExplorerCommand());
            result.Add(new MergeResultCommand());

            return result;
        }

        // Runs a list of commands
        public CommandDto Run(string configurationPath, string pathToSearch)
        {
            CommandDto input = new ConfigurationInput()
            {
                ConfigFilePath = configurationPath,
                PathForSearch = pathToSearch
            };

            foreach (var command in commands)
            {
                var output = command.Execute(input);
                input = output;
            }
            return input;
        }
    }
}
