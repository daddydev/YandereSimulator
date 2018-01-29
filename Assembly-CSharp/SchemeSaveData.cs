using System;
using System.Collections.Generic;

// Token: 0x0200019B RID: 411
[Serializable]
public class SchemeSaveData {

  // Token: 0x06000744 RID: 1860 RVA: 0x0006DDC8 File Offset: 0x0006C1C8
  public static SchemeSaveData ReadFromGlobals() {
    SchemeSaveData schemeSaveData = new SchemeSaveData();
    schemeSaveData.currentScheme = SchemeGlobals.CurrentScheme;
    schemeSaveData.darkSecret = SchemeGlobals.DarkSecret;
    foreach (int num in SchemeGlobals.KeysOfSchemePreviousStage()) {
      schemeSaveData.schemePreviousStage.Add(num, SchemeGlobals.GetSchemePreviousStage(num));
    }
    foreach (int num2 in SchemeGlobals.KeysOfSchemeStage()) {
      schemeSaveData.schemeStage.Add(num2, SchemeGlobals.GetSchemeStage(num2));
    }
    foreach (int num3 in SchemeGlobals.KeysOfSchemeStatus()) {
      if (SchemeGlobals.GetSchemeStatus(num3)) {
        schemeSaveData.schemeStatus.Add(num3);
      }
    }
    foreach (int num4 in SchemeGlobals.KeysOfSchemeUnlocked()) {
      if (SchemeGlobals.GetSchemeUnlocked(num4)) {
        schemeSaveData.schemeUnlocked.Add(num4);
      }
    }
    foreach (int num5 in SchemeGlobals.KeysOfServicePurchased()) {
      if (SchemeGlobals.GetServicePurchased(num5)) {
        schemeSaveData.servicePurchased.Add(num5);
      }
    }
    return schemeSaveData;
  }

  // Token: 0x06000745 RID: 1861 RVA: 0x0006DF20 File Offset: 0x0006C320
  public static void WriteToGlobals(SchemeSaveData data) {
    SchemeGlobals.CurrentScheme = data.currentScheme;
    SchemeGlobals.DarkSecret = data.darkSecret;
    foreach (KeyValuePair<int, int> keyValuePair in data.schemePreviousStage) {
      SchemeGlobals.SetSchemePreviousStage(keyValuePair.Key, keyValuePair.Value);
    }
    foreach (KeyValuePair<int, int> keyValuePair2 in data.schemeStage) {
      SchemeGlobals.SetSchemeStage(keyValuePair2.Key, keyValuePair2.Value);
    }
    foreach (int schemeID in data.schemeStatus) {
      SchemeGlobals.SetSchemeStatus(schemeID, true);
    }
    foreach (int schemeID2 in data.schemeUnlocked) {
      SchemeGlobals.SetSchemeUnlocked(schemeID2, true);
    }
    foreach (int serviceID in data.servicePurchased) {
      SchemeGlobals.SetServicePurchased(serviceID, true);
    }
  }

  // Token: 0x0400125D RID: 4701
  public int currentScheme;

  // Token: 0x0400125E RID: 4702
  public bool darkSecret;

  // Token: 0x0400125F RID: 4703
  public IntAndIntDictionary schemePreviousStage = new IntAndIntDictionary();

  // Token: 0x04001260 RID: 4704
  public IntAndIntDictionary schemeStage = new IntAndIntDictionary();

  // Token: 0x04001261 RID: 4705
  public IntHashSet schemeStatus = new IntHashSet();

  // Token: 0x04001262 RID: 4706
  public IntHashSet schemeUnlocked = new IntHashSet();

  // Token: 0x04001263 RID: 4707
  public IntHashSet servicePurchased = new IntHashSet();
}