using Bogus;
using Bookify.Application.Abstractions.Data;
using Dapper;
using System.Data;

namespace NorthStar.Api.Extensions;

internal static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ISqlConnectionFactory sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using IDbConnection connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        #region People
        List<object> people = new List<object>();

        people.Add(new
        {
            Id = new Guid("1a83ad3c-cd82-422a-a16f-47761036665c"),
            Name = faker.Name.FullName(),
            Email = faker.Internet.Email(),
            PersonRole = faker.Random.Number(0, 4),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            IdentityId = faker.Random.Uuid(),
        });

        const string sqlPeople = """
            INSERT INTO public.people
            (id, "name", email, person_role, created, updated, identity_id)
            VALUES(@Id, @Name, @Email, @PersonRole, @Created, @Updated, @IdentityId);
            """;

        connection.Execute(sqlPeople, people);

        #endregion

        #region Projects
        List<object> projects = new();
        
        projects.Add(new
        {
            Id = new Guid("957c4d17-d207-4cef-b146-3acea97c5e40"),
            Name = faker.Company.CompanyName(),
            Description = faker.Lorem.Sentence(wordCount: 3),
            BeginDate = faker.Date.Past(),
            EndDate = faker.Date.Future(),
            Lead = new Guid("1a83ad3c-cd82-422a-a16f-47761036665c"),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
        });

        

        const string sql = """
            INSERT INTO public.project
            (id, "name", description, begin_date, end_date, lead_id, created, updated)
            VALUES(@Id, @Name, @Description, @BeginDate, @EndDate, @Lead, @Created, @Updated);
            """;

        connection.Execute(sql, projects);

        #endregion

    }
}
