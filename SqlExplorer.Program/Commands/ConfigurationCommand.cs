using System;
using System.Collections.Generic;
using System.Linq;
using SqlExplorer.Program.Models;
using Newtonsoft.Json;
using System.IO;

namespace SqlExplorer.Program.Commands
{
    /// Configuration Command class definition
    public class ConfigurationCommand
    {
        // Retrieves the program configuration from a json into an .NET object
        public Configuration Execute(string input)
        {
            var content = File.ReadAllText(input);
            return JsonConvert.DeserializeObject<Configuration>(content);
        }
    }
}
