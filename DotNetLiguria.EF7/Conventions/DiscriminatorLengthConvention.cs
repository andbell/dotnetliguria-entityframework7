using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLiguria.EF7.Conventions
{
    public class DiscriminatorLengthConvention : IEntityTypeBaseTypeChangedConvention
    {
        public void ProcessEntityTypeBaseTypeChanged(
            IConventionEntityTypeBuilder entityTypeBuilder, 
            IConventionEntityType newBaseType, 
            IConventionEntityType oldBaseType, 
            IConventionContext<IConventionEntityType> context)
        {
            var discriminatorProperty = entityTypeBuilder.Metadata.FindDiscriminatorProperty();
            if (discriminatorProperty != null && discriminatorProperty.ClrType == typeof(string))
            {
                discriminatorProperty.Builder.HasMaxLength(80);
            }
        }
    }
}
