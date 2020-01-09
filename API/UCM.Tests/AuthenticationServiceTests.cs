using System;
using Xunit;
using UCM.Business;
using UCM.Business.Generics;
using UCM.Business.Authentication;
using UCM.Business.Student;
using UCM.Business.Helpers;
using AutoMapper;
using UCM.Api;
using UCM.Persistance;

namespace UCM.Tests
{
    public class AuthenticationServiceTests
    {
        [Fact]
        public void Authenticate_WrongUsernameGoodPassword_ShouldReturnNull()
        {
            //Arrange
            var genericRepository = new CampusManagementContext(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            var passwordHasher = new PasswordHasher();
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            var mapper = config.CreateMapper();

            var appSettings = Configuration.GetSection("AppSettings");

            var authService = new AuthenticationService(genericRepository, passwordHasher, mapper, appSettings);
            //Act
            //Assert
        }
    }
}
