using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class CustomInterfaceAttribute : Attribute
    {
        public CustomInterfaceAttribute(string description)
        {
            Description = string.Format("Описание инетфейса: ", description);
        }

        public string Description { get; private set; }
    }

}
