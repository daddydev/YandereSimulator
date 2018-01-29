using System;
using System.Collections.Generic;

// Token: 0x02000196 RID: 406
[Serializable]
public class MissionModeSaveData {

  // Token: 0x06000735 RID: 1845 RVA: 0x0006D464 File Offset: 0x0006B864
  public static MissionModeSaveData ReadFromGlobals() {
    MissionModeSaveData missionModeSaveData = new MissionModeSaveData();
    foreach (int num in MissionModeGlobals.KeysOfMissionCondition()) {
      missionModeSaveData.missionCondition.Add(num, MissionModeGlobals.GetMissionCondition(num));
    }
    missionModeSaveData.missionDifficulty = MissionModeGlobals.MissionDifficulty;
    missionModeSaveData.missionMode = MissionModeGlobals.MissionMode;
    missionModeSaveData.missionRequiredClothing = MissionModeGlobals.MissionRequiredClothing;
    missionModeSaveData.missionRequiredDisposal = MissionModeGlobals.MissionRequiredDisposal;
    missionModeSaveData.missionRequiredWeapon = MissionModeGlobals.MissionRequiredWeapon;
    missionModeSaveData.missionTarget = MissionModeGlobals.MissionTarget;
    missionModeSaveData.missionTargetName = MissionModeGlobals.MissionTargetName;
    missionModeSaveData.nemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
    return missionModeSaveData;
  }

  // Token: 0x06000736 RID: 1846 RVA: 0x0006D500 File Offset: 0x0006B900
  public static void WriteToGlobals(MissionModeSaveData data) {
    foreach (KeyValuePair<int, int> keyValuePair in data.missionCondition) {
      MissionModeGlobals.SetMissionCondition(keyValuePair.Key, keyValuePair.Value);
    }
    MissionModeGlobals.MissionDifficulty = data.missionDifficulty;
    MissionModeGlobals.MissionMode = data.missionMode;
    MissionModeGlobals.MissionRequiredClothing = data.missionRequiredClothing;
    MissionModeGlobals.MissionRequiredDisposal = data.missionRequiredDisposal;
    MissionModeGlobals.MissionRequiredWeapon = data.missionRequiredWeapon;
    MissionModeGlobals.MissionTarget = data.missionTarget;
    MissionModeGlobals.MissionTargetName = data.missionTargetName;
    MissionModeGlobals.NemesisDifficulty = data.nemesisDifficulty;
  }

  // Token: 0x0400122D RID: 4653
  public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

  // Token: 0x0400122E RID: 4654
  public int missionDifficulty;

  // Token: 0x0400122F RID: 4655
  public bool missionMode;

  // Token: 0x04001230 RID: 4656
  public int missionRequiredClothing;

  // Token: 0x04001231 RID: 4657
  public int missionRequiredDisposal;

  // Token: 0x04001232 RID: 4658
  public int missionRequiredWeapon;

  // Token: 0x04001233 RID: 4659
  public int missionTarget;

  // Token: 0x04001234 RID: 4660
  public string missionTargetName = string.Empty;

  // Token: 0x04001235 RID: 4661
  public int nemesisDifficulty;
}