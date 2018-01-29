using System;

// Token: 0x020001EF RID: 495
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string> {

  // Token: 0x060008D5 RID: 2261 RVA: 0x0009E1E8 File Offset: 0x0009C5E8
  public StringArrayWrapper(int size) : base(size) {
  }

  // Token: 0x060008D6 RID: 2262 RVA: 0x0009E1F1 File Offset: 0x0009C5F1
  public StringArrayWrapper(string[] elements) : base(elements) {
  }
}