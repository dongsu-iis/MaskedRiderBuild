using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;

namespace RabbitTank
{
    public partial class RabbitTank : Form
    {

        #region --------- 変数一覧 ---------
        //ビルド対象フォルダ
        private string targetPath;
        //.NET Frameworkバージョン
        private string netFrameVersion;
        //出力先フォルダ
        private string outPath;
        //参照先フォルダ
        private string logPath;
        //プログラム言語
        private string programlanguage;
        //ビット数
        private string bit;
        //参照一覧
        private AllReference allReference;
        //プロジェクト一覧
        private AllProject allProject;
        //ファイル検索オブジェクト
        private File file;

        private string cantBuildPrjName;
        #endregion

        #region --------- コンストラクタ ---------
        public RabbitTank()
        {
            InitializeComponent();
        }
        #endregion


        #region --------- イベント ---------
        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxVersion.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;
            comboBoxBit.SelectedIndex = 0;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 対象フォルダ選択ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTarget_Click(object sender, EventArgs e)
        {
            txtBoxTargetFol.Text = SetSelectPath();
        }

        /// <summary>
        /// 出力フォルダ選択ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOut_Click(object sender, EventArgs e)
        {
            txtBoxOutputFol.Text = SetSelectPath();
        }

        /// <summary>
        /// ログ出力フォルダ選択ボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLog_Click(object sender, EventArgs e)
        {
            txtBoxLogFol.Text = SetSelectPath();
        }

        /// <summary>
        /// ビルドボタンクリック時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuild_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox1.Image = Properties.Resources.kiryu;

                //パラメータのセット＆整合性チェック
                if (!SetAndCheckParam())
                {
                    MessageBox.Show("パラメータを空にしないでくれ　(T_T)");
                    return;
                }

                //ファイル検索オブジェクト
                file = new File();

                //ビルド対象存在チェック
                if (!TargetExistenceCheck())
                {
                    MessageBox.Show("ビルド対象が見つからないよ～～\n パス見直して出直してこい！！");
                    return;
                }

                //参照一覧インスタンス生成
                allReference = new AllReference
                {
                    References = new List<Reference>()
                };

                //プロジェクト一覧インスタンス生成
                allProject = new AllProject
                {
                    Projecs = new List<Project>()
                };

                //参照が存在の整合性チェックを実施
                if (!CanBuildCheck())
                {
                    MessageBox.Show("対象フォルダのプロジェクトの参照が不足しているぜ\n もう一度プロジェクトの参照を見直してくれ　(；・∀・)" + cantBuildPrjName);
                    dataGridViewProject.DataSource = allProject.Projecs;
                    return;
                }

                //ProgressDialogオブジェクトを生成
                ProgressDialog pd = new ProgressDialog("進行状況",
                    new DoWorkEventHandler(ProgressDialogBuild));

                //進行状況ダイアログを表示
                DialogResult result = pd.ShowDialog(this);

                //結果を取得する
                if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("キャンセルしたな！!短気な奴めww\nビルド結果が中途半端になるかもしれんぞ・・・");
                }
                else if (result == DialogResult.Abort)
                {
                    //エラー情報を取得する
                    Exception ex = pd.Error;
                    MessageBox.Show("エラー: " + ex);
                }
                else if (result == DialogResult.OK)
                {
                    //結果を取得する
                    MessageBox.Show("ビルド完了\n" +
                                    "ログを見てくれ！！\n");
                }

                //後始末
                pd.Dispose();

