﻿namespace Solid.Logger.Appenders.Factories
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Appenders.Factories.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLowerCase = type.ToLower();

            switch (typeAsLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
