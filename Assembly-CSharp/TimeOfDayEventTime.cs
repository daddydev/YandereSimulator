using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
[Serializable]
public class TimeOfDayEventTime : IScheduledEventTime {

  // Token: 0x060002B5 RID: 693 RVA: 0x00035044 File Offset: 0x00033444
  public TimeOfDayEventTime(int week, DayOfWeek weekday, TimeOfDay timeOfDay) {
    this.week = week;
    this.weekday = weekday;
    this.timeOfDay = timeOfDay;
  }

  // Token: 0x17000051 RID: 81
  // (get) Token: 0x060002B6 RID: 694 RVA: 0x00035061 File Offset: 0x00033461
  public ScheduledEventTimeType ScheduleType {
    get {
      return ScheduledEventTimeType.TimeOfDay;
    }
  }

  // Token: 0x060002B7 RID: 695 RVA: 0x00035064 File Offset: 0x00033464
  public bool OccurringNow(DateAndTime currentTime) {
    bool flag = currentTime.Week == this.week;
    bool flag2 = currentTime.Weekday == this.weekday;
    bool flag3 = currentTime.Clock.TimeOfDay == this.timeOfDay;
    return flag && flag2 && flag3;
  }

  // Token: 0x060002B8 RID: 696 RVA: 0x000350B4 File Offset: 0x000334B4
  public bool OccursInTheFuture(DateAndTime currentTime) {
    if (currentTime.Week != this.week) {
      return currentTime.Week < this.week;
    }
    if (currentTime.Weekday == this.weekday) {
      return currentTime.Clock.TimeOfDay < this.timeOfDay;
    }
    return currentTime.Weekday < this.weekday;
  }

  // Token: 0x060002B9 RID: 697 RVA: 0x00035114 File Offset: 0x00033514
  public bool OccurredInThePast(DateAndTime currentTime) {
    if (currentTime.Week != this.week) {
      return currentTime.Week > this.week;
    }
    if (currentTime.Weekday == this.weekday) {
      return currentTime.Clock.TimeOfDay > this.timeOfDay;
    }
    return currentTime.Weekday > this.weekday;
  }

  // Token: 0x040008C6 RID: 2246
  [SerializeField]
  private int week;

  // Token: 0x040008C7 RID: 2247
  [SerializeField]
  private DayOfWeek weekday;

  // Token: 0x040008C8 RID: 2248
  [SerializeField]
  private TimeOfDay timeOfDay;
}