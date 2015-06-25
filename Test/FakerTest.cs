using Faker.Generator;
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

        [TestMethod]
        public void Can_Initialize_Lists()
        {
            var car = new Faker<Car>().Create();

            Assert.IsNotNull(car);
            Assert.IsNotNull(car.Skils);
        }

        [TestMethod]
        public void Fill_With_Real_Email_Properties_Called_Email_Or_Mail()
        {
            var worker = new Faker<Worker>().Create();

            Assert.IsTrue(worker.Mail.Contains("@"));
            Assert.IsTrue(worker.Email.Contains("@"));
        }

        [TestMethod]
        public void Fill_With_Real_Name_Properties_Called_Name()
        {
            var worker    = new Faker<Worker>().Create();
            var firstName = worker.Name.Split(' ').First();
            var lastName  = worker.Name.Split(' ')[1];

            Assert.IsTrue(NameGenerator.Names.Any(x => firstName.Contains(x)));
            Assert.IsTrue(NameGenerator.LastNames.Any(x => lastName.Contains(x)));
        }

        [TestMethod]
        public void Fill_With_Real_Login_Properties_Called_Login()
        {
            var worker = new Faker<Worker>().Create();
            Assert.IsTrue(LoginGenerator.Logins.Any(x => worker.Login.Contains(x)));
        }

        [TestMethod]
        public void By_Default_Dont_Use_Numbers_In_Generated_Values_On_Create()
        {
            var worker = new Faker<Worker>().Create();
            Assert.IsTrue(!worker.Name.Contains("1"));
        }

        [TestMethod]
        public void When_Set_UseSequenceNumbers_We_Have_Numbers_In_Generated_Values_On_Create()
        {
            var worker = new Faker<Worker>(useSequenceNumbers: true).Create();
            Assert.IsTrue(worker.Name.Contains("1"));
        }

        [TestMethod]
        public void By_Default_Dont_Use_Numbers_In_Generated_Values_On_CreateMany()
        {
            var workers = new Faker<Worker>().CreateMany(3);
            Assert.IsTrue(workers.Any(x => !x.Name.Contains("1")));
            Assert.IsTrue(workers.Any(x => !x.Name.Contains("2")));
            Assert.IsTrue(workers.Any(x => !x.Name.Contains("3")));
        }

        [TestMethod]
        public void When_Set_UseSequenceNumbers_We_Have_Numbers_In_Generated_Values_On_CreateMany()
        {
            var workers = new Faker<Worker>(useSequenceNumbers: true).CreateMany(3);
            Assert.IsTrue(workers.Any(x => x.Name.Contains("1")));
            Assert.IsTrue(workers.Any(x => x.Name.Contains("2")));
            Assert.IsTrue(workers.Any(x => x.Name.Contains("3")));
        }
    }
}
