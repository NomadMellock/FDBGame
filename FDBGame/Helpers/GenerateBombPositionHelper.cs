using System.Security.Cryptography;

internal static class RNGPositionHelper
{
    public static int Next(int width = 8, int height = 8)
    {
        var rnd = new byte[4];

        using (var rng = new RNGCryptoServiceProvider())
            rng.GetBytes(rnd);
        var x = Math.Abs(BitConverter.ToInt32(rnd, 0));

        return Convert.ToInt32(x % (width + 1));
    }
}