using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL29.Base
{
   public class IBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime?  UpdateDate { get; set; }
        public DateTime Createdate { get; set; }

    }
}
