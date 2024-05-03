using AutoMapper;
using TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.CriarTarefa;
using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<CriarTarefaRequest, Tarefa>()
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<AtualizarTarefaRequest, Tarefa>();
        }

        private void DomainToResponse()
        {
            CreateMap<Tarefa, RespostaTarefaJson>();
        }
    }
}

