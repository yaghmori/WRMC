namespace WRMC.Core.Shared.Responses
{
    public class AppSettingsResponse
    {
        public string Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool? IsReadOnly { get; set; }
    }
}
