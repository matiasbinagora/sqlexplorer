using System;
using System.Collections.Generic;

namespace SqlExplorer.Program.Commands.Models
{

    /// Configuration Input information definition
    public class ConfigurationInput : Input
    {
       /// Path to configuration file
       public string Path {get; set;}
    }
}