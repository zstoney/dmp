using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.Common
{
    public class PagesModel
    {
        /// <summary>
        /// 分页总条数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public object rows { get; set; }
        
    }

    


}
