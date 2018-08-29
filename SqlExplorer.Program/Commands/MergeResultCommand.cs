using System;
using System.Collections.Generic;
using System.Linq;
using SqlExplorer.Program.Models;

namespace SqlExplorer.Program.Commands
{
    /// Merge Result Command class definition
    public class MergeResultCommand
    {
        // Given a file and a pattern it finds all the ocurrences of this word into this file
        public IList<MergeResult> Execute(IList<SearchResult> input)
        {
            var items = new Dictionary<string, IList<SearchResult>>();
            var result = new List<MergeResult>();
            foreach (var item in input)
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
            return result;
        }

        private IList<ClassInfo> GetClassFound(IList<SearchResult> input)
        {
            var result = new List<ClassInfo>();

            foreach (var item in input)
            {
                result.Add(new ClassInfo()
                {
                    LineNumber = item.LineNumber,
                    ClassName = item.ClassName
                });
            }

            return result;
        }
    }
}
