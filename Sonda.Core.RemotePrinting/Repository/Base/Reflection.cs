using System;
using System.Collections;
using System.Reflection;

namespace Sonda.Core.RemotePrinting.Repository.Base
{
    public static class Reflection
    {
        public static void CopyProperties(this object source, object destination, bool onlyPrimitives = true)
        {
     
            if (source == null || destination == null)
                throw new Exception("Source or/and Destination Objects are null");
     
            Type typeDest = destination.GetType();
            Type typeSrc = source.GetType();

            PropertyInfo[] srcProps = typeSrc.GetProperties();
            foreach (PropertyInfo srcProp in srcProps)
            {
                if (!srcProp.CanRead)
                {
                    continue;
                }
                PropertyInfo targetProperty = typeDest.GetProperty(srcProp.Name);
                if (targetProperty == null)
                {
                    continue;
                }
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod() != null && ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0))
                {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                {
                    continue;
                }
                if (onlyPrimitives && (targetProperty.PropertyType.IsClass || typeof(IEnumerable).IsAssignableFrom(targetProperty.PropertyType)))
                {
                    if (targetProperty.PropertyType != typeof(string) && targetProperty.PropertyType != typeof(byte[]))
                    {
                        continue;
                    }
                }
                
                targetProperty.SetValue(destination, srcProp.GetValue(source, null), null);
            }
        }
    }
}
