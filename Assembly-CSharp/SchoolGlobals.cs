using UnityEngine;

// Token: 0x020000E1 RID: 225
public static class SchoolGlobals {

  // Token: 0x0600042C RID: 1068 RVA: 0x0003BE70 File Offset: 0x0003A270
  public static bool GetDemonActive(int demonID) {
    return GlobalsHelper.GetBool("DemonActive_" + demonID.ToString());
  }

  // Token: 0x0600042D RID: 1069 RVA: 0x0003BE90 File Offset: 0x0003A290
  public static void SetDemonActive(int demonID, bool value) {
    string text = demonID.ToString();
    KeysHelper.AddIfMissing("DemonActive_", text);
    GlobalsHelper.SetBool("DemonActive_" + text, value);
  }

  // Token: 0x0600042E RID: 1070 RVA: 0x0003BEC7 File Offset: 0x0003A2C7
  public static int[] KeysOfDemonActive() {
    return KeysHelper.GetIntegerKeys("DemonActive_");
  }

  // Token: 0x0600042F RID: 1071 RVA: 0x0003BED3 File Offset: 0x0003A2D3
  public static bool GetGardenGraveOccupied(int graveID) {
    return GlobalsHelper.GetBool("GardenGraveOccupied_" + graveID.ToString());
  }

  // Token: 0x06000430 RID: 1072 RVA: 0x0003BEF4 File Offset: 0x0003A2F4
  public static void SetGardenGraveOccupied(int graveID, bool value) {
    string text = graveID.ToString();
    KeysHelper.AddIfMissing("GardenGraveOccupied_", text);
    GlobalsHelper.SetBool("GardenGraveOccupied_" + text, value);
  }

  // Token: 0x06000431 RID: 1073 RVA: 0x0003BF2B File Offset: 0x0003A32B
  public static int[] KeysOfGardenGraveOccupied() {
    return KeysHelper.GetIntegerKeys("GardenGraveOccupied_");
  }

  // Token: 0x170000A0 RID: 160
  // (get) Token: 0x06000432 RID: 1074 RVA: 0x0003BF37 File Offset: 0x0003A337
  // (set) Token: 0x06000433 RID: 1075 RVA: 0x0003BF43 File Offset: 0x0003A343
  public static int KidnapVictim {
    get {
      return PlayerPrefs.GetInt("KidnapVictim");
    }
    set {
      PlayerPrefs.SetInt("KidnapVictim", value);
    }
  }

  // Token: 0x170000A1 RID: 161
  // (get) Token: 0x06000434 RID: 1076 RVA: 0x0003BF50 File Offset: 0x0003A350
  // (set) Token: 0x06000435 RID: 1077 RVA: 0x0003BF5C File Offset: 0x0003A35C
  public static int Population {
    get {
      return PlayerPrefs.GetInt("Population");
    }
    set {
      PlayerPrefs.SetInt("Population", value);
    }
  }

  // Token: 0x170000A2 RID: 162
  // (get) Token: 0x06000436 RID: 1078 RVA: 0x0003BF69 File Offset: 0x0003A369
  // (set) Token: 0x06000437 RID: 1079 RVA: 0x0003BF75 File Offset: 0x0003A375
  public static bool RoofFence {
    get {
      return GlobalsHelper.GetBool("RoofFence");
    }
    set {
      GlobalsHelper.SetBool("RoofFence", value);
    }
  }

  // Token: 0x170000A3 RID: 163
  // (get) Token: 0x06000438 RID: 1080 RVA: 0x0003BF82 File Offset: 0x0003A382
  // (set) Token: 0x06000439 RID: 1081 RVA: 0x0003BF8E File Offset: 0x0003A38E
  public static float SchoolAtmosphere {
    get {
      return PlayerPrefs.GetFloat("SchoolAtmosphere");
    }
    set {
      PlayerPrefs.SetFloat("SchoolAtmosphere", value);
    }
  }

  // Token: 0x170000A4 RID: 164
  // (get) Token: 0x0600043A RID: 1082 RVA: 0x0003BF9B File Offset: 0x0003A39B
  // (set) Token: 0x0600043B RID: 1083 RVA: 0x0003BFA7 File Offset: 0x0003A3A7
  public static bool SchoolAtmosphereSet {
    get {
      return GlobalsHelper.GetBool("SchoolAtmosphereSet");
    }
    set {
      GlobalsHelper.SetBool("SchoolAtmosphereSet", value);
    }
  }

  // Token: 0x170000A5 RID: 165
  // (get) Token: 0x0600043C RID: 1084 RVA: 0x0003BFB4 File Offset: 0x0003A3B4
  // (set) Token: 0x0600043D RID: 1085 RVA: 0x0003BFC0 File Offset: 0x0003A3C0
  public static bool SCP {
    get {
      return GlobalsHelper.GetBool("SCP");
    }
    set {
      GlobalsHelper.SetBool("SCP", value);
    }
  }

  // Token: 0x170000A6 RID: 166
  // (get) Token: 0x0600043E RID: 1086 RVA: 0x0003BFCD File Offset: 0x0003A3CD
  // (set) Token: 0x0600043F RID: 1087 RVA: 0x0003BFD9 File Offset: 0x0003A3D9
  public static bool HighSecurity {
    get {
      return GlobalsHelper.GetBool("HighSecurity");
    }
    set {
      GlobalsHelper.SetBool("HighSecurity", value);
    }
  }

  // Token: 0x06000440 RID: 1088 RVA: 0x0003BFE8 File Offset: 0x0003A3E8
  public static void DeleteAll() {
    Globals.DeleteCollection("DemonActive_", SchoolGlobals.KeysOfDemonActive());
    Globals.DeleteCollection("GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
    Globals.Delete("KidnapVictim");
    Globals.Delete("Population");
    Globals.Delete("RoofFence");
    Globals.Delete("SchoolAtmosphere");
    Globals.Delete("SchoolAtmosphereSet");
    Globals.Delete("SCP");
  }

  // Token: 0x04000A18 RID: 2584
  private const string Str_DemonActive = "DemonActive_";

  // Token: 0x04000A19 RID: 2585
  private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

  // Token: 0x04000A1A RID: 2586
  private const string Str_KidnapVictim = "KidnapVictim";

  // Token: 0x04000A1B RID: 2587
  private const string Str_Population = "Population";

  // Token: 0x04000A1C RID: 2588
  private const string Str_RoofFence = "RoofFence";

  // Token: 0x04000A1D RID: 2589
  private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

  // Token: 0x04000A1E RID: 2590
  private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

  // Token: 0x04000A1F RID: 2591
  private const string Str_SCP = "SCP";

  // Token: 0x04000A20 RID: 2592
  private const string Str_HighSecurity = "HighSecurity";
}