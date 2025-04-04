

namespace ThoughtCatcher.Core.Models
{
    public class Thought
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
