namespace Vivo_Task.Models
{
    public class Notification
    {
        public string SenderName { get; set; }
        public string Title { get; set; }
        public string message { get; set; } 
        public string link { get; set; } 
        public DateTime? Hora {get; set;}
        public bool IsChecked { get; set; } = false;
    }
}
