using System;
using System.Threading;

namespace ConsoleApp5 {
    /*
      〇同期処理とは？
        同期処理が結果が返ってくるまで待つ処理のこと。
        とあるメソッド funcA() を実行し終了、または結果が返ってくるまで待つこと。
        例えば
            Console.WriteLine("テキスト出力");
        このコードを実行した時でも
            メソッドの呼び出し
                →コンソールへの文字の出力
            →メソッドが終わって呼び出し元へ復帰
        と、処理が終わるまで呼び出し元は待つことになる。
      〇非同期処理とは？
        非同期処理は結果が返ってくるのを待たずに並行して次の処理を行う事。
        例えば非同期に以下の二つを実行した場合
            Task task1 = Task.Run(() => {
                HeavyMethod1();
            });
            Task task2 = Task.Run(() => {
                HeavyMethod2();
            });
        task1の処理の実体であるHeavyMethod1()が終了するのを待たずに
        task2の処理の実態であるHeavyMethod2()を実行してしまう。
        非同期処理は並行して実行されるが、論理的な並行なので１つのCPUコアで
        演算する場合はHeavyMethod1()とHeavyMethod2()の実行命令が細切れになって
        順次実行するため
                HeavyMethod1()              HeavyMethod2()
                      ↓
                      ↓
                                                  ↓
                                                  ↓
                      ↓
                      ↓
                                                  ↓
                                                  ↓
        このように入れ子になって実行される。
        この実行方法だと、例えばHeavyMethod1()がディスクやネットワークI/Oで待つ間
        CPUは動かないのでHeavyMethod2()が空いているCPUを使って演算する事ができる。
     */
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
