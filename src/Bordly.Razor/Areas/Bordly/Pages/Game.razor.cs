using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.Razor.Areas.Bordly.Pages
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