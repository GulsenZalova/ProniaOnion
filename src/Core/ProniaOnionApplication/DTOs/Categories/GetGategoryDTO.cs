  namespace ProniaOnion.src.Application 
{
     public record GetCategoryDTO(int Id, string Name,ICollection<ProductItemDTO> Products);
}