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
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }
        public class Handler(DataContext context) : IRequestHandler<Command>
        {
            public DataContext _Context { get; } = context;
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _Context.Activities.Add(request.Activity);
                await _Context.SaveChangesAsync();

                return Unit.Value;
            }
        }


    }
}
