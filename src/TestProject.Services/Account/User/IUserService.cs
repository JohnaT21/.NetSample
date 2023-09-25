using TestProject.Core.Interfaces;
using TestProject.DTO.Account;
using TestProject.Data.Enums;
using TestProject.Repositories.Account.User;
using TestProject.Services.Generics;

namespace TestProject.Services.Account.User;

public interface IUserService : IGService<UserDto, Data.DbModel.AccountSchema.ApplicationUser, IUserRepository>
{
    Task<IResponseDTO> CreateUser(Guid? loggedInUserId, bool isAdmin, UserDto userDto);
    Task<IResponseDTO> GetAllUsers( UserFilterDto filterDto = null);
    // Task<IResponseDTO> GetUsersByRole(Guid? loggedInOrgId, string? role = null,int? pageIndex = null, int? pageSize = null);

    Task<IResponseDTO> GetUserDetails(string rootPath, Guid userId);
    Task<IResponseDTO> Register(UserForRegistrationDto userDto);

    Task<IResponseDTO> UpdateUser(Guid id, UserForUpdateDto userDto);
    Task<IResponseDTO> UpdateUserStatus(Guid? loggedInUserId, Guid userId, string status);
    Task<IResponseDTO> GetUserDetails2(string rootPath, Guid userId);
    Task<IResponseDTO> GetUserByEmailAsync(string email);
    Task<IResponseDTO> GetUserEmails(Guid? userId, Guid? facilityId, Guid? customerId, ApplicationRolesEnum rolesEnum);
    Task<IResponseDTO> GetUserPhoneNumbers(Guid? userId, Guid? facilityId, Guid? customerId, ApplicationRolesEnum rolesEnum);
    Task<IResponseDTO> UpdateBasicCustomerRole(string email, Guid planId);

}
