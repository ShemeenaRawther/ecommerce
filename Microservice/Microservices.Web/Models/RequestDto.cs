using System.Net.Mime;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AcessToken { get; set; }
        public ContentType ContentType { get; set; }
    }
}
