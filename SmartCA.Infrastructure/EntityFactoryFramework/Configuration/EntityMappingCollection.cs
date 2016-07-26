using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.EntityFactoryFramework.Configuration
{
    public sealed class EntityMappingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EntityMappingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EntityMappingElement)element).InterfaceShortTypeName;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return EntityMappingConstants.ConfigurationElementName;
            }
        }

        public EntityMappingElement this[int index]
        {
            get { return (EntityMappingElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new EntityMappingElement this[string interfaceShortTypeName]
        {
            get { return (EntityMappingElement)this.BaseGet(interfaceShortTypeName); }
        }

        public bool ContainsKey(string keyName)
        {
            object[] keys = this.BaseGetAllKeys();
            return keys.Any(a => (string)a == keyName);
        }

    }
}
