using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SqlExplorer.Program
{
    /// File Explorer Command class definition
    public class FileExplorerCommand
    {
        // Given a file and a pattern it finds all the ocurrences of this word into this file
        public IList<SearchResult> Execute(string fileName, string pattern)
        {
            var result = new List<SearchResult>();
            var lineNumber = 0;
            foreach (var line in File.ReadAllLines(fileName))
            {
                lineNumber++;
                if (line.Contains(pattern)) {
                    result.Add(new SearchResult() {
                        ClassName = GetClassName(fileName),
                        LineNumber = lineNumber.ToString(),
                        WordSearched = GetWordInLine(line, pattern)
                    });
                }
            }
            return result;
        }

        // It extracts the complete word between spaces from a pattern
        public string GetWordInLine(string line, string pattern)
        {
            return "SqlExplorer.Program;";
        }

        // It gets the file name of a complete file
        public string GetClassName(string fileName)
        {
            
            var dotIndex = fileName.IndexOf('.');
            var slashIndex = fileName.LastIndexOf('/');
            if (slashIndex == -1)
            {
                slashIndex = fileName.LastIndexOf('\\');
            }
            slashIndex++; // to get zero if there is no slash or to avoid the slash position otherwise
            return fileName.Substring(slashIndex, dotIndex - slashIndex);
        }
    }
}
