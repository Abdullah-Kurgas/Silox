namespace Silox.Data.Models.Authorization;

public static class RoleConstants
{
    public static Role Administrator => new(
        "Administrator",
        [
            PermissionConstants.GarsonView,
            PermissionConstants.GarsonEdit,

            PermissionConstants.EArhivaView,
            PermissionConstants.EArhivaEdit,

            PermissionConstants.NadzorView,

            PermissionConstants.FinansijeView,
            PermissionConstants.FinansijeEdit,

            PermissionConstants.UsersView,
            PermissionConstants.UsersManage,

            PermissionConstants.SettingsView
        ]);

    public static Role Poslovnica => new(
        "Poslovnica",
        [
            PermissionConstants.GarsonView
        ]);

    public static Role Finansije => new(
        "Finansije",
        [
            PermissionConstants.FinansijeView,
            PermissionConstants.FinansijeEdit
        ]);
}