using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;


namespace SIMSrq
{
    interface ITimeObservable {
        void AddTimer(IEnumerable<ITimeObserver> timers);
        void UpdateTime(double deltaTime);
    }
    interface ITimeObserver
    {
        void CorrectTime(double deltaTime);
    }
    class Model: ITimeObservable
    {
        private HashSet<ITimeObserver> timers = new HashSet<ITimeObserver>();
        string path = "iamlog.txt";
        string str;
        public bool isRunning;

        Input input;
        FirstPhase firstPhase;
        SecondPhase secondPhase;
        Output output;
        Orbit orbit;

        public double currentTime;
        public double maxCalls;

        int inputCalls;
        public int outputCalls;
        public int outputFirstCalls;
        int losingCalls;
        int queueCalls;
        int orbitCalls;

        public double kvar1;
        public double kvar2;

        double deltaTime;
        double callFromOrbitTime;

        public List<double> times;
        public int eventCount;

        int k;

        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook workBook;
        Excel.Worksheet workSheet;

        public int simulationsCount;

        public Model()
        {
            workBook = excelApp.Workbooks.Add();
        }

        public void AddTimer(IEnumerable<ITimeObserver> times) {
            foreach (ITimeObserver time in times)
            {
                timers.Add(time);
            }
        }

        public void UpdateTime(double deltaTime)
        {
            foreach (ITimeObserver timer in timers)
            {
                timer.CorrectTime(deltaTime);
            }
        }
        
        public void StartSimulation()
        {
            isRunning = true;
            inputCalls++;
            input.GenerateEvent();
            firstPhase.GetCall();
            
            while (outputCalls < maxCalls)
            {
                FindClosestTime();
            }

            EndSimulation();
        }

        public void EndSimulation()
        {
            isRunning = false;
            File.WriteAllText(path, str);
            kvar1 = Calc.coefficientOfVariation(output.callIntervalsFirst.ToArray(), output.callIntervalsFirst.Count);
            kvar2 = Calc.coefficientOfVariation(output.callIntervalsSecond.ToArray(), output.callIntervalsSecond.Count);
            LogToExcel();
        }

        public void ResetModel(double lambda, double mu1, double mu2, int N, double sigma)
        {
            times = new List<double>();

            input = new Input(lambda);
            firstPhase = new FirstPhase(mu1, N);
            secondPhase = new SecondPhase(mu2);
            output = new Output(5);
            orbit = new Orbit(sigma);
            AddTimer(new List<ITimeObserver>() { input, firstPhase, secondPhase, orbit });

            inputCalls = 0;
            outputCalls = 0;
            losingCalls = 0;
            queueCalls = 0;
            orbitCalls = 0;
            outputFirstCalls = 0;
   
            currentTime = 0;
            maxCalls = 0;
        }

        /// <summary>
        /// Переход к ближайшему событию
        /// </summary>
        public void FindClosestTime()
        {
            deltaTime = 10000;
            callFromOrbitTime = orbit.GetClosestTime();

            times.AddRange(new List<double> { input.newCallTime, firstPhase.servingTime, secondPhase.servingTime, callFromOrbitTime });
            times.RemoveAll(c => c == 0);
            deltaTime = times.Min();

            k =-1;
            if (deltaTime == input.newCallTime) k = 0;
            if (deltaTime == firstPhase.servingTime) k = 1;
            if (deltaTime == secondPhase.servingTime) k = 2;
            if (deltaTime == callFromOrbitTime) k = 3;
            
            currentTime += deltaTime;

            UpdateTime(deltaTime);
            switch (k)
            {
                //Приход новой заявки
                case 0:
                    inputCalls++;
                    input.GenerateEvent();
                    firstPhase.GetCall();

                    //LogToTxt(" Новая заявка");
                    break;
                //Конец обслуживания на первой фазе
                case 1:
                    outputFirstCalls++;
                    firstPhase.EndServing();
                    output.FirstServingCall(currentTime);
                    if (secondPhase.isServing)
                        orbit.NewCall();
                    else
                        secondPhase.GetCall();

                    //LogToTxt(" Конец обслуживания на 1 фазе");
                    break;
                //Конец обслуживания на второй фазе
                case 2:                    
                    outputCalls++;
                    secondPhase.EndServing();
                    output.ServingCall(currentTime);
                    //LogToTxt(" Конец обслуживания на 2 фазе");
                    break;
                //Обращение заявки с орбиты
                case 3:
                    orbit.RemoveCall();
                    if (secondPhase.isServing == false)
                        secondPhase.GetCall();
                    else
                        orbit.NewCall();
                    //LogToTxt(" Вызов с орбиты");
                    break;
                default:
                    //LogToTxt(" Неизвестное событие");
                    break;
            }
            times.Clear();
        }

        /// <summary>
        /// Запись всех событий в текстовый файл
        /// </summary>
        /// <param name="_event"></param>
        public void LogToTxt(string _event)
        {
            losingCalls = firstPhase.losingCalls;
            queueCalls = firstPhase.currentQueue;
            orbitCalls = orbit.currentOrbitTime.Count;
            eventCount++;
            str += eventCount.ToString() + _event;
            str += "\nПромежутки времени:";
            str += "\nПриход новой заявки: " + input.newCallTime;
            str += "\nКонец обслуживания на 1: " + firstPhase.servingTime;
            str += "\nКонец обслуживания на 2: " + secondPhase.servingTime;
            str += "\nВремя обращения с орбиты: " + orbit.GetClosestTime();
            str += "\nВходящие: " + inputCalls.ToString() + " Выходящие: " + outputCalls.ToString() + " Потерянные: " + losingCalls.ToString() + " Очередь: " + queueCalls.ToString();
            str += "\nОрбита:";
            foreach (double call in orbit.currentOrbitTime)
            {
                str += "\n" + call.ToString();
            }
            str += "\n\n";

            File.AppendAllText(path, str);
            str = "";
        }

        public void LogToExcel()
        {
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);            
            if(simulationsCount==0)
                workSheet.Cells[1, simulationsCount+1] = "Длины интервалов выходящего потока 1 фазы";

            int i = 1;
            foreach (double deltaTime in output.callIntervalsFirst)
            {
                i++;
                workSheet.Cells[i, simulationsCount + 1] = deltaTime;               
            }           
            if (simulationsCount == 0)
                workSheet.Cells[1, simulationsCount + 31] = "Длины интервалов выходящего потока 2 фазы";
            i = 1;
            foreach (double time in output.callIntervalsSecond)
            {
                i++;
                workSheet.Cells[i, simulationsCount + 31] = time;
            }
            workSheet.Cells[2, simulationsCount + 60] = kvar1;
            workSheet.Cells[2, simulationsCount + 90] = kvar2;
            simulationsCount++;
        }

        public void OpenTab()
        {
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }     
    }
}
