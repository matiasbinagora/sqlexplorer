using System;
using System.Collections.Generic;
using System.Linq;
using SqlExplorer.Program.Models;
using SqlExplorer.Program.Commands.Models;
using Newtonsoft.Json;
using System.IO;

namespace SqlExplorer.Program.Commands
{
    /// Configuration Command class definition
    public class ConfigurationCommand : ICommand
    {
        // Retrieves the program configuration from a json into an .NET object
        public Output Execute(Input input)
        {
            var content = File.ReadAllText((input as ConfigurationInput).Path);
            return JsonConvert.DeserializeObject<ConfigurationOutput>(content);
        }
    }
}
