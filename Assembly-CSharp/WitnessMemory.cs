using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
[Serializable]
public class WitnessMemory {

  // Token: 0x060002A3 RID: 675 RVA: 0x000344B4 File Offset: 0x000328B4
  public WitnessMemory() {
    this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
    for (int i = 0; i < this.memories.Length; i++) {
      this.memories[i] = float.PositiveInfinity;
    }
    this.memorySpan = 1800f;
  }

  // Token: 0x060002A4 RID: 676 RVA: 0x00034517 File Offset: 0x00032917
  public bool Remembers(WitnessMemoryType type) {
    return this.memories[(int)type] < this.memorySpan;
  }

  // Token: 0x060002A5 RID: 677 RVA: 0x00034529 File Offset: 0x00032929
  public void Refresh(WitnessMemoryType type) {
    this.memories[(int)type] = 0f;
  }

  // Token: 0x060002A6 RID: 678 RVA: 0x00034538 File Offset: 0x00032938
  public void Tick(float dt) {
    for (int i = 0; i < this.memories.Length; i++) {
      this.memories[i] += dt;
    }
  }

  // Token: 0x040008A1 RID: 2209
  [SerializeField]
  private float[] memories;

  // Token: 0x040008A2 RID: 2210
  [SerializeField]
  private float memorySpan;

  // Token: 0x040008A3 RID: 2211
  private const float LongMemorySpan = 28800f;

  // Token: 0x040008A4 RID: 2212
  private const float MediumMemorySpan = 7200f;

  // Token: 0x040008A5 RID: 2213
  private const float ShortMemorySpan = 1800f;

  // Token: 0x040008A6 RID: 2214
  private const float VeryShortMemorySpan = 120f;
}