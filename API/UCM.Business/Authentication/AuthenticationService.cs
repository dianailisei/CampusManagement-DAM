using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UCM.Business.Authentication.Models;
using UCM.Business.Generics;
using UCM.Business.Helpers;
using UCM.Business.Person.Models;

namespace UCM.Business.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IGenericRepository genericRepository,
            IPasswordHasher passwordHasher, IMapper mapper, IOptions<AppSettings> appSettings)
        {

            _genericRepository = genericRepository;
            _appSettings = appSettings.Value;
            _passwordHasher = passwordHasher;
            _mapper = mapper;

        }

        public async Task<IEnumerable<string>> GetRolesByPersonId(Guid personId)
        {
            var result = await _genericRepository.FindAsync<Domain.Entities.Person>(x => x.Id == personId,
                "PersonRoles.Role");
            var person = result.FirstOrDefault();
            var roles = person.PersonRoles.Select(r => r.Role.Name);

            return roles;
        }

        public async Task<TokenDetailsModel> Authenticate(string email, string password)
        {
            var result = await _genericRepository.FindAsync<Domain.Entities.Person>(x => x.Email == email,
                "PersonRoles.Role");
            var person = result.FirstOrDefault();


            if (person == null || !_passwordHasher.PasswordMatches(password, person.Password))
                return null;


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, person.Id.ToString())
            };

            foreach (var personRole in person.PersonRoles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, personRole.Role.Name)
                );
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = tokenHandler.WriteToken(token);

            var tokenDetailsModel = new TokenDetailsModel
            {
                AccessToken = response,
                RefreshToken = null,
                Person = _mapper.Map<PersonDetailsModel>(person),
                PersonRoles = person.PersonRoles.Select(r => r.Role.Name)
            };

            return tokenDetailsModel;
        }
    }
}
