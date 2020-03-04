using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalHome.Shared
{
    public interface IUserLinkJsonWriter
    {
        string GetStringFor(IList<UserLinkGroup> userLinks);
        Task WriteUserLinksToFileAsync(string filepath, IList<UserLinkGroup> userLinks);
    }
}