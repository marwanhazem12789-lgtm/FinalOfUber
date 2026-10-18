using FinalOfUber.DTOs.UserDTOs;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace FinalOfUber.AllCustoms.UserCustom
{
    public class UserRepo : GenaricRepo<User> , IUserRepo
    {
        private readonly Context _context;
        private readonly IConfiguration c;
        public UserRepo(Context context, IConfiguration c) : base(context) 
        {
            _context = context;
            this.c = c;
        }

        public async Task<string> Login(LoginDTOs dto)
        {
           var e = await _context.users.Where( i=> i.Email == dto.Email ).FirstOrDefaultAsync();
            if (e == null)
            {
                throw new Exception();
            }


            if(e.Password == dto.Password)
            {
                return Tokenn(e);
            }
            return null;
        }

        public async Task<List<GetAllUsers>> Search(string Name)
        {
            return await _context.users.Where(o => o.FullName.Contains(Name)).Select(i => new GetAllUsers
            {
                Id = i.Id,
                Email = i.Email,
                FullName = i.FullName,
                Password = i.Password,
                Phone = i.Phone,
                Role = i.Role,
            }).ToListAsync();
        }
        private string Tokenn(User u)
        {
            var cc = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,u.FullName),
                new Claim(ClaimTypes.Email , u.Email),
                new Claim(ClaimTypes.Role , u.Role)
            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(c["JWT:Key"]));


            var ss = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);


            var t = new JwtSecurityToken(
                issuer : c["JWT:Issuer"],
                audience : c["JWT:Audience"],
                expires : DateTime.Now.AddHours(6),
                claims : cc,
                signingCredentials : ss
                );
            var Token = new JwtSecurityTokenHandler().WriteToken(t);
            return Token;


        }
    }
}
