using dmp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DBTable.AddTable();
                Console.WriteLine("生成成功 =^_^= "); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误：" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
