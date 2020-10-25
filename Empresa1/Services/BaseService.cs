using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa1.Interfaces;
using Empresa1.Models;
using Empresa1.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Empresa1.Services
{
    public class BaseService
    {
        private readonly INotifier _notification;

        public BaseService(INotifier notification)
        {
            _notification = notification;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notification.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE> where TE : Entity
        {
            var valid = validation.Validate(entity);

            if (valid.IsValid) return true;

            Notify(valid);

            return false;
        }
    }
}
