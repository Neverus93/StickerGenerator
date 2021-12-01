using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickerGenerator_DocX.Model
{
    public class BoxInfo : IEquatable<BoxInfo>
    {
        public bool Equals(BoxInfo other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return GetHashCode() == other.GetHashCode();
        }
    }
}
