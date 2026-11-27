using Ghando.Entity;
using Ghando.Service.Contracts;
using Ghando.Service.RequestForms.Contracts;
using Ghando.Service.RequestForms.Contracts.Dto;

namespace Ghando.Service.RequestForms;

public class RequestFormService : IRequestFormService
{
    private readonly  IRequestFormRepository _requestFormRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RequestFormService(
        IRequestFormRepository requestFormRepository , 
        IUnitOfWork unitOfWork)
    {
        _requestFormRepository = requestFormRepository;
        
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Guid>> AddRequestFormAsync(
        AddRequestFormDto dto, 
        CancellationToken cancellationToken = default)
    {
        var requestform = new RequestForm
        {
            FirstName = dto.FirstName,

            LastName = dto.LastName,

            PhoneNumber = dto.PhoneNumber,

            Text = dto.Text,

            Subject = dto.Subject,
            
            Status = RequestStatus.NotReviewed ,
        };

        var result = await _requestFormRepository.AddRequestFormAsync(
            requestform,
            cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result;
    }
}