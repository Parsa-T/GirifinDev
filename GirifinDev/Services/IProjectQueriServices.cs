using GirifinDev.Application.DTO;

namespace GirifinDev.Services
{
    public interface IProjectQueriServices
    {
        public ShowProjectDTO ShowProject();
        public List<ProjectShowDTO> ShowAllProject();
        public List<ShowCategoryProjectDTO> GetAllCategory();
        public List<ProjectShowDTO> GetprojectByCategoryId(int categoryId);
    }
}
