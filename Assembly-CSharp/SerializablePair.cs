// Token: 0x0200020C RID: 524
public class SerializablePair<T, U> {

  // Token: 0x06000925 RID: 2341 RVA: 0x0009EF9C File Offset: 0x0009D39C
  public SerializablePair(T first, U second) {
    this.first = first;
    this.second = second;
  }

  // Token: 0x06000926 RID: 2342 RVA: 0x0009EFB4 File Offset: 0x0009D3B4
  public SerializablePair() : this(default(T), default(U)) {
  }

  // Token: 0x04001A1C RID: 6684
  public T first;

  // Token: 0x04001A1D RID: 6685
  public U second;
}