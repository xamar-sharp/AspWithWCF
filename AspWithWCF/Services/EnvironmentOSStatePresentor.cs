using System.Text;

namespace AspWithWCF.Services
{
    public class EnvironmentOSStatePresentor:IOSStatePresentor
    {
        public string GetState(bool includeDetails)
        {
            StringBuilder log = new(256);
            log.AppendLine(Environment.MachineName);
            log.AppendLine(Environment.UserName);
            log.AppendLine(Environment.CurrentDirectory);
            log.AppendLine(Environment.ProcessorCount.ToString());
            log.AppendLine(Environment.ProcessPath);
            log.AppendLine(Environment.ExitCode.ToString());
            log.AppendLine(Environment.CurrentManagedThreadId.ToString());
            log.AppendLine(Environment.StackTrace);
            log.AppendLine(Environment.UserDomainName);
            return log.ToString();
        }
    }
}
