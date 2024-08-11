using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }
        public class Handler(DataContext context) : IRequestHandler<Query, List<Activity>>
        {
            public DataContext _context { get; } = context;

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}
