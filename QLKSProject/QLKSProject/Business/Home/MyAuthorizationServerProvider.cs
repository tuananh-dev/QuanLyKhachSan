using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace QLKSProject.Business
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            context.Validated();
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            using (UserMasterRepository _repo = new UserMasterRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null || user.IsDelete)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim("Email", user.UserEmailID));
                identity.AddClaim(new Claim("FullName", user.FullName));
                identity.AddClaim(new Claim("UserRoles", user.UserRoles));
                identity.AddClaim(new Claim("MaDoan", user.MaDoan));
                context.Validated(identity);

            }
        }
    }
}