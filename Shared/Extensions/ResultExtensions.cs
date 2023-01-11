using Newtonsoft.Json;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Shared.Extensions
{
    public static class ResultExtensions
    {
        public static async Task<IResult<T>> ToResult<T>(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Result<T>>(responseAsString);
            if (responseObject == null)
            {
                return new Result<T>();
            }
            return responseObject;
        }
        public static async Task<T> ToApiResult<T>(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(responseAsString);
            return responseObject;
        }



        public static async Task<IResult> ToResult(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Result<IResult>>(responseAsString);
            return responseObject;
        }

        public static async Task<PagedResult<T>> ToPaginatedResult<T>(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<PagedResult<T>>(responseAsString);
            return responseObject;
        }
    }
}
