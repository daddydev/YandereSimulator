using System;

// Token: 0x02000191 RID: 401
[Serializable]
public class DateSaveData {

  // Token: 0x06000726 RID: 1830 RVA: 0x0006CF48 File Offset: 0x0006B348
  public static DateSaveData ReadFromGlobals() {
    return new DateSaveData {
      week = DateGlobals.Week,
      weekday = DateGlobals.Weekday
    };
  }

  // Token: 0x06000727 RID: 1831 RVA: 0x0006CF72 File Offset: 0x0006B372
  public static void WriteToGlobals(DateSaveData data) {
    DateGlobals.Week = data.week;
    DateGlobals.Weekday = data.weekday;
  }

  // Token: 0x04001218 RID: 4632
  public int week;

  // Token: 0x04001219 RID: 4633
  public DayOfWeek weekday;
}