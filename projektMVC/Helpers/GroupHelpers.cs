using Microsoft.Graph;
using System.Security.Claims;

namespace projektMVC.Helpers
{
    public static class GroupHelpers
    {
        private static string NormalUserGroupId = "f53e0e42-0fd0-4c6b-8a8e-28218b87a60b";

        public static bool IsNormalUser(IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                if (!(claim.Type == "groups"))
                {
                    continue;
                }

                var group = claim.Value;

                if (group == NormalUserGroupId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
