using System;

// Token: 0x0200004F RID: 79
[Serializable]
public class BucketGas : BucketContents {

  // Token: 0x17000015 RID: 21
  // (get) Token: 0x0600011B RID: 283 RVA: 0x00012329 File Offset: 0x00010729
  public override BucketContentsType Type {
    get {
      return BucketContentsType.Gas;
    }
  }

  // Token: 0x17000016 RID: 22
  // (get) Token: 0x0600011C RID: 284 RVA: 0x0001232C File Offset: 0x0001072C
  public override bool IsCleaningAgent {
    get {
      return false;
    }
  }

  // Token: 0x17000017 RID: 23
  // (get) Token: 0x0600011D RID: 285 RVA: 0x0001232F File Offset: 0x0001072F
  public override bool IsFlammable {
    get {
      return true;
    }
  }

  // Token: 0x0600011E RID: 286 RVA: 0x00012332 File Offset: 0x00010732
  public override bool CanBeLifted(int strength) {
    return true;
  }
}