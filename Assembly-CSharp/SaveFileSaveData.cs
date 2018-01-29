using System;

// Token: 0x0200019A RID: 410
[Serializable]
public class SaveFileSaveData {

  // Token: 0x06000741 RID: 1857 RVA: 0x0006DD5C File Offset: 0x0006C15C
  public static SaveFileSaveData ReadFromGlobals() {
    return new SaveFileSaveData {
      currentSaveFile = SaveFileGlobals.CurrentSaveFile
    };
  }

  // Token: 0x06000742 RID: 1858 RVA: 0x0006DD7B File Offset: 0x0006C17B
  public static void WriteToGlobals(SaveFileSaveData data) {
    SaveFileGlobals.CurrentSaveFile = data.currentSaveFile;
  }

  // Token: 0x0400125C RID: 4700
  public int currentSaveFile;
}