using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {

        internal static List<Region> States = new List<Region> {
            new Region { Id=197 , Name ="Puerto Rico" , OfficialName = null, ParentId = 188 , Iso3="PR" , RegionType=RegionTypeEnum.State},
            new Region { Id=198 , Name ="Massachusetts" , OfficialName = null, ParentId = 188 , Iso3="MA" , RegionType=RegionTypeEnum.State},
            new Region { Id=199 , Name ="Rhode Island" , OfficialName = null, ParentId = 188 , Iso3="RI" , RegionType=RegionTypeEnum.State},
            new Region { Id=200 , Name ="New Hampshire" , OfficialName = null, ParentId = 188 , Iso3="NH" , RegionType=RegionTypeEnum.State},
            new Region { Id=201 , Name ="Maine" , OfficialName = null, ParentId = 188 , Iso3="ME" , RegionType=RegionTypeEnum.State},
            new Region { Id=202 , Name ="Vermont" , OfficialName = null, ParentId = 188 , Iso3="VT" , RegionType=RegionTypeEnum.State},
            new Region { Id=203 , Name ="Connecticut" , OfficialName = null, ParentId = 188 , Iso3="CT" , RegionType=RegionTypeEnum.State},
            new Region { Id=204 , Name ="New York" , OfficialName = null, ParentId = 188 , Iso3="NY" , RegionType=RegionTypeEnum.State},
            new Region { Id=205 , Name ="New Jersey" , OfficialName = null, ParentId = 188 , Iso3="NJ" , RegionType=RegionTypeEnum.State},
            new Region { Id=206 , Name ="Pennsylvania" , OfficialName = null, ParentId = 188 , Iso3="PA" , RegionType=RegionTypeEnum.State},
            new Region { Id=207 , Name ="Delaware" , OfficialName = null, ParentId = 188 , Iso3="DE" , RegionType=RegionTypeEnum.State},
            new Region { Id=208 , Name ="District of Columbia" , OfficialName = null, ParentId = 188 , Iso3="DC" , RegionType=RegionTypeEnum.State},
            new Region { Id=209 , Name ="Virginia" , OfficialName = null, ParentId = 188 , Iso3="VA" , RegionType=RegionTypeEnum.State},
            new Region { Id=210 , Name ="Maryland" , OfficialName = null, ParentId = 188 , Iso3="MD" , RegionType=RegionTypeEnum.State},
            new Region { Id=211 , Name ="West Virginia" , OfficialName = null, ParentId = 188 , Iso3="WV" , RegionType=RegionTypeEnum.State},
            new Region { Id=212 , Name ="North Carolina" , OfficialName = null, ParentId = 188 , Iso3="NC" , RegionType=RegionTypeEnum.State},
            new Region { Id=213 , Name ="South Carolina" , OfficialName = null, ParentId = 188 , Iso3="SC" , RegionType=RegionTypeEnum.State},
            new Region { Id=214 , Name ="Georgia" , OfficialName = null, ParentId = 188 , Iso3="GA" , RegionType=RegionTypeEnum.State},
            new Region { Id=215 , Name ="Florida" , OfficialName = null, ParentId = 188 , Iso3="FL" , RegionType=RegionTypeEnum.State},
            new Region { Id=216 , Name ="Alabama" , OfficialName = null, ParentId = 188 , Iso3="AL" , RegionType=RegionTypeEnum.State},
            new Region { Id=217 , Name ="Tennessee" , OfficialName = null, ParentId = 188 , Iso3="TN" , RegionType=RegionTypeEnum.State},
            new Region { Id=218 , Name ="Mississippi" , OfficialName = null, ParentId = 188 , Iso3="MS" , RegionType=RegionTypeEnum.State},
            new Region { Id=219 , Name ="Kentucky" , OfficialName = null, ParentId = 188 , Iso3="KY" , RegionType=RegionTypeEnum.State},
            new Region { Id=220 , Name ="Ohio" , OfficialName = null, ParentId = 188 , Iso3="OH" , RegionType=RegionTypeEnum.State},
            new Region { Id=221 , Name ="Indiana" , OfficialName = null, ParentId = 188 , Iso3="IN" , RegionType=RegionTypeEnum.State},
            new Region { Id=222 , Name ="Michigan" , OfficialName = null, ParentId = 188 , Iso3="MI" , RegionType=RegionTypeEnum.State},
            new Region { Id=223 , Name ="Iowa" , OfficialName = null, ParentId = 188 , Iso3="IA" , RegionType=RegionTypeEnum.State},
            new Region { Id=224 , Name ="Wisconsin" , OfficialName = null, ParentId = 188 , Iso3="WI" , RegionType=RegionTypeEnum.State},
            new Region { Id=225 , Name ="Minnesota" , OfficialName = null, ParentId = 188 , Iso3="MN" , RegionType=RegionTypeEnum.State},
            new Region { Id=226 , Name ="South Dakota" , OfficialName = null, ParentId = 188 , Iso3="SD" , RegionType=RegionTypeEnum.State},
            new Region { Id=227 , Name ="North Dakota" , OfficialName = null, ParentId = 188 , Iso3="ND" , RegionType=RegionTypeEnum.State},
            new Region { Id=228 , Name ="Montana" , OfficialName = null, ParentId = 188 , Iso3="MT" , RegionType=RegionTypeEnum.State},
            new Region { Id=229 , Name ="Illinois" , OfficialName = null, ParentId = 188 , Iso3="IL" , RegionType=RegionTypeEnum.State},
            new Region { Id=230 , Name ="Missouri" , OfficialName = null, ParentId = 188 , Iso3="MO" , RegionType=RegionTypeEnum.State},
            new Region { Id=231 , Name ="Kansas" , OfficialName = null, ParentId = 188 , Iso3="KS" , RegionType=RegionTypeEnum.State},
            new Region { Id=232 , Name ="Nebraska" , OfficialName = null, ParentId = 188 , Iso3="NE" , RegionType=RegionTypeEnum.State},
            new Region { Id=233 , Name ="Louisiana" , OfficialName = null, ParentId = 188 , Iso3="LA" , RegionType=RegionTypeEnum.State},
            new Region { Id=234 , Name ="Arkansas" , OfficialName = null, ParentId = 188 , Iso3="AR" , RegionType=RegionTypeEnum.State},
            new Region { Id=235 , Name ="Oklahoma" , OfficialName = null, ParentId = 188 , Iso3="OK" , RegionType=RegionTypeEnum.State},
            new Region { Id=236 , Name ="Texas" , OfficialName = null, ParentId = 188 , Iso3="TX" , RegionType=RegionTypeEnum.State},
            new Region { Id=237 , Name ="Colorado" , OfficialName = null, ParentId = 188 , Iso3="CO" , RegionType=RegionTypeEnum.State},
            new Region { Id=238 , Name ="Wyoming" , OfficialName = null, ParentId = 188 , Iso3="WY" , RegionType=RegionTypeEnum.State},
            new Region { Id=239 , Name ="Idaho" , OfficialName = null, ParentId = 188 , Iso3="ID" , RegionType=RegionTypeEnum.State},
            new Region { Id=240 , Name ="Utah" , OfficialName = null, ParentId = 188 , Iso3="UT" , RegionType=RegionTypeEnum.State},
            new Region { Id=241 , Name ="Arizona" , OfficialName = null, ParentId = 188 , Iso3="AZ" , RegionType=RegionTypeEnum.State},
            new Region { Id=242 , Name ="New Mexico" , OfficialName = null, ParentId = 188 , Iso3="NM" , RegionType=RegionTypeEnum.State},
            new Region { Id=243 , Name ="Nevada" , OfficialName = null, ParentId = 188 , Iso3="NV" , RegionType=RegionTypeEnum.State},
            new Region { Id=244 , Name ="California" , OfficialName = null, ParentId = 188 , Iso3="CA" , RegionType=RegionTypeEnum.State},
            new Region { Id=245 , Name ="Hawaii" , OfficialName = null, ParentId = 188 , Iso3="HI" , RegionType=RegionTypeEnum.State},
            new Region { Id=246 , Name ="Oregon" , OfficialName = null, ParentId = 188 , Iso3="OR" , RegionType=RegionTypeEnum.State},
            new Region { Id=247 , Name ="Washington" , OfficialName = null, ParentId = 188 , Iso3="WA" , RegionType=RegionTypeEnum.State},
            new Region { Id=248 , Name ="Alaska" , OfficialName = null, ParentId = 188 , Iso3="AK" , RegionType=RegionTypeEnum.State},
    };
    }
}