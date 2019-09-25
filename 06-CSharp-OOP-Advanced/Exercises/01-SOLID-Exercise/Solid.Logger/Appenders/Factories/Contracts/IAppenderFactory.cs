using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Appenders.Factories.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
