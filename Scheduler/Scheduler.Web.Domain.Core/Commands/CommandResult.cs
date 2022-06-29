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
