using Ghando.Entity;
using Ghando.Service.Categories.Contracts;
using Ghando.Service.Categories.Contracts.Dto;
using Ghando.Service.Contracts;

namespace Ghando.Service.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository  _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> AddAsync(AddCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var category = new Category
        {
            Title = dto.Title
        };

        var result = await _repository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result;

    }
}