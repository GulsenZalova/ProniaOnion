using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _repository;
        public readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<CategoryItemDTO>> GetAllAsync(int page, int take)
        {   // category=>categoryItemDTO
            // entity=>dto
            int skipValue = (page - 1) * take; // 5
            var categories = await _repository
            .GetAll(skip: skipValue, take: take)
            .ToListAsync();

            _mapper.Map<IEnumerable<CategoryItemDTO>>(categories);
            return  _mapper.Map<IEnumerable<CategoryItemDTO>>(categories);;
        }

        public async Task<GetCategoryDTO> GetByIdAsync(int id)
        { // category=>getcategorydto
          // entity=>dto

           var category = await _repository.GetById(id);
        //    GetCategoryDTO getCategoryDTO = new GetCategoryDTO(
        //     category.Id,
        //     category.Name,
        //     category.Products.Select(p=>new ProductItemDTO(
        //         p.Id,
        //         p.Price,
        //         p.Name,
        //         p.Description,
        //         p.SKU
        //     )).ToList()
        //    );


            GetCategoryDTO getCategoryDTO=_mapper.Map<GetCategoryDTO>(category);
            return getCategoryDTO;
        }


        public async Task<bool> CreateAsync(CreateCategoryDTO categoryDTO)
        {
            if (await _repository.AnyAsync(category => category.Name == categoryDTO.Name))
            {
                return false;
            }
            
            // dto=>entity

            var category= _mapper.Map<Category>(categoryDTO);
            category.CreatedAt= DateTime.Now;
            category.CreatedBy="Admin";

            await _repository.AddAsync(category);
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

            // dto=>entity
            Category category = await _repository.GetById(id);
            if (category == null)
            {
                throw new Exception("Not Found");
            }

            if (await _repository.AnyAsync(category => category.Name == categoryDTO.Name && category.Id != id))
            {
                throw new Exception("Already Existes");
            }

             category= _mapper.Map(categoryDTO,category);
            //  category.Id=id;
            category.ModifiedAt= DateTime.Now;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }


    }
}
