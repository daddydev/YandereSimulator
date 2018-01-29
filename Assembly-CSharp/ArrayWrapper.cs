using System.Collections;
using UnityEngine;

// Token: 0x020001EC RID: 492
public class ArrayWrapper<T> : IEnumerable {

  // Token: 0x060008CA RID: 2250 RVA: 0x0009E165 File Offset: 0x0009C565
  public ArrayWrapper(int size) {
    this.elements = new T[size];
  }

  // Token: 0x060008CB RID: 2251 RVA: 0x0009E179 File Offset: 0x0009C579
  public ArrayWrapper(T[] elements) {
    this.elements = elements;
  }

  // Token: 0x170000F0 RID: 240
  public T this[int i] {
    get {
      return this.elements[i];
    }
    set {
      this.elements[i] = value;
    }
  }

  // Token: 0x170000F1 RID: 241
  // (get) Token: 0x060008CE RID: 2254 RVA: 0x0009E1A5 File Offset: 0x0009C5A5
  public int Length {
    get {
      return this.elements.Length;
    }
  }

  // Token: 0x060008CF RID: 2255 RVA: 0x0009E1AF File Offset: 0x0009C5AF
  public T[] Get() {
    return this.elements;
  }

  // Token: 0x060008D0 RID: 2256 RVA: 0x0009E1B7 File Offset: 0x0009C5B7
  public IEnumerator GetEnumerator() {
    return this.elements.GetEnumerator();
  }

  // Token: 0x040019FB RID: 6651
  [SerializeField]
  private T[] elements;
}