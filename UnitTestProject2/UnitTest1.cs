using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using hashingService;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete;
namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void usercontextCustomDal_getuserbyusernamepassword_notNull()
        {
            IUserContext userContext = new UserContext_customDAL("name = mysqlCon2");
            //IUserContext userContext = new UserContext_framework("name = mysqlCon");
            
            string pas = hashingService.sha1.GetSha1("admin").Substring(0,20).ToLower();
            user user = userContext.getUserByUsernamePassword("admin", pas);
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void usercontextFramework_getuserbyusernamepassword_notNull()
        {
            //IUserContext userContext = new UserContext_customDAL("name = mysqlCon2");
            IUserContext userContext = new UserContext_framework("name = mysqlCon");

            string pas = hashingService.sha1.GetSha1("admin").Substring(0, 20).ToLower();
            user user = userContext.getUserByUsernamePassword("admin", pas);
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void usercontextCustomDal_usernameAlreadyUsed_true()
        {
            IUserContext userContext = new UserContext_customDAL("name = mysqlCon2");
            //IUserContext userContext = new UserContext_framework("name = mysqlCon");
            string pas = hashingService.sha1.GetSha1("admin").Substring(0,20).ToLower();
            user user = userContext.getUserByUsernamePassword("admin", pas);
            bool output = userContext.usernameAlreadyUsed("joshua", user);
            Assert.IsTrue(output);
        }
        [TestMethod]
        public void usercontextFramework_usernameAlreadyUsed_true()
        {
            //IUserContext userContext = new UserContext_customDAL("name = mysqlCon2");
            IUserContext userContext = new UserContext_framework("name = mysqlCon");
            string pas = hashingService.sha1.GetSha1("admin").Substring(0, 20).ToLower();
            user user = userContext.getUserByUsernamePassword("admin", pas);
            bool output = userContext.usernameAlreadyUsed("joshua", user);
            Assert.IsTrue(output);
        }
    }
}
