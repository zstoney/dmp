﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dmp.IBLL;
using dmp.IDAL;

namespace dmp.BLL
{
    public class TestDemoBLL: ITestDemoBLL
    {
        public ITestDemoDAL TestDemoDal { get; set; }
        public string HelloWorld()
        {
            return TestDemoDal.HelloWorld();
        }
    }
}
