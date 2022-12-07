using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordly.Business.ViewController
{
    public class GameViewController
    {
        private readonly ViewModelFactory _viewModelFactory;


        //public IEnumerable<> 

        public GameViewController(ViewModelFactory viewModelFactory) => _viewModelFactory = viewModelFactory;

        public async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            if (_viewModelFactory.Player != null)
            {

            }
        }

    }

}
