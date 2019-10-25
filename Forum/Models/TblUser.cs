using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public int UsId { get; set; }
        public string UsName { get; set; }
        public string UsHash { get; set; }
        public string UsSalt { get; set; }
        public string UsEmail { get; set; }

        public ICollection<TblPosts> TblPosts { get; set; }
    }
}
