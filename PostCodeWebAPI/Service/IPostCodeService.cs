using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeWebAPI.Service
{
    public interface IPostCodeService
    {
        Task<string> GetPostCodes(string postcode);
        Task<string> GetPostCodeDetail(string postcode);
    }
}
