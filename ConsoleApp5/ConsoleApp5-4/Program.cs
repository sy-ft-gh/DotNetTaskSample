using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5_4 {
    class Program {
        static void Main(string[] args) {
            // Thread.CurrentThread.ManagedThreadId＝現在のスレッドID
            Console.WriteLine($"Main-Start【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            // 結果を受け取る場合は、TaskをGeneric型として定義して
            // そのGenericに戻り値のクラスを指定します。
            Task<string> task = Task.Run(() => {
                // このラムダ式自体が別スレッドになる
                Console.WriteLine($"HeavyMethod-call【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
                return HeavyMethod();
            });

            // 結果を受け取ります。Resultのプロパティを使用すると、Taskで指定したHeavyMethodが
            // 終了するまで待機して、結果をresult変数に入れてくれます。
            string result = task.Result;

            Console.WriteLine(result);

            Console.WriteLine("メインメソッドの終了");
            Console.ReadLine();
        }
        static string HeavyMethod() {
            Console.WriteLine($"HeavyMethod-Start【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            Thread.Sleep(5000);
            Console.WriteLine($"HeavyMethod-End【{Thread.CurrentThread.ManagedThreadId.ToString()}】");

            return "hoge";
        }
    }
}
