using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string password)
        {
            var result = DataAccessFactory.AuthData().Authenticate(uname, password);
            if (result)
            {
                var existingToken = DataAccessFactory.TokenFeatures().isTokenExist(uname);

                if (existingToken != null)
                {
                    var cfg = new MapperConfiguration(c => c.CreateMap<Token, TokenDTO>());
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(existingToken);
                }

                // Create a new token if none exists
                var newToken = new Token
                {
                    Uname = uname,
                    Tkey = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                };

                var ret = DataAccessFactory.TokenData().Create(newToken);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => c.CreateMap<Token, TokenDTO>());
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            return null;
        }

        public static bool IsValidateToken(string tkey)
        {
            var token = DataAccessFactory.TokenData().Read(tkey);
            if (token != null && token.ExpiredAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var token = DataAccessFactory.TokenData().Read(tkey);
            if (token != null)
            {
                token.ExpiredAt = DateTime.Now;
                var ret = DataAccessFactory.TokenData().Update(token);
                if (ret != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
