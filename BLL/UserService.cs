using BLL;
using DTO;



public static class UserValidationService
{
    public static bool ValidateUser(userDto userDto)
    {
       
        if (userDto.Yas < 18)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

