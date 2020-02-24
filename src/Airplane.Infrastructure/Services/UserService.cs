using System;
using System.Threading.Tasks;
using Airplane.Core.Domain;
using Airplane.Core.Repositories;
using Airplane.Infrastructure.DTO;
using Airplane.Infrastructure.Extensions;
using AutoMapper;

namespace Airplane.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTHandler _jwtHandler;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IJWTHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AccountDTO> GetAccountAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            return _mapper.Map<AccountDTO>(user);
        }

        public async Task RegisterAsync(Guid userId, string name, string surename, string email, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email {email} is exist");
            }
            user = new User(userId, name, surename, email, password, role);
            await _userRepository.AddAsync(user);
        }
        public async Task<TokenDTO> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception($"Invalid credentials for -> {email}");
            }
            if (user.Password != password)
            {
                throw new Exception($"Invalid credentials for -> {email} -> password");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            return new TokenDTO
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role
            };
        }
    }
}