                //ビルドした結果の一覧表示
                dataGridViewProject.DataSource = allProject.Projecs;
                pictureBox1.Image = Properties.Resources.build;
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー： " + ex);
            }

        }
        #endregion


        #region --------- プライベートメソッド ---------

        /// <summary>
        /// フォルダのパス選択
        /// </summary>
        /// <returns></returns>
        private string SetSelectPath()
        {
            string selectPath;

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            // ダイアログの説明
            folderBrowser.Description = "フォルダを選択せよ";

            // ルートを設定する
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;

            // 初期選択するパスを設定する
            folderBrowser.SelectedPath = @"C:\";

            // [新しいフォルダ] ボタンを表示しない (初期値 true)
            folderBrowser.ShowNewFolderButton = false;

            // ダイアログを表示し、戻り値が [OK] の場合は、選択したディレクトリを表示する
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectPath = folderBrowser.SelectedPath;
            }
            else
            {
                selectPath = "";
            }

            folderBrowser.Dispose();

            return selectPath;
        }

        /// <summary>
        /// パラメータのセット＆チェック
        /// </summary>
        /// <returns></returns>
        private bool SetAndCheckParam()
        {
            //パラメータ設定
            targetPath = txtBoxTargetFol.Text;
            netFrameVersion = comboBoxVersion.SelectedItem.ToString();
            outPath = txtBoxOutputFol.Text;
            logPath = txtBoxLogFol.Text;
            programlanguage = comboBoxLanguage.SelectedItem.ToString();
            bit = comboBoxBit.SelectedItem.ToString();

            if (string.IsNullOrEmpty(targetPath))
            {
                return false;
            }

            if (string.IsNullOrEmpty(outPath))
            {
                return false;
            }

            if (string.IsNullOrEmpty(logPath))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ビルド対象の存在チェック
        /// </summary>
        /// <returns></returns>
        private bool TargetExistenceCheck()
        {
            if (!file.FilesExists(targetPath, programlanguage))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ビルド参照依存関係を確認し、ビルドできるかをチェック
        /// </summary>
        /// <returns></returns>
        private bool CanBuildCheck()
        {

            bool result = true;

            // 全プロジェクトの参照一覧を取得
            foreach (string item in file.Files)
            {
                Xdoc xdoc = new Xdoc(item);
                allReference.References = xdoc.GetReferencesInfo(allReference.References)
                                          .OrderBy(x => x.Name).Distinct().ToList();
            }

            // プロジェクトの情報を取得
            foreach (string item in file.Files)
            {
                Project project = new Project();
                project.Path = item;

                Xdoc xdoc = new Xdoc(item);
                allProject.Projecs.Add(xdoc.GetProjectInfo(project, allReference.References));
            }

            //参照の整合性チェック
            allReference.References.ForEach(allRef =>
            {
                if (!allProject.Projecs.Exists(pj => pj.Name == allRef.Name))
                {
                    cantBuildPrjName = cantBuildPrjName + allRef.Name + Environment.NewLine;
                    result = false;
                }
            });

            return result;
        }

        /// <summary>
        /// ビルド処理（進捗バー更新）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressDialogBuild(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            double noBuiltCount = allProject.Projecs.Where(x => !x.IsBuilt).Count();
            double allBuiltCount = allProject.Projecs.Count();
            double isBuiltCount;
            int parsent = 0;

            // 全プロジェクトがビルド済みになるまで処理継続
            while (noBuiltCount > 0)
            {
                //キャンセル処理
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                //プロジェクト一覧で繰り返し処理を行う
                allProject.Projecs.ForEach(pj =>
                {

                    //ビルド可能かつ未ビルドのプロジェクト対象にビルド実行
                    if (pj.IsBuildable && !pj.IsBuilt)
                    {
                        //プロジェクトファイルをバックアップ
                        FileSystem.CopyFile(pj.Path, pj.Path + "_" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss-fff") + ".bak", true);

                        //プロジェクトファイルの編集
                        Xdoc xdoc = new Xdoc(pj.Path);

                        //AXJDStatusBarだけ32bitでコンパイル
                        if (pj.Name == "AXJDStatusBar")
                        {
                            xdoc.EditProjectXmlFile(netFrameVersion, "AnyCPU", outPath);
                        }
                        else
                        {
                            xdoc.EditProjectXmlFile(netFrameVersion, bit, outPath);
                        }

                        //ビルド処理
                        Build build = new Build();
                        pj.BuildReturnCode = build.Execute(pj.Name, pj.Path, outPath, logPath);
                        pj.IsBuilt = true;

                        //全部の参照一覧のビルド済みステータスを更新
                        allReference.References.ForEach(re =>
                        {
                            if (re.Name == pj.Name)
                            {
                                re.IsBuilt = true;
                            }
                        });
                    }

                    // プロジェクトがビルドしてOKかを判定する
                    CheckBuildable checkBuildable = new CheckBuildable();
                    pj.IsBuildable = checkBuildable.ProjectIsBuildable(pj, allReference.References);

                    //ビルド済みプロジェクト数を更新
                    noBuiltCount = allProject.Projecs.Where(x => !x.IsBuilt).Count();
                    isBuiltCount = allProject.Projecs.Where(x => x.IsBuilt).Count();

                    //進捗バーの更新
                    if (isBuiltCount != 0)
                    {
                        parsent = (int)(isBuiltCount / allBuiltCount * 100);
                    }

                    bw.ReportProgress(parsent, allBuiltCount.ToString() + "個中 " + isBuiltCount.ToString() + "個 ビルド終了しました");

                });

            }


        }


        #endregion


    }
}