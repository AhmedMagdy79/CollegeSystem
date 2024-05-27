namespace CollegeSystem.Core.Models
{
    public class ServiceResult<T>
    {
        public int StatusCode { get; set; }

        public T? Result { get; set; }
    }
}
