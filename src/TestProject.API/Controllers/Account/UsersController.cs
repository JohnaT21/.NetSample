using AutoMapper;
using TestProject.API.Controllers;
using TestProject.Core.Interfaces;
using TestProject.Data.Enums;
using TestProject.DTO.Account;
using TestProject.Services.Account.User;
using TestProject.Validators.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.API.Controllers
{
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            IResponseDTO responseDTO,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(responseDTO, httpContextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IResponseDTO> GetAllUsers( [FromQuery] UserFilterDto filterDto = null)
        {
            _response = await _userService.GetAllUsers( filterDto);
            return _response;
        }
        // [Authorize]
        // [HttpGet("ByRole")]
        // public async Task<IResponseDTO> GetUserByRole(int? pageIndex = null, int? pageSize = null, string? role=null)
        // {
        //     _response = await _userService.GetUsersByRole(LoggedInOrgUnitId, role,  pageIndex, pageSize);
        //     return _response;
        // }

       
        // [Authorize]
        // [HttpGet("{id}")]
        // public async Task<IResponseDTO> GetUserDetails(Guid id)
        // {
        //     _response = await _userService.GetUserDetails(ServerRootPath, id);
        //     return _response;
        // }

        // [Authorize(Roles = "SuperAdmin,Admin")]
        // [Authorize]
        // [HttpPost]
        // public async Task<IResponseDTO> CreateUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        // {
        //     // var userDto = _mapper.Map<UserDto>(userForRegistrationDto);
        //     // // validate the user
        //     // var validationResult = await (new UserValidator()).ValidateAsync(userDto);
        //     // if (!validationResult.IsValid)
        //     // {
        //     //     _response.IsPassed = false;
        //     //     _response.Message = string.Join(",\n\r", validationResult.Errors.Select(e => e.ErrorMessage));
        //     //     _response.Data = null;
        //     //     return _response;
        //     // }
        //
        //     // // Set variables by the system
        //     // userDto.CreatedBy = LoggedInUserId;
        //     // userDto.CreatedOn = DateTime.Now;
        //     // userDto.Status = UserStatusEnum.Active.ToString();
        //
        //     var result = await _userService.Register(userForRegistrationDto);
        //
        //     return result;
        // }
        //
        // // [Authorize(Roles = "SuperAdmin,Admin")]
        // [Authorize]
        // [HttpPut("{id}")]
        // public async Task<IResponseDTO> UpdateUser(Guid id,[FromBody] UserForUpdateDto userForUpdateDto)
        // {
        //     // var userDto = _mapper.Map<UserDto>(userForUpdateDto);
        //     // // validate the user
        //     // var validationResult = await (new UserValidator()).ValidateAsync(userDto);
        //     // if (!validationResult.IsValid)
        //     // {
        //     //     _response.IsPassed = false;
        //     //     _response.Message = string.Join(",\n\r", validationResult.Errors.Select(e => e.ErrorMessage));
        //     //     _response.Data = null;
        //     //     return _response;
        //     // }
        //
        //     // Set variables by the system
        //     // userForUpdateDto.UpdatedBy = LoggedInUserId;
        //     // userDto.UpdatedOn = DateTime.Now;
        //
        //     var result = await _userService.UpdateUser(id, userForUpdateDto);
        //     return result;
        // }
        //
        // // [Authorize]
        // // [HttpPut("statuses/{id}")]
        // // public async Task<IResponseDTO> UpdateUserStatus(Guid id, [FromBody] ChangeUserStatusParamsDto changeUserStatusParamsDto)
        // // {
        // //     if (changeUserStatusParamsDto?.Status != UserStatusEnum.Active.ToString() &&
        // //         changeUserStatusParamsDto?.Status != UserStatusEnum.Locked.ToString() &&
        // //         changeUserStatusParamsDto?.Status != UserStatusEnum.NotActive.ToString())
        // //     {
        // //         _response.IsPassed = false;
        // //         _response.Message = "Invalid status value";
        // //         return _response;
        // //     }
        // //     if (changeUserStatusParamsDto?.Status == UserStatusEnum.Locked.ToString())
        // //     {
        // //         _response.IsPassed = false;
        // //         _response.Message = "You can not lock the user account, only the system can";
        // //         return _response;
        // //     }
        // //
        // //     _response = await _userService.UpdateUserStatus(LoggedInUserId, id, changeUserStatusParamsDto.Status);
        // //     return _response;
        // // }
        // //
    }
}
