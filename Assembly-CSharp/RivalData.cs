using System;
using UnityEngine;

// Token: 0x020000A9 RID: 169
[Serializable]
public class RivalData {

  // Token: 0x0600029D RID: 669 RVA: 0x0003445F File Offset: 0x0003285F
  public RivalData(int week) {
    this.week = week;
  }

  // Token: 0x1700004C RID: 76
  // (get) Token: 0x0600029E RID: 670 RVA: 0x0003446E File Offset: 0x0003286E
  public int Week {
    get {
      return this.week;
    }
  }

  // Token: 0x04000894 RID: 2196
  [SerializeField]
  private int week;
}