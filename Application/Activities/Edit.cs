using AutoMapper;
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
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }
        public class Handler(DataContext context, IMapper mapper) : IRequestHandler<Command>
        {
            public DataContext _Context { get; } = context;
            public IMapper _Mapper { get; } = mapper;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _Context.Activities.FindAsync(request.Activity.Id);

                _Mapper.Map(request.Activity, activity);

                await _Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
