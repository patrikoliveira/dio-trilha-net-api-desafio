using FluentValidation;
using TrilhaApiDesafio.Shared;
using TrilhaApiDesafio.Shared.Messages;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa
{
    public class AtualizarTarefaValidator : AbstractValidator<AtualizarTarefaRequest>
    {
        public AtualizarTarefaValidator()
        {
            RuleFor(tarefa => tarefa.Titulo).NotEmpty().WithMessage(ResourceMessages.TITULO_EMPTY);
            RuleFor(tarefa => tarefa.Titulo).MaximumLength(ResourceMessages.TITULO_MAX).WithMessage(ResourceMessages.TITULO_MAX_MESSAGE);
            RuleFor(tarefa => tarefa.Descricao).MaximumLength(ResourceMessages.DESCRICAO_MAX).WithMessage(ResourceMessages.DESCRICAO_MAX_MESSAGE);
            RuleFor(tarefa => tarefa.Data).Must(Utils.BeAValidDate).WithMessage(ResourceMessages.DATE_INVALID);
        }
    }
}

