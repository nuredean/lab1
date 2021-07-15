using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Doctors
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Doctor Doctor { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Doctor).SetValidator(new DoctorValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                
                _context.Doctors.Add(request.Doctor);

                if (!(await _context.SaveChangesAsync() > 0))
                {
                    return Result<Unit>.Failure("Failed during doctor creation");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}