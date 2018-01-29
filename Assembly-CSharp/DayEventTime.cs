using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
[Serializable]
public class DayEventTime : IScheduledEventTime {

  // Token: 0x060002BA RID: 698 RVA: 0x00035174 File Offset: 0x00033574
  public DayEventTime(int week, DayOfWeek weekday) {
    this.week = week;
    this.weekday = weekday;
  }

  // Token: 0x17000052 RID: 82
  // (get) Token: 0x060002BB RID: 699 RVA: 0x0003518A File Offset: 0x0003358A
  public ScheduledEventTimeType ScheduleType {
    get {
      return ScheduledEventTimeType.Day;
    }
  }

  // Token: 0x060002BC RID: 700 RVA: 0x0003518D File Offset: 0x0003358D
  public bool OccurringNow(DateAndTime currentTime) {
    return currentTime.Week == this.week && currentTime.Weekday == this.weekday;
  }

  // Token: 0x060002BD RID: 701 RVA: 0x000351B1 File Offset: 0x000335B1
  public bool OccursInTheFuture(DateAndTime currentTime) {
    if (currentTime.Week == this.week) {
      return currentTime.Weekday < this.weekday;
    }
    return currentTime.Week < this.week;
  }

  // Token: 0x060002BE RID: 702 RVA: 0x000351E1 File Offset: 0x000335E1
  public bool OccurredInThePast(DateAndTime currentTime) {
    if (currentTime.Week == this.week) {
      return currentTime.Weekday > this.weekday;
    }
    return currentTime.Week > this.week;
  }

  // Token: 0x040008C9 RID: 2249
  [SerializeField]
  private int week;

  // Token: 0x040008CA RID: 2250
  [SerializeField]
  private DayOfWeek weekday;
}