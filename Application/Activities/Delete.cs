using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler(DataContext context) : IRequestHandler<Command>
        {
            public DataContext _Context { get; } = context;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _Context.Activities.FindAsync(request.Id);
                if (activity != null)
                {
                    _Context.Activities.Remove(activity);
                    await _Context.SaveChangesAsync();
                }
                    
                return Unit.Value;
            }
        }
    }
}
