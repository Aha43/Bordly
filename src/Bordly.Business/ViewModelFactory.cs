using Bordly.Specification.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordly.Business
{
    public class ViewModelFactory
    {
        private readonly IGameApi _gameApi;

        public ViewModelFactory(IGameApi gameApi)
        {
            _gameApi = gameApi;
        }

    }

}
