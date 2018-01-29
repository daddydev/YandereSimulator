using System;

// Token: 0x0200018C RID: 396
[Serializable]
public class ApplicationSaveData {

  // Token: 0x06000717 RID: 1815 RVA: 0x0006C70C File Offset: 0x0006AB0C
  public static ApplicationSaveData ReadFromGlobals() {
    return new ApplicationSaveData {
      versionNumber = ApplicationGlobals.VersionNumber
    };
  }

  // Token: 0x06000718 RID: 1816 RVA: 0x0006C72B File Offset: 0x0006AB2B
  public static void WriteToGlobals(ApplicationSaveData data) {
    ApplicationGlobals.VersionNumber = data.versionNumber;
  }

  // Token: 0x040011FD RID: 4605
  public float versionNumber;
}