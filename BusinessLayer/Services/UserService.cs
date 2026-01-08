using BusinessLayer.Interfaces.Repository;
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
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<bool> CreateAsync(UserDTO model)
		{
			if (model == null || model.Name == null || model.Email == null || model.Password == null)
			{
				return false;
			}

			var user = new UserEntity() { PublicId = model.PublicId, Email = model.Email, Name = model.Name };

			await _userRepository.CreateAsync(user);
			await _userRepository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteAsync(Guid publicId)
		{
			var user = await _userRepository.GetByPublicIdAsync(publicId);

			if (user == null)
			{
				return false;
			}

			_userRepository.Delete(user);
			await _userRepository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteAllAsync(List<UserDTO> listOfId)
		{

			var list = new List<UserEntity>(){};
			foreach (var user in listOfId) {
				var newuser = new UserEntity() { Email = user.Email, Id = user.Id, Name = user.Name, PublicId = user.PublicId };
				list.Add(newuser);
			}

			_userRepository.DeleteAll(list);

			await _userRepository.SaveChangesAsync();

			return true;
		}

		public async Task<List<UserDTO>> GetAllAsync()
		{
			var userList = await _userRepository.GetAllAsync();
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
			var user = await _userRepository.GetByPublicIdAsync(publicId);

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

			var user = await _userRepository.GetByPublicIdAsync(model.PublicId);

			if (user == null)
			{
				return false;
			}

			user.Name = model.Name;
			user.Email = model.Email;
			_userRepository.Update(user);
			await _userRepository.SaveChangesAsync();

			return true;
		}

		public async Task<List<Guid>> GetAllPublicIdAsync()
		{
			var userList = await _userRepository.GetAllAsync();
			var userDTOList = new List<Guid>();

			foreach (var user in userList)
			{
				userDTOList.Add(user.PublicId);
			}

			return userDTOList;
		}
	}
}
