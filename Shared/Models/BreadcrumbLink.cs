namespace WRMC.Core.Shared.Models
{
    public class MyBreadcrumbItem
    {
        public MyBreadcrumbItem(string title, string? icon = null, string? address = null)
        {
            Address = address;
            Title = title;
            Icon = icon;
        }

        public int OrderIndex { get; set; }
        public string? Address { get; set; }
        public string? Title { get; set; }
        public bool IsActive => !string.IsNullOrWhiteSpace(Address);
        public string? Icon { get; set; }
    }

}
