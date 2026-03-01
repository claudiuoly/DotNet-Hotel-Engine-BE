namespace AuraStay.Api.Constants;

public static class UserRoles
{
    public const string Admin = "ADMIN";
    public const string SuperAdmin = "SUPERADMIN";
    public const string Employee = "EMPLOYEE";
    public const string Client = "CLIENT";

    /// <summary>Default role for new registrations (landing page sign-ups).</summary>
    public const string Default = Client;

    /// <summary>All role values for validation or listing.</summary>
    public static readonly string[] All = [Admin, SuperAdmin, Employee, Client];
}
