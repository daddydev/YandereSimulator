using UnityEngine;

// Token: 0x020000DE RID: 222
public static class PoseModeGlobals {

  // Token: 0x1700009A RID: 154
  // (get) Token: 0x0600040E RID: 1038 RVA: 0x0003BB4E File Offset: 0x00039F4E
  // (set) Token: 0x0600040F RID: 1039 RVA: 0x0003BB5A File Offset: 0x00039F5A
  public static Vector3 PosePosition {
    get {
      return GlobalsHelper.GetVector3("PosePosition");
    }
    set {
      GlobalsHelper.SetVector3("PosePosition", value);
    }
  }

  // Token: 0x1700009B RID: 155
  // (get) Token: 0x06000410 RID: 1040 RVA: 0x0003BB67 File Offset: 0x00039F67
  // (set) Token: 0x06000411 RID: 1041 RVA: 0x0003BB73 File Offset: 0x00039F73
  public static Vector3 PoseRotation {
    get {
      return GlobalsHelper.GetVector3("PoseRotation");
    }
    set {
      GlobalsHelper.SetVector3("PoseRotation", value);
    }
  }

  // Token: 0x1700009C RID: 156
  // (get) Token: 0x06000412 RID: 1042 RVA: 0x0003BB80 File Offset: 0x00039F80
  // (set) Token: 0x06000413 RID: 1043 RVA: 0x0003BB8C File Offset: 0x00039F8C
  public static Vector3 PoseScale {
    get {
      return GlobalsHelper.GetVector3("PoseScale");
    }
    set {
      GlobalsHelper.SetVector3("PoseScale", value);
    }
  }

  // Token: 0x06000414 RID: 1044 RVA: 0x0003BB99 File Offset: 0x00039F99
  public static void DeleteAll() {
    GlobalsHelper.DeleteVector3("PosePosition");
    GlobalsHelper.DeleteVector3("PoseRotation");
    GlobalsHelper.DeleteVector3("PoseScale");
  }

  // Token: 0x04000A0D RID: 2573
  private const string Str_PosePosition = "PosePosition";

  // Token: 0x04000A0E RID: 2574
  private const string Str_PoseRotation = "PoseRotation";

  // Token: 0x04000A0F RID: 2575
  private const string Str_PoseScale = "PoseScale";
}