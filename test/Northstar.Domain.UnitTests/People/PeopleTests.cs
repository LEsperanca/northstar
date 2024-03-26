using FluentAssertions;
using NorthStar.Domain.People;
using System.Reflection.Metadata;

namespace Northstar.Domain.UnitTests.People;

public class PeopleTests
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        //Arrange
        var  name = "some user";
        var email = "someuser@gmail.com";

        //Act
        var person = Person.Create(name, email);

        //Assert
        person.Should().NotBeNull();
        person.Name.ToString().Should().Be(name);
        person.Email.Value.Should().Be(email);

        person.Roles.Should().Contain(Role.Registered);
    }

    [Fact]
    public void CreatePersonWithNullName_Should_ThrowArgumentException()
    {
        //Arrange
        var email = "someuser@gmail.com";

        //Act
        Action act =  () => Person.Create(null!, email);

        //Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Person Name cannot be null or empty. (Parameter 'Name')");
    }

    [Fact]
    public void CreatePersonWithEmptyName_Should_ThrowArgumentException()
    {
        //Arrange
        var name = string.Empty;
        var email = "someuser@gmail.com";

        //Act
        Action act = () => Person.Create(name, email);

        //Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Person Name cannot be null or empty. (Parameter 'Name')");
    }

    [Fact]
    public void CreatePersonWithNullEmail_Should_ThrowArgumentException()
    {
        //Arrange
        var name = "somename";

        //Act
        Action act = () => Person.Create(name, null!);

        //Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Email cannot be null or empty. (Parameter 'Email')");
    }

    [Fact]
    public void CreatePersonWithEmptyEmail_Should_ThrowArgumentException()
    {
        //Arrange
        var name = "somename";
        var email = string.Empty;

        //Act
        Action act = () => Person.Create(name, email);

        //Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Email cannot be null or empty. (Parameter 'Email')");
    }


    [Fact]
    public void CreatePersonWithValidEmail_Should_CreateSucess()
    {
        //Arrange
        var name = "somename";
        var email = "somename@email.com";

        //Act
        var person =  Person.Create(name, email);

        //Assert
        person.Should().NotBeNull();
        person.Name.Value.Should().Be(name);
        person.Email.Value.Should().Be(email);

        person.Roles.Should().Contain(Role.Registered);
    }

    [Fact]
    public void CreatePersonWithInvalidEmail_Should_ThrowException()
    {
        //Arrange
        var name = "somename";
        var email = "somenameemail.com";

        //Act
        Action act = () => Person.Create(name, email);

        //Assert
        act?.Should().Throw<ArgumentException>()
            .WithMessage("Email is not valid. (Parameter 'Email')");
    }
}