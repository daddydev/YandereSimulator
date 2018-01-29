using UnityEngine;

// Token: 0x020000DF RID: 223
public static class SaveFileGlobals {

  // Token: 0x1700009D RID: 157
  // (get) Token: 0x06000415 RID: 1045 RVA: 0x0003BBB9 File Offset: 0x00039FB9
  // (set) Token: 0x06000416 RID: 1046 RVA: 0x0003BBC5 File Offset: 0x00039FC5
  public static int CurrentSaveFile {
    get {
      return PlayerPrefs.GetInt("CurrentSaveFile");
    }
    set {
      PlayerPrefs.SetInt("CurrentSaveFile", value);
    }
  }

  // Token: 0x06000417 RID: 1047 RVA: 0x0003BBD2 File Offset: 0x00039FD2
  public static void DeleteAll() {
    Globals.Delete("CurrentSaveFile");
  }

  // Token: 0x04000A10 RID: 2576
  private const string Str_CurrentSaveFile = "CurrentSaveFile";
}