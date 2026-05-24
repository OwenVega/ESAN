using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }





        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoriesDTO = new List<CategoryListDTO>();

            foreach (var category in categories)
            {

                var categoryDTO = new CategoryListDTO()
                {
                    Id = category.Id,
                    Description = category.Description
                };

                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;


        }


        public async Task<CategoryListDTO> GetCategoryByID(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);

            var categoryDTO = new CategoryListDTO()
            {
                Id = category.Id,
                Description = category.Description
            };

            return categoryDTO;

        }


        public async Task CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var category = new Category()
            {
                Description = categoryCreateDTO.Description,
                IsActive = categoryCreateDTO.IsActive
            };
            await _categoryRepository.CreateCategory(category);
        }

        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = new Category()
            {
                Id = categoryUpdateDTO.Id,
                Description = categoryUpdateDTO.Description,
                IsActive = categoryUpdateDTO.IsActive
            };
            await _categoryRepository.UpdateCategory(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }
    }
}
