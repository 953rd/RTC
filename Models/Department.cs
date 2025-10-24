namespace RTC.Models
{
    public class Department
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public int TeamSize { get; set; }
    }
}