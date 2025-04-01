using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModel
{
    public  class ConnectionString
    {
        public static string GetConnectionString() 
        {
            string con = "Server=DESKTOP-P1V523F; Database=ERP_ProjectDB; Trusted_Connection=True; TrustServerCertificate=True";
            return con;
        }
    }
}
