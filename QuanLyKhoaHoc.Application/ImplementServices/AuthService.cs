using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataAccounts;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<TaiKhoan> _baseTaiKhoanRepository;
        private readonly IConfiguration _configuration;
        private readonly AccountConverter _converter;
        private readonly IBaseRepository<QuyenHan> _baseQuyenHanRepository;
        private readonly IBaseRepository<RefreshToken> _baseRefreshTokenRepository;

        public AuthService(IBaseRepository<TaiKhoan> baseTaiKhoanRepository,
                           IConfiguration configuration,
                           AccountConverter converter,
                           IBaseRepository<QuyenHan> baseQuyenHanRepository,
                           IBaseRepository<RefreshToken> baseRefreshTokenRepository)
        {
            _baseTaiKhoanRepository = baseTaiKhoanRepository;
            _configuration = configuration;
            _converter = converter;
            _baseQuyenHanRepository = baseQuyenHanRepository;
            _baseRefreshTokenRepository = baseRefreshTokenRepository;
        }

        public async Task<ResponseObject<DataResponseLogin>> GetJwtTokenAsync(TaiKhoan taiKhoan)
        {
            var role = await _baseQuyenHanRepository.GetByIdAsync(taiKhoan.QuyenHanID);

            var authClaims = new List<Claim>
            {
                new Claim("Id",taiKhoan.TaiKhoanID.ToString()),
                new Claim("Username",taiKhoan.TenDangNhap),
                new Claim(ClaimTypes.Role, role?.TenQuyenHan ?? "")
            };
            var jwtToken = GetToken(authClaims);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken rf = new RefreshToken
            {
                ExpiryTime = DateTime.Now.AddHours(refreshTokenValidity),
                TaiKhoanId = taiKhoan.TaiKhoanID,
                Token = refreshToken,
            };

            rf = await _baseRefreshTokenRepository.CreateAsync(rf);
            return new ResponseObject<DataResponseLogin>
            {
                Status = StatusCodes.Status201Created,
                Message = "Generate Token Success!!!",
                Data = new DataResponseLogin
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    RefreshToken = refreshToken,
                }
            };
        }

        public async Task<ResponseObject<DataResponseLogin>> Login(Request_Login request)
        {
            var user = await _baseTaiKhoanRepository.GetAsync(x=>x.TenDangNhap.Equals(request.TenDangNhap));
            if (user == null) { 
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Sai tên tài khoản",
                    Data = null
                };
            }
            return new ResponseObject<DataResponseLogin>
            {
                Status = StatusCodes.Status200OK,
                Message = "Login success!!",
                Data = new DataResponseLogin
                {
                    AccessToken = GetJwtTokenAsync(user).Result.Data.AccessToken,
                    RefreshToken = GetJwtTokenAsync(user).Result.Data.RefreshToken
                }

            };
        }

        #region Methods Private
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int tokenValidityInHours);
            var expiration = DateTime.Now.AddHours(tokenValidityInHours);
            var localTimeZone = TimeZoneInfo.Local;

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expiration,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        #endregion
    }
}
