using BusinessLayer.Interfaces.Service;
using Common.DTO;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.DataLayer;
using UserApp.DataLayer.Entities;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(UserDTO model)
        {
            if (model == null || model.Name == null || model.Email == null)
            {
                return false;
            }

            var user = new UserEntity() { Id = _context.Users.ToList().Count + 1, PublicId = model.PublicId, Email = model.Email, Name = model.Name };

            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PublicId == publicId);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var userList = await _context.Users.ToListAsync();
            var userDTOList = new List<UserDTO>();

            foreach (var user in userList)
            {
                var userDTO = new UserDTO()
                {
                    Id = user.Id,
                    PublicId = user.PublicId,
                    Name = user.Name,
                    Email = user.Email
                };

                userDTOList.Add(userDTO);
            }

            return userDTOList;
        }

        public async Task<UserDTO?> GetByPublicIdAsync(Guid publicId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PublicId == publicId);

            if (user == null)
            {
                return null;
            }

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email
            };

            return userDTO;
        }

        public async Task<bool> UpdateAsync(UserDTO model)
        {
            if (model == null || model.Name == null || model.Email == null)
            {
                return false;
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.PublicId == model.PublicId);

            if (user == null)
            {
                return false;
            }

            user.Name = model.Name;
            user.Email = model.Email;
            _context.Users.Update(user);
            _context.SaveChanges();

            return true;
        }
    }
}
