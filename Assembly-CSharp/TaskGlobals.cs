using UnityEngine;

// Token: 0x020000E4 RID: 228
public static class TaskGlobals {

  // Token: 0x060004A1 RID: 1185 RVA: 0x0003CBB9 File Offset: 0x0003AFB9
  public static bool GetKittenPhoto(int photoID) {
    return GlobalsHelper.GetBool("KittenPhoto_" + photoID.ToString());
  }

  // Token: 0x060004A2 RID: 1186 RVA: 0x0003CBD8 File Offset: 0x0003AFD8
  public static void SetKittenPhoto(int photoID, bool value) {
    string text = photoID.ToString();
    KeysHelper.AddIfMissing("KittenPhoto_", text);
    GlobalsHelper.SetBool("KittenPhoto_" + text, value);
  }

  // Token: 0x060004A3 RID: 1187 RVA: 0x0003CC0F File Offset: 0x0003B00F
  public static int[] KeysOfKittenPhoto() {
    return KeysHelper.GetIntegerKeys("KittenPhoto_");
  }

  // Token: 0x060004A4 RID: 1188 RVA: 0x0003CC1B File Offset: 0x0003B01B
  public static int GetTaskStatus(int taskID) {
    return PlayerPrefs.GetInt("TaskStatus_" + taskID.ToString());
  }

  // Token: 0x060004A5 RID: 1189 RVA: 0x0003CC3C File Offset: 0x0003B03C
  public static void SetTaskStatus(int taskID, int value) {
    string text = taskID.ToString();
    KeysHelper.AddIfMissing("TaskStatus_", text);
    PlayerPrefs.SetInt("TaskStatus_" + text, value);
  }

  // Token: 0x060004A6 RID: 1190 RVA: 0x0003CC73 File Offset: 0x0003B073
  public static int[] KeysOfTaskStatus() {
    return KeysHelper.GetIntegerKeys("TaskStatus_");
  }

  // Token: 0x060004A7 RID: 1191 RVA: 0x0003CC7F File Offset: 0x0003B07F
  public static void DeleteAll() {
    Globals.DeleteCollection("KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
    Globals.DeleteCollection("TaskStatus_", TaskGlobals.KeysOfTaskStatus());
  }

  // Token: 0x04000A46 RID: 2630
  private const string Str_KittenPhoto = "KittenPhoto_";

  // Token: 0x04000A47 RID: 2631
  private const string Str_TaskStatus = "TaskStatus_";
}