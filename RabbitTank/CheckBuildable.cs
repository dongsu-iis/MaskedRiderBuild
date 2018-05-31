using System.Collections.Generic;

namespace RabbitTank
{
    public class CheckBuildable
    {

        public bool ProjectIsBuildable(Project project, List<Reference> allReference)
        {
            bool IsBuildable;

            // プロジェクトがビルドしてOKかを判定する
            int noBuiltCount = 0;
            project.References.ForEach(pjItem => {
                allReference.ForEach(reItem => {

                    if (pjItem.Name == reItem.Name)
                    {
                        if (!reItem.IsBuilt)
                        {
                            noBuiltCount++;
                        }
                    }
                });
            });

            IsBuildable = noBuiltCount > 0 ? false : true;

            return IsBuildable;

        }
    }
}
