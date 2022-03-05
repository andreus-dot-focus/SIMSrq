using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    class FirstPhase: ITimeObserver
    {
        public double mu1;
        public bool isServing = false;

        public double servingTime = 0;

        public int currentQueue = 0;
        public int queueLength;

        public int losingCalls = 0;
        public int inputCalls = 0;
        Random rnd = new Random();
        
        public void GetCall()
        {
            if ((currentQueue < queueLength) && (isServing == true))
            {
                currentQueue++;
            }
            else if ((currentQueue == 0) && (isServing == false))
            {
                NewServing();
            }           
            else if((currentQueue==queueLength) && (isServing == true))
            {
                losingCalls++;
            }
        }
        public void NewServing()
        {
            isServing = true;
            servingTime = Calc.ExpDist(mu1);
        }
        public void EndServing()
        {
            isServing = false;
            servingTime = 0;
            if(currentQueue > 0)
            {
                currentQueue--;
                NewServing();
            }            
        }        
        public void CorrectTime(double deltaTime)
        {
            if(servingTime!=0)
                servingTime -= deltaTime;
        }
    }
}
