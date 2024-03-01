using ecommerce.Enums;

namespace ecommerce.Shared
{
    public static class DatabaseTypeGetter
    {
        public static DatabaseEngine DbEngine { get; set; }

        public static string GetType(DataType type, int length = 256)
        {
            switch (type)
            {
                case DataType.IntegerType:
                    return "BIGINT";
                case DataType.DecimalType:
                    return "DECIMAL(10, 2)";
                case DataType.StringType:
                    return DbEngine == DatabaseEngine.MySql ? $"VARCHAR({length})" : $"NVARCHAR({length})";
                case DataType.DateTimeType:
                    return DbEngine == DatabaseEngine.MySql ? "DATETIME" : "DATETIME2";
                case DataType.BooleanType:
                    return DbEngine == DatabaseEngine.MySql ? "TINYINT(1)" : "BIT";
            }
            return "";
        }
    }
}
