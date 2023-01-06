using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class UserAddressRequest
    {
        //[Required]
        //[Display(Name = "UserAddress_Region", ResourceType = typeof(DisplayResources))]
        public string? RegionId { get; set; }

        [Required]
        public RegionResponse SelectedState { get; set; }
        [Required]
        public RegionResponse SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                RegionId = value?.Id;
            }
        }
        private RegionResponse selectedCity;


        [Required]
        [Display(Name = "UserAddress_AddressType", ResourceType = typeof(DisplayResources))]
        public AddressTypeEnum? AddressType { get; set; }

        [Required]
        [Display(Name = "UserAddress_Address", ResourceType = typeof(DisplayResources))]
        public string Address { get; set; } = default!;

        [Required]
        [Display(Name = "UserAddress_ZipCode", ResourceType = typeof(DisplayResources))]
        public string? ZipCode { get; set; } = default!;


        [Display(Name = "UserAddress_Description", ResourceType = typeof(DisplayResources))]
        public string? Description { get; set; }

        public bool IsDefault { get; set; } = false;
        public int? Order { get; set; }
    }

}
