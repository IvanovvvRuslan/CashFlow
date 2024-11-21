using AutoMapper;
using CashFlowApi.Data;
using CashFlowApi.DTOs;
using CashFlowApi.Exceptions;
using CashFlowApi.Models;
using CashFlowApi.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CashFlowApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
        Task Create(UserCreateDto userDto);
        //Task Update(int id, UserDto userDto);
        Task Delete(int id);
    }

    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        { 
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return usersViewModel;
        }

        public async Task<UserViewModel> GetById(int id)
        { 
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new NotFoundException("User not found");

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }

        public async Task Create(UserCreateDto userDto)
        { 
            var user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        //public async Task Update(int id, UserDto userDto)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        //    if (user == null)
        //        throw new NotFoundException("User not found");

        //    user.Name = userDto.Name;
        //    user.Password = userDto.Password;
        //    user.Email = userDto.Email;
        //    user.Description = userDto.Description;
        //    user.Roles = userDto.Roles;
        //    user.Phones = userDto.Phones;
        //    user.Companies = userDto.Companies;
        //    user.ContactCompanies = userDto.ContactCompanies;
        //    user.CompaniesOwner = userDto.CompaniesOwner;

        //    await _context.SaveChangesAsync();
        //}

        public async Task Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>u.Id == id);

            if (user == null)
                throw new NotFoundException("User not found");

            _context.Users?.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
