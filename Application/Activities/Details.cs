using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler(DataContext context) : IRequestHandler<Query, Activity>
        {
            public DataContext _Context { get; } = context;

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _Context.Activities.FindAsync(request.Id);
            }
        }
    }
}
