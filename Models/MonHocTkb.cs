using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class MonHocTkb
    {
        public string MaMhTkb { get; set; } = null!;
        public string MaMh { get; set; } = null!;
        public string MaTkb { get; set; } = null!;

        public virtual MonHoc MaMhNavigation { get; set; } = null!;
        public virtual Tkb MaTkbNavigation { get; set; } = null!;
    }
}
