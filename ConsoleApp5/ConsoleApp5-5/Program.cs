using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5_5 {
    class Program {
        static void Main(string[] args) {
            // 1の整数を返すHeavyMethod1のTaskを生成します。
            Task<int> task1 = Task.Run(() => {
                return HeavyMethod1();
            });

            // 2の整数を返すHeavyMethod2のTaskを生成します。
            Task<int> task2 = Task.Run(() => {
                return HeavyMethod2();
            });

            // WhenAllの引数に、先程生成したTaskを入れると、HeavyMethod1、HeavyMethod2が終了するまで
            // 次のコードに進みません。つまり待機します。
            Task.WhenAll(task1, task2);

            Console.WriteLine(task1.Result + task2.Result);

            Console.WriteLine("メインメソッドの終了");
            Console.ReadLine();
        }
        static int HeavyMethod1() {
            Console.WriteLine("HeavyMethod-1-Start");
            Thread.Sleep(5000);
            Console.WriteLine("HeavyMethod-1-End");

            return 1;
        }

        static int HeavyMethod2() {
            Console.WriteLine("HeavyMethod-2-Start");
            Thread.Sleep(3000);
            Console.WriteLine("HeavyMethod-2-End");

            return 2;
        }
    }
}
