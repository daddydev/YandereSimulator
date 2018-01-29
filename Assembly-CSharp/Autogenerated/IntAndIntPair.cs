using System;

// Token: 0x0200020D RID: 525
[Serializable]
public class IntAndIntPair : SerializablePair<int, int> {

  // Token: 0x06000927 RID: 2343 RVA: 0x0009EFD9 File Offset: 0x0009D3D9
  public IntAndIntPair(int first, int second) : base(first, second) {
  }

  // Token: 0x06000928 RID: 2344 RVA: 0x0009EFE3 File Offset: 0x0009D3E3
  public IntAndIntPair() : base(0, 0) {
  }
}