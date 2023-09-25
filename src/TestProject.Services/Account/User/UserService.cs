using AutoMapper;
using TestProject.Core.Common;
using TestProject.Core.Interfaces;
using TestProject.Data.DataContext;
using TestProject.Data.DbModel.AccountSchema;
using TestProject.DTO.Account;
using TestProject.Repositories.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TestProject.Data.Enums;
using TestProject.Repositories.Account.User;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using TestProject.Services.Generics;

namespace TestProject.Services.Account.User;

public class UserService : GService<UserDto, ApplicationUser, IUserRepository>, IUserService
{
    private readonly IMapper _mapper;

    private readonly RoleManager<ApplicationRole> _roleManager;

    //private readonly ICustomerRepository _customerRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly IResponseDTO _response;
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;


    public UserService(
        IUnitOfWork<AppDbContext> unitOfWork,
        IMapper mapper,
        UserManager<ApplicationUser> userManager,
        IResponseDTO responseDTO,
        IUserRepository userRepository,
        RoleManager<ApplicationRole> roleManager
    ) : base(userRepository, mapper)
    {
        _mapper = mapper;
        _roleManager = roleManager;
        _userManager = userManager;
        _response = responseDTO;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IResponseDTO> GetAllUsers(UserFilterDto filterDto = null)
    {
        try
        {


    // var appUsers = _userRepository.GetAll()
    //         .Include(x=>x.OrganizationUnit)
    //         .Include(x=>x.Department)
    //         .Include(x=>x.UserRoles)
    //         .ThenInclude(x=>x.Role);

    

     string jsonString = @"[
           {
               ""userId"": 1,
               ""id"": 1,
               ""title"": ""sunt aut facere repellat provident occaecati excepturi optio reprehenderit"",
               ""body"": ""quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto""
           },
           {
               ""userId"": 1,
               ""id"": 2,
               ""title"": ""qui est esse"",
               ""body"": ""est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla""
           }
        ]";
    List<MyModel> myModels = JsonConvert.DeserializeObject<List<MyModel>>(jsonString);
    if(!string.IsNullOrEmpty(filterDto.text))
    {
        var response = myModels.Where(x => x.Title.Trim().Contains(filterDto.text.Trim()) || x.Body.Trim().Contains(filterDto.text.Trim()));
        myModels = response.ToList();
    }

            _response.Data = new
            {
                List = myModels.ToList()
            };


            _response.Message = "Ok";
            _response.IsPassed = true;
        }
        catch (Exception ex)
        {
            _response.Data = null;
            _response.Message = "Error " + ex.Message;
            _response.IsPassed = false;
        }

        return _response;
    }

   
    public async Task<IResponseDTO> GetUserDetails(string rootPath, Guid userId)
    {
        var appUser =  _userManager.Users.Where(x => x.Id == userId).
            Include(x=>x.UserRoles).ThenInclude(x=>x.Role).FirstOrDefault();
        var userDetailsDto = _mapper.Map<UserDto>(appUser);

        // userDetailsDto.UserRoles = _accountService.GetRoleCollection(appUser.Id);
        // userDetailsDto.Roles = _accountService.getRoleDtos(appUser.Id);
        //
        // userDetailsDto.OrganizationUnit = _organizationUnitRepository.GetAll()
        //         .Where(x=>x.Id == userDetailsDto.OrganizationUnitId).FirstOrDefault();

        _response.IsPassed = true;
        _response.Data = userDetailsDto;
        return _response;
    }

   
   

