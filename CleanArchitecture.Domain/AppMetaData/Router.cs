namespace CleanArchitecture.Domain.AppMetaData
{
    public static class Router
    {
        public const string singleRoute = "/{id}";
        public const string root = "api";
        public const string version = "v1";
        public const string rule = root + "/" + version + "/";

        public static class RepositoryRouting
        {
            public const string Prefix = rule + "Repository";

            public static class Actions
            {
                public const string Create = Prefix + "/Create";
                public const string GetById = Prefix + singleRoute;
                public const string GetAll = Prefix + "/All";
                public const string Update = Prefix + singleRoute;
                public const string Delete = Prefix + singleRoute;
            }
        }
        public static class RepositoryFolderRouting
        {
            public const string Prefix = rule + "RepositoryFolder";

            public static class Actions
            {
                public const string CreateFolder = Prefix + "/CreateFolder";
                public const string GetFolderContents = Prefix + "/GetFolderContents";
                public const string GetFolderById = Prefix + "/GetFolderById";
                public const string GetFoldersByParentId = Prefix + "/GetFoldersByParentId";
                public const string EditName = Prefix + "/EditName";
            }
        }
        public static class AuthRouting
        {
            public const string Prefix = rule + "Auth";

            public static class Actions
            {
                public const string Login = Prefix + "/Login";
                public const string Register = Prefix + "/Register";
                public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
                public const string ResetPassword = Prefix + "/ResetPassword";
            }
        }

        public static class RoleRouting
        {
            public const string Prefix = rule + "Role";

            public static class Actions
            {
                public const string CreateRole = Prefix + "/CreateRole";
                public const string EditRole = Prefix + "/EditRole";
                public const string DeleteRole = Prefix + "/DeleteRole";
                public const string GetRoleClaims = Prefix + "/GetRoleClaims";
                public const string AddClaimToRole = Prefix + "/AddClaimToRole";
                public const string AssignRoleToUser = Prefix + "/AssignRoleToUser";
                public const string AssignClaimToUser = Prefix + "/AssignClaimToUser";
                public const string GetUserRoles = Prefix + "/GetUserRoles";
                public const string GetUserClaims = Prefix + "/GetUserClaims";
                public const string GetAllRoles = Prefix + "/GetAllRoles";
                public const string GetAllClaims = Prefix + "/GetAllClaims";
            }
        }
        public static class EmailsRoute
        {
            public const string Prefix = rule + "Emails";
            public static class Actions
            {
                public const string SendEmail = Prefix + "/SendEmail";
            }
        }
    }
}
