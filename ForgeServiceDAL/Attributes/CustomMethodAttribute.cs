using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomMethodAttribute : Attribute
    {
        public CustomMethodAttribute(string description)
        {
            Description = string.Format("Описание метода: ", description);
        }

        public string Description { get; private set; }
    }

}
