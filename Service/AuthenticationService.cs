using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;


namespace Service
{
    internal sealed class AuthenticationService : BaseService, IAuthenticationService
    {
  
        private readonly IConfiguration _configuration;

        public AuthenticationService(IRepositoryManager repository, 
            ILoggerManager logger, 
            IMapper mapper, 
            IConfiguration configuration) : base(repository, logger, mapper)
        {
            _configuration = configuration;
        }

        public async Task<bool> ValidarUsuario(UsuarioForAuthenticationDto usuarioForAuth, bool trackChanges) 
        {
            var usuario = await _repository.Usuario.GetUsuarioByUsuarioAccesoAsync(usuarioForAuth.UsuarioAcceso!, trackChanges);

            bool result = usuario != null && VerificarContrasenna(usuario, usuarioForAuth.Contrasenna!);
           
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

        public async Task<UsuarioDto> GetUsuarioByName(string usuarioAcceso, bool trackChanges)
        {
            var usuario = await _repository.Usuario.GetUsuarioByUsuarioAccesoAsync(usuarioAcceso!, trackChanges);

            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioAcceso!);

            var usuarioToReturn = _mapper.Map<UsuarioDto>(usuario);

            return usuarioToReturn;
        }

        private bool VerificarContrasenna(Usuario usuario, string contrasenna)
        {
            using var hmac = new HMACSHA512(usuario.ContrasennaSalt!);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(contrasenna));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.ContrasennaHash![i]) return false;
            }

            return true;
        }
    }
}
