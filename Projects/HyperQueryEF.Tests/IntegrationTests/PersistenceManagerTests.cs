using System;
using System.IO;
using System.Reflection;
using HyperQueryEF.Tests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperQueryEF.Tests.IntegrationTests.PersistenceManagerTests
{
    [TestClass]
    public class When_the_app_initializes : IntegrationTestBase
    {
        [TestInitialize]
        public void Init()
        {
            
        }

        [TestMethod]
        public void The_database_exists_as_configured()
        {
            using (var dbContext = new HyperQueryEFContext())
            {
                Assert.IsTrue(dbContext.Database.Exists());
            }
        }
    }
}
