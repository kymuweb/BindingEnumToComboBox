using System;
using System.ComponentModel;

namespace EnumClass
{
    /// <summary>
    /// Gets or sets the draft document handling setup which controls how draft documents will be deleted after publishing.
    /// </summary>
    public enum MyEnumType
    {
        [Description("Description 1")]
        Option1 = 0,
        [Description("Description 2")]
        Option2 = 1,
        [Description("Description 3")]
        Option3 = 2,
        [Description("Description 4")]
        Option4 = 3,
    }

    public class EnumClass
    {
        /// <summary>
        /// Gets the description for an enum value.
        /// 
        /// </summary>
        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// Gets an enum value by the description.
        /// </summary>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }
    }
}