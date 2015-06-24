using Faker.Test.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Faker.Test
{
    [TestClass]
    public class FakerTest
    {
        [TestMethod]
        public void Can_Create_One_User()
        {
            var user = new Faker<User>().Create();

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.Name);
            Assert.AreNotEqual(user.Name, "");
            Assert.IsNotNull(user.Email);
            Assert.IsTrue(user.Email.Contains("@"));
        }

        [TestMethod]
        public void Can_Create_10_Users()
        {
            var users = new Faker<User>().CreateMany(10);

            Assert.IsNotNull(users);
            Assert.AreEqual(10, users.Count());
            Assert.IsTrue(users.First().Email.Contains("@"));
            Assert.IsTrue(users.Last().Email.Contains("@"));
        }

        [TestMethod]
        public void Can_Create_Without_Using_IFaker_Interface()
        {
            var car = new Faker<Car>().Create();

            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void Can_Create_Car_Without_Color()
        {
            var car = new Faker<Car>().Create(x => x.Color = "");

            Assert.IsNotNull(car);
            Assert.AreEqual(car.Color, "");
        }

        [TestMethod]
        public void Can_Create_5_Without_Color()
        {
            var cars = new Faker<Car>().CreateMany(5, x => x.Color = "");            

            Assert.IsNotNull(cars);
            Assert.AreEqual(5, cars.Count());

            Assert.IsTrue(cars.All(x => x.Color == ""));
        }


        [TestMethod]
        public void Can_Create_5_Without_Color_And_Model()
        {
            var cars = new Faker<Car>().CreateMany(5, x => { x.Color = ""; x.Model = ""; });

            Assert.IsNotNull(cars);
            Assert.AreEqual(5, cars.Count());

            Assert.IsTrue(cars.All(x => x.Color == "" && x.Model == ""));
        }
    }
}
