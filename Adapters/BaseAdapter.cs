
using System;

namespace alsideeq_bookstore_api.Adapters
{
    public class BaseAdapter
    {
        protected void AssignRowValueToModel<T>(Action<object> setter, object rowValue)
        {
            if (rowValue == null || rowValue == System.DBNull.Value)
            {
                if (typeof(T) == typeof(string))
                {
                    rowValue = string.Empty;
                }
                else 
                {
                    return;
                }
            }

            setter(rowValue);
        }

        protected void AssignModelValueToDomain<T>(Action<object> setter, object modelValue)
        {
            if (modelValue == null)
            {
                return;
            }

            setter(modelValue);
        }
    }
}