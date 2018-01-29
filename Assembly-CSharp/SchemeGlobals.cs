using UnityEngine;

// Token: 0x020000E0 RID: 224
public static class SchemeGlobals {

  // Token: 0x1700009E RID: 158
  // (get) Token: 0x06000418 RID: 1048 RVA: 0x0003BBDE File Offset: 0x00039FDE
  // (set) Token: 0x06000419 RID: 1049 RVA: 0x0003BBEA File Offset: 0x00039FEA
  public static int CurrentScheme {
    get {
      return PlayerPrefs.GetInt("CurrentScheme");
    }
    set {
      PlayerPrefs.SetInt("CurrentScheme", value);
    }
  }

  // Token: 0x1700009F RID: 159
  // (get) Token: 0x0600041A RID: 1050 RVA: 0x0003BBF7 File Offset: 0x00039FF7
  // (set) Token: 0x0600041B RID: 1051 RVA: 0x0003BC03 File Offset: 0x0003A003
  public static bool DarkSecret {
    get {
      return GlobalsHelper.GetBool("DarkSecret");
    }
    set {
      GlobalsHelper.SetBool("DarkSecret", value);
    }
  }

  // Token: 0x0600041C RID: 1052 RVA: 0x0003BC10 File Offset: 0x0003A010
  public static int GetSchemePreviousStage(int schemeID) {
    return PlayerPrefs.GetInt("SchemePreviousStage_" + schemeID.ToString());
  }

  // Token: 0x0600041D RID: 1053 RVA: 0x0003BC30 File Offset: 0x0003A030
  public static void SetSchemePreviousStage(int schemeID, int value) {
    string text = schemeID.ToString();
    KeysHelper.AddIfMissing("SchemePreviousStage_", text);
    PlayerPrefs.SetInt("SchemePreviousStage_" + text, value);
  }

  // Token: 0x0600041E RID: 1054 RVA: 0x0003BC67 File Offset: 0x0003A067
  public static int[] KeysOfSchemePreviousStage() {
    return KeysHelper.GetIntegerKeys("SchemePreviousStage_");
  }

  // Token: 0x0600041F RID: 1055 RVA: 0x0003BC73 File Offset: 0x0003A073
  public static int GetSchemeStage(int schemeID) {
    return PlayerPrefs.GetInt("SchemeStage_" + schemeID.ToString());
  }

  // Token: 0x06000420 RID: 1056 RVA: 0x0003BC94 File Offset: 0x0003A094
  public static void SetSchemeStage(int schemeID, int value) {
    string text = schemeID.ToString();
    KeysHelper.AddIfMissing("SchemeStage_", text);
    PlayerPrefs.SetInt("SchemeStage_" + text, value);
  }

  // Token: 0x06000421 RID: 1057 RVA: 0x0003BCCB File Offset: 0x0003A0CB
  public static int[] KeysOfSchemeStage() {
    return KeysHelper.GetIntegerKeys("SchemeStage_");
  }

  // Token: 0x06000422 RID: 1058 RVA: 0x0003BCD7 File Offset: 0x0003A0D7
  public static bool GetSchemeStatus(int schemeID) {
    return GlobalsHelper.GetBool("SchemeStatus_" + schemeID.ToString());
  }

  // Token: 0x06000423 RID: 1059 RVA: 0x0003BCF8 File Offset: 0x0003A0F8
  public static void SetSchemeStatus(int schemeID, bool value) {
    string text = schemeID.ToString();
    KeysHelper.AddIfMissing("SchemeStatus_", text);
    GlobalsHelper.SetBool("SchemeStatus_" + text, value);
  }

  // Token: 0x06000424 RID: 1060 RVA: 0x0003BD2F File Offset: 0x0003A12F
  public static int[] KeysOfSchemeStatus() {
    return KeysHelper.GetIntegerKeys("SchemeStatus_");
  }

  // Token: 0x06000425 RID: 1061 RVA: 0x0003BD3B File Offset: 0x0003A13B
  public static bool GetSchemeUnlocked(int schemeID) {
    return GlobalsHelper.GetBool("SchemeUnlocked_" + schemeID.ToString());
  }

  // Token: 0x06000426 RID: 1062 RVA: 0x0003BD5C File Offset: 0x0003A15C
  public static void SetSchemeUnlocked(int schemeID, bool value) {
    string text = schemeID.ToString();
    KeysHelper.AddIfMissing("SchemeUnlocked_", text);
    GlobalsHelper.SetBool("SchemeUnlocked_" + text, value);
  }

  // Token: 0x06000427 RID: 1063 RVA: 0x0003BD93 File Offset: 0x0003A193
  public static int[] KeysOfSchemeUnlocked() {
    return KeysHelper.GetIntegerKeys("SchemeUnlocked_");
  }

  // Token: 0x06000428 RID: 1064 RVA: 0x0003BD9F File Offset: 0x0003A19F
  public static bool GetServicePurchased(int serviceID) {
    return GlobalsHelper.GetBool("ServicePurchased_" + serviceID.ToString());
  }

  // Token: 0x06000429 RID: 1065 RVA: 0x0003BDC0 File Offset: 0x0003A1C0
  public static void SetServicePurchased(int serviceID, bool value) {
    string text = serviceID.ToString();
    KeysHelper.AddIfMissing("ServicePurchased_", text);
    GlobalsHelper.SetBool("ServicePurchased_" + text, value);
  }

  // Token: 0x0600042A RID: 1066 RVA: 0x0003BDF7 File Offset: 0x0003A1F7
  public static int[] KeysOfServicePurchased() {
    return KeysHelper.GetIntegerKeys("ServicePurchased_");
  }

  // Token: 0x0600042B RID: 1067 RVA: 0x0003BE04 File Offset: 0x0003A204
  public static void DeleteAll() {
    Globals.Delete("CurrentScheme");
    Globals.Delete("DarkSecret");
    Globals.DeleteCollection("SchemePreviousStage_", SchemeGlobals.KeysOfSchemePreviousStage());
    Globals.DeleteCollection("SchemeStage_", SchemeGlobals.KeysOfSchemeStage());
    Globals.DeleteCollection("SchemeStatus_", SchemeGlobals.KeysOfSchemeStatus());
    Globals.DeleteCollection("SchemeUnlocked_", SchemeGlobals.KeysOfSchemeUnlocked());
    Globals.DeleteCollection("ServicePurchased_", SchemeGlobals.KeysOfServicePurchased());
  }

  // Token: 0x04000A11 RID: 2577
  private const string Str_CurrentScheme = "CurrentScheme";

  // Token: 0x04000A12 RID: 2578
  private const string Str_DarkSecret = "DarkSecret";

  // Token: 0x04000A13 RID: 2579
  private const string Str_SchemePreviousStage = "SchemePreviousStage_";

  // Token: 0x04000A14 RID: 2580
  private const string Str_SchemeStage = "SchemeStage_";

  // Token: 0x04000A15 RID: 2581
  private const string Str_SchemeStatus = "SchemeStatus_";

  // Token: 0x04000A16 RID: 2582
  private const string Str_SchemeUnlocked = "SchemeUnlocked_";

  // Token: 0x04000A17 RID: 2583
  private const string Str_ServicePurchased = "ServicePurchased_";
}