namespace HB.MVCAPP2.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public string ImagePath { get; set; }


        public List<Comment> Comments { get; set; }



    }

    public class Comment
    {

        public int BlogId { get; set; }
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
    }
}
