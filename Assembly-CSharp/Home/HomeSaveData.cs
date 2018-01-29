using System;

// Token: 0x02000195 RID: 405
[Serializable]
public class HomeSaveData {

  // Token: 0x06000732 RID: 1842 RVA: 0x0006D3EC File Offset: 0x0006B7EC
  public static HomeSaveData ReadFromGlobals() {
    return new HomeSaveData {
      lateForSchool = HomeGlobals.LateForSchool,
      night = HomeGlobals.Night,
      startInBasement = HomeGlobals.StartInBasement
    };
  }

  // Token: 0x06000733 RID: 1843 RVA: 0x0006D421 File Offset: 0x0006B821
  public static void WriteToGlobals(HomeSaveData data) {
    HomeGlobals.LateForSchool = data.lateForSchool;
    HomeGlobals.Night = data.night;
    HomeGlobals.StartInBasement = data.startInBasement;
  }

  // Token: 0x0400122A RID: 4650
  public bool lateForSchool;

  // Token: 0x0400122B RID: 4651
  public bool night;

  // Token: 0x0400122C RID: 4652
  public bool startInBasement;
}