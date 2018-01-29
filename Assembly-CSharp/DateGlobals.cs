using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public static class DateGlobals {

  // Token: 0x17000065 RID: 101
  // (get) Token: 0x06000375 RID: 885 RVA: 0x0003AE2A File Offset: 0x0003922A
  // (set) Token: 0x06000376 RID: 886 RVA: 0x0003AE36 File Offset: 0x00039236
  public static int Week {
    get {
      return PlayerPrefs.GetInt("Week");
    }
    set {
      PlayerPrefs.SetInt("Week", value);
    }
  }

  // Token: 0x17000066 RID: 102
  // (get) Token: 0x06000377 RID: 887 RVA: 0x0003AE43 File Offset: 0x00039243
  // (set) Token: 0x06000378 RID: 888 RVA: 0x0003AE4F File Offset: 0x0003924F
  public static DayOfWeek Weekday {
    get {
      return GlobalsHelper.GetEnum<DayOfWeek>("Weekday");
    }
    set {
      GlobalsHelper.SetEnum<DayOfWeek>("Weekday", value);
    }
  }

  // Token: 0x06000379 RID: 889 RVA: 0x0003AE5C File Offset: 0x0003925C
  public static void DeleteAll() {
    Globals.Delete("Week");
    Globals.Delete("Weekday");
  }

  // Token: 0x040009CB RID: 2507
  private const string Str_Week = "Week";

  // Token: 0x040009CC RID: 2508
  private const string Str_Weekday = "Weekday";
}