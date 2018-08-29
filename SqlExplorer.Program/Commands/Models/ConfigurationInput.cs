using System;
using System.Collections.Generic;

namespace SqlExplorer.Program.Commands.Models
{

    /// Configuration Input information definition
    public class ConfigurationInput : CommandDto
    {
        /// Path to configuration file
        public string ConfigFilePath {get; set;}

        /// Path to file or directory for search
        public string PathForSearch {get; set;}
    }
}