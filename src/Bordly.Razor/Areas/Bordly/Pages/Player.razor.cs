using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.Razor.Areas.Bordly.Pages
{
    public partial class Player
    {
        [Inject] PlayerViewController Controller { get; set; }
    }
}