using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    class Input: ITimeObserver
    {
        public double lambda;
        public double newCallTime;

        public Input(double lambda)
        {
            this.lambda = lambda;
            newCallTime = 0;
        }
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
