using System;
using UnityEngine;

// Token: 0x020001F5 RID: 501
[Serializable]
public class DateAndTime {

  // Token: 0x060008F5 RID: 2293 RVA: 0x0009E869 File Offset: 0x0009CC69
  public DateAndTime(int week, DayOfWeek weekday, Clock clock) {
    this.week = week;
    this.weekday = weekday;
    this.clock = clock;
  }

  // Token: 0x170000FC RID: 252
  // (get) Token: 0x060008F6 RID: 2294 RVA: 0x0009E886 File Offset: 0x0009CC86
  public int Week {
    get {
      return this.week;
    }
  }

  // Token: 0x170000FD RID: 253
  // (get) Token: 0x060008F7 RID: 2295 RVA: 0x0009E88E File Offset: 0x0009CC8E
  public DayOfWeek Weekday {
    get {
      return this.weekday;
    }
  }

  // Token: 0x170000FE RID: 254
  // (get) Token: 0x060008F8 RID: 2296 RVA: 0x0009E896 File Offset: 0x0009CC96
  public Clock Clock {
    get {
      return this.clock;
    }
  }

  // Token: 0x170000FF RID: 255
  // (get) Token: 0x060008F9 RID: 2297 RVA: 0x0009E8A0 File Offset: 0x0009CCA0
  public int TotalSeconds {
    get {
      int num = this.week * 604800;
      int num2 = (int)weekday * 86400;
      int totalSeconds = this.clock.TotalSeconds;
      return num + num2 + totalSeconds;
    }
  }

  // Token: 0x060008FA RID: 2298 RVA: 0x0009E8D8 File Offset: 0x0009CCD8
  public void IncrementWeek() {
    this.week++;
  }

  // Token: 0x060008FB RID: 2299 RVA: 0x0009E8E8 File Offset: 0x0009CCE8
  public void IncrementWeekday() {
    int num = (int)this.weekday;
    num++;
    if (num == 7) {
      this.IncrementWeek();
      num = 0;
    }
    this.weekday = (DayOfWeek)num;
  }

  // Token: 0x060008FC RID: 2300 RVA: 0x0009E918 File Offset: 0x0009CD18
  public void Tick(float dt) {
    int hours = this.clock.Hours24;
    this.clock.Tick(dt);
    int hours2 = this.clock.Hours24;
    if (hours2 < hours) {
      this.IncrementWeekday();
    }
  }

  // Token: 0x04001A0F RID: 6671
  [SerializeField]
  private int week;

  // Token: 0x04001A10 RID: 6672
  [SerializeField]
  private DayOfWeek weekday;

  // Token: 0x04001A11 RID: 6673
  [SerializeField]
  private Clock clock;
}