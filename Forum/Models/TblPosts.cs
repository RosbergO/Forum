using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public partial class TblPosts
    {
        public int PoId { get; set; }
        public string PoName { get; set; }
        public string PoContent { get; set; }
        public DateTime PoDate { get; set; }
        public int PoAuthor { get; set; }
        public int PoCategory { get; set; }

        public TblUser PoAuthorNavigation { get; set; }
        public TblCategories PoCategoryNavigation { get; set; }
    }
}
