using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Users;
using DDDSample1.Infrastructure;
using DDDSample1.Domain.Shared;
using Services;
using System;

namespace Services
{
    public class UserService{

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserRepository _repo;

        public UserService(IUnitOfWork unitOfWork, UserRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public UserService(){}
        public async Task<List<UserDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<UserDto> listDto = list.ConvertAll<UserDto>(urs => new UserDto{Id = urs.Id, Username = urs.Username, Role = urs.Role, Email = urs.Email});

            return listDto;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var urs = await this._repo.GetByIdAsync(id);
            
            if(urs == null)
                return null;

            return new UserDto{Id = urs.Id, Username = urs.Username, Role = urs.Role, Email = urs.Email};
        }
        public async Task<UserDto> AddAsync(UserDto dto)
        {   
            //PASSWORD TEMPORARIA DEPOIS MUDAR AO METER A MERDA DO EMAIL
            string password = "123";
            var user = new User(dto.Username, dto.Role, dto.Email, password );
            await this._repo.AddAsync(user);

           await this._unitOfWork.CommitAsync();

            return new UserDto { Id = user.Id, Username = user.Username, Role = user.Role, Email = user.Email };
        }
        
        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _repo.GetByUserName(username);

            if (user == null )
                return null;

            if (!user.Password.Equals(password))
                return null;

            var token = TokenService.GenerateToken(user);
            return token;
        } 

        









        
    }
}