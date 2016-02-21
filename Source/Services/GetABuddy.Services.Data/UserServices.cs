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
            var user = this.users.GetById(id);

            return user;
        }

        public ApplicationUser GetByUserName(string username)
        {
            var user = this.users.All().Where(u => u.UserName == username).FirstOrDefault();

            return user;
        }
    }
}
