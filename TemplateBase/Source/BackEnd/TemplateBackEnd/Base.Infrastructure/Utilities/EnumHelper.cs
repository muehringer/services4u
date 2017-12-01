using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Utilities
{
    public class EnumHelper
    {
        public static string PesquisarDescricaoEnum(Enum valorEnum)
        {
            FieldInfo fieldInfo = valorEnum.GetType().GetField(valorEnum.ToString());
            DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                return descriptionAttributes[0].Description;
            }
            else
            {
                return valorEnum.ToString();
            }
        }
    }
}
