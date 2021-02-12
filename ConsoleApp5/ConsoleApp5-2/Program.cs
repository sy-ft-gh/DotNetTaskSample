using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5_2 {
    class Program {
        static void Main(string[] args) {
            // Taskを生成しています。Task.RunメソッドはTaskを生成するFactoryクラスで、
            // 戻り値はTask型のオブジェクトです。
            // ※生成と同時に実行(Run)します。
            // 引数には、delegateを渡します。単純にHeavyMethod1を実行したい場合は、
            // 引数なしのdelegateを渡します。
            Task task = Task.Run(() => {
                HeavyMethod1();
            });

            HeavyMethod2();

            Console.WriteLine("メインメソッドの終了");
            Console.ReadLine();
        }
        static void HeavyMethod1() {
            Console.WriteLine("HeavyMethod-1-Start");
            Thread.Sleep(5000);
            Console.WriteLine("HeavyMethod-1-End");
        }

        static void HeavyMethod2() {
            Console.WriteLine("HeavyMethod-2-Start");
            Thread.Sleep(3000);
            Console.WriteLine("HeavyMethod-2-End");
        }
    }
}
