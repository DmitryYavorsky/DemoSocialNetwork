using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Common.Authentication;
using DSN.Common.Types;
using DSN.Identity.Domain;
using DSN.Identity.Repositories;
using DSN.Identity.Validation;
using Microsoft.AspNetCore.Identity;


namespace DSN.Identity.Services
{
    public class IdentityService: IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IJwtHandler _jwtHandler;
        public IdentityService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IClaimsProvider claimsProvider, IJwtHandler jwtHandler)
        {
            _passwordHasher = passwordHasher?? throw new ArgumentNullException(nameof(passwordHasher));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _claimsProvider = claimsProvider?? throw new ArgumentNullException(nameof(claimsProvider));
            _jwtHandler = jwtHandler ?? throw new ArgumentNullException(nameof(jwtHandler));
        }
        public async Task SignUpAsync(Guid id, string email, string password, string role = Role.User)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new DSNException(Codes.EmailInUse, $"Email {email} is already in use");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                role = Role.User;
            }
            user = new User(id,email,role);
            user.SetPassword(password,_passwordHasher);
            var validator = new UserValidator();
            var valid = await validator.ValidateAsync(user);
            if (!valid.IsValid)
            {
                throw new DSNException("User is invalid");
            }
            await _userRepository.AddAsync(user);

        }

        public async Task<JsonWebToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null || !user.ValidatePassword(password, _passwordHasher))
            {
                throw new DSNException(Codes.InvalidCredentials, "Invalid credentials");
            }
            var refreshToken = new RefreshToken(user,_passwordHasher);
            var claims = await _claimsProvider.GetAsync(user.Id);
            var jwt = _jwtHandler.CreateToken(user.Id.ToString("N"), user.Role, claims);
            //jwt.RefreshToken = refreshToken.Token;
            //Add refresh token after
            return jwt;
        }

        public Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
