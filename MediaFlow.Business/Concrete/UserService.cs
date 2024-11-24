using MediaFlow.Business.Abstract;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.Entities.DTOs;
using MediaFlow.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MediaFlow.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IConfiguration _configuration;

        public UserService(IUserDal userDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _configuration = configuration;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            // Check if username is already taken
            var existingUser = await _userDal.Get(u => u.Username == registerDto.Username);
            if (existingUser != null) return false;

            // Hash password
            CreatePasswordHash(registerDto.Password, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = registerDto.Email
            };

            await _userDal.Add(user);
            return true;
        }

        public async Task<string?> Login(LoginDto loginDto)
        {
            var user = await _userDal.Get(u => u.Username == loginDto.Username);
            if (user == null || !VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            // Generate JWT Token after successful login
            var token = GenerateJwtToken(user);

            return token;
        }

        public async Task<bool> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = await _userDal.Get(u => u.UserId == userId);
            if (user == null || !VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
                return false;

            CreatePasswordHash(newPassword, out var newHash, out var newSalt);
            user.PasswordHash = newHash;
            user.PasswordSalt = newSalt;
            await _userDal.Update(user);

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                // Generate a random salt
                passwordSalt = hmac.Key;

                // Compute the hash using the salt
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Convert string to byte[]
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                // Compute the hash of the provided password with the stored salt
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Convert string to byte[]

                // Compare the computed hash with the stored hash
                return computedHash.SequenceEqual(storedHash);
            }
        }

        // Generate JWT token
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                // Add more claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Set expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
