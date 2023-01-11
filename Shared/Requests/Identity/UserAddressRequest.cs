using FluentValidation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class UserAddressRequest
    {
        public string? RegionId { get; set; }
        public RegionResponse SelectedState { get; set; }
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
        public AddressTypeEnum? Type { get; set; }
        public string Address { get; set; } = default!;
        public string? ZipCode { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; } = false;
        public int? Order { get; set; }
    }
    public class UserAddressValidator : AbstractValidator<UserAddressRequest>
    {

        public UserAddressValidator()
        {

            RuleFor(x => x.SelectedState).NotEmpty().WithMessage("Selected state is required");
            RuleFor(x => x.SelectedCity).NotEmpty().WithMessage("Selected city is required");
            RuleFor(x => x.Type).NotNull().WithMessage("Type is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip code is required");
        }

    }

}
