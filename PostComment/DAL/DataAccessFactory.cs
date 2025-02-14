using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Post, int, Post> GetPosts()
        {
            return new PostRepo();
        }
        public static IRepo<Comment, int, Comment> GetComments()
        {
            return new CommentRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static ITokenFeatures<Token> TokenFeatures() {
            return new TokenRepo();
        }

    }
}
