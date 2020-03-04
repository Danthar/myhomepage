using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalHome.Shared
{
    public interface IUserLinkJsonReader
    {
        List<UserLinkGroup> GetUserLinksFrom(string text);
        Task<List<UserLinkGroup>> GetUserLinksFromFileAsync(string filepath);
    }
}