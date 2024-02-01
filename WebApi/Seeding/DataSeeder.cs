using DAL.EntityModels;

namespace DCRWebApi.Seeding
{
    public class DataSeeder
    {
        private readonly EMS_ITCContext _context;

        public DataSeeder(EMS_ITCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
        if (!_context.Roles.Any()) 
            {
                var role = new List<Role>()
                {
                new Role()
                {
                  RoleName = "Admin",
                  RoleDescription = "Admin"
                },
                new Role()
                {
                    RoleName = "HR",
                    RoleDescription = "HR"
                }, 
                new Role()
                {
                 RoleName = "User",
                 RoleDescription = "User"
                }

                };

                _context.Roles.AddRange(role);
                _context.SaveChanges();

            }
        }
    }
}
