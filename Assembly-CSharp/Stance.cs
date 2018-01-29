using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
[Serializable]
public class Stance {

  // Token: 0x0600029F RID: 671 RVA: 0x00034476 File Offset: 0x00032876
  public Stance(StanceType initialStance) {
    this.current = initialStance;
    this.previous = initialStance;
  }

  // Token: 0x1700004D RID: 77
  // (get) Token: 0x060002A0 RID: 672 RVA: 0x0003448C File Offset: 0x0003288C
  // (set) Token: 0x060002A1 RID: 673 RVA: 0x00034494 File Offset: 0x00032894
  public StanceType Current {
    get {
      return this.current;
    }
    set {
      this.previous = this.current;
      this.current = value;
    }
  }

  // Token: 0x1700004E RID: 78
  // (get) Token: 0x060002A2 RID: 674 RVA: 0x000344A9 File Offset: 0x000328A9
  public StanceType Previous {
    get {
      return this.previous;
    }
  }

  // Token: 0x04000899 RID: 2201
  [SerializeField]
  private StanceType current;

  // Token: 0x0400089A RID: 2202
  [SerializeField]
  private StanceType previous;
}