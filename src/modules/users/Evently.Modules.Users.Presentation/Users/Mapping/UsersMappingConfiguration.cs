using Evently.Modules.Users.Application.Users.Commands.Register;
using Evently.Modules.Users.Presentation.Users.Requests.Register;
using Mapster;

namespace Evently.Modules.Users.Presentation.Users.Mapping;

public class UsersMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterUserRequest, RegisterUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName);
    }
}