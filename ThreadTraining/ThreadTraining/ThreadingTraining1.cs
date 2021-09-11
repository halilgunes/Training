using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ThreadTraining {
    public class ThreadingTraining1 {
        /// <summary>
        /// temp değişkene almazsak eğer i'yi sıralı olarak yazmaz.
        /// </summary>
        public void WriteEachTenNumber() {
            for (int i = 0; i < 10; i++) {
                int temp = i;
                new Thread(() => Console.WriteLine(temp)).Start();
            }
        }

        public void WriteEachOneHundred() {
            try {
                for (int i = 0; i < 100; i++) {
                    int temp = i;
                    Console.WriteLine(temp);
                }
            }
            catch (Exception ex) {
                //log atılabilir.
            }
        }

        public void SignalTest() {
            var signal = new ManualResetEvent(false);
            new Thread(()=> {
                Console.WriteLine("Waiting for signal");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal");
            }).Start();
            Thread.Sleep(2000);
            signal.Set();//Main thread set fonksiyonunu çağırınca çalışan diğer thread sinyali alarak bloklanmayı bitirir, çalışmaya devam eder.
        }
    }
}
