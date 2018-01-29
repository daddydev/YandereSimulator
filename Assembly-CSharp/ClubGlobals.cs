// Token: 0x020000D3 RID: 211
public static class ClubGlobals {

  // Token: 0x17000064 RID: 100
  // (get) Token: 0x06000352 RID: 850 RVA: 0x0003A75F File Offset: 0x00038B5F
  // (set) Token: 0x06000353 RID: 851 RVA: 0x0003A76B File Offset: 0x00038B6B
  public static ClubType Club {
    get {
      return GlobalsHelper.GetEnum<ClubType>("Club");
    }
    set {
      GlobalsHelper.SetEnum<ClubType>("Club", value);
    }
  }

  // Token: 0x06000354 RID: 852 RVA: 0x0003A778 File Offset: 0x00038B78
  public static bool GetClubClosed(ClubType clubID) {
    string str = "ClubClosed_";
    int num = (int)clubID;
    return GlobalsHelper.GetBool(str + num.ToString());
  }

  // Token: 0x06000355 RID: 853 RVA: 0x0003A7A4 File Offset: 0x00038BA4
  public static void SetClubClosed(ClubType clubID, bool value) {
    int num = (int)clubID;
    string text = num.ToString();
    KeysHelper.AddIfMissing("ClubClosed_", text);
    GlobalsHelper.SetBool("ClubClosed_" + text, value);
  }

  // Token: 0x06000356 RID: 854 RVA: 0x0003A7DD File Offset: 0x00038BDD
  public static ClubType[] KeysOfClubClosed() {
    return KeysHelper.GetEnumKeys<ClubType>("ClubClosed_");
  }

  // Token: 0x06000357 RID: 855 RVA: 0x0003A7EC File Offset: 0x00038BEC
  public static bool GetClubKicked(ClubType clubID) {
    string str = "ClubKicked_";
    int num = (int)clubID;
    return GlobalsHelper.GetBool(str + num.ToString());
  }

  // Token: 0x06000358 RID: 856 RVA: 0x0003A818 File Offset: 0x00038C18
  public static void SetClubKicked(ClubType clubID, bool value) {
    int num = (int)clubID;
    string text = num.ToString();
    KeysHelper.AddIfMissing("ClubKicked_", text);
    GlobalsHelper.SetBool("ClubKicked_" + text, value);
  }

  // Token: 0x06000359 RID: 857 RVA: 0x0003A851 File Offset: 0x00038C51
  public static ClubType[] KeysOfClubKicked() {
    return KeysHelper.GetEnumKeys<ClubType>("ClubKicked_");
  }

  // Token: 0x0600035A RID: 858 RVA: 0x0003A860 File Offset: 0x00038C60
  public static bool GetQuitClub(ClubType clubID) {
    string str = "QuitClub_";
    int num = (int)clubID;
    return GlobalsHelper.GetBool(str + num.ToString());
  }

  // Token: 0x0600035B RID: 859 RVA: 0x0003A88C File Offset: 0x00038C8C
  public static void SetQuitClub(ClubType clubID, bool value) {
    int num = (int)clubID;
    string text = num.ToString();
    KeysHelper.AddIfMissing("QuitClub_", text);
    GlobalsHelper.SetBool("QuitClub_" + text, value);
  }

  // Token: 0x0600035C RID: 860 RVA: 0x0003A8C5 File Offset: 0x00038CC5
  public static ClubType[] KeysOfQuitClub() {
    return KeysHelper.GetEnumKeys<ClubType>("QuitClub_");
  }

  // Token: 0x0600035D RID: 861 RVA: 0x0003A8D4 File Offset: 0x00038CD4
  public static void DeleteAll() {
    Globals.Delete("Club");
    foreach (ClubType clubType in ClubGlobals.KeysOfClubClosed()) {
      string str = "ClubClosed_";
      int num = (int)clubType;
      Globals.Delete(str + num.ToString());
    }
    foreach (ClubType clubType2 in ClubGlobals.KeysOfClubKicked()) {
      string str2 = "ClubKicked_";
      int num2 = (int)clubType2;
      Globals.Delete(str2 + num2.ToString());
    }
    foreach (ClubType clubType3 in ClubGlobals.KeysOfQuitClub()) {
      string str3 = "QuitClub_";
      int num3 = (int)clubType3;
      Globals.Delete(str3 + num3.ToString());
    }
    KeysHelper.Delete("ClubClosed_");
    KeysHelper.Delete("ClubKicked_");
    KeysHelper.Delete("QuitClub_");
  }

  // Token: 0x040009C0 RID: 2496
  private const string Str_Club = "Club";

  // Token: 0x040009C1 RID: 2497
  private const string Str_ClubClosed = "ClubClosed_";

  // Token: 0x040009C2 RID: 2498
  private const string Str_ClubKicked = "ClubKicked_";

  // Token: 0x040009C3 RID: 2499
  private const string Str_QuitClub = "QuitClub_";
}