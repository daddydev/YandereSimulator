using System;

// Token: 0x0200019D RID: 413
[Serializable]
public class SenpaiSaveData {

  // Token: 0x0600074A RID: 1866 RVA: 0x0006E2DC File Offset: 0x0006C6DC
  public static SenpaiSaveData ReadFromGlobals() {
    return new SenpaiSaveData {
      customSenpai = SenpaiGlobals.CustomSenpai,
      senpaiEyeColor = SenpaiGlobals.SenpaiEyeColor,
      senpaiEyeWear = SenpaiGlobals.SenpaiEyeWear,
      senpaiFacialHair = SenpaiGlobals.SenpaiFacialHair,
      senpaiHairColor = SenpaiGlobals.SenpaiHairColor,
      senpaiHairStyle = SenpaiGlobals.SenpaiHairStyle,
      senpaiSkinColor = SenpaiGlobals.SenpaiSkinColor
    };
  }

  // Token: 0x0600074B RID: 1867 RVA: 0x0006E340 File Offset: 0x0006C740
  public static void WriteToGlobals(SenpaiSaveData data) {
    SenpaiGlobals.CustomSenpai = data.customSenpai;
    SenpaiGlobals.SenpaiEyeColor = data.senpaiEyeColor;
    SenpaiGlobals.SenpaiEyeWear = data.senpaiEyeWear;
    SenpaiGlobals.SenpaiFacialHair = data.senpaiFacialHair;
    SenpaiGlobals.SenpaiHairColor = data.senpaiHairColor;
    SenpaiGlobals.SenpaiHairStyle = data.senpaiHairStyle;
    SenpaiGlobals.SenpaiSkinColor = data.senpaiSkinColor;
  }

  // Token: 0x0400126C RID: 4716
  public bool customSenpai;

  // Token: 0x0400126D RID: 4717
  public string senpaiEyeColor = string.Empty;

  // Token: 0x0400126E RID: 4718
  public int senpaiEyeWear;

  // Token: 0x0400126F RID: 4719
  public int senpaiFacialHair;

  // Token: 0x04001270 RID: 4720
  public string senpaiHairColor = string.Empty;

  // Token: 0x04001271 RID: 4721
  public int senpaiHairStyle;

  // Token: 0x04001272 RID: 4722
  public int senpaiSkinColor;
}