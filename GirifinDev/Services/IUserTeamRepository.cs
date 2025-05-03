using GirifinDev.Application.DTO;

namespace GirifinDev.Services
{
    public interface IUserTeamRepository
    {
        public List<ShowUserTeamDTO> GetAllUserTeam();
    }
}