    public async Task<IResponseDTO> GetUserDetails2(string rootPath, Guid userId)
    {
        var appUser = await _userManager.FindByIdAsync("" + userId);
        //var id = appUser.CustomerID;
        var userDetailsDto = _mapper.Map<UserDto>(appUser);
        // userDetailsDto.UserRoleLevels = new List<Guid>();

        for (int i = 0; i < appUser.UserRoles.Count; i++)
        {
            var roleId = appUser.UserRoles.ElementAt(i).RoleId;
            // userDetailsDto.UserRoleLevels.Add(roleId);

        }
        //if (!string.IsNullOrEmpty(userDetailsDto.PersonalImagePath))
        //{
        //    userDetailsDto.PersonalImagePath = rootPath + userDetailsDto.PersonalImagePath;
        //}
        //if (userDetailsDto.CustomerId == null  )
        //{
        //    var customer = _customerRepository.GetFirstOrDefault(x => x.Email == appUser.Email);
        //    if(customer !=null)
        //        userDetailsDto.CustomerId = customer.Id;
        //}
        _response.IsPassed = true;
        _response.Data = userDetailsDto;
        return _response;
    }

    public async Task<IResponseDTO> GetUserByEmailAsync(string email )
    {
        var appUser = new ApplicationUser();
        try
        {
            appUser= await _userManager.FindByEmailAsync(email);

            _response.IsPassed = true;
            _response.Data = appUser;
        }
        catch (Exception Ex)
        {
            _response.IsPassed = false;
            _response.Data = null;
        }

        return _response;
    }


    public async Task<IResponseDTO> GetUserEmails(Guid? userId, Guid? facilityId, Guid? customerId, ApplicationRolesEnum rolesEnum)
    {
        IQueryable<ApplicationUser> appUsers = _userManager.Users;



        var appUser = new List<ApplicationUser>();
        List<string> EmailList = new List<string>();


        // Filtering

        if (userId > null && userId != null)
        {
            appUser.Add(await _userManager.FindByIdAsync("" + userId));
        }
        //if (facilityId > null && facilityId != null)
        //{
        //    appUser = appUsers.Where(x => x.HealthFacilityId == facilityId && x.UserRoles.Any(r => r.RoleId == (Guid)rolesEnum)).ToList();
        //}
        //if (customerId > null && customerId != null)
        //{
        //    appUser = appUsers.Where(x => x.CustomerID == customerId && x.UserRoles.Any(r => r.RoleId == (Guid)rolesEnum)).ToList();
        //}

        // adding emails to the list
        foreach (var value in appUser)
        {
            EmailList.Add(value.Email);
        }

        _response.IsPassed = true;
        _response.Data = EmailList;

        return _response;
    }
    public async Task<IResponseDTO> GetUserPhoneNumbers(Guid? userId, Guid? facilityId, Guid? customerId, ApplicationRolesEnum rolesEnum)
    {
        IQueryable<ApplicationUser> appUsers = _userManager.Users;



        var appUser = new List<ApplicationUser>();
        List<string> EmailList = new List<string>();


        // Filtering

        if (userId > null && userId != null)
        {
            appUser.Add(await _userManager.FindByIdAsync("" + userId));
        }
        //if (facilityId > null && facilityId != null)
        //{
        //    appUser = appUsers.Where(x => x.HealthFacilityId == facilityId && x.UserRoles.Any(r => r.RoleId == (Guid)rolesEnum)).ToList();
        //}
        //if (customerId > 0 && customerId != null)
        //{
        //    appUser = appUsers.Where(x => x.CustomerID == customerId && x.UserRoles.Any(r => r.RoleId == (Guid)rolesEnum)).ToList();
        //}

        // adding emails to the list
        foreach (var value in appUser)
        {
            if(value.PhoneNumber!=null) EmailList.Add(value.PhoneNumber);
        }

        _response.IsPassed = true;
        _response.Data = EmailList;

        return _response;
    }
    public async Task<IResponseDTO> CreateUser(Guid? loggedInUserId, bool isAdmin, UserDto userDto)
    {
        try
        {
            // var config = _configurationRepository.GetFirst();

            // Generate user password
            // userDto.Password = GeneratePassword();

            var appUser = _mapper.Map<ApplicationUser>(userDto);
            var customerUser = new ApplicationUser();
            if (isAdmin)
            {
                customerUser = await _userManager.FindByIdAsync(loggedInUserId.ToString());
                //var customer = _customerRepository.GetFirstOrDefault(x => x.Email == customerUser.Email);
                //appUser.CustomerID = customer.Id;
            }

            appUser.UserName = userDto.Email;
            appUser.ChangePassword = true;
            appUser.EmailVerifiedDate = null;
            
            List<ApplicationUserRole> userRoleList = new List<ApplicationUserRole>();


            // Commit to database
            var finalResult = await _unitOfWork.CommitAsync();
            if (finalResult == null)
            {
                _response.IsPassed = false;
                _response.Message = "Failed to create the user";
                return _response;
            }

            // Token to reset tha pass
            var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
            resetPassToken = WebUtility.UrlEncode(resetPassToken);
            // send email
            if (isAdmin)
            {
                // await _emailService.CreateUserForUser(appUser.Email, customerUser.UserName, appUser.UserName, userDto.UserRoleLevelName, resetPassToken);
                // await _emailService.CreateUserForAdmin(customerUser.Email, customerUser.UserName, appUser.UserName, userDto.UserRoleLevelName);
            }
            else
            {
                // await _emailService.CreateUserForUser(appUser.Email, "SuperAdmin", appUser.UserName, userDto.UserRoleLevelName, resetPassToken);
            }

            _response.IsPassed = true;
            _response.Message = "User is created successfully";
            _response.Data = _mapper.Map<UserDto>(appUser);

        }
        catch (Exception ex)
        {
            _response.Data = null;
            _response.Message = "Error " + ex.Message;
            _response.IsPassed = false;
        }

        return _response;
    }
    public async Task<IResponseDTO> UpdateUser(Guid id, UserForUpdateDto userDto)
    {
        // When Updating Profile => AccountController.UpdateUserProfile
        try
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());

           

