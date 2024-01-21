using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;
using System.Net;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Update;

public class UpdateJobCommandHandler(IJobRepository jobRepository) : IRequestHandler<UpdateJobCommandInputModel, GenericViewModel<UpdateJobCommandViewModel>>
{
    private readonly IJobRepository _jobRepository = jobRepository;
    public async Task<GenericViewModel<UpdateJobCommandViewModel>> Handle(UpdateJobCommandInputModel request, CancellationToken cancellationToken)
    {
        try
        {
            int jobRepository = await _jobRepository.Update(UpdateJobCommandInputModel.ToEntity(request));
            UpdateJobCommandViewModel jobViewModel = UpdateJobCommandViewModel.ToViewModel(jobRepository);

            if (jobRepository is 1)
            {
                return GenericViewModel<UpdateJobCommandViewModel>.Create(HttpStatusCode.NoContent, "Jobs updating successfully", null);
            }
            else if (jobRepository is 0)
            {
                return GenericViewModel<UpdateJobCommandViewModel>.Create(HttpStatusCode.InternalServerError, "Error updating job", null);
            }
            else
            {
                return GenericViewModel<UpdateJobCommandViewModel>.Create(HttpStatusCode.InternalServerError, "Error updating job", null);
            }

        }
        catch (Exception ex)
        {
            return GenericViewModel<UpdateJobCommandViewModel>.Create(HttpStatusCode.InternalServerError, "Error updating job: " + ex.Message, null);
        }
    }
}
