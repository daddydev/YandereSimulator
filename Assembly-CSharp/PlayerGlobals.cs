using UnityEngine;

// Token: 0x020000DD RID: 221
public static class PlayerGlobals {

  // Token: 0x1700008A RID: 138
  // (get) Token: 0x060003D8 RID: 984 RVA: 0x0003B619 File Offset: 0x00039A19
  // (set) Token: 0x060003D9 RID: 985 RVA: 0x0003B625 File Offset: 0x00039A25
  public static int Alerts {
    get {
      return PlayerPrefs.GetInt("Alerts");
    }
    set {
      PlayerPrefs.SetInt("Alerts", value);
    }
  }

  // Token: 0x1700008B RID: 139
  // (get) Token: 0x060003DA RID: 986 RVA: 0x0003B632 File Offset: 0x00039A32
  // (set) Token: 0x060003DB RID: 987 RVA: 0x0003B63E File Offset: 0x00039A3E
  public static int Enlightenment {
    get {
      return PlayerPrefs.GetInt("Enlightenment");
    }
    set {
      PlayerPrefs.SetInt("Enlightenment", value);
    }
  }

  // Token: 0x1700008C RID: 140
  // (get) Token: 0x060003DC RID: 988 RVA: 0x0003B64B File Offset: 0x00039A4B
  // (set) Token: 0x060003DD RID: 989 RVA: 0x0003B657 File Offset: 0x00039A57
  public static int EnlightenmentBonus {
    get {
      return PlayerPrefs.GetInt("EnlightenmentBonus");
    }
    set {
      PlayerPrefs.SetInt("EnlightenmentBonus", value);
    }
  }

  // Token: 0x1700008D RID: 141
  // (get) Token: 0x060003DE RID: 990 RVA: 0x0003B664 File Offset: 0x00039A64
  // (set) Token: 0x060003DF RID: 991 RVA: 0x0003B670 File Offset: 0x00039A70
  public static bool Headset {
    get {
      return GlobalsHelper.GetBool("Headset");
    }
    set {
      GlobalsHelper.SetBool("Headset", value);
    }
  }

  // Token: 0x1700008E RID: 142
  // (get) Token: 0x060003E0 RID: 992 RVA: 0x0003B67D File Offset: 0x00039A7D
  // (set) Token: 0x060003E1 RID: 993 RVA: 0x0003B689 File Offset: 0x00039A89
  public static int Kills {
    get {
      return PlayerPrefs.GetInt("Kills");
    }
    set {
      PlayerPrefs.SetInt("Kills", value);
    }
  }

  // Token: 0x1700008F RID: 143
  // (get) Token: 0x060003E2 RID: 994 RVA: 0x0003B696 File Offset: 0x00039A96
  // (set) Token: 0x060003E3 RID: 995 RVA: 0x0003B6A2 File Offset: 0x00039AA2
  public static int Numbness {
    get {
      return PlayerPrefs.GetInt("Numbness");
    }
    set {
      PlayerPrefs.SetInt("Numbness", value);
    }
  }

  // Token: 0x17000090 RID: 144
  // (get) Token: 0x060003E4 RID: 996 RVA: 0x0003B6AF File Offset: 0x00039AAF
  // (set) Token: 0x060003E5 RID: 997 RVA: 0x0003B6BB File Offset: 0x00039ABB
  public static int NumbnessBonus {
    get {
      return PlayerPrefs.GetInt("NumbnessBonus");
    }
    set {
      PlayerPrefs.SetInt("NumbnessBonus", value);
    }
  }

  // Token: 0x17000091 RID: 145
  // (get) Token: 0x060003E6 RID: 998 RVA: 0x0003B6C8 File Offset: 0x00039AC8
  // (set) Token: 0x060003E7 RID: 999 RVA: 0x0003B6D4 File Offset: 0x00039AD4
  public static int PantiesEquipped {
    get {
      return PlayerPrefs.GetInt("PantiesEquipped");
    }
    set {
      PlayerPrefs.SetInt("PantiesEquipped", value);
    }
  }

  // Token: 0x17000092 RID: 146
  // (get) Token: 0x060003E8 RID: 1000 RVA: 0x0003B6E1 File Offset: 0x00039AE1
  // (set) Token: 0x060003E9 RID: 1001 RVA: 0x0003B6ED File Offset: 0x00039AED
  public static int PantyShots {
    get {
      return PlayerPrefs.GetInt("PantyShots");
    }
    set {
      PlayerPrefs.SetInt("PantyShots", value);
    }
  }

