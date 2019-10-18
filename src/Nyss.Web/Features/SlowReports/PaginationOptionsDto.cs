namespace Nyss.Web.Features.SlowReports
{
    public class PaginationOptionsDto
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public ColumnOrder[] Order { get; set; }
        public Column[] Columns { get; set; }
        public SearchValue Search { get; set; }
    }

    public class ColumnOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class Column
    {
        public string Data { get; set; }
        public SearchValue Search { get; set; }
    }

    public class SearchValue
    {
        public string Value { get; set; }
    }
}
