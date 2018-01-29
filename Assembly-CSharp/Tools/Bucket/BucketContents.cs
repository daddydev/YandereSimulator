// Token: 0x0200004D RID: 77
public abstract class BucketContents {

  // Token: 0x1700000D RID: 13
  // (get) Token: 0x0600010D RID: 269
  public abstract BucketContentsType Type { get; }

  // Token: 0x1700000E RID: 14
  // (get) Token: 0x0600010E RID: 270
  public abstract bool IsCleaningAgent { get; }

  // Token: 0x1700000F RID: 15
  // (get) Token: 0x0600010F RID: 271
  public abstract bool IsFlammable { get; }

  // Token: 0x06000110 RID: 272
  public abstract bool CanBeLifted(int strength);
}