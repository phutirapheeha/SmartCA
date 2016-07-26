using System;
using System.Configuration;
using System.Linq;

namespace SmartCA.Infrastructure.RepositoryFramework.Configuration
{
    public sealed class RepositoryMappingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RepositoryMappingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RepositoryMappingElement)element).InterfaceShortTypeName;
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
                return RepositoryMappingConstants.ConfigurationElementName;
            }
        }

        public RepositoryMappingElement this[int index]
        {
            get { return (RepositoryMappingElement)this.BaseGet(index); }
            set
            {
                if(this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new RepositoryMappingElement this[string interfaceShortTypeName]
        {
            get { return (RepositoryMappingElement)this.BaseGet(interfaceShortTypeName); }
        }

        public bool ContainsKey(string keyName)
        {
            object[] keys = this.BaseGetAllKeys();
            return keys.Any(a => (string)a == keyName);
        }
    }
}
