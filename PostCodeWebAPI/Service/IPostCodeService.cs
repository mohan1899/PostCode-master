using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeWebAPI.Service
{
    public interface IPostCodeService
    {
        /// <summary>
        /// GetPostCodes
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        Task<string> GetPostCodes(string postcode);

        /// <summary>
        /// GetPostCodeDetail
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        Task<string> GetPostCodeDetail(string postcode);
    }
}
