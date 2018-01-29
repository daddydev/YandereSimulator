using System;

// Token: 0x02000197 RID: 407
[Serializable]
public class OptionSaveData {

  // Token: 0x06000738 RID: 1848 RVA: 0x0006D5C8 File Offset: 0x0006B9C8
  public static OptionSaveData ReadFromGlobals() {
    return new OptionSaveData {
      disableBloom = OptionGlobals.DisableBloom,
      disableFarAnimations = OptionGlobals.DisableFarAnimations,
      disableOutlines = OptionGlobals.DisableOutlines,
      disablePostAliasing = OptionGlobals.DisablePostAliasing,
      disableShadows = OptionGlobals.DisableShadows,
      drawDistance = OptionGlobals.DrawDistance,
      drawDistanceLimit = OptionGlobals.DrawDistanceLimit,
      fog = OptionGlobals.Fog,
      fpsIndex = OptionGlobals.FPSIndex,
      highPopulation = OptionGlobals.HighPopulation,
      lowDetailStudents = OptionGlobals.LowDetailStudents,
      particleCount = OptionGlobals.ParticleCount
    };
  }

  // Token: 0x06000739 RID: 1849 RVA: 0x0006D660 File Offset: 0x0006BA60
  public static void WriteToGlobals(OptionSaveData data) {
    OptionGlobals.DisableBloom = data.disableBloom;
    OptionGlobals.DisableFarAnimations = data.disableFarAnimations;
    OptionGlobals.DisableOutlines = data.disableOutlines;
    OptionGlobals.DisablePostAliasing = data.disablePostAliasing;
    OptionGlobals.DisableShadows = data.disableShadows;
    OptionGlobals.DrawDistance = data.drawDistance;
    OptionGlobals.DrawDistanceLimit = data.drawDistanceLimit;
    OptionGlobals.Fog = data.fog;
    OptionGlobals.FPSIndex = data.fpsIndex;
    OptionGlobals.HighPopulation = data.highPopulation;
    OptionGlobals.LowDetailStudents = data.lowDetailStudents;
    OptionGlobals.ParticleCount = data.particleCount;
  }

  // Token: 0x04001236 RID: 4662
  public bool disableBloom;

  // Token: 0x04001237 RID: 4663
  public bool disableFarAnimations;

  // Token: 0x04001238 RID: 4664
  public bool disableOutlines;

  // Token: 0x04001239 RID: 4665
  public bool disablePostAliasing;

  // Token: 0x0400123A RID: 4666
  public bool disableShadows;

  // Token: 0x0400123B RID: 4667
  public int drawDistance;

  // Token: 0x0400123C RID: 4668
  public int drawDistanceLimit;

  // Token: 0x0400123D RID: 4669
  public bool fog;

  // Token: 0x0400123E RID: 4670
  public int fpsIndex;

  // Token: 0x0400123F RID: 4671
  public bool highPopulation;

  // Token: 0x04001240 RID: 4672
  public int lowDetailStudents;

  // Token: 0x04001241 RID: 4673
  public int particleCount;
}