using System.Net;
using System.Text.Json.Serialization;

namespace Jubo.Application.Models.Results
{
    public class ApiResult
    {
        public ApiResult()
        {
            Code = (int)HttpStatusCode.OK;
        }

        /// <summary>
        /// HttpStatusCode
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        public void SetCodeAndMessage(HttpStatusCode httpStatusCode)
        {
            Code = (int)httpStatusCode;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return (HttpStatusCode)Code;
        }
    }

    public class ApiResult<TModel> : ApiResult
    {
        public ApiResult()
        {
        }

        public ApiResult(TModel? data)
        {
            Data = data;
        }

        /// <summary>
        /// Api response data
        /// </summary>
        [JsonPropertyName("data")]
        public TModel? Data { get; set; }
    }
}