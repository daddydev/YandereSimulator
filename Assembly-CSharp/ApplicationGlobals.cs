using UnityEngine;

// Token: 0x020000D1 RID: 209
public static class ApplicationGlobals {

  // Token: 0x17000054 RID: 84
  // (get) Token: 0x06000330 RID: 816 RVA: 0x0003A520 File Offset: 0x00038920
  // (set) Token: 0x06000331 RID: 817 RVA: 0x0003A52C File Offset: 0x0003892C
  public static float VersionNumber {
    get {
      return PlayerPrefs.GetFloat("VersionNumber");
    }
    set {
      PlayerPrefs.SetFloat("VersionNumber", value);
    }
  }

  // Token: 0x06000332 RID: 818 RVA: 0x0003A539 File Offset: 0x00038939
  public static void DeleteAll() {
    Globals.Delete("VersionNumber");
  }

  // Token: 0x040009B0 RID: 2480
  private const string Str_VersionNumber = "VersionNumber";
}