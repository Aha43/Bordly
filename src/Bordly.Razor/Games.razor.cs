using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.Razor
{
    public partial class Games
    {
        [Inject] GamesViewController Controller { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Controller.LoadAsync();
        }
    }
}