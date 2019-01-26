using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webApiFirst.Controllers;
using MySql.Data;
namespace webApiFirst.Tests.Controllers
{
    [TestClass]
    public class ToDoListControllerTest
    {
        //DBconnect Test
        [TestMethod]
        public void dbConnect()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            Assert.AreEqual("dbConnect success", controller.dbConnect());         
        }

        //打某隻 post api 可以新增一個 todo 事件。
        [TestMethod]
        public void Post()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            //Assert.AreEqual("buy some cake", controller.Post("buy some cake"));
             //Assert.AreEqual("buy some book", controller.Post("buy some book"));
             Assert.AreEqual("shopping", controller.Post("shopping"));
        }

        //打某隻 get api 可以取得所有的 todo 事件
        [TestMethod]
        public void Get()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            Assert.AreEqual("select success", controller.Get());
        }

        // 打某隻 delete api 可以移除某個 todo 事件。
        //update delTime
        [TestMethod]
        public void Delete()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            Assert.AreEqual("delete success", controller.Delete("5"));
        }

        //打某集 put api 可以修改某個 todo 事件。
        [TestMethod]
        public void Put()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            Assert.AreEqual("update success", controller.Put("6","buy some toys"));
        }



    }
}
