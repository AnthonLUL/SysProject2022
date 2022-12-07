namespace AbsenseApi.Models
{
    public class Schedule
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Schedule(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
