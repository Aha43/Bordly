using Bordly.Specification.Domain.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordly.Domain.Param
{
    public class GamesParam : IGamesParam
    {
        public string UsersEmailAddress { get; init; }
    }
}
