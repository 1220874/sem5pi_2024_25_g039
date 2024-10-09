using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Users;
using DDDSample1.Infrastructure;
using DDDSample1.Domain.Shared;
using Services;
using System;
using System.Text.RegularExpressions;
using Shared;
using Domain.MailDomain;
using Microsoft.Extensions.Options;

namespace Services
{
    public class UserService{

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserRepository _repo;
        private readonly IMailService _mailService;
        private readonly MailDSettings _mailSettings;

        public UserService(IUnitOfWork unitOfWork, UserRepository repo, IMailService mailService, IOptions<MailDSettings> mailSettings)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _mailSettings = mailSettings?.Value ?? throw new ArgumentNullException(nameof(mailSettings));
        
        }

        public UserService(){}
        public async Task<List<UserDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<UserDto> listDto = list.ConvertAll<UserDto>(urs => new UserDto(urs.Username, urs.Role, urs.Email));

            return listDto;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var urs = await this._repo.GetByIdAsync(id);
            
            if(urs == null)
                return null;

            return new UserDto(urs.Username, urs.Role, urs.Email);
        }
        public async Task<UserDto> AddAsync(UserDto dto)
        {   
            //PASSWORD TEMPORARIA DEPOIS MUDAR AO METER A MERDA DO EMAIL
            string password = "123";

            // Verificar se o email já existe no banco de dados
            var existingUser = await this._repo.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email já registado no sistema.");
            }

            // Validar formato do email usando regex
            string emailPattern = @"^[\w.-]+@[a-zA-Z\d.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(dto.Email, emailPattern))
            {
                throw new Exception("Formato de email inválido. (Exemplo: aaa@aaa.aaa)");
            }
            var user = new User(dto.Username, dto.Role, dto.Email, password);
            await _repo.AddAsync(user);
            await _unitOfWork.CommitAsync();

            // Mandar email para o email do user
            MailData mailData = new MailData
            (
                dto.Email,
                dto.Username,
                "HOSPITAL DO ISEP - Conta Criada Com Sucesso",
                "CLICA AQUI PARA MUDAR A PASSWORD: " + password
            );
            bool emailSent = _mailService.SendMail(mailData);

            return new UserDto(user.Username, user.Role, user.Email);
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