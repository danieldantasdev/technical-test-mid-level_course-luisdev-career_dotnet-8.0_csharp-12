﻿using Jobs.CleanArchitecture.Application.Commands.Jobs.Update;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Create;

public class CreateJobCommandHandler(IJobRepository jobRepository) : IRequestHandler<CreateJobCommandInputModel, CreateJobCommandViewModel>
{
    private readonly IJobRepository _jobRepository = jobRepository;
    public async Task<CreateJobCommandViewModel> Handle(CreateJobCommandInputModel request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.Post(CreateJobCommandInputModel.ToEntity(request));
        return new CreateJobCommandViewModel(job);
    }
}
