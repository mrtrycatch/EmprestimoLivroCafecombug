using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Infra.Ioc
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("id").Value);
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst("email").Value;
        }
    }
}
