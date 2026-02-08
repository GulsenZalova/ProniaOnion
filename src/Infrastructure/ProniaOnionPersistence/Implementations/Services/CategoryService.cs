using Microsoft.EntityFrameworkCore;
using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }



        public async Task<IEnumerable<CategoryItemDTO>> GetAllAsync(int page, int take)
        {
            int skipValue = (page - 1) * take; // 5
            var categories = await _repository
            .GetAll(skip: skipValue, take: take)
            .Select(x => new CategoryItemDTO
            (
                 x.Id,
              x.Name
            ))
            .ToListAsync();
            return categories;
        }

        public async Task<GetCategoryDTO> GetByIdAsync(int id)
        { // category=>getcategorydto
          // entity=>dto

           var category = await _repository.GetById(id);
           GetCategoryDTO getCategoryDTO = new GetCategoryDTO(
            category.Id,
            category.Name,
            category.Products.Select(p=>new ProductItemDTO(
                p.Id,
                p.Price,
                p.Name,
                p.Description,
                p.SKU
            )).ToList()
           );
            return getCategoryDTO;
        }


        public async Task<bool> CreateAsync(CreateCategoryDTO categoryDTO)
        {
            if (await _repository.AnyAsync(category => category.Name == categoryDTO.Name))
            {
                return false;
            }

            await _repository.AddAsync(new Category { Name = categoryDTO.Name,CreatedAt= DateTime.Now,CreatedBy="Admin"});
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.GetById(id);
            if (category == null)
            {
                throw new Exception("Not Found");
            }
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateCategoryDTO categoryDTO)
        {
            Category category = await _repository.GetById(id);
            if (category == null)
            {
                throw new Exception("Not Found");
            }

            if (await _repository.AnyAsync(category => category.Name == categoryDTO.Name && category.Id != id))
            {
                throw new Exception("Already Existes");
            }

            category.Name = categoryDTO.Name;
            category.ModifiedAt= DateTime.Now;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }


    }
}
