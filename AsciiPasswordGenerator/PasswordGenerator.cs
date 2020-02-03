using System;

namespace AsciiPasswordGenerator
{
    public enum PasswordTypeName
    {
        AllLettersDigitsAndSpecials = 1,
        AllLettersAndDigits = 2,
        UppercaseAndLowercase = 3,
        OnlyUppercase = 4,
        OnlyLowercase = 5,
        OnlyDigits = 6,
        OnlySpecials = 7
    }
    class PasswordGenerator
    {
        public static string GeneratePassword(int passLength, int passType)
        {
            if (passLength >= 2)
            {
                var myEnumMemberCount = Enum.GetNames(typeof(PasswordTypeName)).Length;
                if (passType > 0 && passType <= myEnumMemberCount)
                {
                    var bufferChars = new char[passLength];
                    var passwordType = (PasswordTypeName) passType;
                    var rnd = new Random();
                    for (int i = 0; i < bufferChars.Length; i++)
                    {
                        switch (passwordType)
                        {
                            case PasswordTypeName.AllLettersDigitsAndSpecials:
                                bufferChars[i] = (char) (rnd.Next(33, 127));
                                break;
                            case PasswordTypeName.AllLettersAndDigits:
                                link1:
                                var temp1 = rnd.Next(48, 123);
                                if (temp1 >= 48 && temp1 <= 57 || temp1 >= 65 && temp1 <= 90 || temp1 >= 97 && temp1 <= 122)
                                    bufferChars[i] = (char) temp1;
                                else goto link1;
                                break;
                            case PasswordTypeName.OnlyUppercase:
                                bufferChars[i] = (char) (rnd.Next(65, 91));
                                break;
                            case PasswordTypeName.OnlyLowercase:
                                bufferChars[i] = (char) (rnd.Next(97, 123));
                                break;
                            case PasswordTypeName.UppercaseAndLowercase:
                                link2:
                                var temp2 = rnd.Next(48, 123);
                                if (temp2 >= 65 && temp2 <= 90 || temp2 >= 97 && temp2 <= 122) bufferChars[i] = (char) temp2;
                                else goto link2;
                                break;
                            case PasswordTypeName.OnlyDigits:
                                bufferChars[i] = (char) (rnd.Next(48, 57));
                                break;
                            case PasswordTypeName.OnlySpecials:
                                link3:
                                var temp3 = rnd.Next(48, 123);
                                if (temp3 >= 33 && temp3 <= 47 || temp3 >= 58 && temp3 <= 64 || temp3 >= 91 && temp3 <= 96 ||
                                    temp3 >= 123 && temp3 <= 126) bufferChars[i] = (char) temp3;
                                else goto link3;
                                break;
                        }
                    }

                    return new string(bufferChars);
                }

                return "Enter correct password type.\r\nNo password was created, please try again.";
            }

            return "Password length must be over 2 characters.\r\nNo password was created, please try again.";
        }
    }
}