  // Token: 0x060003EA RID: 1002 RVA: 0x0003B6FA File Offset: 0x00039AFA
  public static bool GetPhoto(int photoID) {
    return GlobalsHelper.GetBool("Photo_" + photoID.ToString());
  }

  // Token: 0x060003EB RID: 1003 RVA: 0x0003B718 File Offset: 0x00039B18
  public static void SetPhoto(int photoID, bool value) {
    string text = photoID.ToString();
    KeysHelper.AddIfMissing("Photo_", text);
    GlobalsHelper.SetBool("Photo_" + text, value);
  }

  // Token: 0x060003EC RID: 1004 RVA: 0x0003B74F File Offset: 0x00039B4F
  public static int[] KeysOfPhoto() {
    return KeysHelper.GetIntegerKeys("Photo_");
  }

  // Token: 0x060003ED RID: 1005 RVA: 0x0003B75B File Offset: 0x00039B5B
  public static bool GetPhotoOnCorkboard(int photoID) {
    return GlobalsHelper.GetBool("PhotoOnCorkboard_" + photoID.ToString());
  }

  // Token: 0x060003EE RID: 1006 RVA: 0x0003B77C File Offset: 0x00039B7C
  public static void SetPhotoOnCorkboard(int photoID, bool value) {
    string text = photoID.ToString();
    KeysHelper.AddIfMissing("PhotoOnCorkboard_", text);
    GlobalsHelper.SetBool("PhotoOnCorkboard_" + text, value);
  }

  // Token: 0x060003EF RID: 1007 RVA: 0x0003B7B3 File Offset: 0x00039BB3
  public static int[] KeysOfPhotoOnCorkboard() {
    return KeysHelper.GetIntegerKeys("PhotoOnCorkboard_");
  }

  // Token: 0x060003F0 RID: 1008 RVA: 0x0003B7BF File Offset: 0x00039BBF
  public static Vector2 GetPhotoPosition(int photoID) {
    return GlobalsHelper.GetVector2("PhotoPosition_" + photoID.ToString());
  }

  // Token: 0x060003F1 RID: 1009 RVA: 0x0003B7E0 File Offset: 0x00039BE0
  public static void SetPhotoPosition(int photoID, Vector2 value) {
    string text = photoID.ToString();
    KeysHelper.AddIfMissing("PhotoPosition_", text);
    GlobalsHelper.SetVector2("PhotoPosition_" + text, value);
  }

  // Token: 0x060003F2 RID: 1010 RVA: 0x0003B817 File Offset: 0x00039C17
  public static int[] KeysOfPhotoPosition() {
    return KeysHelper.GetIntegerKeys("PhotoPosition_");
  }

  // Token: 0x060003F3 RID: 1011 RVA: 0x0003B823 File Offset: 0x00039C23
  public static float GetPhotoRotation(int photoID) {
    return PlayerPrefs.GetFloat("PhotoRotation_" + photoID.ToString());
  }

  // Token: 0x060003F4 RID: 1012 RVA: 0x0003B844 File Offset: 0x00039C44
  public static void SetPhotoRotation(int photoID, float value) {
    string text = photoID.ToString();
    KeysHelper.AddIfMissing("PhotoRotation_", text);
    PlayerPrefs.SetFloat("PhotoRotation_" + text, value);
  }

  // Token: 0x060003F5 RID: 1013 RVA: 0x0003B87B File Offset: 0x00039C7B
  public static int[] KeysOfPhotoRotation() {
    return KeysHelper.GetIntegerKeys("PhotoRotation_");
  }

  // Token: 0x17000093 RID: 147
  // (get) Token: 0x060003F6 RID: 1014 RVA: 0x0003B887 File Offset: 0x00039C87
  // (set) Token: 0x060003F7 RID: 1015 RVA: 0x0003B893 File Offset: 0x00039C93
  public static float Reputation {
    get {
      return PlayerPrefs.GetFloat("Reputation");
    }
    set {
      PlayerPrefs.SetFloat("Reputation", value);
    }
  }

  // Token: 0x17000094 RID: 148
  // (get) Token: 0x060003F8 RID: 1016 RVA: 0x0003B8A0 File Offset: 0x00039CA0
  // (set) Token: 0x060003F9 RID: 1017 RVA: 0x0003B8AC File Offset: 0x00039CAC
  public static int Seduction {
    get {
      return PlayerPrefs.GetInt("Seduction");
    }
    set {
      PlayerPrefs.SetInt("Seduction", value);
    }
  }

