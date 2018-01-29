using System;
using UnityEngine;

// Token: 0x02000199 RID: 409
[Serializable]
public class PoseModeSaveData {

  // Token: 0x0600073E RID: 1854 RVA: 0x0006DCFC File Offset: 0x0006C0FC
  public static PoseModeSaveData ReadFromGlobals() {
    return new PoseModeSaveData {
      posePosition = PoseModeGlobals.PosePosition,
      poseRotation = PoseModeGlobals.PoseRotation,
      poseScale = PoseModeGlobals.PoseScale
    };
  }

  // Token: 0x0600073F RID: 1855 RVA: 0x0006DD31 File Offset: 0x0006C131
  public static void WriteToGlobals(PoseModeSaveData data) {
    PoseModeGlobals.PosePosition = data.posePosition;
    PoseModeGlobals.PoseRotation = data.poseRotation;
    PoseModeGlobals.PoseScale = data.poseScale;
  }

  // Token: 0x04001259 RID: 4697
  public Vector3 posePosition = default(Vector3);

  // Token: 0x0400125A RID: 4698
  public Vector3 poseRotation = default(Vector3);

  // Token: 0x0400125B RID: 4699
  public Vector3 poseScale = default(Vector3);
}