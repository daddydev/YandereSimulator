// Token: 0x020000D9 RID: 217
public static class GameGlobals {

  // Token: 0x17000070 RID: 112
  // (get) Token: 0x0600039D RID: 925 RVA: 0x0003B1F9 File Offset: 0x000395F9
  // (set) Token: 0x0600039E RID: 926 RVA: 0x0003B205 File Offset: 0x00039605
  public static bool LoveSick {
    get {
      return GlobalsHelper.GetBool("LoveSick");
    }
    set {
      GlobalsHelper.SetBool("LoveSick", value);
    }
  }

  // Token: 0x17000071 RID: 113
  // (get) Token: 0x0600039F RID: 927 RVA: 0x0003B212 File Offset: 0x00039612
  // (set) Token: 0x060003A0 RID: 928 RVA: 0x0003B21E File Offset: 0x0003961E
  public static bool MasksBanned {
    get {
      return GlobalsHelper.GetBool("MasksBanned");
    }
    set {
      GlobalsHelper.SetBool("MasksBanned", value);
    }
  }

  // Token: 0x17000072 RID: 114
  // (get) Token: 0x060003A1 RID: 929 RVA: 0x0003B22B File Offset: 0x0003962B
  // (set) Token: 0x060003A2 RID: 930 RVA: 0x0003B237 File Offset: 0x00039637
  public static bool Paranormal {
    get {
      return GlobalsHelper.GetBool("Paranormal");
    }
    set {
      GlobalsHelper.SetBool("Paranormal", value);
    }
  }

  // Token: 0x060003A3 RID: 931 RVA: 0x0003B244 File Offset: 0x00039644
  public static void DeleteAll() {
    Globals.Delete("LoveSick");
    Globals.Delete("MasksBanned");
    Globals.Delete("Paranormal");
  }

  // Token: 0x040009DB RID: 2523
  private const string Str_LoveSick = "LoveSick";

  // Token: 0x040009DC RID: 2524
  private const string Str_MasksBanned = "MasksBanned";

  // Token: 0x040009DD RID: 2525
  private const string Str_Paranormal = "Paranormal";
}