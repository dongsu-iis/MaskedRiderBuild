using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitTank
{
    /// <summary>
    /// バックグラウンド処理の進行状況を表示するフォーム
    /// </summary>
    public partial class ProgressDialog : Form
    {
        /// <summary>
        /// ProgressDialogクラスのコンストラクタ
        /// </summary>
        /// <param name="caption">タイトルバーに表示するテキスト</param>
        /// <param name="doWorkHandler">バックグラウンドで実行するメソッド</param>
        /// <param name="argument">doWorkで取得できるパラメータ</param>
        public ProgressDialog(string caption,
            DoWorkEventHandler doWork,
            object argument)
        {
            InitializeComponent();

            //初期設定
            workerArgument = argument;
            Text = caption;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ControlBox = false;
            CancelButton = btnCancel;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            btnCancel.Enabled = true;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            //イベント
            Shown += new EventHandler(ProgressDialog_Shown);
            btnCancel.Click += new EventHandler(bntCancel_Click);
            backgroundWorker1.DoWork += doWork;
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        /// <summary>
        /// ProgressDialogクラスのコンストラクタ
        /// </summary>
        public ProgressDialog(string formTitle,
            DoWorkEventHandler doWorkHandler)
            : this(formTitle, doWorkHandler, null)
        {
        }

        private object workerArgument = null;

        private object _result = null;
        /// <summary>
        /// DoWorkイベントハンドラで設定された結果
        /// </summary>
        public object Result
        {
            get
            {
                return _result;
            }
        }

        private Exception _error = null;
        /// <summary>
        /// バックグラウンド処理中に発生したエラー
        /// </summary>
        public Exception Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// 進行状況ダイアログで使用しているBackgroundWorkerクラス
        /// </summary>
        public BackgroundWorker BackgroundWorker
        {
            get
            {
                return backgroundWorker1;
            }
        }

        //フォームが表示されたときにバックグラウンド処理を開始
        private void ProgressDialog_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(workerArgument);
        }


        //キャンセルボタンが押されたとき
        private void bntCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            backgroundWorker1.CancelAsync();
        }



        //ReportProgressメソッドが呼び出されたとき
        private void backgroundWorker1_ProgressChanged(
            object sender, ProgressChangedEventArgs e)
        {
            //プログレスバーの値を変更する
            if (e.ProgressPercentage < progressBar1.Minimum)
            {
                progressBar1.Value = progressBar1.Minimum;
            }
            else if (progressBar1.Maximum < e.ProgressPercentage)
            {
                progressBar1.Value = progressBar1.Maximum;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
            //メッセージのテキストを変更する
            messageLabel.Text = (string)e.UserState;
        }

        //バックグラウンド処理が終了したとき
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this,
                    "エラー",
                    "エラーが発生しました。\n\n" + e.Error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _error = e.Error;
                DialogResult = DialogResult.Abort;
            }
            else if (e.Cancelled)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                _result = e.Result;
                DialogResult = DialogResult.OK;
            }

            Close();
        }
    }
}
