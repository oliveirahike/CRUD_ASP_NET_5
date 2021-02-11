using CRUD_ASP_NET_5_Shared.Enums;
using System;

namespace CRUD_ASP_NET_5_Shared.Models
{
    public class Configurations
    {
        public string ConnectionStringDB { get; set; }
        public string TypeStringDB { get; set; }
        public TypeDB TypeDB { get { return GetTypeDB(TypeStringDB); }}

        private static TypeDB GetTypeDB(string typeDb)
        {
            Enum.TryParse(typeDb, out TypeDB tipoBanco);
            return tipoBanco;
        }
    }
}
