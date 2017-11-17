using ControleJogo.Infra.DatabaseRead.OutputModel;
using System;

namespace ControleJogo.Extensions
{
    public static class ModelConverter
    {
        public static O ConvertTo<O>(this IOutputModel input) where O : class
        {
            var obj = Activator.CreateInstance<O>();
            foreach (var propertyOutput in obj.GetType().GetProperties())
            {
                var propertyInput = input.GetType().GetProperty(propertyOutput.Name);
                if (propertyInput == null)
                    continue;

                propertyOutput.SetValue(obj, propertyInput.GetValue(input));
            }
            return obj;
        }
    }
}