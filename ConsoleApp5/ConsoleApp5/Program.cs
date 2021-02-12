using System;
using System.Threading;

namespace ConsoleApp5 {
    class Program {
        static void Main(string[] args) {
            // threadの変数でスレッドを作成
            Thread thread = new Thread(new ThreadStart(() => {
                // 処理はHeavyMethod1()を実行
                HeavyMethod1();
            }));
            // threadの処理を実行
            thread.Start();
            // HeavyMethod2()を実行
            HeavyMethod2();

            Console.WriteLine("メインメソッドの終了");
            Console.ReadLine();
        }
        static void HeavyMethod1() {
            Console.WriteLine("すごく重い処理その1(´・ω・｀)はじまり");
            Thread.Sleep(5000);
            Console.WriteLine("すごく重い処理その1(´・ω・｀)おわり");
        }

        static void HeavyMethod2() {
            Console.WriteLine("すごく重い処理その2(´・ω・｀)はじまり");
            Thread.Sleep(3000);
            Console.WriteLine("すごく重い処理その2(´・ω・｀)おわり");
        }
    }
}
