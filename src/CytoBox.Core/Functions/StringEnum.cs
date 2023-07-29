using CytoBox.Core.Attributes;
using System.Reflection;

namespace CytoBox.Core.Functions
{
    /// <summary>
    /// Get DisplayText
    /// </summary>
    public class StringEnum
    {
        /// <summary>
        /// Get DisplayText
        /// </summary>
        /// <param name="value">Enum</param>
        /// <returns>Attribute：DisplayText Value</returns>
        public static string GetStringValue(Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString())!;
            DisplayTextAttribute? attr = fieldInfo.GetCustomAttribute(typeof(DisplayTextAttribute), false) as DisplayTextAttribute;
            return attr!.DisplayText;
        }

        /// <summary>
        /// Get DisplayText
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Attribute：DisplayText Value</returns>
        public static string GetStringValue(Type enumType)
        {
            DisplayTextAttribute? attr = enumType.GetCustomAttribute(typeof(DisplayTextAttribute), false) as DisplayTextAttribute;
            return attr!.DisplayText;
        }

        /// <summary>
        /// Enum To List
        /// </summary>
        /// <param name="enumType">Enum Type</param>
        /// <returns>EnumList</returns>
        /// <exception cref="ArgumentException"></exception>
        public static EnumList GetEnumList(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException($"传入的类型不是枚举，类型是 {enumType}");

            EnumList enumList = new()
            {
                type = enumType,
                data = new List<EnumList.Item>()
            };

            foreach (Enum item in Enum.GetValues(enumType))
            {
                enumList.data.Add(new EnumList.Item()
                {
                    Key = Convert.ToInt32(item),
                    Value = GetStringValue(item)
                });
            }
            return enumList;
        }

        public struct EnumList
        {
            public Type type;

            public List<Item> data;
            public struct Item
            {
                public int Key;
                public string Value;
            }
        }
    }
}
