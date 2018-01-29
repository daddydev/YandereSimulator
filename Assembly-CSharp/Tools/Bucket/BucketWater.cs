using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[Serializable]
public class BucketWater : BucketContents {

  // Token: 0x17000010 RID: 16
  // (get) Token: 0x06000112 RID: 274 RVA: 0x000122E9 File Offset: 0x000106E9
  // (set) Token: 0x06000113 RID: 275 RVA: 0x000122F1 File Offset: 0x000106F1
  public float Bloodiness {
    get {
      return this.bloodiness;
    }
    set {
      this.bloodiness = Mathf.Clamp01(value);
    }
  }

  // Token: 0x17000011 RID: 17
  // (get) Token: 0x06000114 RID: 276 RVA: 0x000122FF File Offset: 0x000106FF
  // (set) Token: 0x06000115 RID: 277 RVA: 0x00012307 File Offset: 0x00010707
  public bool HasBleach {
    get {
      return this.hasBleach;
    }
    set {
      this.hasBleach = value;
    }
  }

  // Token: 0x17000012 RID: 18
  // (get) Token: 0x06000116 RID: 278 RVA: 0x00012310 File Offset: 0x00010710
  public override BucketContentsType Type {
    get {
      return BucketContentsType.Water;
    }
  }

  // Token: 0x17000013 RID: 19
  // (get) Token: 0x06000117 RID: 279 RVA: 0x00012313 File Offset: 0x00010713
  public override bool IsCleaningAgent {
    get {
      return this.hasBleach;
    }
  }

  // Token: 0x17000014 RID: 20
  // (get) Token: 0x06000118 RID: 280 RVA: 0x0001231B File Offset: 0x0001071B
  public override bool IsFlammable {
    get {
      return false;
    }
  }

  // Token: 0x06000119 RID: 281 RVA: 0x0001231E File Offset: 0x0001071E
  public override bool CanBeLifted(int strength) {
    return true;
  }

  // Token: 0x0400039F RID: 927
  [SerializeField]
  private float bloodiness;

  // Token: 0x040003A0 RID: 928
  [SerializeField]
  private bool hasBleach;
}