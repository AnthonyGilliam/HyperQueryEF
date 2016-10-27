using System;
using System.IO;
using System.Reflection;
using Castle.Core.Internal;
using HyperQueryEF.Tests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperQueryEF.Tests.IntegrationTests
{
    [TestClass]
    public abstract class IntegrationTestBase
    {
        protected static DirectoryInfo AppDataDirectory;

        static IntegrationTestBase()
        {
            AppDataDirectory = new DirectoryInfo(Assembly.GetExecutingAssembly().Location).Parent;
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
        }

        [TestInitialize]
        public void BaseInit()
        {
            using (var dbContext = new HyperQueryEFContext())
            {
                dbContext.Initialize();
            }
        }
    }
}
