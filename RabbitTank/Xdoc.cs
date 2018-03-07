using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;


namespace RabbitTank
{

    public class Xdoc
    {
        private XDocument xdocument;
        private XNamespace nspace;
        private string projectFile;

        // 除外参照（System系は一切除外）
        private List<FilterList> filteringListSystem;
        // 除外参照（一部）
        private List<FilterList> filteringListSystemPartial;

        private List<ConvertList> convertRef;

        /// <summary>
        /// コンストラクタ（プロジェクトXML）
        /// </summary>
        /// <param name="path"></param>
        public Xdoc(string path)
        {
            xdocument = XDocument.Load(path);
            nspace = xdocument.Root.Name.Namespace;
            projectFile = path;
            SetInitialList();
        }

        /// <summary>
        /// 参照情報を取得
        /// </summary>
        /// <param name="referenceList"></param>
        /// <returns></returns>
        public List<Reference> GetReferencesInfo(List<Reference> referenceList)
        {
            referenceList = SetXmlReferences(GetXmlReferences(filteringListSystem), referenceList);
            return referenceList;
        }


        /// <summary>
        /// プロジェクト情報を取得
        /// </summary>
        /// <param name="project"></param>
        /// <param name="allReference"></param>
        /// <returns></returns>
        public Project GetProjectInfo(Project project, List<Reference> allReference)
        {
            //プロジェクト名（アセンブリ名）取得
            project.Name = GetXmlProjectName();

            // プロジェクトの参照を取得＆設定
            project.References = new List<Reference>();
            project.References = SetXmlReferences(GetXmlReferences(filteringListSystem), project.References);

            // プロジェクトがビルドしてOKかを判定する
            CheckBuildable checkBuildable = new CheckBuildable();
            project.IsBuildable = checkBuildable.ProjectIsBuildable(project, allReference);

            return project;
        }


        /// <summary>
        /// プロジェクトのXMLファイルを編集
        /// </summary>
        /// <param name="pjFrameworkVersion"></param>
        /// <param name="pjBit"></param>
        /// <param name="piRefPath"></param>
        public void EditProjectXmlFile(string pjFrameworkVersion, string pjBit, string piRefPath)
        {
            //フレームワークバージョン変更
            var frameworkVersion= xdocument.Root.Descendants(nspace + "TargetFrameworkVersion")
                                            .Select(x => x).FirstOrDefault();
            frameworkVersion.SetValue(pjFrameworkVersion);

            //Bit数変更
            var bit = xdocument.Root.Descendants(nspace + "PlatformTarget").Select(x => x);
            foreach(var i in bit)
            {
                i.SetValue(pjBit);
            }

            //出力パス変更
            var outpath = xdocument.Root.Descendants(nspace + "OutputPath").Select(x => x);
            foreach (var i in outpath)
            {
                i.SetValue(piRefPath);
            }


            //ライセンスファイル削除
            //var licenses = xdocument.Root.Descendants(nspace + "EmbeddedResource")
            //                .Where(x => x.Attribute("Include").Value.Contains("licenses.licx"))
            //                .Select(x => x);

            //if (licenses != null)
            //{
            //    licenses.Remove();
            //}

            //参照先フォルダ変更
            // 参照先パスをOUTフォルダ、ローカルへコピーをFalse
            var refs = GetXmlReferences(filteringListSystemPartial);

            //参照の変換処理
            foreach (var i in refs)
            {
                string name;
                name = i.Attribute("Include").Value.Split(',')[0];

                //参照を置き換え
                convertRef.ForEach(x => 
                {
                   if(x.from == name)
                    {
                        i.SetAttributeValue("Include", x.to);
                        var hintPath = Path.Combine(piRefPath, x.to + ".dll");

                        //参照パス
                        if (i.Element(nspace + "HintPath") == null)
                        {
                            i.Add(new XElement(nspace + "HintPath", hintPath));
                        }
                        else
                        {
                            i.Element(nspace + "HintPath").SetValue(hintPath);
                        }

                        //名前
                        if (i.Element(nspace + "Name") == null)
                        {
                            i.Add(new XElement(nspace + "Name", x.to));
                        }
                        else
                        {
                            i.Element(nspace + "Name").SetValue(x.to);
                        }

                    }
                });

                string fileName;
                string newPath;

                //参照パス
                if (i.Element(nspace + "HintPath") == null)
                {
                    fileName = name + ".dll";
                    newPath = Path.Combine(piRefPath, fileName);
                    i.Add(new XElement(nspace + "HintPath", newPath));
                }
                else
                {
                    fileName = Path.GetFileName(i.Element(nspace + "HintPath").Value.ToString());
                    newPath = Path.Combine(piRefPath, fileName);
                    i.Element(nspace + "HintPath").SetValue(newPath);
                }

                //ローカルへコピー
                if (i.Element(nspace + "Private") == null)
                {
                    i.Add(new XElement(nspace + "Private", "False"));
                }
                else
                {
                    i.Element(nspace + "Private").SetValue("False");
                }
            }

            //XMLファイル保存
            xdocument.Save(projectFile);
        }


        /// <summary>
        /// Settingファイルを読み込み、リストを設定する
        /// </summary>
        private void SetInitialList()
        {
            var json_system_list = ConfigurationManager.AppSettings["json_system_list"];
            filteringListSystem = JsonConvert.DeserializeObject<List<FilterList>>(json_system_list);

            var json_system_list_partial = ConfigurationManager.AppSettings["json_system_list_partial"];
            filteringListSystemPartial = JsonConvert.DeserializeObject<List<FilterList>>(json_system_list_partial);

            var json_convert_ref = ConfigurationManager.AppSettings["json_convert_ref"];
            convertRef = JsonConvert.DeserializeObject<List<ConvertList>>(json_convert_ref);
        }

        /// <summary>
        /// プロジェクト名の取得（アセンブリ名）
        /// </summary>
        /// <returns></returns>
        private string GetXmlProjectName()
        {

            XElement xprojectName = xdocument.Root.Descendants(nspace + "AssemblyName")
                                            .Select(x => x).FirstOrDefault();
            return xprojectName.Value.ToString();
        }


        /// <summary>
        /// 参照を取得
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IEnumerable<XElement> GetXmlReferences(List<FilterList> list)
        {
            IEnumerable<XElement> xReference = xdocument.Root.Descendants(nspace + "Reference")
                                    // System系の参照を除外
                                    .Where(x => list.Any(f => x.Attribute("Include").Value.StartsWith(f.name.ToString())) == false)
                                    .Select(x => x);

            return xReference;
        }

        /// <summary>
        /// 参照を設定
        /// </summary>
        /// <param name="xmlRef"></param>
        /// <param name="refList"></param>
        /// <returns></returns>
        private List<Reference> SetXmlReferences(IEnumerable<XElement> xmlRef, List<Reference> refList)
        {
            
            foreach (XElement item in xmlRef)
            {
                Reference reference = new Reference
                {
                    Name = item.Attribute("Include").Value.Split(',')[0]
                };
                
                refList.Add(reference);
            }

            return refList;
        }









    }
}