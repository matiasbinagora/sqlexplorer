using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlExplorer.Program;
using SqlExplorer.Program.Commands;
using SqlExplorer.Program.Commands.Models;
using SqlExplorer.Program.Models;
using FluentAssertions;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace SqlExplorer.UnitTest
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void GivenProgram_WhenSetupCommands_ThenListOfCommandsExpected()
        {
            //act
            var program = new Job();
            //arrange
            var result = program.SetupCommands();

            // assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
        }

        [TestMethod]
        public void GivenProgram_WhenRunCommands_ThenProperResultExpected()
        {
            //act
            var program = new Job();
            program.commands = program.SetupCommands();
            var path = @"resources";
            var config = @"resources/programconfig.json";
            var expected = new SearchedValuesMerged()
            {

                Output = new List<MergeResult>(){
                 new MergeResult() {
                     Found = new List<ClassInfo>(){
                         new ClassInfo() {
                             ClassName = "anotherinput",
                            LineNumber = "7"
                         }
                     },
                     WordSearched = "SqlExplorer.Program",
                },
                 new MergeResult() {
                     Found = new List<ClassInfo>(){
                         new ClassInfo() {
                             ClassName = "anotherinput",
                            LineNumber = "64"
                         }
                     },
                     WordSearched = "Program;",
                },
                new MergeResult(){
                    Found =  new List<ClassInfo>() {
                         new ClassInfo(){
                             ClassName = "input",
                            LineNumber = "2"
                         }
                     },
                     WordSearched = "SqlExplorer.Program;",
                }
            }
            };
            //arrange
            var result = program.Run(config, path);

            // assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
