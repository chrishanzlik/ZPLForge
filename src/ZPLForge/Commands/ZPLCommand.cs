using System;

namespace ZPLForge.Commands
{
    /// <summary>
    /// Represents a single ZPL command
    /// </summary>
    public sealed partial class ZPLCommand
    {
        private ZPLCommand(string cmd, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(cmd))
                throw new ArgumentException("The command cannot be null or empty.");

            CommandValue = cmd;
            CommandParameters = string.Join(",", parameters);
        }

        public string CommandValue { get; }
        public string CommandParameters { get; }

        public override string ToString() => CommandValue + CommandParameters;

        public static implicit operator string(ZPLCommand command) => command.ToString();
    }
}
