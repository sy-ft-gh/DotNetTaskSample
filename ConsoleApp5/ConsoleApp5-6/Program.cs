using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5_6 {
    class Program {
        // 非同期メソッドとして
        // static async Task Main(string[] args) {
        // と、宣言できるがメソッド内でawaitが無いと同期メソッドとして
        // 扱われ、警告が出るので不要にasyncにしない
        static void Main(string[] args) {

            // HeavyMethod1()の実行とtaskへの格納
            // ※このステップが実行されると通常のメソッド同様に実行される。
            // ※Thread.CurrentThread.ManagedThreadId＝現在のスレッドID
            Console.WriteLine($"HeavyMethod1-call-start【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            Task<string> task = HeavyMethod1();
            Console.WriteLine($"HeavyMethod1-call-end【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            // taskの終了を待たずにHeavyMethod2()を実行
            // HeavyMethod2()は同期処理のためmain()の処理は終わるまでまつ
            Console.WriteLine($"HeavyMethod2-call-start【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            HeavyMethod2();
            Console.WriteLine($"HeavyMethod2-call-end【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            // HeavyMethod2()が終了すると次のConsole.WriteLineを実行する
            // ※このステップの実行時にtaskが完了していないとResultプロパティは
            //   未定のためtaskの中身が終わるまで待つ。
            Console.WriteLine(task.Result);

            Console.ReadLine();

        }
        // 非同期処理メソッドの宣言 async をメソッドの前に付ける
        static async Task<string> HeavyMethod1() {
            Console.WriteLine($"※※※※※※HeavyMethod-1-start【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            // asyncメソッドにはawaitが必要
            // await=待ち 待つ処理にawaitを付加し実行する
            // awaitで実行されると、以降の処理が別スレッドになる
            await Task.Delay(5000);
            Console.WriteLine($"※※※※※※HeavyMethod-1-end【{ Thread.CurrentThread.ManagedThreadId.ToString()}】");
            return "hoge";
        }

        static void HeavyMethod2() {
            Console.WriteLine($"★★★★★★HeavyMethod-2-start【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
            Thread.Sleep(3000);
            Console.WriteLine($"★★★★★★HeavyMethod-2-end【{Thread.CurrentThread.ManagedThreadId.ToString()}】");
        }
    }
}
