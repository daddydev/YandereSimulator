using UnityEngine;

// Token: 0x020000D7 RID: 215
public static class DatingGlobals {

  // Token: 0x17000067 RID: 103
  // (get) Token: 0x0600037A RID: 890 RVA: 0x0003AE72 File Offset: 0x00039272
  // (set) Token: 0x0600037B RID: 891 RVA: 0x0003AE7E File Offset: 0x0003927E
  public static float Affection {
    get {
      return PlayerPrefs.GetFloat("Affection");
    }
    set {
      PlayerPrefs.SetFloat("Affection", value);
    }
  }

  // Token: 0x17000068 RID: 104
  // (get) Token: 0x0600037C RID: 892 RVA: 0x0003AE8B File Offset: 0x0003928B
  // (set) Token: 0x0600037D RID: 893 RVA: 0x0003AE97 File Offset: 0x00039297
  public static float AffectionLevel {
    get {
      return PlayerPrefs.GetFloat("AffectionLevel");
    }
    set {
      PlayerPrefs.SetFloat("AffectionLevel", value);
    }
  }

  // Token: 0x0600037E RID: 894 RVA: 0x0003AEA4 File Offset: 0x000392A4
  public static bool GetComplimentGiven(int complimentID) {
    return GlobalsHelper.GetBool("ComplimentGiven_" + complimentID.ToString());
  }

  // Token: 0x0600037F RID: 895 RVA: 0x0003AEC4 File Offset: 0x000392C4
  public static void SetComplimentGiven(int complimentID, bool value) {
    string text = complimentID.ToString();
    KeysHelper.AddIfMissing("ComplimentGiven_", text);
    GlobalsHelper.SetBool("ComplimentGiven_" + text, value);
  }

  // Token: 0x06000380 RID: 896 RVA: 0x0003AEFB File Offset: 0x000392FB
  public static int[] KeysOfComplimentGiven() {
    return KeysHelper.GetIntegerKeys("ComplimentGiven_");
  }

  // Token: 0x06000381 RID: 897 RVA: 0x0003AF07 File Offset: 0x00039307
  public static bool GetSuitorCheck(int checkID) {
    return GlobalsHelper.GetBool("SuitorCheck_" + checkID.ToString());
  }

  // Token: 0x06000382 RID: 898 RVA: 0x0003AF28 File Offset: 0x00039328
  public static void SetSuitorCheck(int checkID, bool value) {
    string text = checkID.ToString();
    KeysHelper.AddIfMissing("SuitorCheck_", text);
    GlobalsHelper.SetBool("SuitorCheck_" + text, value);
  }

  // Token: 0x06000383 RID: 899 RVA: 0x0003AF5F File Offset: 0x0003935F
  public static int[] KeysOfSuitorCheck() {
    return KeysHelper.GetIntegerKeys("SuitorCheck_");
  }

  // Token: 0x17000069 RID: 105
  // (get) Token: 0x06000384 RID: 900 RVA: 0x0003AF6B File Offset: 0x0003936B
  // (set) Token: 0x06000385 RID: 901 RVA: 0x0003AF77 File Offset: 0x00039377
  public static int SuitorProgress {
    get {
      return PlayerPrefs.GetInt("SuitorProgress");
    }
    set {
      PlayerPrefs.SetInt("SuitorProgress", value);
    }
  }

  // Token: 0x06000386 RID: 902 RVA: 0x0003AF84 File Offset: 0x00039384
  public static int GetSuitorTrait(int traitID) {
    return PlayerPrefs.GetInt("SuitorTrait_" + traitID.ToString());
  }

  // Token: 0x06000387 RID: 903 RVA: 0x0003AFA4 File Offset: 0x000393A4
  public static void SetSuitorTrait(int traitID, int value) {
    string text = traitID.ToString();
    KeysHelper.AddIfMissing("SuitorTrait_", text);
    PlayerPrefs.SetInt("SuitorTrait_" + text, value);
  }

  // Token: 0x06000388 RID: 904 RVA: 0x0003AFDB File Offset: 0x000393DB
  public static int[] KeysOfSuitorTrait() {
    return KeysHelper.GetIntegerKeys("SuitorTrait_");
  }

