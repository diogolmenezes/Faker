# Faker
Faker is a C# fake object generator like rails factory girl and it´s awesome to generate fake data for make tests.

## Getting Started

Add [Faker.dll](https://github.com/diogolmenezes/Faker/blob/master/Binary) as reference on your test project.

or use the [NuGet repository](https://www.nuget.org/packages/FakerTest):

```
PM> Install-Package FakerTest
```

## Creating simple fake objects

Faker can create automatic fake objects based in your custom type:

```c#
public class User
{
    public string Name  { get; set; }
    public string Email  { get; set; }
    public int Age  { get; set; }
    public DateTime CreatedAt  { get; set; }
}
```

With simple commands :)

```c#
// creating one fake user
var user = new Faker<User>().Create();

// creating 10 fake users
var user = new Faker<User>().CreateMany(10);
```

## Creating custom fake objects

You can set specific properties to have a specific value on creation

```c#
// creating 1 fake user with 18 years and CreatedAt on today
var user = new Faker<User>().CreateMany(x=> { x.Age = 18; x.CreatedAt = DateTime.Now; });

// creating 5 fake users with 18 years and CreatedAt on today
var user = new Faker<User>().CreateMany(5, x=> { x.Age = 18; x.CreatedAt = DateTime.Now; });

// if you want that the generated data have a sequencial number at the end,
// like (Name 1, Name 2, Email_1@gmail.com, Email_2@gmail.com)
// use UseSequentialNumber in Faker contructor.
// By default UseSequentialNumber is false.
var user = new Faker<User>(true).CreateMany(10);
```

## Using simple generators

Faker implements some types of generators, like NameGenerator, EmailGenerator, LoginGenerator, IntegerGenerator and DateTimeGenerator and you can use your custom generator too.

By default faker will try to use the best generator based on your property name, so if you have a Email property, faker will give you a e-mail address ;)

```c#
// creating 10 users with real names and real mail adresses
var user = new Faker<User>().CreateMany(10, x=> { x.Name = new NameGenerator().Get(); x.Email = new EmailGenerator().Get() });
```

## Creating fake objects using custom factory

You can create objects using custom default schema, and all you need to do is implement IFaker<T> interface.

```c#
public class User : IFaker<User>
{
    public string Name  { get; set; }
    public string Email  { get; set; }
    public int Age  { get; set; }
    public DateTime CreatedAt  { get; set; }

    public void Fake(int number)
    {
        Name       = new NameGenerator().Get(number: number);  // Name generator will generate real names like Jhon Doe 1, Bruno Matarazo 2.
        Email      = new EmailGenerator().Get(); // Email generator will generate real mails like jhon_doe@gmail.com
        Age        = new IntegerGenerator().Get(15, 99);
        CreatedAt  = new DateTimeGenerator().Get();
    }
}
```
And create objects normally

```c#
// creating one fake user using IFake<T> interface
var user = new Faker<User>().Create();

// creating 10 fake users using IFake<T> interface
var user = new Faker<User>().CreateMany(10);
```

## Tests

Faker has many tests in the test project if you want take a look.

## Pull Requests

Faker is open to improve, send your pull request and help Faker to be the best fake object generator ever :)