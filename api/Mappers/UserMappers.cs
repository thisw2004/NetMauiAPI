using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDTO ToUserDTO(this User userModel){
            return new UserDTO{
                //set here all data you want to be displayed.
                ID = userModel.ID,
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password
                
            };
        }
    }
}