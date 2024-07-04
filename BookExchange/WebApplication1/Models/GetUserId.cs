using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst("UserId");
        return userIdClaim != null ? int.Parse(userIdClaim.Value) : 1;
    }
}
