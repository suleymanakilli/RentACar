using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } //Kullanıcı kitlesi
        public string Issuer { get; set; } //İmzalayan
        public int AccessTokenExpiration { get; set; } //Dakika cinsinden yazdığımız için int
        public string SecurityKey { get; set; }
    }
}
