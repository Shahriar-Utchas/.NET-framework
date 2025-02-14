using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : RepoDB, IRepo<Token, string, Token>, ITokenFeatures<Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }

        public Token Delete(string id)
        {
            var token = Read(id);
            if (token != null)
            {
                db.Tokens.Remove(token);
                db.SaveChanges();
                return token;
            }
            return null;
        }

        public Token isTokenExist(string Uname)
        {
            var exObj = db.Tokens.FirstOrDefault(t => t.Uname == Uname && t.ExpiredAt == null);
            if (exObj != null) return exObj;
            return null;
        }

        public Token Read(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.Tkey.Equals(id));
        }

        public List<Token> ReadAll()
        {
            return db.Tokens.ToList();
        }

        public Token Update(Token obj)
        {
            var token = Read(obj.Tkey);
            if (token != null)
            {
                db.Entry(token).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

    }
}
