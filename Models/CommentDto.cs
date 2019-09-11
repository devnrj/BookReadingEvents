using System;

namespace Models
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}