namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Common;
    using GetABuddy.Data.Models;

    public class UserServices : IUserServices
    {
        private readonly IDbRepository<ApplicationUser, string> users;

        public UserServices(IDbRepository<ApplicationUser, string> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public ApplicationUser GetById(string id)
        {
            var eventById = this.users.GetById(id);

            return eventById;
        }
    }
}
