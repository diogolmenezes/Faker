
namespace Faker.Test.Entity
{
    /// <summary>
    /// Entity to test create fake objects in the third level
    /// </summary>
    public class FirtLevel
    {
        public string Id { get; set; }
        public SecondLevel SecondLevel{ get; set; }
    }

    public class SecondLevel
    {
        public string Id { get; set; }
        public ThirdLevel ThirdLevel { get; set; }
    }

    public class ThirdLevel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
