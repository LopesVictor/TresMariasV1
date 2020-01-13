namespace Service.Dto
{
    public class ResponseDto<T>
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public T Obj { get; set; }
    }
}
