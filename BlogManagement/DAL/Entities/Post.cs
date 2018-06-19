using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.DAL.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public String Title { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public DateTime DatePost { get; set; }
        public String Content { get; set; }
        public String Image { get; set; }
        public int Like { get; set; }

        public Post()
        {
        }

        public Post(int postId, string title, int categoryId, int accountId, DateTime datePost, string content, string image, int like)
        {
            PostId = postId;
            Title = title;
            CategoryId = categoryId;
            AccountId = accountId;
            DatePost = datePost;
            Content = content;
            Image = image;
            Like = like;
        }

        public IEnumerable<Comment> Comments { get; set; }
    }
}