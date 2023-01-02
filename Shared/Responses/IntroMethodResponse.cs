using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class IntroMethodResponse
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public virtual TreeTypeEnum? Type { get; set; }
        public short? Order { get; set; }
        public string? Name { get; set; }
        public string? DisplayTitle { get; set; }
        public string? Description { get; set; }
        public bool AdditionalInfoRequired { get; set; }
        public string AdditionalInfoLabel { get; set; }
        public bool IsExpanded { get; set; }
        public bool HasChild => IntroMethods.Count > 0;
        public string? Path { get; set; }
        
        public string Icon
        {
            get
            {
                switch (Type)
                {
                    case TreeTypeEnum.Root:
                        return "fad fa-folders text-warning";
                    case TreeTypeEnum.Node:
                        return "fad fa-folders text-warning";
                    default:
                        return "far fa-window-maximize text-primary";//leaf
                }
            }
        }
        public string Color
        {
            get
            {
                switch (Type)
                {
                    case TreeTypeEnum.Leaf:
                        return "text-primary";
                    default:
                        return "";
                }
            }
        }

        public virtual ICollection<IntroMethodResponse> IntroMethods { get; set; } = new List<IntroMethodResponse>();
    }
}
