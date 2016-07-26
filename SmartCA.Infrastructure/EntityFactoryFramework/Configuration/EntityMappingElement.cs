using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.EntityFactoryFramework.Configuration
{
    public sealed class EntityMappingElement : ConfigurationElement
    {
        [ConfigurationProperty(EntityMappingConstants.InterfaceShortTypeNameAttributeName, IsKey = true, IsRequired = true)]
        public string InterfaceShortTypeName
        {
            get { return (string)this[EntityMappingConstants.InterfaceShortTypeNameAttributeName]; }
            set
            {
                this[EntityMappingConstants.InterfaceShortTypeNameAttributeName] = value;
            }
        }

        [ConfigurationProperty(EntityMappingConstants.EntityFullTypeNameAttributeName, IsKey = true, IsRequired = true)]
        public string EntityFullTypeName
        {
            get { return (string)this[EntityMappingConstants.EntityFullTypeNameAttributeName]; }
            set
            {
                this[EntityMappingConstants.EntityFullTypeNameAttributeName] = value;
            }
        }
    }
}
