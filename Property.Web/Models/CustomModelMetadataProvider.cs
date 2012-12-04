using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Property.Web.Models
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor,
                                                        Type modelType, string propertyName)
        {
            var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            if (meta.DisplayName == null)
                meta.DisplayName = meta.PropertyName.ToSeperatedWords();
            return meta;
        }
    }
}