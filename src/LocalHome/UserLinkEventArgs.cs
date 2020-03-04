using System;
using LocalHome.Shared;
using Microsoft.AspNetCore.Components.Web;

namespace LocalHome
{
    public class UserLinkEventArgs : EventArgs
    {


        public UserLinkEventArgs() { }
        public UserLinkEventArgs(UserLink userLink, string groupname) : this()
        {
            UserLink = userLink;
            Groupname = groupname;
        }

        public UserLink UserLink { get; set; }
        public string Groupname { get; set; }

    }
}
