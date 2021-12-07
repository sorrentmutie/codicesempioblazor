using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class ProfiloConRuoliIdentityResource
        : IdentityResources.Profile
    {
        public ProfiloConRuoliIdentityResource()
        {
            this.UserClaims.Add(JwtClaimTypes.Role);
            this.UserClaims.Add("fiscalcode");
            this.UserClaims.Add("magazziniere");
            this.UserClaims.Add("contabilita");
        }
    }

    public class MyProfile : IProfileService
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        public MyProfile(UserManager<ApplicationUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject.Identity.Name;
            var user = await _usermanager.FindByNameAsync(subject);


        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }

}
