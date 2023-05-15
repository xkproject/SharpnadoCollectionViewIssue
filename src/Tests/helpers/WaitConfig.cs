using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.helpers
{
    public class WaitConfig
    {
        public static WaitConfig Default = new WaitConfig(60, 0.5);

        public double Timeout { get; private set; } = 60;
        public double PollingInterval { get; private set; } = 0.5;

        public WaitConfig(double timeout, double pollingInterval)
        {
            Timeout = timeout;
            PollingInterval = pollingInterval;
        }
    }
}
