using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    public class TypeDocumentConfiguration : IEntityTypeConfiguration<TypeDocument>
    {
        public void Configure(EntityTypeBuilder<TypeDocument> builder)
        {
            builder.ToTable("DocumentType").HasKey(x => x.DocumentTypeId);
        }
    }
}
