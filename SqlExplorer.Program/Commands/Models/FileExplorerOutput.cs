using System;
using System.Collections.Generic;
using SqlExplorer.Program.Models;

namespace SqlExplorer.Program.Commands.Models
{

    /// File Explorer Output information definition
    public class FileExplorerOutput : Output
    {

        /// Search result output list
        public IList<SearchResult> Output { get; set; }
    }
}