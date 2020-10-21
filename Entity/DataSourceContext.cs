using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace alsideeq_bookstore_api.Entity
{
    public class DataSourceContext : DbContext
    {
        public DataSourceContext() : base(DataSourceConnectionString.GetRDSConnectionString())
        {

        }

        public static DataSourceContext Create()
        {
            return new DataSourceContext();
        }
        
    }
}