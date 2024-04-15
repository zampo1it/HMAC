
using System.Text;
using System.Security.Cryptography;

namespace RockPaperScissors
{
    internal class GenerateHMAC
    {
        public string HMACKey()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] keyBytes = new byte[32];
            rng.GetBytes(keyBytes);
            string sKey = BitConverter.ToString(keyBytes).Replace("-", string.Empty);
            return sKey;
        }

        public string HMACValue(string sMessage, string sKey)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(sKey)))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(sMessage));
                string sHmac = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return sHmac;
            }
        }
    }
}
