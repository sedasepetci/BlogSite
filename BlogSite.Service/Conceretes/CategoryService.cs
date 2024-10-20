

using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Conceretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create)
    {
        Category createdCategory = _mapper.Map<Category>(create);

        _categoryRepository.Add(createdCategory);
        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Kategori Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> result = _mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = result,
            Message = "Listelendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        var category = _categoryRepository.GetById(id);

        var response = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        Category category = _categoryRepository.GetById(id);
        Category deletedCategory = _categoryRepository.Remove(category);
        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Kategori silindi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
    {

        Category category = _categoryRepository.GetById(updateCategory.Id);

        if (category == null)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = "Kategori bulunamadı.",
                StatusCode = 404,
                Success = false
            };
        }

       
        category.CategoryName = updateCategory.CategoryName;
        category.UpdatedDate = DateTime.Now;

       
        Category updatedCategory = _categoryRepository.Update(category);

       
        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);

      
        return new ReturnModel<CategoryResponseDto>
        {
            Data = dto,
            Message = "Kategori başarıyla güncellendi.",
            StatusCode = 200,
            Success = true
        };
    }
}
