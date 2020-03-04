using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LocalHome.Shared
{
    public class UserLinkJsonReader : IUserLinkJsonReader
    {
        public async Task<List<UserLinkGroup>> GetUserLinksFromFileAsync(string filepath)
        {
            Debug.Assert(filepath != null);
            return GetUserLinksFrom(await File.ReadAllTextAsync(filepath));
        }

        public List<UserLinkGroup> GetUserLinksFrom(string text)
        {
            Debug.Assert(text != null);
            List<UserLinkGroup> result = JsonConvert.DeserializeObject<List<UserLinkGroup>>(text);
            return result;
        }
    }

    public class UserLinkJsonWriter : IUserLinkJsonWriter
    {
        public async Task WriteUserLinksToFileAsync(string filepath, IList<UserLinkGroup> userLinksGroups)
        {
            Debug.Assert(!string.IsNullOrEmpty(filepath));
            Debug.Assert(userLinksGroups != null);

            await File.WriteAllTextAsync(filepath, GetStringFor(userLinksGroups));

        }
        public string GetStringFor(IList<UserLinkGroup> userLinksGroups)
        {
            Debug.Assert(userLinksGroups != null);

            return JsonConvert.SerializeObject(userLinksGroups, Formatting.Indented); ;
        }
    }

}
