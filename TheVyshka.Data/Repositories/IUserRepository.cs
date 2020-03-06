using TheVyshka.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheVyshka.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> GetByIdAsync(Guid id);

        Task<UserDto> GetByEmailAsync(string email);
        Task<bool> AddToRoleAsync(Guid id, string role);

        Task<UserDto> CreateAsync(UserDto item);

        Task<bool> UpdateAsync(UserDto item);

        Task<bool> DeleteByIdAsync(Guid id);

        Task<bool> DeleteByEmailAsync(string email);
    }
}
