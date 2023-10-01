using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Beach.GetAllBeaches
{
    public class GetAllBeachesRequest : IRequest<List<GetAllBeachesResponse>>
    {
    }
}
