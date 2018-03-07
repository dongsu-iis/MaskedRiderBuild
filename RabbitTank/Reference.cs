using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RabbitTank
{
    public class AllReference
    {
        public List<Reference> References { get; set; }
    }

    public class Reference : IEquatable<Reference>
    {
        [DisplayName("参照名")]
        public string Name { get; set; }
        [DisplayName("ビルド済み")]
        public bool IsBuilt { get; set; }

        public Reference(string Name) => this.Name = Name;

        public Reference()
        {
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        bool IEquatable<Reference>.Equals(Reference reference)
        {
            if (reference == null)
            {
                return false;
            }
            return (Name == reference.Name);
        }

    }


}
