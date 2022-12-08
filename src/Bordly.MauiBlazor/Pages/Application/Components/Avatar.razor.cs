using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.MauiBlazor.Pages.Application.Components
{
    public partial class Avatar
    {
        [Inject] PlayerViewController Controller { get; set; }
    }
}