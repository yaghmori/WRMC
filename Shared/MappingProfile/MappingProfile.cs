using AutoMapper;
using Newtonsoft.Json;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap(typeof(PagedList<>), typeof(IPagedList<>)).ReverseMap();
            //==========================================================================
            CreateMap<CultureResponse, Culture>().ReverseMap();
            //==========================================================================
            CreateMap<AppSettingsResponse, AppSetting>().ReverseMap();
            //==========================================================================
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap()
                //Computed
                .ForMember(dest => dest.ClaimsCount, opt => opt.MapFrom(src => src.UserClaims.Count))
                .ForMember(dest => dest.SessionsCount, opt => opt.MapFrom(src => src.UserSessions.Count))
                .ForMember(dest => dest.RolesCount, opt => opt.MapFrom(src => src.UserRoles.Count))
                .ForMember(dest => dest.ImagesCount, opt => opt.MapFrom(src => src.UserImages.Count))
                .ForMember(dest => dest.AddressesCount, opt => opt.MapFrom(src => src.UserAddresses.Count))
                .ForMember(dest => dest.PhoneNumbersCount, opt => opt.MapFrom(src => src.UserPhoneNumbers.Count));
            CreateMap<User, RegisterRequest>().ReverseMap();/*.ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()));*/
            CreateMap<UserResponse, UserRequest>().ReverseMap();
            CreateMap<User, NewUserRequest>().ReverseMap();
            CreateMap<UserProfileRequest, UserResponse>().ReverseMap(); //TODO : resolve flattening mapping
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                ////Userprofile
                //.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.UserProfile.BirthDate))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.UserProfile.Description))
                //.ForMember(dest => dest.EmergencyName, opt => opt.MapFrom(src => src.UserProfile.EmergencyName))
                //.ForMember(dest => dest.EmergencyPhone, opt => opt.MapFrom(src => src.UserProfile.EmergencyPhone))
                //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserProfile.FirstName))
                //.ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.UserProfile.Height))
                //.ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.UserProfile.Weight))
                //.ForMember(dest => dest.IdNumber, opt => opt.MapFrom(src => src.UserProfile.IdNumber))
                //.ForMember(dest => dest.IntroMethodDescription, opt => opt.MapFrom(src => src.UserProfile.IntroMethodDescription))
                //.ForMember(dest => dest.IntroMethodId, opt => opt.MapFrom(src => src.UserProfile.IntroMethodId))
                //.ForMember(dest => dest.IntroMethod, opt => opt.MapFrom(src => src.UserProfile.IntroMethod))
                //.ForMember(dest => dest.IsNoticeAccepted, opt => opt.MapFrom(src => src.UserProfile.IsNoticeAccepted))
                //.ForMember(dest => dest.IsVolunteer, opt => opt.MapFrom(src => src.UserProfile.IsVolunteer))
                //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.UserProfile.LastName))
                //.ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.UserProfile.MiddleName))
                //.ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.UserProfile.ProfileImage))
                //.ForMember(dest => dest.RaceNationality, opt => opt.MapFrom(src => src.UserProfile.RaceNationality))
                //.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.UserProfile.Gender));

            CreateMap<UserProfileResponse, UserResponse>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IntroMethod, opt => opt.MapFrom(src => src.UserProfile.IntroMethod))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.UserProfile.BirthDate));
            //==========================================================================
            CreateMap<UserRoleResponse, UserRole>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name));
            //==========================================================================
            CreateMap<BaseUserResponse, UserRole>().ReverseMap() //TODO : Resolve flattening
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.User.UserProfile.Description))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.UserProfile.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.UserProfile.LastName))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.User.UserProfile.ProfileImage))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber));
            //==========================================================================
            CreateMap<ClaimResponse, UserClaim>().ReverseMap();
            CreateMap<ClaimRequest, UserClaim>().ReverseMap();

            CreateMap<ClaimRequest, RoleClaim>().ReverseMap();
            CreateMap<ClaimResponse, RoleClaim>().ReverseMap();
            //==========================================================================
            CreateMap<UserSettingResponse, UserSetting>().ReverseMap();
            CreateMap<UserSettingRequest, UserSetting>().ReverseMap();
            CreateMap<UserSettingRequest, UserSettingResponse>().ReverseMap();
            //==========================================================================
            CreateMap<UserProfileResponse, UserProfile>().ReverseMap();
            CreateMap<UserProfileRequest, UserProfile>().ReverseMap();
            CreateMap<UserProfileRequest, UserProfileResponse>().ReverseMap();
            //==========================================================================
            CreateMap<IntroMethodResponse, IntroMethod>().ReverseMap();
            CreateMap<IntroMethodRequest, IntroMethod>().ReverseMap();
            CreateMap<IntroMethodRequest, IntroMethodResponse>().ReverseMap();
            //==========================================================================
            CreateMap<UserAttachmentResponse, UserAttachment>().ReverseMap();
            CreateMap<UserAttachmentRequest, UserAttachment>().ReverseMap();
            CreateMap<UserAttachmentRequest, UserAttachmentResponse>().ReverseMap();
            //==========================================================================
            CreateMap<UserPhoneNumberResponse, UserPhoneNumber>().ReverseMap();
            CreateMap<UserPhoneNumberRequest, UserPhoneNumber>().ReverseMap();
            CreateMap<UserPhoneNumberRequest, UserPhoneNumberResponse>().ReverseMap();
            //==========================================================================
            CreateMap<UserAddressResponse, UserAddress>().ReverseMap();
            CreateMap<UserAddressRequest, UserAddress>().ReverseMap();
            CreateMap<UserAddressResponse, UserAddressRequest>()
                .ForMember(dest => dest.SelectedCity, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.SelectedState, opt => opt.MapFrom(src => src.Region.Parent));
            //==========================================================================
            CreateMap<RegionResponse, Region>().ReverseMap()
                .ForPath(dest => dest.Parent.Regions, opt => opt.Ignore())
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent)).MaxDepth(2)
                .ForMember(dest => dest.UserAddressesCount, opt => opt.MapFrom(src => src.UserAddresses.Count));
            CreateMap<RegionRequest, Region>().ReverseMap();
            CreateMap<RegionRequest, RegionResponse>().ReverseMap();
            //==========================================================================
            CreateMap<MedicalIntakeResponse, MedicalIntake>().ReverseMap()
                .ForMember(dest => dest.Symptoms, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<SymptomsEnum>>(src.Symptoms)))
                .ForMember(dest => dest.StdTypes, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<STDTypesEnum>>(src.StdTypes)))
                .ForMember(dest => dest.DrugFrequency, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<DrugFrequencyResponse>>(src.DrugFrequency)));

            CreateMap<MedicalIntake, MedicalIntakeRequest>().ReverseMap()
                .ForMember(dest => dest.Symptoms, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Symptoms)))
                .ForMember(dest => dest.StdTypes, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.StdTypes)))
                .ForMember(dest => dest.DrugFrequency, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.DrugFrequency)));
            CreateMap<MedicalIntakeResponse, MedicalIntakeRequest>().ReverseMap();
            //TODO : Define Mapping
            //==========================================================================
            CreateMap<DemographicIntakeResponse, DemographicIntake>().ReverseMap();
            CreateMap<DemographicIntake, DemographicIntakeRequest>()
                .ForMember(d => d.FinancialIntake, opt => opt.MapFrom(src => src))
                .ForMember(d => d.ResidentialIntake, opt => opt.MapFrom(src => src))
                .ForMember(d => d.OtherDemographicIntake, opt => opt.MapFrom(src => src)).ReverseMap();//Flattening / Unflattening
            CreateMap<DemographicIntakeResponse, DemographicIntakeRequest>()
                .ForMember(d => d.FinancialIntake, opt => opt.MapFrom(src => src))
                .ForMember(d => d.ResidentialIntake, opt => opt.MapFrom(src => src))
                .ForMember(d => d.OtherDemographicIntake, opt => opt.MapFrom(src => src)).ReverseMap(); //Flattening / Unflattening


            CreateMap<DemographicIntake, ResidentialIntakeRequest>().ReverseMap();
            CreateMap<DemographicIntake, FinancialIntakeRequest>().ReverseMap();
            CreateMap<DemographicIntake, OtherDemographicIntakeRequest>().ReverseMap();

            CreateMap<DemographicIntakeResponse, ResidentialIntakeRequest>().ReverseMap();
            CreateMap<DemographicIntakeResponse, FinancialIntakeRequest>().ReverseMap();
            CreateMap<DemographicIntakeResponse, OtherDemographicIntakeRequest>().ReverseMap();

            CreateMap<DemographicIntakeRequest, ResidentialIntakeRequest>().ReverseMap();
            CreateMap<DemographicIntakeRequest, FinancialIntakeRequest>().ReverseMap();
            CreateMap<DemographicIntakeRequest, OtherDemographicIntakeRequest>().ReverseMap();
            //===========================================================================
            CreateMap<UserSessionResponse, UserSession>().ReverseMap();
            CreateMap<SessionResponse, UserSession>().ReverseMap();
            //===========================================================================
            //==========================================================================
            CreateMap<RoleResponse, Role>().ReverseMap()
                .ForMember(dest => dest.ClaimCount, opt => opt.MapFrom(src => src.RoleClaims.Count))
                .ForMember(dest => dest.UsersCount, opt => opt.MapFrom(src => src.UserRoles.Count));
            CreateMap<RoleRequest, Role>().ReverseMap();
            CreateMap<RoleRequest, RoleResponse>().ReverseMap();
            //==========================================================================
            CreateMap<CaseRequest, Case>().ReverseMap();
            CreateMap<CaseResponse, Case>().ReverseMap()
            .ForPath(dest => dest.Visits, opt => opt.Ignore());//TODO : Resolve mapping cycle

            CreateMap<CaseResponse, Case>().ReverseMap();
            CreateMap<CaseRequest, CaseResponse>().ReverseMap();

            //==========================================================================
            CreateMap<VisitResponse, Visit>().ReverseMap()
                 .ForPath(dest => dest.Case.Visits, opt => opt.Ignore())//TODO : Resolve mapping cycle
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
            CreateMap<VisitRequest, Visit>().ReverseMap();
            CreateMap<VisitRequest, VisitResponse>().ReverseMap();
            //==========================================================================
            CreateMap<SectionRequest, Section>().ReverseMap();
            CreateMap<Section, SectionResponse>().ReverseMap();
            CreateMap<SectionRequest, SectionResponse>().ReverseMap();
            //==========================================================================
            CreateMap<TaskRequest, Tasks>().ReverseMap();
            CreateMap<TaskRequest, TaskResponse>().ReverseMap();
            CreateMap<TaskResponse, Tasks>().ReverseMap();
            CreateMap<VisitResponse, Tasks>().ReverseMap();//Flatten and Unflattn using ReverseMapp 



        }

        private static List<short> ConvertToList(string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                return new List<short>();
            }

            return str.Split(',').Select(short.Parse).ToList();

        }

    }
}
