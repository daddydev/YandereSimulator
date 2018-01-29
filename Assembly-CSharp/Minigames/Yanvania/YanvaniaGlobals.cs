// Token: 0x020000E5 RID: 229
public static class YanvaniaGlobals {

  // Token: 0x170000B8 RID: 184
  // (get) Token: 0x060004A8 RID: 1192 RVA: 0x0003CC9F File Offset: 0x0003B09F
  // (set) Token: 0x060004A9 RID: 1193 RVA: 0x0003CCAB File Offset: 0x0003B0AB
  public static bool DraculaDefeated {
    get {
      return GlobalsHelper.GetBool("DraculaDefeated");
    }
    set {
      GlobalsHelper.SetBool("DraculaDefeated", value);
    }
  }

  // Token: 0x170000B9 RID: 185
  // (get) Token: 0x060004AA RID: 1194 RVA: 0x0003CCB8 File Offset: 0x0003B0B8
  // (set) Token: 0x060004AB RID: 1195 RVA: 0x0003CCC4 File Offset: 0x0003B0C4
  public static bool MidoriEasterEgg {
    get {
      return GlobalsHelper.GetBool("MidoriEasterEgg");
    }
    set {
      GlobalsHelper.SetBool("MidoriEasterEgg", value);
    }
  }

  // Token: 0x060004AC RID: 1196 RVA: 0x0003CCD1 File Offset: 0x0003B0D1
  public static void DeleteAll() {
    Globals.Delete("DraculaDefeated");
    Globals.Delete("MidoriEasterEgg");
  }

  // Token: 0x04000A48 RID: 2632
  private const string Str_DraculaDefeated = "DraculaDefeated";

  // Token: 0x04000A49 RID: 2633
  private const string Str_MidoriEasterEgg = "MidoriEasterEgg";
}