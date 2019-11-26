using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCM.Business.Authentication.Models;

namespace UCM.Business.Authentication
{
    public interface IAuthenticationService
    {
        Task<IEnumerable<string>> GetRolesByPersonId(Guid personId);
        Task<TokenDetailsModel> Authenticate(string email, string password);
    }
}
