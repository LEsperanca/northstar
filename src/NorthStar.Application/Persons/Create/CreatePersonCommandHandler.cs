using NorthStar.Application.Abstractions.Authentication;
using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;
using NorthStar.Domain.People.Repository;

namespace NorthStar.Application.Persons.Create;
internal sealed  class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, Guid>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IPeopleRepository _peopleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonCommandHandler(IAuthenticationService authenticationService, IPeopleRepository peopleRepository, IUnitOfWork unitOfWork)
    {
        _authenticationService = authenticationService;
        _peopleRepository = peopleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        //TO DO
        //verify if user already exists

        var person = Person.Create(request.Name, request.Email);

        var identityId = await _authenticationService.RegisterAsync(
            person, 
            request.Password, 
            cancellationToken);

        person.SetIdentityId(identityId);

        _peopleRepository.Add(person);

        await _unitOfWork.SaveChangesAsync();

        return person.Id;
    }
}
