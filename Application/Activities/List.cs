using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            public Handler(DataContext context)
            {
                _Context = context;
            }

            public DataContext _Context { get; }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _Context.Activities.ToListAsync();
            }
        }
    }
}
