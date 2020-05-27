using Tiririt.Data.Entities;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Mappings
{
    internal static class UserModelMapping 
    {
        public static UserModel ToDomainModel(this TIRIRIT_USER value)
        {
            if (value == null) return null;

            return new UserModel 
            {
                BirthDate = value.BIRTH_DT,
                FirstName = value.FIRST_NAME,
                Lastname = value.LAST_NAME,
                RegisterDate = value.REGISTER_DT,
                UserId = value.TIRIRIT_USER_ID,
                UserName = value.USER_NAME
            };
        }
    }
}