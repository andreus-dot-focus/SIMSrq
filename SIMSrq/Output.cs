using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    class Output
    {
        public List<double> callTimes = new List<double>();
        public List<double> callIntervalsFirst = new List<double>();
        public List<double> callIntervalsSecond = new List<double>();
        public List<double> firstPhase = new List<double>();
        double deltaTime = 0;

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
