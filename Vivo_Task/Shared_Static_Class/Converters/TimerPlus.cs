using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Converters
{
    public class TimerPlus : System.Timers.Timer
    {
        private DateTime m_dueTime;

        public TimerPlus() : base() => this.Elapsed += this.ElapsedAction;
        protected new void Dispose()
        {
            this.Elapsed -= this.ElapsedAction;
            base.Dispose();
        }
        public TimeSpan TimeLeft => (this.m_dueTime - DateTime.Now);
        public new void Start()
        {
            this.m_dueTime = DateTime.Now.AddMilliseconds(this.Interval);
            base.Start();
        }

        private void ElapsedAction(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.AutoReset)
                this.m_dueTime = DateTime.Now.AddMilliseconds(this.Interval);
        }
    }
}
