using DragonQuestNine.Dtos.Accolades;
using DragonQuestNine.Models;
using DragonQuestNine.Repositories.Accolades;
using DragonQuestNine.Repositories.UnitOfWork;
using DragonQuestNine.Services.Communication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public class AccoladeCategoryService: IAccoladeCategoryService
    {
        private readonly IAccoladeCategoryRepository _accoladeCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccoladeCategoryService(IAccoladeCategoryRepository accoladeCategoryRepository, IUnitOfWork unitOfWork)
        {
            _accoladeCategoryRepository = accoladeCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AccoladeCategory>> GetAllAccoladeCategories()
        {
            return await _accoladeCategoryRepository.GetAllAccoladeCategories();
        }

        public async Task<AccoladeCategory> GetAccoladeCategoryById(int accoladeCategoryId)
        {
            return await _accoladeCategoryRepository.GetAccoladeCategoryById(accoladeCategoryId);
        }

        public async Task<SaveAccoladeCategoryResponse> AddAccoladeCategory(AccoladeCategory accoladeCategory)
        {

            //TODO Think of other errors and remove try catch
            try
            {
               await _accoladeCategoryRepository.AddAccoladeCategory(accoladeCategory);
               await _unitOfWork.CompleteAsync();

                return new SaveAccoladeCategoryResponse(accoladeCategory);

            }
            catch(Exception ex)
            {
                return new SaveAccoladeCategoryResponse($"An error returned when saving the new Accolade Category{ex.Message}");
            }
        }

    }
}
