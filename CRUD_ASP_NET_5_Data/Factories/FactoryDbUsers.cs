using CRUD_ASP_NET_5_Data.DBs.MSSQL;
using CRUD_ASP_NET_5_Data.Interfaces;
using CRUD_ASP_NET_5_Shared.Models;
using System;

namespace CRUD_ASP_NET_5_Data.Factories
{
    public static class FactoryDbUsers
    {
        public static IDbUsers GetDbUsers(Configurations configurations)
        {
            switch (configurations.TypeDB)
            {
                case CRUD_ASP_NET_5_Shared.Enums.TypeDB.MSSQL:
                    return new MsSqlDbUsers(configurations);
                case CRUD_ASP_NET_5_Shared.Enums.TypeDB.ORACLE:
                case CRUD_ASP_NET_5_Shared.Enums.TypeDB.INFORMIX:
                    throw new NotImplementedException("The database has not been implemented.");
                case CRUD_ASP_NET_5_Shared.Enums.TypeDB.ERROR:
                default:
                    throw new InvalidOperationException("This operation is invalid.");
            }
        }
    }
}
