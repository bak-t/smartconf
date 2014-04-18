using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartConf
{
    public class PropertyChain
    {
        private readonly PropertyInfo _property;
        private readonly PropertyChain _parent;

        public PropertyChain(PropertyInfo property)
        {
            _property = property;
            _parent = null;
        }

        public PropertyChain(PropertyChain parent, PropertyInfo property)
        {
            _property = property;
            _parent = parent;
        }

        public override string ToString()
        {
            return GetProperties()
                .Select(_ => _.Name)
                .Aggregate((a, b) => a + "." + b);
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            var current = this;
            do
            {
                yield return current._property;
                current = current._parent;
            }
            while (current!=null);
            
        }
    }
}
