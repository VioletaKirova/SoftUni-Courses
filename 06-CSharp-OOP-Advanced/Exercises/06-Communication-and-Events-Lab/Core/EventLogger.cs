namespace Heroes.Core
{
    using System;

    using Enums;

    public class EventLogger : Logger
    {
        public override void Handle(LogType type, string message)
        {
            switch (type)
            {
                case LogType.EVENT:
                    Console.WriteLine(type.ToString() + ": " + message);
                    break;
            }
      
            this.PassToSuccessor(type, message);
        }
    }
}
