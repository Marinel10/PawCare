namespace PawCare.Web.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public abstract class BaseController : Controller
{
    protected string? GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    protected bool IsUserAuthenticated() => User.Identity?.IsAuthenticated ?? false;
}