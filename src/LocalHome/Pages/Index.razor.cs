using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LocalHome.Shared;
using LocalHome.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;

namespace LocalHome.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IWebHostEnvironment WebHostEnv { get; set; }
        [Inject]
        public IUserLinkJsonReader UlReader { get; set; }

        public async Task<List<UserLinkGroup>> GetUserLinks()
        {
            string filepath = Path.Combine(WebHostEnv.WebRootPath, "data.json");
            return await UlReader.GetUserLinksFromFileAsync(filepath);
        }

        public async Task<List<UserlinkGroupViewModel>> GetUserLinkViewModels()
        {
            string filepath = Path.Combine(WebHostEnv.WebRootPath, "data.json");
            List<UserLinkGroup> groups = await UlReader.GetUserLinksFromFileAsync(filepath);

            List<UserlinkGroupViewModel> result = new List<UserlinkGroupViewModel>();
            groups.ForEach(ul => result.Add(new UserlinkGroupViewModel { Name = ul.Name, Links = ul.Links.Select(link => new UserLinkViewModel { UserLink = link }).ToList() }));
            return result;
        }

        protected List<UserlinkGroupViewModel> ULinks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ULinks = await GetUserLinkViewModels();
        }

        protected void DoFilter(ChangeEventArgs args)
        {
            //Console.WriteLine($"inside Index.Razor->DoFilter: {args.Value}");
            //string searchText = args.Value as string;

            //if (string.IsNullOrWhiteSpace(searchText))
            //{
            //    // make them all visible
            //    foreach (var ul in ULinks)
            //    {
            //        ul.Hidden = false;
            //    }
            //}
            //else
            //{
            //    foreach (var ul in ULinks)
            //    {
            //        ul.Hidden = !IsMatch(ul.UserLink, searchText);
            //    }
            //}

        }

        protected bool IsMatch(UserLink userLink, string searchText)
        {
            var strtosearch = $"{userLink.Text};{userLink.ImageUrl};{userLink.Url}";
            return strtosearch.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}
