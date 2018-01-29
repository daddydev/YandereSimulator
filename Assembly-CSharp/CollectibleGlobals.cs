// Token: 0x020000D4 RID: 212
public static class CollectibleGlobals {

  // Token: 0x0600035E RID: 862 RVA: 0x0003A9D3 File Offset: 0x00038DD3
  public static bool GetBasementTapeCollected(int tapeID) {
    return GlobalsHelper.GetBool("BasementTapeCollected_" + tapeID.ToString());
  }

  // Token: 0x0600035F RID: 863 RVA: 0x0003A9F4 File Offset: 0x00038DF4
  public static void SetBasementTapeCollected(int tapeID, bool value) {
    string text = tapeID.ToString();
    KeysHelper.AddIfMissing("BasementTapeCollected_", text);
    GlobalsHelper.SetBool("BasementTapeCollected_" + text, value);
  }

  // Token: 0x06000360 RID: 864 RVA: 0x0003AA2B File Offset: 0x00038E2B
  public static int[] KeysOfBasementTapeCollected() {
    return KeysHelper.GetIntegerKeys("BasementTapeCollected_");
  }

  // Token: 0x06000361 RID: 865 RVA: 0x0003AA37 File Offset: 0x00038E37
  public static bool GetBasementTapeListened(int tapeID) {
    return GlobalsHelper.GetBool("BasementTapeListened_" + tapeID.ToString());
  }

  // Token: 0x06000362 RID: 866 RVA: 0x0003AA58 File Offset: 0x00038E58
  public static void SetBasementTapeListened(int tapeID, bool value) {
    string text = tapeID.ToString();
    KeysHelper.AddIfMissing("BasementTapeListened_", text);
    GlobalsHelper.SetBool("BasementTapeListened_" + text, value);
  }

  // Token: 0x06000363 RID: 867 RVA: 0x0003AA8F File Offset: 0x00038E8F
  public static int[] KeysOfBasementTapeListened() {
    return KeysHelper.GetIntegerKeys("BasementTapeListened_");
  }

  // Token: 0x06000364 RID: 868 RVA: 0x0003AA9B File Offset: 0x00038E9B
  public static bool GetMangaCollected(int mangaID) {
    return GlobalsHelper.GetBool("MangaCollected_" + mangaID.ToString());
  }

  // Token: 0x06000365 RID: 869 RVA: 0x0003AABC File Offset: 0x00038EBC
  public static void SetMangaCollected(int mangaID, bool value) {
    string text = mangaID.ToString();
    KeysHelper.AddIfMissing("MangaCollected_", text);
    GlobalsHelper.SetBool("MangaCollected_" + text, value);
  }

  // Token: 0x06000366 RID: 870 RVA: 0x0003AAF3 File Offset: 0x00038EF3
  public static int[] KeysOfMangaCollected() {
    return KeysHelper.GetIntegerKeys("MangaCollected_");
  }

  // Token: 0x06000367 RID: 871 RVA: 0x0003AAFF File Offset: 0x00038EFF
  public static bool GetTapeCollected(int tapeID) {
    return GlobalsHelper.GetBool("TapeCollected_" + tapeID.ToString());
  }

  // Token: 0x06000368 RID: 872 RVA: 0x0003AB20 File Offset: 0x00038F20
  public static void SetTapeCollected(int tapeID, bool value) {
    string text = tapeID.ToString();
    KeysHelper.AddIfMissing("TapeCollected_", text);
    GlobalsHelper.SetBool("TapeCollected_" + text, value);
  }

  // Token: 0x06000369 RID: 873 RVA: 0x0003AB57 File Offset: 0x00038F57
  public static int[] KeysOfTapeCollected() {
    return KeysHelper.GetIntegerKeys("TapeCollected_");
  }

  // Token: 0x0600036A RID: 874 RVA: 0x0003AB63 File Offset: 0x00038F63
  public static bool GetTapeListened(int tapeID) {
    return GlobalsHelper.GetBool("TapeListened_" + tapeID.ToString());
  }

  // Token: 0x0600036B RID: 875 RVA: 0x0003AB84 File Offset: 0x00038F84
  public static void SetTapeListened(int tapeID, bool value) {
    string text = tapeID.ToString();
    KeysHelper.AddIfMissing("TapeListened_", text);
    GlobalsHelper.SetBool("TapeListened_" + text, value);
  }

  // Token: 0x0600036C RID: 876 RVA: 0x0003ABBB File Offset: 0x00038FBB
  public static int[] KeysOfTapeListened() {
    return KeysHelper.GetIntegerKeys("TapeListened_");
  }

  // Token: 0x0600036D RID: 877 RVA: 0x0003ABC8 File Offset: 0x00038FC8
  public static void DeleteAll() {
    Globals.DeleteCollection("BasementTapeCollected_", CollectibleGlobals.KeysOfBasementTapeCollected());
    Globals.DeleteCollection("BasementTapeListened_", CollectibleGlobals.KeysOfBasementTapeListened());
    Globals.DeleteCollection("MangaCollected_", CollectibleGlobals.KeysOfMangaCollected());
    Globals.DeleteCollection("TapeCollected_", CollectibleGlobals.KeysOfTapeCollected());
    Globals.DeleteCollection("TapeListened_", CollectibleGlobals.KeysOfTapeListened());
  }

  // Token: 0x040009C4 RID: 2500
  private const string Str_BasementTapeCollected = "BasementTapeCollected_";

  // Token: 0x040009C5 RID: 2501
  private const string Str_BasementTapeListened = "BasementTapeListened_";

  // Token: 0x040009C6 RID: 2502
  private const string Str_MangaCollected = "MangaCollected_";

  // Token: 0x040009C7 RID: 2503
  private const string Str_TapeCollected = "TapeCollected_";

  // Token: 0x040009C8 RID: 2504
  private const string Str_TapeListened = "TapeListened_";
}