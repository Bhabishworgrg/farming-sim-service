using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class PatchOwnerHandler : AuthorizationHandler<OwnerRequirement> {
	private IPatchService _service;
	private HttpContext? _httpContext;

	public PatchOwnerHandler(
		IPatchService service,
		IHttpContextAccessor httpContextAccessor
	) {
		_service = service;
		_httpContext = httpContextAccessor.HttpContext;
	}

	protected override Task HandleRequirementAsync(
		AuthorizationHandlerContext context,
		OwnerRequirement requirement
	) {
		string? userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (userId == null) {
			context.Fail();
			return Task.CompletedTask;
		}

		string? idStr = _httpContext?.GetRouteData().Values["id"]?.ToString();
		if (idStr == null) {
			context.Fail();
			return Task.CompletedTask;
		}

		int id = int.Parse(idStr);

		bool isOwner = _service.IsOwner(id, userId);
		if (isOwner) {
			context.Succeed(requirement);
		} else {
			context.Fail();
		}

		return Task.CompletedTask;
	}
}
