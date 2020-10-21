
using alsideeq_bookstore_api.DTOs;
using System.Data.Entity;
 using System.Data.Entity.Core.Objects;
 using System.Data.Entity.Infrastructure;
using System.Linq;
 using System;


namespace alsideeq_bookstore_api.Entity
{
    public partial class EntityCustomers : DbContext
    {
        public EntityCustomers() : base()
        {
        }
        public virtual DbSet<Users> Users { get; set; }

        public virtual ObjectResult<Users> GetUsers(Nullable<int> user_id)
        {
            var userIdParameter = user_id.HasValue ? 
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Users>("GetUsers", userIdParameter);
        }
    }
}