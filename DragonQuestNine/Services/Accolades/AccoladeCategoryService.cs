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

        public async Task<SaveAccoladeCategoryResponse> UpdateAccoladeCategory(int accoladeCategoryId, AccoladeCategory accoladeCategory)
        {
            var existingAccoladeCategory = await _accoladeCategoryRepository.GetAccoladeCategoryById(accoladeCategoryId);

            if (existingAccoladeCategory == null)
            {
                return new SaveAccoladeCategoryResponse("Accolade Category not found.");
            }

            existingAccoladeCategory.Name = accoladeCategory.Name;

            // TODO try and think of more errors to remove try-catch
            try
            {
                _accoladeCategoryRepository.Update(existingAccoladeCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveAccoladeCategoryResponse(existingAccoladeCategory);
            }
            catch(Exception ex)
            {
                return new SaveAccoladeCategoryResponse($"An error occurred when updating the category {ex.Message}");
            }
        }

    }
}
