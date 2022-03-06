using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SIMSrq
{

    struct Orbit:ITimeObserver
    {
        public List<double> currentOrbitTime;
        public double sigma;
        public Orbit(double sigma)
        {
            currentOrbitTime = new List<double>();
            this.sigma = sigma;
        }
        public void NewCall()
        {
            currentOrbitTime.Add(Calc.ExpDist(sigma));
        }
        public void RemoveCall()
        {
            //Так как убираем элемент после корректировки, то нужное время заявки = 0
            currentOrbitTime.Remove(0);
        }
        public double GetClosestTime()
        {
            if (currentOrbitTime?.Count != 0)
                return currentOrbitTime.Min();
            else
                return 0;
        }
        public void CorrectTime(double deltaTime)
        {
            if (currentOrbitTime.Count != 0)
            {
                for (int i = 0; i < currentOrbitTime.Count; i++)
                {
                    currentOrbitTime[i] -= deltaTime;
                }
            }
        }
    }
}
