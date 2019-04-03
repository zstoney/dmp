using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Model
{
    public class RoleUser: ModelBase
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }
        
    }
}
