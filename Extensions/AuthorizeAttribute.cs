using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NS.Core.Commons;
using System.Security.Claims;

namespace NS.Core.API.Extensions;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _permissions;

    public AuthorizeAttribute(string permission = "")
    {
        _permissions = new string[] {permission};
    }

    public AuthorizeAttribute(params string[] permissions)
    {
        _permissions = permissions;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var permissions = (List<Claim>)context.HttpContext.Items[Constants.ContextItem.PERMISSIONS]!;
            if (!permissions.Any(p => _permissions.Contains(p.Value)))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            
        }
        catch (Exception)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}