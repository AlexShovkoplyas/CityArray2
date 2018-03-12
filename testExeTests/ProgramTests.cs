using Microsoft.VisualStudio.TestTools.UnitTesting;
using testExe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace testExe.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            Mapper.Configuration.AssertConfigurationIsValid();
            //Assert.Fail();
        }
    }
}