  // Token: 0x17000095 RID: 149
  // (get) Token: 0x060003FA RID: 1018 RVA: 0x0003B8B9 File Offset: 0x00039CB9
  // (set) Token: 0x060003FB RID: 1019 RVA: 0x0003B8C5 File Offset: 0x00039CC5
  public static int SeductionBonus {
    get {
      return PlayerPrefs.GetInt("SeductionBonus");
    }
    set {
      PlayerPrefs.SetInt("SeductionBonus", value);
    }
  }

  // Token: 0x060003FC RID: 1020 RVA: 0x0003B8D2 File Offset: 0x00039CD2
  public static bool GetSenpaiPhoto(int photoID) {
    return GlobalsHelper.GetBool("SenpaiPhoto_" + photoID.ToString());
  }

  // Token: 0x060003FD RID: 1021 RVA: 0x0003B8F0 File Offset: 0x00039CF0
  public static void SetSenpaiPhoto(int photoID, bool value) {
    string text = photoID.ToString();
    KeysHelper.AddIfMissing("SenpaiPhoto_", text);
    GlobalsHelper.SetBool("SenpaiPhoto_" + text, value);
  }

  // Token: 0x060003FE RID: 1022 RVA: 0x0003B927 File Offset: 0x00039D27
  public static int[] KeysOfSenpaiPhoto() {
    return KeysHelper.GetIntegerKeys("SenpaiPhoto_");
  }

  // Token: 0x17000096 RID: 150
  // (get) Token: 0x060003FF RID: 1023 RVA: 0x0003B933 File Offset: 0x00039D33
  // (set) Token: 0x06000400 RID: 1024 RVA: 0x0003B93F File Offset: 0x00039D3F
  public static int SenpaiShots {
    get {
      return PlayerPrefs.GetInt("SenpaiShots");
    }
    set {
      PlayerPrefs.SetInt("SenpaiShots", value);
    }
  }

  // Token: 0x17000097 RID: 151
  // (get) Token: 0x06000401 RID: 1025 RVA: 0x0003B94C File Offset: 0x00039D4C
  // (set) Token: 0x06000402 RID: 1026 RVA: 0x0003B958 File Offset: 0x00039D58
  public static int SocialBonus {
    get {
      return PlayerPrefs.GetInt("SocialBonus");
    }
    set {
      PlayerPrefs.SetInt("SocialBonus", value);
    }
  }

  // Token: 0x17000098 RID: 152
  // (get) Token: 0x06000403 RID: 1027 RVA: 0x0003B965 File Offset: 0x00039D65
  // (set) Token: 0x06000404 RID: 1028 RVA: 0x0003B971 File Offset: 0x00039D71
  public static int SpeedBonus {
    get {
      return PlayerPrefs.GetInt("SpeedBonus");
    }
    set {
      PlayerPrefs.SetInt("SpeedBonus", value);
    }
  }

  // Token: 0x17000099 RID: 153
  // (get) Token: 0x06000405 RID: 1029 RVA: 0x0003B97E File Offset: 0x00039D7E
  // (set) Token: 0x06000406 RID: 1030 RVA: 0x0003B98A File Offset: 0x00039D8A
  public static int StealthBonus {
    get {
      return PlayerPrefs.GetInt("StealthBonus");
    }
    set {
      PlayerPrefs.SetInt("StealthBonus", value);
    }
  }

  // Token: 0x06000407 RID: 1031 RVA: 0x0003B997 File Offset: 0x00039D97
  public static bool GetStudentFriend(int studentID) {
    return GlobalsHelper.GetBool("StudentFriend_" + studentID.ToString());
  }

  // Token: 0x06000408 RID: 1032 RVA: 0x0003B9B8 File Offset: 0x00039DB8
  public static void SetStudentFriend(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentFriend_", text);
    GlobalsHelper.SetBool("StudentFriend_" + text, value);
  }

  // Token: 0x06000409 RID: 1033 RVA: 0x0003B9EF File Offset: 0x00039DEF
  public static int[] KeysOfStudentFriend() {
    return KeysHelper.GetIntegerKeys("StudentFriend_");
  }

  // Token: 0x0600040A RID: 1034 RVA: 0x0003B9FB File Offset: 0x00039DFB
  public static bool GetStudentPantyShot(string studentName) {
    return GlobalsHelper.GetBool("StudentPantyShot_" + studentName);
  }

