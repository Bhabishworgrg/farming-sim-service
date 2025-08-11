using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class AdminOrOwnerHandler<T> : AuthorizationHandler<AdminOrOwnerRequirement>
	where T : PlayerOwnedEntity {
	private IResourceService _resourceService;
	private HttpContext? _httpContext;

	public AdminOrOwnerHandler(
		IResourceService resourceService, 
		IHttpContextAccessor httpContextAccessor
	) {
		_resourceService = resourceService;
		_httpContext = httpContextAccessor.HttpContext;
	}

    protected override Task HandleRequirementAsync(
		AuthorizationHandlerContext context,
		AdminOrOwnerRequirement requirement
	) {
		if (context.User.IsInRole(Roles.ADMIN)) {
			context.Succeed(requirement);
			return Task.CompletedTask;
		}

		string? userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (userId == null) {
			context.Fail();
			return Task.CompletedTask;
		}

		string? resourceIdStr = _httpContext?.GetRouteData().Values["id"]?.ToString();

		if (resourceIdStr == null) {
			context.Fail();
			return Task.CompletedTask;
		}

		int resourceId = int.Parse(resourceIdStr);

		bool isOwner = _resourceService.IsOwner<T>(resourceId, userId);
		if (isOwner) {
			context.Succeed(requirement);
		} else {
			context.Fail();
		}

		return Task.CompletedTask;
    }
}
