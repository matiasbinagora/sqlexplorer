using System;
using System.Collections.Generic;

namespace SqlExplorer.Program.Commands.Models
{

    /// File Explorer Input information definition
    public class FileExplorerInput : Input
    {
       /// Path to file or directory for search
       public string Path {get; set;}

       // type of file to search into a directory
       public string TypeOfFiles {get; set;}
       
       // list of patterns to search into files
       public IList<string> Patterns {get; set; }
    }
}