using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using SqlExplorer.Program.Models;
using SqlExplorer.Program.Commands.Models;

namespace SqlExplorer.Program.Commands
{
    /// File Explorer Command class definition
    public class FileExplorerCommand : ICommand
    {
        // Given a file and a pattern it finds all the ocurrences of this word into this file
        public Output Execute(Input input)
        {
            FileExplorerInput fileExplorerInput = input as FileExplorerInput;
            var result = new List<SearchResult>();

            bool isDirectory = (File.GetAttributes(fileExplorerInput.Path) & FileAttributes.Directory) == FileAttributes.Directory;
            var entries = new List<string>();

            if (isDirectory)
                entries = Directory.GetFileSystemEntries(fileExplorerInput.Path, fileExplorerInput.TypeOfFiles, SearchOption.AllDirectories).ToList();
            else
                entries.Add(fileExplorerInput.Path); // just a file

            foreach (var entry in entries)
            {
                result.AddRange(SearchWordInFile(entry, fileExplorerInput.Patterns));
            }

            return new FileExplorerOutput() { Output = result };
        }

        // It extracts the complete word between spaces from a pattern
        public string GetWordInLine(string line, string pattern)
        {
            var lineArray = line.Split(' ');
            for (int i = 0; i < lineArray.Length; i++)
            {
                if (lineArray[i].Contains(pattern))
                    return lineArray[i];
            }
            return string.Empty;
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

        private IList<SearchResult> SearchWordInFile(string file, IList<string> patterns)
        {
            var lineNumber = 0;
            var result = new List<SearchResult>();
            var lines = File.ReadAllLines(file);
            foreach (var pattern in patterns)
            {
                foreach (var line in lines)
                {
                    lineNumber++;
                    if (line.Contains(pattern))
                    {
                        result.Add(new SearchResult()
                        {
                            ClassName = GetClassName(file),
                            LineNumber = lineNumber.ToString(),
                            WordSearched = GetWordInLine(line, pattern)
                        });
                    }
                }
            }
            return result;
        }
    }
}
