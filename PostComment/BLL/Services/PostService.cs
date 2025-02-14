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
    public class PostService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<Post, PostCommentDTO>();
                cfg.CreateMap<PostCommentDTO, Post>();
            });
            return new Mapper(config);
        }

        public static List<PostDTO> GetPosts()
        {
            var db = DataAccessFactory.GetPosts();
            var posts = db.ReadAll();
            var mapper = GetMapper();
            return mapper.Map<List<PostDTO>>(posts);
        }
        public static List<PostCommentDTO> GetPostWithComments()
        {
            var db = DataAccessFactory.GetPosts();
            var posts = db.ReadAll();
            var mapper = GetMapper();

            return mapper.Map<List<PostCommentDTO>>(posts); 
        }
        public static PostCommentDTO GetPostWithComments(int id)
        {
            var db = DataAccessFactory.GetPosts();
            var post = db.Read(id);
            var mapper = GetMapper();
            return mapper.Map<PostCommentDTO>(post);
        }


        public static PostDTO GetPost(int id)
        {
            var db = DataAccessFactory.GetPosts();
            var post = db.Read(id);
            var mapper = GetMapper();
            return mapper.Map<PostDTO>(post);
        }
    }
}
