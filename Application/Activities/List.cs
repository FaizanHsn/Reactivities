using System.Data.Entity;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class List
    {
            public class Query : IRequest<List<Activity>>{ }
            public class Handler : IRequestHandler<Query, List<Activity>>
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;
                }
                public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var activities = await _context.Activities.ToListAsync(); // Make sure _context.Activities is from DbContext
                    return activities;
                }
            }
    }

}