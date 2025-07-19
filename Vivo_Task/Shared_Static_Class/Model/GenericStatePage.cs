
namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class GenericStatePage<T>
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; }
        public int TotalPages { get; set; } = 0;
        public int TotalRecords { get; set; }
        public bool isFirstpage { get; set; }
        public bool isLastpage { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string[] Message { get; set; }
        public List<T> Data { get; set; }
    }
}