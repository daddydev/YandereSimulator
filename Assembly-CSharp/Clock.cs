using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001F4 RID: 500
[Serializable]
public class Clock {

  // Token: 0x060008E1 RID: 2273 RVA: 0x0009E5CD File Offset: 0x0009C9CD
  public Clock(int hours, int minutes, int seconds, float currentSecond) {
    this.hours = hours;
    this.minutes = minutes;
    this.seconds = seconds;
    this.currentSecond = currentSecond;
  }

  // Token: 0x060008E2 RID: 2274 RVA: 0x0009E5F2 File Offset: 0x0009C9F2
  public Clock(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0f) {
  }

  // Token: 0x060008E3 RID: 2275 RVA: 0x0009E602 File Offset: 0x0009CA02
  public Clock() : this(0, 0, 0, 0f) {
  }

  // Token: 0x170000F2 RID: 242
  // (get) Token: 0x060008E4 RID: 2276 RVA: 0x0009E612 File Offset: 0x0009CA12
  public int Hours24 {
    get {
      return this.hours;
    }
  }

  // Token: 0x170000F3 RID: 243
  // (get) Token: 0x060008E5 RID: 2277 RVA: 0x0009E61C File Offset: 0x0009CA1C
  public int Hours12 {
    get {
      int num = this.hours % 12;
      return (num != 0) ? num : 12;
    }
  }

  // Token: 0x170000F4 RID: 244
  // (get) Token: 0x060008E6 RID: 2278 RVA: 0x0009E641 File Offset: 0x0009CA41
  public int Minutes {
    get {
      return this.minutes;
    }
  }

  // Token: 0x170000F5 RID: 245
  // (get) Token: 0x060008E7 RID: 2279 RVA: 0x0009E649 File Offset: 0x0009CA49
  public int Seconds {
    get {
      return this.seconds;
    }
  }

  // Token: 0x170000F6 RID: 246
  // (get) Token: 0x060008E8 RID: 2280 RVA: 0x0009E651 File Offset: 0x0009CA51
  public float CurrentSecond {
    get {
      return this.currentSecond;
    }
  }

  // Token: 0x170000F7 RID: 247
  // (get) Token: 0x060008E9 RID: 2281 RVA: 0x0009E659 File Offset: 0x0009CA59
  public int TotalSeconds {
    get {
      return this.hours * 3600 + this.minutes * 60 + this.seconds;
    }
  }

  // Token: 0x170000F8 RID: 248
  // (get) Token: 0x060008EA RID: 2282 RVA: 0x0009E678 File Offset: 0x0009CA78
  public float PreciseTotalSeconds {
    get {
      return (float)this.TotalSeconds + this.currentSecond;
    }
  }

  // Token: 0x170000F9 RID: 249
  // (get) Token: 0x060008EB RID: 2283 RVA: 0x0009E688 File Offset: 0x0009CA88
  public bool IsAM {
    get {
      return this.hours < 12;
    }
  }

  // Token: 0x170000FA RID: 250
  // (get) Token: 0x060008EC RID: 2284 RVA: 0x0009E694 File Offset: 0x0009CA94
  public TimeOfDay TimeOfDay {
    get {
      if (this.hours < 3) {
        return TimeOfDay.Midnight;
      }
      if (this.hours < 6) {
        return TimeOfDay.EarlyMorning;
      }
      if (this.hours < 9) {
        return TimeOfDay.Morning;
      }
      if (this.hours < 12) {
        return TimeOfDay.LateMorning;
      }
      if (this.hours < 15) {
        return TimeOfDay.Noon;
      }
      if (this.hours < 18) {
        return TimeOfDay.Afternoon;
      }
      if (this.hours < 21) {
        return TimeOfDay.Evening;
      }
      return TimeOfDay.Night;
    }
  }

  // Token: 0x170000FB RID: 251
  // (get) Token: 0x060008ED RID: 2285 RVA: 0x0009E709 File Offset: 0x0009CB09
  public string TimeOfDayString {
    get {
      return Clock.TimeOfDayStrings[this.TimeOfDay];
    }
  }

  // Token: 0x060008EE RID: 2286 RVA: 0x0009E71B File Offset: 0x0009CB1B
  public bool IsBefore(Clock clock) {
    return this.TotalSeconds < clock.TotalSeconds;
  }

  // Token: 0x060008EF RID: 2287 RVA: 0x0009E72B File Offset: 0x0009CB2B
  public bool IsAfter(Clock clock) {
    return this.TotalSeconds > clock.TotalSeconds;
  }

  // Token: 0x060008F0 RID: 2288 RVA: 0x0009E73B File Offset: 0x0009CB3B
  public void IncrementHour() {
    this.hours++;
    if (this.hours == 24) {
      this.hours = 0;
    }
  }

  // Token: 0x060008F1 RID: 2289 RVA: 0x0009E75F File Offset: 0x0009CB5F
  public void IncrementMinute() {
    this.minutes++;
    if (this.minutes == 60) {
      this.IncrementHour();
      this.minutes = 0;
    }
  }

  // Token: 0x060008F2 RID: 2290 RVA: 0x0009E789 File Offset: 0x0009CB89
  public void IncrementSecond() {
    this.seconds++;
    if (this.seconds == 60) {
      this.IncrementMinute();
      this.seconds = 0;
    }
  }

  // Token: 0x060008F3 RID: 2291 RVA: 0x0009E7B3 File Offset: 0x0009CBB3
  public void Tick(float dt) {
    this.currentSecond += dt;
    while (this.currentSecond >= 1f) {
      this.IncrementSecond();
      this.currentSecond -= 1f;
    }
  }

  // Token: 0x04001A0A RID: 6666
  [SerializeField]
  private int hours;

  // Token: 0x04001A0B RID: 6667
  [SerializeField]
  private int minutes;

  // Token: 0x04001A0C RID: 6668
  [SerializeField]
  private int seconds;

  // Token: 0x04001A0D RID: 6669
  [SerializeField]
  private float currentSecond;

  // Token: 0x04001A0E RID: 6670
  private static readonly Dictionary<TimeOfDay, string> TimeOfDayStrings = new Dictionary<TimeOfDay, string>
  {
    {
      TimeOfDay.Midnight,
      "Midnight"
    },
    {
      TimeOfDay.EarlyMorning,
      "Early Morning"
    },
    {
      TimeOfDay.Morning,
      "Morning"
    },
    {
      TimeOfDay.LateMorning,
      "Late Morning"
    },
    {
      TimeOfDay.Noon,
      "Noon"
    },
    {
      TimeOfDay.Afternoon,
      "Afternoon"
    },
    {
      TimeOfDay.Evening,
      "Evening"
    },
    {
      TimeOfDay.Night,
      "Night"
    }
  };
}