using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTraining {
    /// <summary>
    /// async ve await için örnekleri içeriyor.
    /// </summary>
    public class AsyncTraining {
        /// <summary>
        /// void yerine Task döndürülüyor.
        /// </summary>
        /// <returns></returns>
        public async Task PrintAnswer() {
            await Task.Delay(1000);// Task tipinde dönüş için basitçe ; await Task.Delay(1000); yazıyoruzç
            int answer = 21 * 2;
            Console.WriteLine(answer);
        }

        public async Task Go() {
            await PrintAnswer();
            Console.WriteLine("Done");
        }

        /// <summary>
        /// void tipinde dönüş yazmazsak başka yerde çağıramıyoruz.
        /// </summary>
        public async void FinalCountDown() {//void tipinde dönmezsek metodu classın bir instance'ından çağıramıyoruz.
            await Go();
        }
    }
}
