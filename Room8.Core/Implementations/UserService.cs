using Microsoft.AspNetCore.Identity;
using Room8.API.Dtos;
using Room8.Core.Abstractions;
using Room8.Core.Dtos;
using Room8.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Room8.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto<EditProfileResponseDto>> EditProfile(EditProfileDto editProfileDto)
        {
            var user = await _userManager.FindByIdAsync(editProfileDto.UserId);
            if (user == null)
            {
                var errors = new List<Error>
                {
                    new Error("404", "User does not exist")
                };
                return ResponseDto<EditProfileResponseDto>.Failure(errors, 404);
            }

            user.FirstName = editProfileDto.Firstname;
            user.LastName = editProfileDto.Lastname;
            user.Email = editProfileDto.Email;
            user.PhoneNumber = editProfileDto.PhoneNumber;
            user.Location = editProfileDto.Location;
            user.Occupation = editProfileDto.Occupation;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return ResponseDto<EditProfileResponseDto>.Failure(updateResult.Errors.Select(e => new Error(e.Code, e.Description)));
            }

            var editProfileResponseDto = new EditProfileResponseDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
               Location = user.Location,
               Occupation = user.Occupation
            };

            return ResponseDto<EditProfileResponseDto>.Success("Profile updated successfully", 200);
        }
    }
}
