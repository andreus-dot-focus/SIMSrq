using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    class Input: ITimeObserver
    {
        public double lambda;
        public double newCallTime;
        public void GenerateEvent() 
        {            
            newCallTime = Calc.ExpDist(lambda);
        }
        public void CorrectTime(double deltaTime)
        {
            if(newCallTime!=0)
                newCallTime -= deltaTime;
        }
    }
}
