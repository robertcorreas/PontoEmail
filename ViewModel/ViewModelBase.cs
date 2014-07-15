using Catel.Data;
using Model;
using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class ViewModelBase : Catel.MVVM.ViewModelBase
    {
        public void Validate<T>(PropertyData propertyData, T property, List<IFieldValidationResult> validationResults, Func<T, ValidationMessage> validationMethod)
        {
            ValidationMessage validationMessage = validationMethod.Invoke(property);
            if (!validationMessage.Success)
            {
                validationResults.Add(FieldValidationResult.CreateError(propertyData, validationMessage.Message));
            }
        }
    }
}