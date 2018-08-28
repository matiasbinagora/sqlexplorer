using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlExplorer.Program;
using FluentAssertions;
using System.Linq;
using System;

namespace SqlExplorer.UnitTest
{
    /// Test suite for File Explorer Command class
    [TestClass]
    public class FileExplorerCommandTests
    {
        private string file;
        private FileExplorerCommand fileExplorer;

        /// Test initialization method
        [TestInitialize()]
        public void Setup()
        {
            file =  @"resources/input.txt";
            fileExplorer = new FileExplorerCommand();
        }

        // Test cleanup method
        [TestCleanup()]
        public void TearDown()
        {
            file = String.Empty;
            fileExplorer = null;
        }

        [TestMethod]
        public void GivenSingleFile_WhenSearch_ThenLinesExpected()
        {
            // arrange
            var pattern = "Program";

                // act
            var result = fileExplorer.Execute(file, pattern);

            // arrange
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            var item = result.First();
            item.ClassName.Should().Be("input");
            item.LineNumber.Should().Be("2");
            item.WordSearched.Should().Be("SqlExplorer.Program;");
        }

        [TestMethod]
        public void GivenFileName_WhenClassNameWantedWithLeftSlash_ThenNameExpected()
        {           
            // act
            var result = fileExplorer.GetClassName(file);

            // arrange
            result.Should().Be("input");
        }

        [TestMethod]
        public void GivenFileName_WhenClassNameWantedWithRightSlash_ThenNameExpected()
        {
            // act
            file = @"resources\input.txt";
            var result = fileExplorer.GetClassName(file);

            // arrange
            result.Should().Be("input");
        }

        [TestMethod]
        public void GivenFileName_WhenClassNameWantedWithouttSlash_ThenNameExpected()
        {
            // arrange 
            file =  @"input.txt";

            // act
            var result = fileExplorer.GetClassName(file);

            // arrange
            result.Should().Be("input");
        }

        [TestMethod]
        public void GivenPattern_WhenWordRequiredAndContains_ThenCompleteWordExpected()
        {
            // arrange 
            var pattern = "Program";
            var line = "using SqlExplorer.Program;";

            // act
            var result = fileExplorer.GetWordInLine(line, pattern);

            // arrange
            result.Should().Be("SqlExplorer.Program;");
        }

        [TestMethod]
        public void GivenPattern_WhenWordRequiredAndItIsNotPresent_ThenEmptyExpected()
        {
            // arrange 
            var pattern = "something";
            var line = "using SqlExplorer.Program;";

            // act
            var result = fileExplorer.GetWordInLine(line, pattern);

            // arrange
            result.Should().BeEmpty();
        }
    }
}
