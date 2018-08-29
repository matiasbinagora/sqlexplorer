using System;
using System.Collections.Generic;

namespace SqlExplorer.Program.Models
{

    /// Merge result class definition
    public class MergeResult
    {

        /// Complete word searched
        public string WordSearched { get; set; }

        /// List of class information where the word was found
        public IList<ClassInfo> Found { get; set; }
    }
}