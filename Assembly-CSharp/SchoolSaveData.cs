using System;

// Token: 0x0200019C RID: 412
[Serializable]
public class SchoolSaveData {

  // Token: 0x06000747 RID: 1863 RVA: 0x0006E100 File Offset: 0x0006C500
  public static SchoolSaveData ReadFromGlobals() {
    SchoolSaveData schoolSaveData = new SchoolSaveData();
    foreach (int num in SchoolGlobals.KeysOfDemonActive()) {
      if (SchoolGlobals.GetDemonActive(num)) {
        schoolSaveData.demonActive.Add(num);
      }
    }
    foreach (int num2 in SchoolGlobals.KeysOfGardenGraveOccupied()) {
      if (SchoolGlobals.GetGardenGraveOccupied(num2)) {
        schoolSaveData.gardenGraveOccupied.Add(num2);
      }
    }
    schoolSaveData.kidnapVictim = SchoolGlobals.KidnapVictim;
    schoolSaveData.population = SchoolGlobals.Population;
    schoolSaveData.roofFence = SchoolGlobals.RoofFence;
    schoolSaveData.schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
    schoolSaveData.schoolAtmosphereSet = SchoolGlobals.SchoolAtmosphereSet;
    schoolSaveData.scp = SchoolGlobals.SCP;
    return schoolSaveData;
  }

  // Token: 0x06000748 RID: 1864 RVA: 0x0006E1D0 File Offset: 0x0006C5D0
  public static void WriteToGlobals(SchoolSaveData data) {
    foreach (int demonID in data.demonActive) {
      SchoolGlobals.SetDemonActive(demonID, true);
    }
    foreach (int graveID in data.gardenGraveOccupied) {
      SchoolGlobals.SetGardenGraveOccupied(graveID, true);
    }
    SchoolGlobals.KidnapVictim = data.kidnapVictim;
    SchoolGlobals.Population = data.population;
    SchoolGlobals.RoofFence = data.roofFence;
    SchoolGlobals.SchoolAtmosphere = data.schoolAtmosphere;
    SchoolGlobals.SchoolAtmosphereSet = data.schoolAtmosphereSet;
    SchoolGlobals.SCP = data.scp;
  }

  // Token: 0x04001264 RID: 4708
  public IntHashSet demonActive = new IntHashSet();

  // Token: 0x04001265 RID: 4709
  public IntHashSet gardenGraveOccupied = new IntHashSet();

  // Token: 0x04001266 RID: 4710
  public int kidnapVictim;

  // Token: 0x04001267 RID: 4711
  public int population;

  // Token: 0x04001268 RID: 4712
  public bool roofFence;

  // Token: 0x04001269 RID: 4713
  public float schoolAtmosphere;

  // Token: 0x0400126A RID: 4714
  public bool schoolAtmosphereSet;

  // Token: 0x0400126B RID: 4715
  public bool scp;
}