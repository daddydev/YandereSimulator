using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
[Serializable]
public class SpecificEventTime : IScheduledEventTime {

  // Token: 0x060002B0 RID: 688 RVA: 0x00034ED9 File Offset: 0x000332D9
  public SpecificEventTime(int week, DayOfWeek weekday, Clock startClock, Clock endClock) {
    this.week = week;
    this.weekday = weekday;
    this.startClock = startClock;
    this.endClock = endClock;
  }

  // Token: 0x17000050 RID: 80
  // (get) Token: 0x060002B1 RID: 689 RVA: 0x00034EFE File Offset: 0x000332FE
  public ScheduledEventTimeType ScheduleType {
    get {
      return ScheduledEventTimeType.Specific;
    }
  }

  // Token: 0x060002B2 RID: 690 RVA: 0x00034F04 File Offset: 0x00033304
  public bool OccurringNow(DateAndTime currentTime) {
    bool flag = currentTime.Week == this.week;
    bool flag2 = currentTime.Weekday == this.weekday;
    Clock clock = currentTime.Clock;
    bool flag3 = clock.TotalSeconds >= this.startClock.TotalSeconds && clock.TotalSeconds < this.endClock.TotalSeconds;
    return flag && flag2 && flag3;
  }

  // Token: 0x060002B3 RID: 691 RVA: 0x00034F74 File Offset: 0x00033374
  public bool OccursInTheFuture(DateAndTime currentTime) {
    if (currentTime.Week != this.week) {
      return currentTime.Week < this.week;
    }
    if (currentTime.Weekday == this.weekday) {
      return currentTime.Clock.TotalSeconds < this.startClock.TotalSeconds;
    }
    return currentTime.Weekday < this.weekday;
  }

  // Token: 0x060002B4 RID: 692 RVA: 0x00034FDC File Offset: 0x000333DC
  public bool OccurredInThePast(DateAndTime currentTime) {
    if (currentTime.Week != this.week) {
      return currentTime.Week > this.week;
    }
    if (currentTime.Weekday == this.weekday) {
      return currentTime.Clock.TotalSeconds >= this.endClock.TotalSeconds;
    }
    return currentTime.Weekday > this.weekday;
  }

  // Token: 0x040008C2 RID: 2242
  [SerializeField]
  private int week;

  // Token: 0x040008C3 RID: 2243
  [SerializeField]
  private DayOfWeek weekday;

  // Token: 0x040008C4 RID: 2244
  [SerializeField]
  private Clock startClock;

  // Token: 0x040008C5 RID: 2245
  [SerializeField]
  private Clock endClock;
}