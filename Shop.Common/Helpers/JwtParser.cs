using System.Security.Claims;
using System.Text.Json;

namespace Shop.Common.Helpers
{
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJWT(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];


            byte[] jsonBytes = ParseBase64Padding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            claims.AddRange(keyValuePairs.Select(x => new Claim(x.Key, x.Value.ToString() ?? "")));

            return claims;

        }

        private static byte[] ParseBase64Padding(string base64)
        {
   

            switch (base64.Length % 4)
            {

                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
