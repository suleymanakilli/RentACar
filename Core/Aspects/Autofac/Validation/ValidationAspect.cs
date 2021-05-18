using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilites.Interceptors;
using Core.Utilites.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//Gönderilen validator type IValidator type değilse
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Objeye ulaşmak istiyoruz. Mesela car nesnesi. Yani  Fluent Validation içindeki AbstractValidator<Car>'daki Car argümanına ulaşmak istiyoruz
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Metodun argümanlarına ulaştık. void Add(Car car) buradaki car'a ulaşmış olduk. Birden fazlada olabilir
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