  // Token: 0x06000389 RID: 905 RVA: 0x0003AFE7 File Offset: 0x000393E7
  public static bool GetTopicDiscussed(int topicID) {
    return GlobalsHelper.GetBool("TopicDiscussed_" + topicID.ToString());
  }

  // Token: 0x0600038A RID: 906 RVA: 0x0003B008 File Offset: 0x00039408
  public static void SetTopicDiscussed(int topicID, bool value) {
    string text = topicID.ToString();
    KeysHelper.AddIfMissing("TopicDiscussed_", text);
    GlobalsHelper.SetBool("TopicDiscussed_" + text, value);
  }

  // Token: 0x0600038B RID: 907 RVA: 0x0003B03F File Offset: 0x0003943F
  public static int[] KeysOfTopicDiscussed() {
    return KeysHelper.GetIntegerKeys("TopicDiscussed_");
  }

  // Token: 0x0600038C RID: 908 RVA: 0x0003B04B File Offset: 0x0003944B
  public static int GetTraitDemonstrated(int traitID) {
    return PlayerPrefs.GetInt("TraitDemonstrated_" + traitID.ToString());
  }

  // Token: 0x0600038D RID: 909 RVA: 0x0003B06C File Offset: 0x0003946C
  public static void SetTraitDemonstrated(int traitID, int value) {
    string text = traitID.ToString();
    KeysHelper.AddIfMissing("TraitDemonstrated_", text);
    PlayerPrefs.SetInt("TraitDemonstrated_" + text, value);
  }

  // Token: 0x0600038E RID: 910 RVA: 0x0003B0A3 File Offset: 0x000394A3
  public static int[] KeysOfTraitDemonstrated() {
    return KeysHelper.GetIntegerKeys("TraitDemonstrated_");
  }

  // Token: 0x1700006A RID: 106
  // (get) Token: 0x0600038F RID: 911 RVA: 0x0003B0AF File Offset: 0x000394AF
  // (set) Token: 0x06000390 RID: 912 RVA: 0x0003B0BB File Offset: 0x000394BB
  public static int RivalSabotaged {
    get {
      return PlayerPrefs.GetInt("RivalSabotaged");
    }
    set {
      PlayerPrefs.SetInt("RivalSabotaged", value);
    }
  }

  // Token: 0x06000391 RID: 913 RVA: 0x0003B0C8 File Offset: 0x000394C8
  public static void DeleteAll() {
    Globals.Delete("Affection");
    Globals.Delete("AffectionLevel");
    Globals.DeleteCollection("ComplimentGiven_", DatingGlobals.KeysOfComplimentGiven());
    Globals.DeleteCollection("SuitorCheck_", DatingGlobals.KeysOfSuitorCheck());
    Globals.Delete("SuitorProgress");
    Globals.Delete("RivalSabotaged");
    Globals.DeleteCollection("SuitorTrait_", DatingGlobals.KeysOfSuitorTrait());
    Globals.DeleteCollection("TopicDiscussed_", DatingGlobals.KeysOfTopicDiscussed());
    Globals.DeleteCollection("TraitDemonstrated_", DatingGlobals.KeysOfTraitDemonstrated());
  }

  // Token: 0x040009CD RID: 2509
  private const string Str_Affection = "Affection";

  // Token: 0x040009CE RID: 2510
  private const string Str_AffectionLevel = "AffectionLevel";

  // Token: 0x040009CF RID: 2511
  private const string Str_ComplimentGiven = "ComplimentGiven_";

  // Token: 0x040009D0 RID: 2512
  private const string Str_SuitorCheck = "SuitorCheck_";

  // Token: 0x040009D1 RID: 2513
  private const string Str_SuitorProgress = "SuitorProgress";

  // Token: 0x040009D2 RID: 2514
  private const string Str_SuitorTrait = "SuitorTrait_";

  // Token: 0x040009D3 RID: 2515
  private const string Str_TopicDiscussed = "TopicDiscussed_";

  // Token: 0x040009D4 RID: 2516
  private const string Str_TraitDemonstrated = "TraitDemonstrated_";

  // Token: 0x040009D5 RID: 2517
  private const string Str_RivalSabotaged = "RivalSabotaged";
}