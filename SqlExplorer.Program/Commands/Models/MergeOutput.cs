using System;
using System.Collections.Generic;
using SqlExplorer.Program.Models;

namespace SqlExplorer.Program.Commands.Models
{

    /// Merge Output information definition
    public class MergeOutput : Output
    {

        /// Merge result output list
        public IList<MergeResult> Output { get; set; }
    }
}