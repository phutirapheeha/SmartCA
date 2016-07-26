using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Model.Employees;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using System.Collections;
using System.Collections.Generic;

namespace SmartCA.UnitTests.Employees
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private TestContext testContextInstance;
        private UnitOfWork unitOfWork;
        private IEmployeeRepository repository;

        /// <summary>
        /// Use TestInitialize to run code before running each test
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<IEmployeeRepository, Employee>(this.unitOfWork);
        }

        /// <summary>
        /// A test for GetPrincipals
        /// </summary>
        [TestMethod]
        public void GetPrincipalsTest()
        {
            //Get the list of all Principals
            IList<Employee> principals = this.repository.GetPrincipals();

            //Make sure there is at least one item in the list
            Assert.AreEqual(true, principals.Count > 0);
        }

        /// <summary>
        /// A test for GetConstructionAdministrators
        /// </summary>
        [TestMethod]
        public void GetConstructionAdministratorsTest()
        {
            //Get the list of all Principals
            IList<Employee> administrators = this.repository.GetConstructionAdministrators();

            //Make sure there is at least one item in the list
            Assert.AreEqual(true, administrators.Count > 0);
        }
    }
}
