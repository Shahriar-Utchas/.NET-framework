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
    public class CommentService
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
        public static List<CommentDTO> GetComments()
        {
            var db = DataAccessFactory.GetComments();
            var comments = db.ReadAll();
            var mapper = GetMapper();
            return mapper.Map<List<CommentDTO>>(comments);
        }
        public static CommentDTO GetComment(int id)
        {
            var db = DataAccessFactory.GetComments();
            var comment = db.Read(id);
            var mapper = GetMapper();
            return mapper.Map<CommentDTO>(comment);
        }
    }
}
