using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Service
{
    internal sealed class AuthenticationService : BaseService, IAuthenticationService
    {
  
        private readonly IConfiguration _configuration;
        //private Usuario? _usuario;

        public AuthenticationService(IRepositoryManager repository, 
            ILoggerManager logger, 
            IMapper mapper, 
            IConfiguration configuration) : base(repository, logger, mapper)
        {
            _configuration = configuration;
        }

        public bool ValidarUsuario(UsuarioForAuthenticationDto usuarioForAuth)
        //public Task<bool> ValidarUsuario(UsuarioForAuthenticationDto usuarioForAuth) 
        {
            Boolean result = false;

            //_usuario = await _repository.FindByNameAsync(userForAuth.UserName); 
            var usuario = GetUsuarioByName(usuarioForAuth.UsuarioAcceso!);

            //var result = (_usuario != null && await _repository.CheckPasswordAsync(_usuario, usuarioForAuth.Contrasenna)); 
            result = (usuario != null);

            //if (!result) 
            //_logger.LogWarn($"{nameof(ValidarUsuario)}: Autenticación fallida. Usuario o contrasenna incorrecta."); 

            return result; 
        }

        public string CrearToken() 
        { 
            var signingCredentials = GetSigningCredentials(); 
            //var claims = await GetClaims(); 
            var tokenOptions = GenerateTokenOptions(signingCredentials/*, claims*/); 
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions); 
        }

        private SigningCredentials GetSigningCredentials() 
        { 
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JEPFUENTES")!); 
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256); 
        }

        //private async Task<List<Claim>> GetClaims() 
        //{ 
        //    var claims = new List<Claim> 
        //    { 
        //        new Claim(ClaimTypes.Name, _user.UserName) 
        //    }; 
            
        //    var roles = await _userManager.GetRolesAsync(_user); 
        //    foreach (var role in roles) 
        //    { 
        //        claims.Add(new Claim(ClaimTypes.Role, role)); 
        //    } 

        //    return claims; 
        //}

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials/*, List<Claim> claims*/) 
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            
            var tokenOptions = new JwtSecurityToken
                (
                issuer: jwtSettings["validIssuer"], 
                audience: jwtSettings["validAudience"], 
                //claims: claims, 
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])), 
                signingCredentials: signingCredentials
                ); 
            
            return tokenOptions; 
        }

        public UsuarioDto GetUsuarioByName(string usuarioAcceso)
        {
            //usuario = await _repository.FindByNameAsync(userForAuth.UserName); 
            Usuario usuario = new Usuario
            {
                Id = 1, 
                PrimerNombre = "Gabriel", 
                SegundoNombre = "Dario", 
                PrimerApellido = "Villa", 
                SegundoApellido = "Acevedo",
                UsuarioAcceso = usuarioAcceso
            };

            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioAcceso!);

            var usuarioToReturn = _mapper.Map<UsuarioDto>(usuario);

            return usuarioToReturn;
        }
    }
}
