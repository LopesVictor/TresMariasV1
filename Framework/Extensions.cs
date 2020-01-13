using System;

namespace Framework
{
    public static class Extensions
    {
        public static object NullToNew(this object objeto)
        {
            if (objeto == null)
                return new object();

            return objeto;
        }

        public static int AsId(this object item, int defaultId = -1)
        {
            if (item == null)
                return defaultId;

            int result;

            if (!int.TryParse(item.ToString(), out result))
                return defaultId;

            return result;
        }

        public static int AsInt(this object item, int defaultInt = default(int))
        {
            if (item == null)
                return defaultInt;

            int result;

            if (!int.TryParse(item.ToString(), out result))
                return defaultInt;

            return result;
        }

        public static decimal AsDecimal(this object item, decimal defaultDecimal = default(decimal))
        {
            if (item == null || item.Equals(DBNull.Value))
                return defaultDecimal;

            return Convert.ToDecimal(item);
        }

        public static string AsString(this object item, string defaultString = default(string))
        {
            if (item == null || item.Equals(DBNull.Value))
                return defaultString;

            return item.ToString().Trim();

        }

        public static Boolean AsBoolean(this object item, Boolean defaultBoolean = default(Boolean))
        {
            if (item == null || item.Equals(DBNull.Value))
                return defaultBoolean;

            return ((bool)item) ? false : true;
        }
    }
}

