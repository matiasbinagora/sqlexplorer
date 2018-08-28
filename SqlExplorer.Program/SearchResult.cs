using System;

namespace SqlExplorer.Program{

    /// Search result class definition
    public class SearchResult {

        /// Line number where the word was found in the class
        public string LineNumber { get; set; }

        /// Complete word searched
        public string WordSearched { get; set; }

        /// Class (File) name where the word was found
        public string ClassName { get; set; }
    }
}