using System.Net;

namespace Application.Common;

public class CqrsResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public ICollection<string> ErrorMessages { get; set; }
}