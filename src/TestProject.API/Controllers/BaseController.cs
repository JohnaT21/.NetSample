using TestProject.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestProject.DTO.Account;
using TestProject.Services.Account.User;

namespace TestProject.API.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public IResponseDTO _response;
    private IUserService _userService;

    public BaseController(IResponseDTO responseDTO, IHttpContextAccessor httpContextAccessor)
    {
        _response = responseDTO;
        _httpContextAccessor = httpContextAccessor;
    }

    public BaseController(IResponseDTO responseDTO, IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _userService = userService;
        _response = responseDTO;
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? LoggedInUserId
    {
        get
        {
            var userId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;

            if (userId is not null)
            {
                return Guid.Parse(userId);
            }
            return null;
        }
    }
    public Guid? LoggedInOrgUnitId
    {
        get
        {
            var userOrgUnitId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "userOrgUnitId")?.Value;

            if (userOrgUnitId is not null && userOrgUnitId != "")
            {
                return Guid.Parse(userOrgUnitId);
            }
            return null;
        }
    }

    public Guid? LoggedInDepartmentId
    {
        get
        {
            var departmentId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "departmentId")?.Value;

            if (departmentId is not null && departmentId != "")
            {
                return Guid.Parse(departmentId);
            }
            return null;
        }
    }
    public Guid? LoggedInStoreId
    {
        get
        {
            var storeId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "storeId")?.Value;

            if (storeId is not null && storeId != "")
            {
                return Guid.Parse(storeId);
            }
            return null;
        }
    }


    public bool IsSuperAdmin
    {
        get
        {
            var role = _httpContextAccessor.HttpContext?.User?.Claims?
                .Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?
                .SingleOrDefault()?.Value;
            if (role is not null && role.ToLower() == "superadmin")
            {
                return true;
            }
            return false;
        }
    }

    public bool IsAdmin
    {
        get
        {
            var role = _httpContextAccessor.HttpContext?.User?.Claims?
                .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?
                .SingleOrDefault()?.Value;
            if (role is not null && role.ToLower() == "admin")
            {
                return true;
            }
            return false;
        }
    }
    public string LoggedInUserName { get { return _httpContextAccessor.HttpContext?.User?.Identity?.Name; } }
    public string ServerRootPath { get { return $"{Request.Scheme}://{Request.Host}{Request.PathBase}"; } }
    public string IP { get { return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString(); } }
}
