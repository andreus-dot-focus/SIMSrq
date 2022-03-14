using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq
{
    class FirstPhase: ITimeObserver
    {
        public double mu1;
        public bool isServing;

        public double servingTime;

        public int currentQueue;
        public int queueLength;

        public int losingCalls;
        public int inputCalls;
        Random rnd;
        
        public FirstPhase(double mu1, int N)
        {
            isServing = false;
            this.mu1 = mu1;
            servingTime = 0;
            currentQueue = 0;
            losingCalls = 0;
            inputCalls = 0;
            rnd = new Random();

            queueLength = N;
        }

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
