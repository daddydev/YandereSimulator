﻿using System;
using System.Collections.Generic;

// Token: 0x02000192 RID: 402
[Serializable]
public class DatingSaveData {

  // Token: 0x06000729 RID: 1833 RVA: 0x0006CFCC File Offset: 0x0006B3CC
  public static DatingSaveData ReadFromGlobals() {
    DatingSaveData datingSaveData = new DatingSaveData();
    datingSaveData.affection = DatingGlobals.Affection;
    datingSaveData.affectionLevel = DatingGlobals.AffectionLevel;
    foreach (int num in DatingGlobals.KeysOfComplimentGiven()) {
      if (DatingGlobals.GetComplimentGiven(num)) {
        datingSaveData.complimentGiven.Add(num);
      }
    }
    foreach (int num2 in DatingGlobals.KeysOfSuitorCheck()) {
      if (DatingGlobals.GetSuitorCheck(num2)) {
        datingSaveData.suitorCheck.Add(num2);
      }
    }
    datingSaveData.suitorProgress = DatingGlobals.SuitorProgress;
    foreach (int num3 in DatingGlobals.KeysOfSuitorTrait()) {
      datingSaveData.suitorTrait.Add(num3, DatingGlobals.GetSuitorTrait(num3));
    }
    foreach (int num4 in DatingGlobals.KeysOfTopicDiscussed()) {
      if (DatingGlobals.GetTopicDiscussed(num4)) {
        datingSaveData.topicDiscussed.Add(num4);
      }
    }
    foreach (int num5 in DatingGlobals.KeysOfTraitDemonstrated()) {
      datingSaveData.traitDemonstrated.Add(num5, DatingGlobals.GetTraitDemonstrated(num5));
    }
    return datingSaveData;
  }

  // Token: 0x0600072A RID: 1834 RVA: 0x0006D130 File Offset: 0x0006B530
  public static void WriteToGlobals(DatingSaveData data) {
    DatingGlobals.Affection = data.affection;
    DatingGlobals.AffectionLevel = data.affectionLevel;
    foreach (int complimentID in data.complimentGiven) {
      DatingGlobals.SetComplimentGiven(complimentID, true);
    }
    foreach (int checkID in data.suitorCheck) {
      DatingGlobals.SetSuitorCheck(checkID, true);
    }
    DatingGlobals.SuitorProgress = data.suitorProgress;
    foreach (KeyValuePair<int, int> keyValuePair in data.suitorTrait) {
      DatingGlobals.SetSuitorTrait(keyValuePair.Key, keyValuePair.Value);
    }
    foreach (int topicID in data.topicDiscussed) {
      DatingGlobals.SetTopicDiscussed(topicID, true);
    }
    foreach (KeyValuePair<int, int> keyValuePair2 in data.traitDemonstrated) {
      DatingGlobals.SetTraitDemonstrated(keyValuePair2.Key, keyValuePair2.Value);
    }
  }

  // Token: 0x0400121A RID: 4634
  public float affection;

  // Token: 0x0400121B RID: 4635
  public float affectionLevel;

  // Token: 0x0400121C RID: 4636
  public IntHashSet complimentGiven = new IntHashSet();

  // Token: 0x0400121D RID: 4637
  public IntHashSet suitorCheck = new IntHashSet();

  // Token: 0x0400121E RID: 4638
  public int suitorProgress;

  // Token: 0x0400121F RID: 4639
  public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();

  // Token: 0x04001220 RID: 4640
  public IntHashSet topicDiscussed = new IntHashSet();

  // Token: 0x04001221 RID: 4641
  public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();
}