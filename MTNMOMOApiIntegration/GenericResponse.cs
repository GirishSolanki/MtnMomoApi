namespace MTNMOMOApiIntegration
{
    public class GenericResponse<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public bool Success { get; set; }

        public GenericResponse(string status, string message, T result, bool success)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
            this.Success = success;
        }
    }
}
