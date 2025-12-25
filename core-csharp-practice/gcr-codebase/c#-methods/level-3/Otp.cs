using System;

class Otp
{
    static void Main(string[] args)
    {
        const int totalOTPs = 10;
        int[] otps = new int[totalOTPs];

        for (int i = 0; i < totalOTPs; i++)
        {
            otps[i] = GenerateOTP();
            Console.WriteLine("OTP " + (i + 1) + ": " + otps[i]);
        }

        bool unique = OTPsUnique(otps);
        Console.WriteLine("All OTPs unique? " + unique);
    }

    public static int GenerateOTP()
    {
        Random random = new Random();
        return random.Next(100000, 1000000); 
    }

    public static bool OTPsUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j])
                    return false;
            }
        }
        return true;
    }
}
