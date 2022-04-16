namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool IsSeccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSeccedded = false;
        }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSeccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSeccedded = false;
            Message = message;
            return this;
        }
    }
}
