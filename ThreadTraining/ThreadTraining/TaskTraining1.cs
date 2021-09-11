using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTraining {
/// <summary>
/// Aşağıdakilere ait örnekler var bu classta;
/// 
/// 1. Task
/// 2. Task<int>
/// 3. TaskCompleteSource
/// 4. async ve await
/// 5. ContinueWith 
/// 
/// </summary>
    public class TaskTraining1 {

        /// <summary>
        /// Doğduğum günden beri doğum günlerim hangi günlere geliyorsa yazdırıyoruz.
        /// </summary>
        /// <returns></returns>
        public Task GetBirthDayOfYears(int birthYear) {
          var task =  Task.Run(() => {
                for (int i = birthYear; i < DateTime.Now.Year; i++) {
                    Console.WriteLine(i.ToString() + " senesi" + new DateTime(i, 7, 1).DayOfWeek.ToString());
                }
            });
            task.Wait();
            return task;
        }

        /// <summary>
        /// Pazar günlerine gelen doğum günlerimin sayısı
        /// </summary>
        /// <returns></returns>
        public Task<int> GetSundayCountOfMyBirthDays(int birthYear) {
            Task<int> task = Task.Run(() => {
                int result = 0;
                for (int i = birthYear; i < DateTime.Now.Year; i++) {
                    result += new DateTime(i, 7, 1).DayOfWeek == DayOfWeek.Sunday ? 1 : 0;
                }
                return result;
            });
            task.Wait();
            return task;
        }

        /// <summary>
        /// Yaşadığım günlerin sayısı
        /// </summary>
        /// <returns></returns>
        public Task<int> GetCountDayOfYears(int birthYear) {
            TaskCompletionSource<int> completionSource = new TaskCompletionSource<int>();
            try {
                int totalDay = 0;
                for (int i = birthYear; i < DateTime.Now.Year; i++) {
                    totalDay += Convert.ToInt32((new DateTime(i, 12, 31) - new DateTime(i, 1, 1)).TotalDays);
                }
                completionSource.SetResult(totalDay);
            }
            catch (Exception ex) {
                completionSource.SetException(ex);
            }
           return completionSource.Task;
        }

        public async void WriteBirthDayMatchSunday(int birthDay) {
            int result = await GetSundayCountOfMyBirthDays(birthDay);
            Console.WriteLine(result);

        }




    }
}
