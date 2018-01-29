using System;
using UnityEngine;

// Token: 0x020000B5 RID: 181
[Serializable]
public class WeekEventTime : IScheduledEventTime {

  // Token: 0x060002BF RID: 703 RVA: 0x00035211 File Offset: 0x00033611
  public WeekEventTime(int week) {
    this.week = week;
  }

  // Token: 0x17000053 RID: 83
  // (get) Token: 0x060002C0 RID: 704 RVA: 0x00035220 File Offset: 0x00033620
  public ScheduledEventTimeType ScheduleType {
    get {
      return ScheduledEventTimeType.Week;
    }
  }

  // Token: 0x060002C1 RID: 705 RVA: 0x00035223 File Offset: 0x00033623
  public bool OccurringNow(DateAndTime currentTime) {
    return currentTime.Week == this.week;
  }

  // Token: 0x060002C2 RID: 706 RVA: 0x00035233 File Offset: 0x00033633
  public bool OccursInTheFuture(DateAndTime currentTime) {
    return currentTime.Week < this.week;
  }

  // Token: 0x060002C3 RID: 707 RVA: 0x00035243 File Offset: 0x00033643
  public bool OccurredInThePast(DateAndTime currentTime) {
    return currentTime.Week > this.week;
  }

  // Token: 0x040008CB RID: 2251
  [SerializeField]
  private int week;
}