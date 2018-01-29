using System;

// Token: 0x020001A0 RID: 416
[Serializable]
public class YanvaniaSaveData {

  // Token: 0x06000753 RID: 1875 RVA: 0x0006F238 File Offset: 0x0006D638
  public static YanvaniaSaveData ReadFromGlobals() {
    return new YanvaniaSaveData {
      draculaDefeated = YanvaniaGlobals.DraculaDefeated,
      midoriEasterEgg = YanvaniaGlobals.MidoriEasterEgg
    };
  }

  // Token: 0x06000754 RID: 1876 RVA: 0x0006F262 File Offset: 0x0006D662
  public static void WriteToGlobals(YanvaniaSaveData data) {
    YanvaniaGlobals.DraculaDefeated = data.draculaDefeated;
    YanvaniaGlobals.MidoriEasterEgg = data.midoriEasterEgg;
  }

  // Token: 0x04001293 RID: 4755
  public bool draculaDefeated;

  // Token: 0x04001294 RID: 4756
  public bool midoriEasterEgg;
}