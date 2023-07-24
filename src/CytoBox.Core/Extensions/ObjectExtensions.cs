namespace CytoBox.Core.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj is null;
        }

        /// <summary>
        /// 判断对象是否不为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return obj is not null;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        public static void ThrowIfNull(this object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }
    }
}
