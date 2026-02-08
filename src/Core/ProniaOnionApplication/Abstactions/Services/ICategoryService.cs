namespace ProniaOnion.src.Application
{
    public interface ICategoryService
    {
        
         Task<IEnumerable<CategoryItemDTO>> GetAllAsync(int page,int take);
         Task<GetCategoryDTO> GetByIdAsync(int id);
         Task<bool> CreateAsync(CreateCategoryDTO categoryDTO);
         Task DeleteAsync(int id);
         Task UpdateAsync(int id,UpdateCategoryDTO categoryDTO); 
    }
}