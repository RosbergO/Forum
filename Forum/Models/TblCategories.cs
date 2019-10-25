using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public partial class TblCategories
    {
        public TblCategories()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public int CaId { get; set; }
        public string CaName { get; set; }

        public ICollection<TblPosts> TblPosts { get; set; }
    }
}
