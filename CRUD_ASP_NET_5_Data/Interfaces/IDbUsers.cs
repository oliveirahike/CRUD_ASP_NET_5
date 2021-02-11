using CRUD_ASP_NET_5_Shared.Models;
using System.Collections.Generic;

namespace CRUD_ASP_NET_5_Data.Interfaces
{
    public interface IDbUsers
    {
        List<Users> GetUsers();
        bool SaveUser(Users user);
    }
}
