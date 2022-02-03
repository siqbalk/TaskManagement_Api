namespace Common.DTO
{
    public class ApiResponseDto
    {
        public int Status { get; set; }
        public dynamic ResponseData { get; set; }
        public string Error { get; set; }
        public bool IsSuccessful { get; set; }
    }


}
