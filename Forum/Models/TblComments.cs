using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public partial class TblComments
    {
        public int CoId { get; set; }
        public string CoContent { get; set; }
        public DateTime CoDate { get; set; }
        public int CoAuthor { get; set; }
        public int CoPost { get; set; }

        public TblPosts CoPostNavigation { get; set; }
    }
}
