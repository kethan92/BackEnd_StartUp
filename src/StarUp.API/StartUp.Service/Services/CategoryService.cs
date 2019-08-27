using StartUp.Data.Model;
using StartUp.Data.UnitOfWork;
using StartUp.Service.Interfaces;

namespace StartUp.Service.Services
{
    public class CategoryService : Service<db_category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork) : base (unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
