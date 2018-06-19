using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.DAL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AccountId { get; set; }
        public String Content { get; set; }
        public DateTime CommentTime { get; set; }

        public Comment()
        {
        }

        public Comment(int commentId, int accountId, string content, DateTime commentTime)
        {
            CommentId = commentId;
            AccountId = accountId;
            Content = content;
            CommentTime = commentTime;
        }
        
    }
}