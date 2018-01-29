using UnityEngine;

// Token: 0x020000E2 RID: 226
public static class SenpaiGlobals {

  // Token: 0x170000A7 RID: 167
  // (get) Token: 0x06000441 RID: 1089 RVA: 0x0003C04F File Offset: 0x0003A44F
  // (set) Token: 0x06000442 RID: 1090 RVA: 0x0003C05B File Offset: 0x0003A45B
  public static bool CustomSenpai {
    get {
      return GlobalsHelper.GetBool("CustomSenpai");
    }
    set {
      GlobalsHelper.SetBool("CustomSenpai", value);
    }
  }

  // Token: 0x170000A8 RID: 168
  // (get) Token: 0x06000443 RID: 1091 RVA: 0x0003C068 File Offset: 0x0003A468
  // (set) Token: 0x06000444 RID: 1092 RVA: 0x0003C074 File Offset: 0x0003A474
  public static string SenpaiEyeColor {
    get {
      return PlayerPrefs.GetString("SenpaiEyeColor");
    }
    set {
      PlayerPrefs.SetString("SenpaiEyeColor", value);
    }
  }

  // Token: 0x170000A9 RID: 169
  // (get) Token: 0x06000445 RID: 1093 RVA: 0x0003C081 File Offset: 0x0003A481
  // (set) Token: 0x06000446 RID: 1094 RVA: 0x0003C08D File Offset: 0x0003A48D
  public static int SenpaiEyeWear {
    get {
      return PlayerPrefs.GetInt("SenpaiEyeWear");
    }
    set {
      PlayerPrefs.SetInt("SenpaiEyeWear", value);
    }
  }

  // Token: 0x170000AA RID: 170
  // (get) Token: 0x06000447 RID: 1095 RVA: 0x0003C09A File Offset: 0x0003A49A
  // (set) Token: 0x06000448 RID: 1096 RVA: 0x0003C0A6 File Offset: 0x0003A4A6
  public static int SenpaiFacialHair {
    get {
      return PlayerPrefs.GetInt("SenpaiFacialHair");
    }
    set {
      PlayerPrefs.SetInt("SenpaiFacialHair", value);
    }
  }

  // Token: 0x170000AB RID: 171
  // (get) Token: 0x06000449 RID: 1097 RVA: 0x0003C0B3 File Offset: 0x0003A4B3
  // (set) Token: 0x0600044A RID: 1098 RVA: 0x0003C0BF File Offset: 0x0003A4BF
  public static string SenpaiHairColor {
    get {
      return PlayerPrefs.GetString("SenpaiHairColor");
    }
    set {
      PlayerPrefs.SetString("SenpaiHairColor", value);
    }
  }

  // Token: 0x170000AC RID: 172
  // (get) Token: 0x0600044B RID: 1099 RVA: 0x0003C0CC File Offset: 0x0003A4CC
  // (set) Token: 0x0600044C RID: 1100 RVA: 0x0003C0D8 File Offset: 0x0003A4D8
  public static int SenpaiHairStyle {
    get {
      return PlayerPrefs.GetInt("SenpaiHairStyle");
    }
    set {
      PlayerPrefs.SetInt("SenpaiHairStyle", value);
    }
  }

  // Token: 0x170000AD RID: 173
  // (get) Token: 0x0600044D RID: 1101 RVA: 0x0003C0E5 File Offset: 0x0003A4E5
  // (set) Token: 0x0600044E RID: 1102 RVA: 0x0003C0F1 File Offset: 0x0003A4F1
  public static int SenpaiSkinColor {
    get {
      return PlayerPrefs.GetInt("SenpaiSkinColor");
    }
    set {
      PlayerPrefs.SetInt("SenpaiSkinColor", value);
    }
  }

  // Token: 0x0600044F RID: 1103 RVA: 0x0003C100 File Offset: 0x0003A500
  public static void DeleteAll() {
    Globals.Delete("CustomSenpai");
    Globals.Delete("SenpaiEyeColor");
    Globals.Delete("SenpaiEyeWear");
    Globals.Delete("SenpaiFacialHair");
    Globals.Delete("SenpaiHairColor");
    Globals.Delete("SenpaiHairStyle");
    Globals.Delete("SenpaiSkinColor");
  }

  // Token: 0x04000A21 RID: 2593
  private const string Str_CustomSenpai = "CustomSenpai";

  // Token: 0x04000A22 RID: 2594
  private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

  // Token: 0x04000A23 RID: 2595
  private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

  // Token: 0x04000A24 RID: 2596
  private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

  // Token: 0x04000A25 RID: 2597
  private const string Str_SenpaiHairColor = "SenpaiHairColor";

  // Token: 0x04000A26 RID: 2598
  private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

  // Token: 0x04000A27 RID: 2599
  private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}