// Token: 0x020000DA RID: 218
public static class HomeGlobals {

  // Token: 0x17000073 RID: 115
  // (get) Token: 0x060003A4 RID: 932 RVA: 0x0003B264 File Offset: 0x00039664
  // (set) Token: 0x060003A5 RID: 933 RVA: 0x0003B270 File Offset: 0x00039670
  public static bool LateForSchool {
    get {
      return GlobalsHelper.GetBool("LateForSchool");
    }
    set {
      GlobalsHelper.SetBool("LateForSchool", value);
    }
  }

  // Token: 0x17000074 RID: 116
  // (get) Token: 0x060003A6 RID: 934 RVA: 0x0003B27D File Offset: 0x0003967D
  // (set) Token: 0x060003A7 RID: 935 RVA: 0x0003B289 File Offset: 0x00039689
  public static bool Night {
    get {
      return GlobalsHelper.GetBool("Night");
    }
    set {
      GlobalsHelper.SetBool("Night", value);
    }
  }

  // Token: 0x17000075 RID: 117
  // (get) Token: 0x060003A8 RID: 936 RVA: 0x0003B296 File Offset: 0x00039696
  // (set) Token: 0x060003A9 RID: 937 RVA: 0x0003B2A2 File Offset: 0x000396A2
  public static bool StartInBasement {
    get {
      return GlobalsHelper.GetBool("StartInBasement");
    }
    set {
      GlobalsHelper.SetBool("StartInBasement", value);
    }
  }

  // Token: 0x060003AA RID: 938 RVA: 0x0003B2AF File Offset: 0x000396AF
  public static void DeleteAll() {
    Globals.Delete("LateForSchool");
    Globals.Delete("Night");
    Globals.Delete("StartInBasement");
  }

  // Token: 0x040009DE RID: 2526
  private const string Str_LateForSchool = "LateForSchool";

  // Token: 0x040009DF RID: 2527
  private const string Str_Night = "Night";

  // Token: 0x040009E0 RID: 2528
  private const string Str_StartInBasement = "StartInBasement";
}