using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository(DapperDbContext dbContext) : IUserRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        string query = "INSERT INTO public.\"users\"(\"userid\", \"email\", \"personname\", \"gender\", \"password\") " +
                       "VALUES(@UserId, @Email, @PersonName,@Gender, @Password)";

        var rowAffected = await dbContext.DbConnection.ExecuteAsync(query, user); //user param will supply all its property as parameter for the query

        return rowAffected > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var query = "SELECT * FROM public.\"users\" \nWHERE \"email\" = @Email AND \"password\" = @Password";

        var parameters = new { Email = email, Password = password };
        var user = await dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;

    }
}