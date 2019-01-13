namespace Abacus.Domain
{
    public abstract class InstrumentWithSchedule<TPeriod> : Instrument where TPeriod : Period
    {
        public InstrumentWithSchedule(ScheduleInfo scheduleInfo)
        {
            if (scheduleInfo == null)
            {
                throw new System.ArgumentNullException(nameof(scheduleInfo));
            }

            ScheduleInfo = scheduleInfo;
            Schedule = scheduleInfo.ExpandToSchedule<TPeriod>();
        }

        public InstrumentWithSchedule(ScheduleInfo scheduleInfo, Schedule<TPeriod> schedule)
        {
            if (scheduleInfo == null)
            {
                throw new System.ArgumentNullException(nameof(scheduleInfo));
            }
            if (schedule == null)
            {
                throw new System.ArgumentNullException(nameof(schedule));
            }

            ScheduleInfo = scheduleInfo;
            Schedule = schedule;
        }

        public ScheduleInfo ScheduleInfo { get; }

        public Schedule<TPeriod> Schedule { get; }
    }
}
