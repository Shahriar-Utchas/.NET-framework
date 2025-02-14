namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.postCmtContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.postCmtContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //for (int i = 0; i < 10; i++)
            //{

            //    context.Users.AddOrUpdate(new EF.Tables.User
            //    {
            //        Uname = "User" + i,
            //        password = "password" + i,
            //        Type = "General"
            //    });

            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    Random rand = new Random();

            //    context.Posts.AddOrUpdate(new EF.Tables.Post
            //    {
            //        Title = "Post" + i,
            //        Description = "Content" + i,
            //        PostedBy = "User-" + rand.Next(1, 11)
            //    });
            //}
            //for (int i = 0; i < 30; i++)
            //{
            //    Random rand = new Random();
            //    context.Comments.AddOrUpdate(new EF.Tables.Comment
            //    {
            //        commentText = "Comment" + i,
            //        CommentBy = "User-" + rand.Next(1, 11),
            //        postID = 10
            //    });
            //}
        }
    }
}
