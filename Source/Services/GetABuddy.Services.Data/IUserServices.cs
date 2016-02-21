namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface IUserServices
    {
        IQueryable<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);

        ApplicationUser GetByUserName(string id);
    }
}
