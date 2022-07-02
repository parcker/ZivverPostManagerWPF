using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZivverServiceProvider.JsonPostService;

namespace ZivverDeskTopUI.ViewModels
{
    public class PostViewModel
    {
        private readonly IJsonPlaceHolderService jsonPlaceHolderService;

        public PostViewModel(IJsonPlaceHolderService jsonPlaceHolderService)
        {
            this.jsonPlaceHolderService = jsonPlaceHolderService;
        }
    }
}
