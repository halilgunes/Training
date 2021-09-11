using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTraining {
    class Program {
        static object locker = new object();
        static void Main(string[] args) {
            //1
            Thread th = new Thread(() => Print("Demet"));
            th.Start();
           
            TaskTraining1 t = new TaskTraining1();
            t.GetBirthDayOfYears(1979);
            Task<int> task = t.GetSundayCountOfMyBirthDays(1979);
            Console.WriteLine("Pazar gününe denk gelen doğum günlerim : " + task.Result);

            var awaiter = t.GetCountDayOfYears(1979).GetAwaiter();
            awaiter.OnCompleted(() => {
               Console.WriteLine("Toplam gün sayısı :" + awaiter.GetResult());
            });

            ///Bununla GetAwaiter() ve OnCompleted'lı yapı aynı işi yapıyor.
            t.GetCountDayOfYears(1979).ContinueWith(n => {
                int result = n.Result;
                Console.WriteLine("Toplam gün sayısı :" + result);

            });

            t.WriteBirthDayMatchSunday(1979);
            th.Join();

            ThreadingTraining1 tt1 = new ThreadingTraining1();
            tt1.WriteEachTenNumber();

            Thread t1 = new Thread(tt1.WriteEachOneHundred);
            t1.Start();
            t1.Join();

            tt1.SignalTest();


            AsyncTraining at1 = new AsyncTraining();
            at1.FinalCountDown();

            Console.WriteLine("Thread ended");
            Console.ReadLine();
        }

        public static void Print(object omessage) {
            lock (locker) {
                string message = (string)omessage;
                for (int i = 0; i < 1000; i++) {
                    Console.WriteLine("Hello " + message);
                }
            }
        }
     
    }
}
