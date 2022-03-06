using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    struct Output
    {
        public List<double> callTimes;
        public List<double> callIntervalsFirst;
        public List<double> callIntervalsSecond;
        public List<double> firstPhase;
        double deltaTime;

        public Output(int k)
        {
            callTimes = new List<double>();
            callIntervalsFirst = new List<double>();
            callIntervalsSecond = new List<double>();
            firstPhase = new List<double>();
            deltaTime = 0;
        }

        public void ServingCall(double time)
        {
            if (callTimes.Count > 1)
            {
                deltaTime = time - callTimes[callTimes.Count - 1];
            }
            else
            {
                deltaTime = time;
            }
            callIntervalsSecond.Add(deltaTime);
            callTimes.Add(time);
        }

        public void FirstServingCall(double time)
        {
            if (firstPhase.Count > 0)
            {
                callIntervalsFirst.Add(time - firstPhase[firstPhase.Count - 1]);
            }
            else
            {
                callIntervalsFirst.Add(time);
            }
            firstPhase.Add(time);
        }
    }
}
