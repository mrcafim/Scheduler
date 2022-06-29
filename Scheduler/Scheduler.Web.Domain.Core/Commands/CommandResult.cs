using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
