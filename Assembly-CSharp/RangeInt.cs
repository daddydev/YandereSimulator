using System;
using UnityEngine;

// Token: 0x020001F7 RID: 503
[Serializable]
public class RangeInt {

  // Token: 0x060008FF RID: 2303 RVA: 0x0009EA40 File Offset: 0x0009CE40
  public RangeInt(int value, int min, int max) {
    this.value = value;
    this.min = min;
    this.max = max;
  }

  // Token: 0x06000900 RID: 2304 RVA: 0x0009EA5D File Offset: 0x0009CE5D
  public RangeInt(int min, int max) : this(min, min, max) {
  }

  // Token: 0x17000100 RID: 256
  // (get) Token: 0x06000901 RID: 2305 RVA: 0x0009EA68 File Offset: 0x0009CE68
  // (set) Token: 0x06000902 RID: 2306 RVA: 0x0009EA70 File Offset: 0x0009CE70
  public int Value {
    get {
      return this.value;
    }
    set {
      this.value = value;
    }
  }

  // Token: 0x17000101 RID: 257
  // (get) Token: 0x06000903 RID: 2307 RVA: 0x0009EA79 File Offset: 0x0009CE79
  public int Min {
    get {
      return this.min;
    }
  }

  // Token: 0x17000102 RID: 258
  // (get) Token: 0x06000904 RID: 2308 RVA: 0x0009EA81 File Offset: 0x0009CE81
  public int Max {
    get {
      return this.max;
    }
  }

  // Token: 0x17000103 RID: 259
  // (get) Token: 0x06000905 RID: 2309 RVA: 0x0009EA89 File Offset: 0x0009CE89
  public int Next {
    get {
      return (this.value != this.max) ? (this.value + 1) : this.min;
    }
  }

  // Token: 0x17000104 RID: 260
  // (get) Token: 0x06000906 RID: 2310 RVA: 0x0009EAAF File Offset: 0x0009CEAF
  public int Previous {
    get {
      return (this.value != this.min) ? (this.value - 1) : this.max;
    }
  }

  // Token: 0x04001A12 RID: 6674
  [SerializeField]
  private int value;

  // Token: 0x04001A13 RID: 6675
  [SerializeField]
  private int min;

  // Token: 0x04001A14 RID: 6676
  [SerializeField]
  private int max;
}