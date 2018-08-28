using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlExplorer.Program;
using FluentAssertions;
using System.Linq;

namespace SqlExplorer.UnitTest
{
    /// Test suite for File Explorer Command class
    [TestClass]
    public class FileExplorerCommandTests
    {
        [TestMethod]
        public void GivenSingleFile_WhenSearch_ThenLinesExpected()
        {
                // arrange
            var fileExplorer = new FileExplorerCommand();
            var file = @"resources/input.txt";
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
        public void GivenFileName_WhenClassNameWanted_ThenNameExpected()
        {
            // arrange 
            var fileExplorer = new FileExplorerCommand();
            var file =  @"resources/input.txt";

            // act
            var result = fileExplorer.GetClassName(file);

            // arrange
            result.Should().Be("input");
        }
    }
}
