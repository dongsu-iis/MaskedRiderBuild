# README

## 概要
選択したフォルダ配下のVBとC#のプロジェクトを対象に自動ビルドを行う。  
ビルドツールはMsBuildを用いる。


　
## 機能
1. 指定されたフォルダ配下（サブフォルダも含む）のプロジェクトを対象に、ビルドを行う
2. 画面で指定された「.NET Frameworkのバージョン」と「コンパイルするモジュールのビット数」を全プロジェクトに適用する
3. プロジェクト同士の参照依存を検知し、ビルド順番を自動的に並び替える
4. ビルド結果を画面一覧に表示し、ビルドログを出力する


　
## 初期設定
本ツールと同梱する設定ファイル（RabbitTank.exe.config）のappSettingsをユーザー環境に合わせて書き換えてください。  


例）  
```xml:App.config
<appSettings>
    <!-- 参照依存は検知しないための除外する参照リスト -->
    <add key="json_system_list" value="[
         {'name':'System'},
         {'name':'CrystalDecisions'},
         {'name':'Microsoft'},
         {'name':'C1'},
         {'name':'FlashControlV71'},
         {'name':'office'},
         {'name':'Oracle'},
         {'name':'GrapeCity'},
         {'name':'Interop'},
         {'name':'Ionic.Zip'},
         ]
         "/>
    
    <!-- 参照依存は検知しないための除外する参照リスト 
         このリストに含まれていない参照のパスは出力フォルダになる-->
    <add key="json_system_list_partial" value="[
         {'name':'System'},
         {'name':'Microsoft.VisualBasic'},
         {'name':'office'},
         {'name':'CrystalDecisions'},
         {'name':'FlashControlV71'},
         {'name':'C1'},
         {'name':'GrapeCity'},
         ]
         "/>


    <!--参照の置き換えリスト（dllバージョンアップの際に用いるといい）-->
    <add key="json_convert_ref" value="[
         {'from':'Oracle.DataAccess','to':'Oracle.DataAccess'},
         ]
         "/>

    <!-- MSBuildのパス（自身のVisual Studio付属のMSBuildを指定する） -->
    <add key="MSBuildPath" value="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe"/>
</appSettings>
```


　
## その他
まぁ、とりあえず使って見てください。