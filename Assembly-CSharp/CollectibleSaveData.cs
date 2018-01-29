using System;

// Token: 0x0200018F RID: 399
[Serializable]
public class CollectibleSaveData {

  // Token: 0x06000720 RID: 1824 RVA: 0x0006CAF0 File Offset: 0x0006AEF0
  public static CollectibleSaveData ReadFromGlobals() {
    CollectibleSaveData collectibleSaveData = new CollectibleSaveData();
    foreach (int num in CollectibleGlobals.KeysOfBasementTapeCollected()) {
      if (CollectibleGlobals.GetBasementTapeCollected(num)) {
        collectibleSaveData.basementTapeCollected.Add(num);
      }
    }
    foreach (int num2 in CollectibleGlobals.KeysOfBasementTapeListened()) {
      if (CollectibleGlobals.GetBasementTapeListened(num2)) {
        collectibleSaveData.basementTapeListened.Add(num2);
      }
    }
    foreach (int num3 in CollectibleGlobals.KeysOfMangaCollected()) {
      if (CollectibleGlobals.GetMangaCollected(num3)) {
        collectibleSaveData.mangaCollected.Add(num3);
      }
    }
    foreach (int num4 in CollectibleGlobals.KeysOfTapeCollected()) {
      if (CollectibleGlobals.GetTapeCollected(num4)) {
        collectibleSaveData.tapeCollected.Add(num4);
      }
    }
    foreach (int num5 in CollectibleGlobals.KeysOfTapeListened()) {
      if (CollectibleGlobals.GetTapeListened(num5)) {
        collectibleSaveData.tapeListened.Add(num5);
      }
    }
    return collectibleSaveData;
  }

  // Token: 0x06000721 RID: 1825 RVA: 0x0006CC40 File Offset: 0x0006B040
  public static void WriteToGlobals(CollectibleSaveData data) {
    foreach (int tapeID in data.basementTapeCollected) {
      CollectibleGlobals.SetBasementTapeCollected(tapeID, true);
    }
    foreach (int tapeID2 in data.basementTapeListened) {
      CollectibleGlobals.SetBasementTapeListened(tapeID2, true);
    }
    foreach (int mangaID in data.mangaCollected) {
      CollectibleGlobals.SetMangaCollected(mangaID, true);
    }
    foreach (int tapeID3 in data.tapeCollected) {
      CollectibleGlobals.SetTapeCollected(tapeID3, true);
    }
    foreach (int tapeID4 in data.tapeListened) {
      CollectibleGlobals.SetTapeListened(tapeID4, true);
    }
  }

  // Token: 0x04001211 RID: 4625
  public IntHashSet basementTapeCollected = new IntHashSet();

  // Token: 0x04001212 RID: 4626
  public IntHashSet basementTapeListened = new IntHashSet();

  // Token: 0x04001213 RID: 4627
  public IntHashSet mangaCollected = new IntHashSet();

  // Token: 0x04001214 RID: 4628
  public IntHashSet tapeCollected = new IntHashSet();

  // Token: 0x04001215 RID: 4629
  public IntHashSet tapeListened = new IntHashSet();
}