            // Update the user props
            var user = _mapper.Map(userDto, appUser);

            var result = await _userManager.UpdateAsync(appUser);

            if (!result.Succeeded)
            {
                _response.IsPassed = false;
                _response.Message = $"Code: {result.Errors.FirstOrDefault().Code}, \n Description: {result.Errors.FirstOrDefault().Description}";
                return _response;
            }

            await _userManager.AddToRolesAsync(user, userDto.Roles);

            var finalResult = await _unitOfWork.CommitAsync();

            // Res
            appUser.UserRoles = null;
            var userResult = _mapper.Map<UserDto>(appUser);
            // userResult.UserRoles = _accountService.GetRoleCollection(appUser.Id);
            // userResult.UserRoles = _accountService.GetRoleCollection(appUser.Id);

            _response.IsPassed = true;
            _response.Message = "Profile is updated successfully";
            _response.Data = userResult;

        }
        catch (Exception ex)
        {
            _response.Data = null;
            _response.Message = "Error " + ex.Message;
            _response.IsPassed = false;
        }

        return _response;
    }
    public async Task<IResponseDTO> UpdateUserStatus(Guid? loggedInUserId, Guid userId, string status)
    {
        try
        {
            bool isUnLocked = false;

            var appUser = await _userManager.FindByIdAsync(userId.ToString());
            if (appUser == null)
            {
                _response.IsPassed = false;
                _response.Message = "User not found";
                return _response;
            }
            if (appUser.Status == status)
            {
                _response.IsPassed = false;
                _response.Message = $"User is already {status}";
                return _response;
            }


            // check if the admin activate or unlock the user
            isUnLocked = appUser.Status == UserStatusEnum.Locked.ToString() ? true : false;

            appUser.Status = status;
            if (status == UserStatusEnum.Active.ToString())
            {
                appUser.AccessFailedCount = 0;
            }

            // Update the user in database
            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded)
            {
                _response.IsPassed = false;
                _response.Message = $"Code: {result.Errors.FirstOrDefault().Code}, \n Description: {result.Errors.FirstOrDefault().Description}";
                return _response;
            }

            // Send email when unlock
            if (status == UserStatusEnum.Active.ToString() && isUnLocked)
            {
                // Token to reset tha pass
                var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                resetPassToken = WebUtility.UrlEncode(resetPassToken);

                appUser.ChangePassword = true;
                await _userManager.UpdateAsync(appUser);

                // send email
                // await _emailService.UnlockUserEmail(appUser.Email, resetPassToken);
            }

            _response.IsPassed = true;
            _response.Message = "Done";
            _response.Data = null;
        }
        catch (Exception ex)
        {
            _response.Data = null;
            _response.Message = "Error " + ex.Message;
            _response.IsPassed = false;
        }

        return _response;
    }

    // Helper Methods
    private string GeneratePassword()
    {
        var options = _userManager.Options.Password;

        int length = options.RequiredLength;

        bool nonAlphanumeric = options.RequireNonAlphanumeric;
        bool digit = options.RequireDigit;
        bool lowercase = options.RequireLowercase;
        bool uppercase = options.RequireUppercase;

        StringBuilder password = new StringBuilder();
        Random random = new Random();

        while (password.Length < length)
        {
            char c = (char)random.Next(32, 126);

            password.Append(c);

            if (char.IsDigit(c))
                digit = false;
            else if (char.IsLower(c))
                lowercase = false;
            else if (char.IsUpper(c))
                uppercase = false;
            else if (!char.IsLetterOrDigit(c))
                nonAlphanumeric = false;
        }

        if (nonAlphanumeric)
            password.Append((char)random.Next(33, 48));
        if (digit)
            password.Append((char)random.Next(48, 58));
        if (lowercase)
            password.Append((char)random.Next(97, 123));
        if (uppercase)
            password.Append((char)random.Next(65, 91));

        var result = Regex.Replace(password.ToString(), @"[^0-9a-zA-Z]+", "$");
        result += RandomString(6);

        return result;
    }
    private string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdrfghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public async Task<IResponseDTO> UpdateBasicCustomerRole(string email, Guid planId)
    {
        // Basic Plan IDs: 2,3,4; Engineer Role ID: 6
        // If Customer's membership is Basic, the customer has Engineer Role
        // If Customer's membership is not Basic, this customer doesn't have the Engineer Role
        try
        {
            var customerUser = await _userManager.FindByEmailAsync(email);
            // if (planId == 2 || planId == 3 || planId == 4)  //Basic Plan
            // {
            //     if (!customerUserRoles.Contains(6))
            //     {
            //         _userRoleRepository.Add(new ApplicationUserRole()
            //         {
            //             UserId = customerUser.Id,
            //             RoleId = 6
            //         });
            //     }
            // }
            // else
            // {
            //     if (customerUserRoles.Contains(6))
            //     {
            //         var oldUserRole = _userRoleRepository.GetAll(x => x.UserId == customerUser.Id && x.RoleId == 6);
            //         _userRoleRepository.RemoveRange(oldUserRole);
            //     }
            //
            // }
            _response.IsPassed = true;
            _response.Message = "Done";
            _response.Data = null;
        }
        catch (Exception ex)
        {
            _response.Data = null;
            _response.Message = "Error " + ex.Message;
            _response.IsPassed = false;
        }

        return _response;
    }


   public async Task<IResponseDTO> Register(UserForRegistrationDto userForRegistration)
    {
        try
        {
            var user = _mapper.Map<ApplicationUser>(userForRegistration);
            
            // Set variables by the system
            // user.CreatedBy = LoggedInUserId;
            user.CreatedOn = DateTime.UtcNow;
           
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                _response.Data = null;
                result.Errors.ToList().ForEach(x => _response.Message += x.Description + "\n");
                _response.IsPassed = false;
                return _response;
            }

            //await _signInManager.SignInAsync(user, isPersistent: false);
            if (!userForRegistration.Roles.Any())
            {
                _response.Data = null;
                _response.Message = "User Created without roles";
                _response.IsPassed = true;
                return _response;
            }
            // Token to verify the email
            // var verifyEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            // verifyEmailToken = WebUtility.UrlEncode(verifyEmailToken);

            // send email
           

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            _response.IsPassed = true;
            _response.Message = "Successfully Registered";
            _response.Data = null;
        }
        catch (Exception ex)
        {
            _response.Data = null;
            _response.Message = "Error " + ex.Message;
            _response.IsPassed = false;
        }

        return _response;
    }

}


