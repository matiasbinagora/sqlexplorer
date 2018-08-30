using System;
using System.Collections.Generic;
using System.Linq;
using SqlExplorer.Program.Models;
using SqlExplorer.Program.Commands.Models;

namespace SqlExplorer.Program.Commands
{
    /// Merge Result Command class definition
    public class MergeResultCommand : ICommand
    {
        // Merges results from search into a single list of one key object
        public CommandDto Execute(CommandDto mergeInput)
        {
            var items = new Dictionary<string, IList<SearchResult>>();
            var result = new List<MergeResult>();
            foreach (var item in (mergeInput as SearchedValues).Output)
            {
                if (!items.ContainsKey(item.WordSearched))
                    items.Add(item.WordSearched, new List<SearchResult>());

                items[item.WordSearched].Add(item);
            }

            foreach (var item in items)
            {
                result.Add(new MergeResult()
                {
                    WordSearched = item.Key,
                    Found = GetClassFound(item.Value)
                }
                );
            }
            return new SearchedValuesMerged() {  Output = result };
        }

        private IList<ClassInfo> GetClassFound(IList<SearchResult> input)
        {
            var result = new List<ClassInfo>();

            foreach (var item in input)
            {
                result.Add(new ClassInfo()
                {
                    LineNumber = item.LineNumber,
                    ClassName = item.ClassName,
                    FilePath = item.FilePath
                });
            }

            return result;
        }
    }
}
