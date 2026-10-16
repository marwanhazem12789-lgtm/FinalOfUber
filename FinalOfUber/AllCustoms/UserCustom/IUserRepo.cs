using FinalOfUber.DTOs.UserDTOs;
using FinalOfUber.GenaricRepos;
using FinalOfUber.Models;

namespace FinalOfUber.AllCustoms.UserCustom
{
    public interface IUserRepo : IGenaricRepo<User>
    {
        Task<List<GetAllUsers>> Search(string Name);
        Task<string> Login(LoginDTOs dto);
        
    }
}
