using Study.SehirRehberi.Business.Interfaces;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.Context;
using Study.SehirRehberi.DataAccess.Concrete.EntityFrameworkCore.UnitOfWork;
using Study.SehirRehberi.DataAccess.Interfaces;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Study.SehirRehberi.Business.Concrete
{
    public class AuthManager : GenericManager<User>, IAuthService
    {
        private readonly IUserDal _userDal;
        public AuthManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }
        public async Task<User> Login(string userName, string password)
        {
            var user = await _userDal.GetByFilterAsync(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }

            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) == false)
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userDal.InsertAsync(new User
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            });
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));


        }

        /// <summary>
        /// IsTrue -> UserExists
        /// IsFalse -> UserNonExists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UserExists(string userName)
        {
            var controlledUser = await _userDal.GetByFilterAsync(x => x.UserName == userName);
            if (controlledUser != null)
            {
                return true;
            }
            return false;
        }


    }
}
