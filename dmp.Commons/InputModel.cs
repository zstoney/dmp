using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Common
{
    public class InputModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; } 
        public string SortName { get; set; }
        public string SortOrder { get; set; }

    }

    public class InputUser: InputModel
    {
        public string UserName { get; set; }

        public int Status { get; set; }
    }

}
