using UnityEngine;

// Token: 0x020000D0 RID: 208
public static class Globals {

  // Token: 0x0600032A RID: 810 RVA: 0x0003A481 File Offset: 0x00038881
  public static bool KeyExists(string key) {
    return PlayerPrefs.HasKey(key);
  }

  // Token: 0x0600032B RID: 811 RVA: 0x0003A489 File Offset: 0x00038889
  public static void DeleteAll() {
    PlayerPrefs.DeleteAll();
  }

  // Token: 0x0600032C RID: 812 RVA: 0x0003A490 File Offset: 0x00038890
  public static void Delete(string key) {
    PlayerPrefs.DeleteKey(key);
  }

  // Token: 0x0600032D RID: 813 RVA: 0x0003A498 File Offset: 0x00038898
  public static void DeleteCollection(string key, int[] usedKeys) {
    foreach (int num in usedKeys) {
      PlayerPrefs.DeleteKey(key + num.ToString());
    }
    KeysHelper.Delete(key);
  }

  // Token: 0x0600032E RID: 814 RVA: 0x0003A4E0 File Offset: 0x000388E0
  public static void DeleteCollection(string key, string[] usedKeys) {
    foreach (string str in usedKeys) {
      PlayerPrefs.DeleteKey(key + str);
    }
    KeysHelper.Delete(key);
  }

  // Token: 0x0600032F RID: 815 RVA: 0x0003A519 File Offset: 0x00038919
  public static void Save() {
    PlayerPrefs.Save();
  }
}