  // Token: 0x0600040B RID: 1035 RVA: 0x0003BA0D File Offset: 0x00039E0D
  public static void SetStudentPantyShot(string studentName, bool value) {
    KeysHelper.AddIfMissing("StudentPantyShot_", studentName);
    GlobalsHelper.SetBool("StudentPantyShot_" + studentName, value);
  }

  // Token: 0x0600040C RID: 1036 RVA: 0x0003BA2B File Offset: 0x00039E2B
  public static string[] KeysOfStudentPantyShot() {
    return KeysHelper.GetStringKeys("StudentPantyShot_");
  }

  // Token: 0x0600040D RID: 1037 RVA: 0x0003BA38 File Offset: 0x00039E38
  public static void DeleteAll() {
    Globals.Delete("Alerts");
    Globals.Delete("Enlightenment");
    Globals.Delete("EnlightenmentBonus");
    Globals.Delete("Headset");
    Globals.Delete("Kills");
    Globals.Delete("Numbness");
    Globals.Delete("NumbnessBonus");
    Globals.Delete("PantiesEquipped");
    Globals.Delete("PantyShots");
    Globals.DeleteCollection("Photo_", PlayerGlobals.KeysOfPhoto());
    Globals.DeleteCollection("PhotoOnCorkboard_", PlayerGlobals.KeysOfPhotoOnCorkboard());
    Globals.DeleteCollection("PhotoPosition_", PlayerGlobals.KeysOfPhotoPosition());
    Globals.DeleteCollection("PhotoRotation_", PlayerGlobals.KeysOfPhotoRotation());
    Globals.Delete("Reputation");
    Globals.Delete("Seduction");
    Globals.Delete("SeductionBonus");
    Globals.DeleteCollection("SenpaiPhoto_", PlayerGlobals.KeysOfSenpaiPhoto());
    Globals.Delete("SenpaiShots");
    Globals.Delete("SocialBonus");
    Globals.Delete("SpeedBonus");
    Globals.Delete("StealthBonus");
    Globals.DeleteCollection("StudentFriend_", PlayerGlobals.KeysOfStudentFriend());
    Globals.DeleteCollection("StudentPantyShot_", PlayerGlobals.KeysOfStudentPantyShot());
  }

  // Token: 0x040009F6 RID: 2550
  private const string Str_Alerts = "Alerts";

  // Token: 0x040009F7 RID: 2551
  private const string Str_Enlightenment = "Enlightenment";

  // Token: 0x040009F8 RID: 2552
  private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

  // Token: 0x040009F9 RID: 2553
  private const string Str_Headset = "Headset";

  // Token: 0x040009FA RID: 2554
  private const string Str_Kills = "Kills";

  // Token: 0x040009FB RID: 2555
  private const string Str_Numbness = "Numbness";

  // Token: 0x040009FC RID: 2556
  private const string Str_NumbnessBonus = "NumbnessBonus";

  // Token: 0x040009FD RID: 2557
  private const string Str_PantiesEquipped = "PantiesEquipped";

  // Token: 0x040009FE RID: 2558
  private const string Str_PantyShots = "PantyShots";

  // Token: 0x040009FF RID: 2559
  private const string Str_Photo = "Photo_";

  // Token: 0x04000A00 RID: 2560
  private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

  // Token: 0x04000A01 RID: 2561
  private const string Str_PhotoPosition = "PhotoPosition_";

  // Token: 0x04000A02 RID: 2562
  private const string Str_PhotoRotation = "PhotoRotation_";

  // Token: 0x04000A03 RID: 2563
  private const string Str_Reputation = "Reputation";

  // Token: 0x04000A04 RID: 2564
  private const string Str_Seduction = "Seduction";

  // Token: 0x04000A05 RID: 2565
  private const string Str_SeductionBonus = "SeductionBonus";

  // Token: 0x04000A06 RID: 2566
  private const string Str_SenpaiPhoto = "SenpaiPhoto_";

  // Token: 0x04000A07 RID: 2567
  private const string Str_SenpaiShots = "SenpaiShots";

  // Token: 0x04000A08 RID: 2568
  private const string Str_SocialBonus = "SocialBonus";

  // Token: 0x04000A09 RID: 2569
  private const string Str_SpeedBonus = "SpeedBonus";

  // Token: 0x04000A0A RID: 2570
  private const string Str_StealthBonus = "StealthBonus";

  // Token: 0x04000A0B RID: 2571
  private const string Str_StudentFriend = "StudentFriend_";

  // Token: 0x04000A0C RID: 2572
  private const string Str_StudentPantyShot = "StudentPantyShot_";
}