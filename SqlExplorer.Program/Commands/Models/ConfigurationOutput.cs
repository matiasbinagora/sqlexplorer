using System;
using System.Collections.Generic;

namespace SqlExplorer.Program.Commands.Models
{

    /// Configuration information definition
    public class ConfigurationOutput : Output
    {

        /// Type of files supported
        public string FileType { get; set; }

        /// Patterns to search
        public IList<string> Patterns { get; set; }
    }
}