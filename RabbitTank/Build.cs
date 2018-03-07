using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace RabbitTank
{
    public class Build
    {

        private string MSBuildPath = ConfigurationManager.AppSettings["MSBuildPath"];
        //@"C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe";

        public int Execute(string prjName, string projectFilePath, string outputDirPath,string logDirPath)
        {

            //ビルド結果
            int buildResultCode;
            string logFilePath;
            logFilePath = Path.Combine(logDirPath, prjName+ "_" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss-fff") + ".log");

            using (Process p = new Process())
            {

                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = MSBuildPath;

                // パラメータについては「http://msdn.microsoft.com/ja-jp/library/bb629394.aspx」参照
                StringBuilder args = new StringBuilder();
                // プロジェクトファイル
                args.AppendFormat("\"{0}\"", projectFilePath);
                // ビルド構成(リリース)
                args.Append(" /p:Configuration=Release");
                // 出力フォルダ
                args.AppendFormat(" /p:OutputPath=\"{0}\"", outputDirPath);
                // 変数の宣言を強制
                //args.Append(" /p:OptionExplicit=true");
                // バイナリで文字列比較
                //args.Append(" /p:OptionCompare=binary");
                // 暗黙的な型変換を無効
                //args.Append(" /p:OptionStrict=true");
                // 変数の型の推論を可能
                //args.Append(" /p:OptionInfer=true");
                // プロジェクト参照をビルドするか
                args.Append(" /p:BuildProjectReferences=false");
                // デバッグ情報の出力（full）
                args.Append(" /p:DebugType=full");
                // pdbファイルを生成するか(false)
                args.Append(" /p:DebugSymbols=false");
                // XMLドキュメントファイル
                //args.AppendFormat(" /p:DocumentationFile={0}", string.Format("{0}.xml", GetAssemblyName(projectFilePath)));
                args.Append(" /t:Clean;Rebuild");
                //ログファイル出力
                args.AppendFormat(" /fl /flp:logfile=\"{0}\"", logFilePath);
                //ログレベル（詳細）
                args.Append(" /v:diag");

                p.StartInfo.Arguments = args.ToString();

                // MSBuild実行
                p.Start();
                // MSBuild実行完了まで待機
                p.WaitForExit();

                // MSBuildの戻り値を取得
                buildResultCode = p.ExitCode;

            }

            return buildResultCode;
        }

    }
}
