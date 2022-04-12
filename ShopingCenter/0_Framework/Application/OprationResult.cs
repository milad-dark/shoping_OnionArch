namespace _0_Framework.Application
{
    public class OprationResult
    {
        public bool IsSeccedded { get; set; }
        public string Message { get; set; }

        public OprationResult()
        {
            IsSeccedded = false;
        }

        public OprationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSeccedded = true;
            Message = message;
            return this;
        }

        public OprationResult Failed(string message)
        {
            IsSeccedded = false;
            Message = message;
            return this;
        }
    }
}
