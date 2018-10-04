namespace dateRange.DTOs
{
    public class PatternsDTO
    {
        public string StartPattern { get; set; }
        public string EndPattern { get; set; }

        public PatternsDTO(string startPattern, string endPattern)
        {
            StartPattern = startPattern;
            EndPattern = endPattern;
        }
    }
}
