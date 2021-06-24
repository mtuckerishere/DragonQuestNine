using DragonQuestNine.Dtos.Accolades;
using DragonQuestNine.Models;
using DragonQuestNine.Repositories.Accolades;
using DragonQuestNine.Repositories.UnitOfWork;
using DragonQuestNine.Services.Communication;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<AccoladeCategoryResponse> AddAccoladeCategory(AccoladeCategory accoladeCategory)
        {

            //TODO Think of other errors and remove try catch
            try
            {
               await _accoladeCategoryRepository.AddAccoladeCategory(accoladeCategory);
               await _unitOfWork.CompleteAsync();

                return new AccoladeCategoryResponse(accoladeCategory);

            }
            catch(Exception ex)
            {
                return new AccoladeCategoryResponse($"An error returned when saving the new Accolade Category{ex.Message}");
            }
        }

        public async Task<AccoladeCategoryResponse> UpdateAccoladeCategory(int accoladeCategoryId, AccoladeCategory accoladeCategory)
        {
            var existingAccoladeCategory = await _accoladeCategoryRepository.GetAccoladeCategoryById(accoladeCategoryId);

            if (existingAccoladeCategory == null)
            {
                return new AccoladeCategoryResponse("Accolade Category not found.");
            }

            existingAccoladeCategory.Name = accoladeCategory.Name;

            // TODO try and think of more errors to remove try-catch
            try
            {
                _accoladeCategoryRepository.UpdateAccoladeCategory(existingAccoladeCategory);
                await _unitOfWork.CompleteAsync();

                return new AccoladeCategoryResponse(existingAccoladeCategory);
            }
            catch(Exception ex)
            {
                return new AccoladeCategoryResponse($"An error occurred when updating the category {ex.Message}");
            }
        }

        public async Task<AccoladeCategoryResponse> DeleteAccoladeCategory(int accoladeCategoryId)
        {
            var existingAccoladeCategory = await _accoladeCategoryRepository.GetAccoladeCategoryById(accoladeCategoryId);

            if (existingAccoladeCategory == null)
            {
                return new AccoladeCategoryResponse("Accolade Category not found");
            }


            //TODO try and think of other errors to remove try catch
            try
            {
                _accoladeCategoryRepository.DeleteAccoladeCategory(existingAccoladeCategory);
                await _unitOfWork.CompleteAsync();

                return new AccoladeCategoryResponse(existingAccoladeCategory);

            }
            catch(Exception ex)
            {
                return new AccoladeCategoryResponse($"An error occured when trying to delete the Accolade Category: {ex.Message}");
            }
        }

    }
}
