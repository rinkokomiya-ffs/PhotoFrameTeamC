using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoFrameApp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 集約例外ハンドラ
            // ThreadExceptionイベント・ハンドラを登録する
            Application.ThreadException += new
              ThreadExceptionEventHandler(Application_ThreadException);

            // UnhandledExceptionイベント・ハンドラを登録する
            Thread.GetDomain().UnhandledException += new
              UnhandledExceptionEventHandler(Application_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PhotoFrameForm());
        }

        private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;

                //エラー処理
                MessageBox.Show(
                    "エラーが発生しました。アプリを終了します。\n開発元にお知らせください。\n\n" +
                    "【エラー内容】\n" + ex.Message + "\n\n" +
                    "【スタックトレース】\n" + ex.StackTrace, "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                Application.Exit();
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;

                //エラー処理
                MessageBox.Show(
                    "エラーが発生しました。アプリを終了します。\n開発元にお知らせください。\n\n" +
                    "【エラー内容】\n" + ex.Message + "\n\n" +
                    "【スタックトレース】\n" + ex.StackTrace, "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
