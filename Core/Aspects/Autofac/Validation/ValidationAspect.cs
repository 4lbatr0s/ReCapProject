﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcern;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect: MethodInterception
    {
        private Type _validatorType;
        //we use Type value type because ValidationAspect is an Attribute.
        public ValidationAspect(Type validatorType) //send me the validator type. This is where we do [ValidationAspect (typeof(EntityValidator)) etc..
        {
            //if validatorType is not an IValidator, throw exception.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("This is not a validation class!");
            }

            _validatorType = validatorType;
        }

        //we fill in the OnBefore Function that we inherit from MethodInterception class.So the ValidationAspect (typeof(EntityValidator)) will work before the function.
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Reflector, works in runtime, Meaning: Create an instance of EntityValidator in runtime.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Find entityValidator's base type: AbstractValidator, find it's generic Type: EntityName
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //find for example Add() method's parameters in ProductManager, for example in Add() function we only give a Product instance, but we could give more.So fetch all.
            foreach (var entity in entities) //iterate one by one and validate by using ValidationTool. 
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
