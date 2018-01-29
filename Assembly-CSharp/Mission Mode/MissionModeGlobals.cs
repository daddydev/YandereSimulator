using UnityEngine;

// Token: 0x020000DB RID: 219
public static class MissionModeGlobals {

  // Token: 0x060003AB RID: 939 RVA: 0x0003B2CF File Offset: 0x000396CF
  public static int GetMissionCondition(int id) {
    return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
  }

  // Token: 0x060003AC RID: 940 RVA: 0x0003B2F0 File Offset: 0x000396F0
  public static void SetMissionCondition(int id, int value) {
    string text = id.ToString();
    KeysHelper.AddIfMissing("MissionCondition_", text);
    PlayerPrefs.SetInt("MissionCondition_" + text, value);
  }

  // Token: 0x060003AD RID: 941 RVA: 0x0003B327 File Offset: 0x00039727
  public static int[] KeysOfMissionCondition() {
    return KeysHelper.GetIntegerKeys("MissionCondition_");
  }

  // Token: 0x17000076 RID: 118
  // (get) Token: 0x060003AE RID: 942 RVA: 0x0003B333 File Offset: 0x00039733
  // (set) Token: 0x060003AF RID: 943 RVA: 0x0003B33F File Offset: 0x0003973F
  public static int MissionDifficulty {
    get {
      return PlayerPrefs.GetInt("MissionDifficulty");
    }
    set {
      PlayerPrefs.SetInt("MissionDifficulty", value);
    }
  }

  // Token: 0x17000077 RID: 119
  // (get) Token: 0x060003B0 RID: 944 RVA: 0x0003B34C File Offset: 0x0003974C
  // (set) Token: 0x060003B1 RID: 945 RVA: 0x0003B358 File Offset: 0x00039758
  public static bool MissionMode {
    get {
      return GlobalsHelper.GetBool("MissionMode");
    }
    set {
      GlobalsHelper.SetBool("MissionMode", value);
    }
  }

  // Token: 0x17000078 RID: 120
  // (get) Token: 0x060003B2 RID: 946 RVA: 0x0003B365 File Offset: 0x00039765
  // (set) Token: 0x060003B3 RID: 947 RVA: 0x0003B371 File Offset: 0x00039771
  public static int MissionRequiredClothing {
    get {
      return PlayerPrefs.GetInt("MissionRequiredClothing");
    }
    set {
      PlayerPrefs.SetInt("MissionRequiredClothing", value);
    }
  }

  // Token: 0x17000079 RID: 121
  // (get) Token: 0x060003B4 RID: 948 RVA: 0x0003B37E File Offset: 0x0003977E
  // (set) Token: 0x060003B5 RID: 949 RVA: 0x0003B38A File Offset: 0x0003978A
  public static int MissionRequiredDisposal {
    get {
      return PlayerPrefs.GetInt("MissionRequiredDisposal");
    }
    set {
      PlayerPrefs.SetInt("MissionRequiredDisposal", value);
    }
  }

  // Token: 0x1700007A RID: 122
  // (get) Token: 0x060003B6 RID: 950 RVA: 0x0003B397 File Offset: 0x00039797
  // (set) Token: 0x060003B7 RID: 951 RVA: 0x0003B3A3 File Offset: 0x000397A3
  public static int MissionRequiredWeapon {
    get {
      return PlayerPrefs.GetInt("MissionRequiredWeapon");
    }
    set {
      PlayerPrefs.SetInt("MissionRequiredWeapon", value);
    }
  }

  // Token: 0x1700007B RID: 123
  // (get) Token: 0x060003B8 RID: 952 RVA: 0x0003B3B0 File Offset: 0x000397B0
  // (set) Token: 0x060003B9 RID: 953 RVA: 0x0003B3BC File Offset: 0x000397BC
  public static int MissionTarget {
    get {
      return PlayerPrefs.GetInt("MissionTarget");
    }
    set {
      PlayerPrefs.SetInt("MissionTarget", value);
    }
  }

  // Token: 0x1700007C RID: 124
  // (get) Token: 0x060003BA RID: 954 RVA: 0x0003B3C9 File Offset: 0x000397C9
  // (set) Token: 0x060003BB RID: 955 RVA: 0x0003B3D5 File Offset: 0x000397D5
  public static string MissionTargetName {
    get {
      return PlayerPrefs.GetString("MissionTargetName");
    }
    set {
      PlayerPrefs.SetString("MissionTargetName", value);
    }
  }

  // Token: 0x1700007D RID: 125
  // (get) Token: 0x060003BC RID: 956 RVA: 0x0003B3E2 File Offset: 0x000397E2
  // (set) Token: 0x060003BD RID: 957 RVA: 0x0003B3EE File Offset: 0x000397EE
  public static int NemesisDifficulty {
    get {
      return PlayerPrefs.GetInt("NemesisDifficulty");
    }
    set {
      PlayerPrefs.SetInt("NemesisDifficulty", value);
    }
  }

  // Token: 0x060003BE RID: 958 RVA: 0x0003B3FC File Offset: 0x000397FC
  public static void DeleteAll() {
    Globals.DeleteCollection("MissionCondition_", MissionModeGlobals.KeysOfMissionCondition());
    Globals.Delete("MissionDifficulty");
    Globals.Delete("MissionMode");
    Globals.Delete("MissionRequiredClothing");
    Globals.Delete("MissionRequiredDisposal");
    Globals.Delete("MissionRequiredWeapon");
    Globals.Delete("MissionTarget");
    Globals.Delete("MissionTargetName");
    Globals.Delete("NemesisDifficulty");
  }

  // Token: 0x040009E1 RID: 2529
  private const string Str_MissionCondition = "MissionCondition_";

  // Token: 0x040009E2 RID: 2530
  private const string Str_MissionDifficulty = "MissionDifficulty";

  // Token: 0x040009E3 RID: 2531
  private const string Str_MissionMode = "MissionMode";

  // Token: 0x040009E4 RID: 2532
  private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

  // Token: 0x040009E5 RID: 2533
  private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

  // Token: 0x040009E6 RID: 2534
  private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

  // Token: 0x040009E7 RID: 2535
  private const string Str_MissionTarget = "MissionTarget";

  // Token: 0x040009E8 RID: 2536
  private const string Str_MissionTargetName = "MissionTargetName";

  // Token: 0x040009E9 RID: 2537
  private const string Str_NemesisDifficulty = "NemesisDifficulty";
}