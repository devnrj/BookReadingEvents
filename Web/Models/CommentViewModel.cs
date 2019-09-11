using System;

namespace Web.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public CommentViewModel(int uid,string content,DateTime dateTime)
        {
            UserId = uid;
            Content = content;
            TimeStamp = dateTime;
        }
    }
}