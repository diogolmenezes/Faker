# Faker
Faker is a fake object generator like rails factory girl.

## Creating simple fake objects
Faker you can create automatic fake objects based in your custom type:

```
public class User
{
    public string Name  { get; set; }
    public string Email  { get; set; }
    public int Age  { get; set; }
    public DateTime CreatedAt  { get; set; }
}
```

With simple commands :)

```
// creating one fake user
var user = new Faker<User>().Create();

// creating 10 fake users
var user = new Faker<User>().CreateMany(10);
```
## Creating custom fake objects
You can set specific properties to have a specific value on creation
```
// creating 1 fake user with 18 years and CreatedAt on today
var user = new Faker<User>().CreateMany(x=> x.Age = 18 && x.CreatedAt = DateTime.Now);

// creating 5 fake users with 18 years and CreatedAt on today
var user = new Faker<User>().CreateMany(5, x=> x.Age = 18 && x.CreatedAt = DateTime.Now);
```

## Creating fake objects using custom factory
You can create objects using a custom default schema, for this you need to implement IFaker<T> interface.

Faker implements some types of generators, like NameGenerator, EmailGenerator, IntegerGenerator and DateTimeGenerator and you can youse your custom generators too.

```
public class User : IFaker<User>
{
    public string Name  { get; set; }
    public string Email  { get; set; }
    public int Age  { get; set; }
    public DateTime CreatedAt  { get; set; }

    public void Fake(int number)
    {
        Name       = NameGenerator.Get();
        Email      = EmailGenerator.Get();
        Age        = IntegerGenerator.Get(15, 99);
        CreatedAt  = DateTimeGenerator.Get();
    }
}
```
And create objects normally

```
// creating one fake user using IFake<T> interface
var user = new Faker<User>().Create();

// creating 10 fake users using IFake<T> interface
var user = new Faker<User>().CreateMany(10);
```

