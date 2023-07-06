using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steve.Core
{
    public class TimeLog : Log
    {
        private Stopwatch _stopwatch;

        internal TimeLog(string name, Action<LogMessage> submit) : base(name, submit)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public override void Submit()
        {
            _stopwatch.Stop();
            _message.Duration = _stopwatch.Elapsed.TotalSeconds;
            base.Submit();
        }
    }
}
