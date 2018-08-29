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
    public class ConfigurationCommand : CommandDto
    {
        // Retrieves the program configuration from a json into an .NET object
        public CommandDto Execute(CommandDto input)
        {
            var content = File.ReadAllText((input as ConfigurationInput).ConfigFilePath);
            var result = JsonConvert.DeserializeObject<ValuesForSearch>(content);
            result.Path = (input as ConfigurationInput).PathForSearch;
            return result;
        }
    }
}
