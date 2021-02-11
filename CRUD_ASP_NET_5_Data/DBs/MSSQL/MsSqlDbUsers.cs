using CRUD_ASP_NET_5_Data.Interfaces;
using CRUD_ASP_NET_5_Shared.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CRUD_ASP_NET_5_Data.DBs.MSSQL
{
    internal class MsSqlDbUsers : IDbUsers
    {
        #region Objects

        private Configurations configurations;

        #endregion

        #region Constructors
        public MsSqlDbUsers(Configurations configurations)
        {
            this.configurations = configurations;
        }

        #endregion

        #region Get Users
        public List<Users> GetUsers()
        {
            string query = @"SELECT [Id]
                                   ,[Nome]
                                   ,[Email]
                                   ,[CPF]
                               FROM [dbo].[Users]";

            using (IDbConnection con = new SqlConnection(configurations.ConnectionStringDB))
            {
                return con.Query<Users>(query).ToList();
            }
        }


        #endregion

        #region Save User
        public bool SaveUser(Users user)
        {
            string query = @"INSERT INTO [dbo].[Users]
                                        ([Nome]
                                        ,[Email]
                                        ,[CPF])
                                  VALUES
                                        (@Nome
                                        ,@Email
                                        ,@CPF)";

            using (IDbConnection con = new SqlConnection(configurations.ConnectionStringDB))
            {
                return Convert.ToBoolean(con.Execute(query, 
                    new 
                    { 
                        user.Nome,
                        user.Email,
                        user.CPF
                    }));
            }
        }

        #endregion
    }
}
