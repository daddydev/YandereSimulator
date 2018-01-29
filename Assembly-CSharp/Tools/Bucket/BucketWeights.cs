using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
[Serializable]
public class BucketWeights : BucketContents {

  // Token: 0x17000018 RID: 24
  // (get) Token: 0x06000120 RID: 288 RVA: 0x0001233D File Offset: 0x0001073D
  // (set) Token: 0x06000121 RID: 289 RVA: 0x00012345 File Offset: 0x00010745
  public int Count {
    get {
      return this.count;
    }
    set {
      this.count = ((value >= 0) ? value : 0);
    }
  }

  // Token: 0x17000019 RID: 25
  // (get) Token: 0x06000122 RID: 290 RVA: 0x0001235B File Offset: 0x0001075B
  public override BucketContentsType Type {
    get {
      return BucketContentsType.Weights;
    }
  }

  // Token: 0x1700001A RID: 26
  // (get) Token: 0x06000123 RID: 291 RVA: 0x0001235E File Offset: 0x0001075E
  public override bool IsCleaningAgent {
    get {
      return false;
    }
  }

  // Token: 0x1700001B RID: 27
  // (get) Token: 0x06000124 RID: 292 RVA: 0x00012361 File Offset: 0x00010761
  public override bool IsFlammable {
    get {
      return false;
    }
  }

  // Token: 0x06000125 RID: 293 RVA: 0x00012364 File Offset: 0x00010764
  public override bool CanBeLifted(int strength) {
    return strength > 0;
  }

  // Token: 0x040003A1 RID: 929
  [SerializeField]
  private int count;
}