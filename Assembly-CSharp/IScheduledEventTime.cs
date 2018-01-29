// Token: 0x020000B1 RID: 177
public interface IScheduledEventTime {

  // Token: 0x1700004F RID: 79
  // (get) Token: 0x060002AC RID: 684
  ScheduledEventTimeType ScheduleType { get; }

  // Token: 0x060002AD RID: 685
  bool OccurringNow(DateAndTime currentTime);

  // Token: 0x060002AE RID: 686
  bool OccursInTheFuture(DateAndTime currentTime);

  // Token: 0x060002AF RID: 687
  bool OccurredInThePast(DateAndTime currentTime);
}