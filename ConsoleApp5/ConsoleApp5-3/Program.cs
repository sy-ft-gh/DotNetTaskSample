using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5_3 {
    class Program {
        static void Main(string[] args) {
            // メインスレッドからアクセスできる変数を定義します。これに結果を格納します。
            string result = "";

            Thread thread = new Thread(new ThreadStart(() =>
            {
                // メインスレッドとは異なるスレットでHeavyMethodを実行して、
                // 結果(hoge)をresultに格納します。
                result = HeavyMethod();
            }));

            // スレッドを開始します。
            thread.Start();

            // Joinメソッドを使うとスレッドが終了するまで、これより先のコードに
            // 進まないようになります。
            thread.Join();

            // 結果をコンソールに表示します。
            Console.WriteLine(result);

            Console.WriteLine("メインメソッドの終了");
            Console.ReadLine();
        }
        static string HeavyMethod() {
            Console.WriteLine("HeavyMethod-Start");
            Thread.Sleep(5000);
            Console.WriteLine("HeavyMethod-End");

            return "hoge";
        }
    }
}
