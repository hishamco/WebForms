using System;

namespace My.AspNetCore.WebForms.Controls
{
    public class CommandEventArgs : EventArgs
    {
        public CommandEventArgs(string commandName, string commandArgument)
        {
            CommandName = commandName;
            CommandArgument = commandArgument;
        }

        public string CommandName { get; }

        public string CommandArgument { get;}
    }
}
