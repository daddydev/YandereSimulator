using System;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class HomeClockScript : MonoBehaviour {

  // Token: 0x060004DF RID: 1247 RVA: 0x0004104C File Offset: 0x0003F44C
  private void Start() {
    this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
    if (HomeGlobals.Night) {
      this.HourLabel.text = "8:00 PM";
    } else {
      this.HourLabel.text = ((!HomeGlobals.LateForSchool) ? "6:30 AM" : "7:30 AM");
    }
  }

  // Token: 0x060004E0 RID: 1248 RVA: 0x000410B4 File Offset: 0x0003F4B4
  private string GetWeekdayText(DayOfWeek weekday) {
    if (weekday == DayOfWeek.Sunday) {
      return "SUNDAY";
    }
    if (weekday == DayOfWeek.Monday) {
      return "MONDAY";
    }
    if (weekday == DayOfWeek.Tuesday) {
      return "TUESDAY";
    }
    if (weekday == DayOfWeek.Wednesday) {
      return "WEDNESDAY";
    }
    if (weekday == DayOfWeek.Thursday) {
      return "THURSDAY";
    }
    if (weekday == DayOfWeek.Friday) {
      return "FRIDAY";
    }
    return "SATURDAY";
  }

  // Token: 0x04000B1C RID: 2844
  public UILabel HourLabel;

  // Token: 0x04000B1D RID: 2845
  public UILabel DayLabel;
}