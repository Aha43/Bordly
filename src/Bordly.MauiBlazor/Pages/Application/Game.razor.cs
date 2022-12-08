using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Bordly.MauiBlazor;
using Bordly.MauiBlazor.Shared;
using MudBlazor;
using Bordly.Business.ViewController;

namespace Bordly.MauiBlazor.Pages.Application
{
    public partial class Game
    {
        [Parameter] public string Id { get; set; }
        [Inject] GameViewController Controller { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await Controller.LoadAsync(Id);
        }
    }
}