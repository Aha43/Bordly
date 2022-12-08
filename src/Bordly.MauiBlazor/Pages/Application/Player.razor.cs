using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.MauiBlazor.Pages.Application
{
    public partial class Player
    {
        [Inject] PlayerViewController Controller { get; set; }
    }
}