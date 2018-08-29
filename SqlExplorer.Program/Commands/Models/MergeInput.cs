using System;
using System.Collections.Generic;
using SqlExplorer.Program.Models;

namespace SqlExplorer.Program.Commands.Models
{

    /// Merge Input information definition
    public class MergeInput : Input
    {
        // list of search result as input
        public IList<SearchResult> Input {get; set;}
    }
}