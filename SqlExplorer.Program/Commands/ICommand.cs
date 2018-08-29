using System;
using SqlExplorer.Program.Commands.Models;

namespace SqlExplorer.Program.Commands
{
    // Command interface definition
    public interface ICommand
    {
        CommandDto Execute(CommandDto input);
    }
}