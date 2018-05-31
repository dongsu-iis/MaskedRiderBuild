using System.Collections.Generic;
using System.ComponentModel;

namespace RabbitTank
{

    public class AllProject
    {
        public List<Project> Projecs { get; set; }
    }

    public class Project
    {
        [DisplayName("プロジェクト名")]
        public string Name { get; set; }
        [DisplayName("パス")]
        public string Path { get; set; }
        [DisplayName("ビルド済み")]
        public bool IsBuilt { get; set; }
        [DisplayName("ビルド可否")]
        public bool IsBuildable { get; set; }
        [DisplayName("ビルド戻り値")]
        public int BuildReturnCode { get; set; }
        public List<Reference> References { get; set; }
    }


}
