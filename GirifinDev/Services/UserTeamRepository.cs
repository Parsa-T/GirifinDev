using GirifinDev.Application.DTO;
using GirifinDev.Infra.Data.Context;

namespace GirifinDev.Services
{
    public class UserTeamRepository : IUserTeamRepository
    {
        GirifinDevContext _context;
        public UserTeamRepository(GirifinDevContext context)
        {
            _context = context;
        }
        public List<ShowUserTeamDTO> GetAllUserTeam()
        {
            var user = (from us in _context.Users
                        select new ShowUserTeamDTO()
                        {
                            Description = us.Description,
                            GitHub = us.GitHub,
                            Id = us.Id,
                            ImageUrl = us.ImageUrl,
                            LinkDin = us.LinkDin,
                            SiteLink = us.SiteLink,
                            UserName = us.UserName,
                            UserSkil = us.UserSkil,
                        }).ToList();
            return user;
        }
    }
}
