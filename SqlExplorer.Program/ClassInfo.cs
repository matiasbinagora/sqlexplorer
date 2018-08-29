using System;

namespace SqlExplorer.Program{

    /// Class information definition
    public class ClassInfo {

        /// Line number where the word was found in the class
        public string LineNumber { get; set; }

        /// Class (File) name where the word was found
        public string ClassName { get; set; }
    }
}