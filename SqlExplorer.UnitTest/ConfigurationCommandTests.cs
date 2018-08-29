using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlExplorer.Program.Commands;
using SqlExplorer.Program.Commands.Models;
using SqlExplorer.Program.Models;
using FluentAssertions;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SqlExplorer.UnitTest
{
    /// Test suite for Configuration Command class
    [TestClass]
    public class ConfigurationCommandTests
    {
        private ConfigurationCommand configuration;

        /// Test initialization method
        [TestInitialize()]
        public void Setup()
        {
            configuration = new ConfigurationCommand();
        }

        // Test cleanup method
        [TestCleanup()]
        public void TearDown()
        {

        }

        [TestMethod]
        public void GivenFileInput_WhenConfiguration_ThenObjectExpected()
        {
            // arrange
            var file = @"resources/config.json";
            var expected =  new ValuesForSearch()
            {
                FileType = "*.txt",
                Patterns = new List<string>() {"1", "2"},
                Path = "some/path/here"
            };
            // act
            var result = configuration.Execute(new ConfigurationInput() {
                ConfigFilePath = file,
                PathForSearch = "some/path/here"
            });

            // arrange
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
