using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlExplorer.Program.Commands;
using SqlExplorer.Program.Models;
using FluentAssertions;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SqlExplorer.UnitTest
{
    /// Test suite for Merge Result Command class
    [TestClass]
    public class MergeResultCommandTests
    {
        private MergeResultCommand mergeResult;

        /// Test initialization method
        [TestInitialize()]
        public void Setup()
        {
            mergeResult = new MergeResultCommand();
        }

        // Test cleanup method
        [TestCleanup()]
        public void TearDown()
        {

        }

        [TestMethod]
        public void GivenSearchResultInput_WhenMerge_ThenProperResultExpected()
        {
            // arrange
            var input = new List<SearchResult>(){
                new SearchResult(){
                    ClassName = "input",
                    LineNumber = "2",
                    WordSearched = "SqlExplorer.Program;"
                },
                new SearchResult(){
                    ClassName = "anotherinput",
                    LineNumber = "7",
                    WordSearched = "SqlExplorer.Program"
                },
                new SearchResult(){
                    ClassName = "anotherinput",
                    LineNumber = "64",
                    WordSearched = "SqlExplorer.Program;"
                }
            };
            var expected = new List<MergeResult>(){
                 new MergeResult() {
                     WordSearched = "SqlExplorer.Program;",
                     Found = new List<ClassInfo>(){
                         new ClassInfo() {
                             ClassName = "anotherinput",
                            LineNumber = "64"
                         },
                          new ClassInfo() {
                             ClassName = "input",
                            LineNumber = "2"
                         }
                     }
                },
                new MergeResult() {
                     WordSearched = "SqlExplorer.Program",
                     Found = new List<ClassInfo>(){
                         new ClassInfo() {
                             ClassName = "anotherinput",
                            LineNumber = "7"
                         }
                     }
                }
            };

            // act
            var result = mergeResult.Execute(input);

            // arrange
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
