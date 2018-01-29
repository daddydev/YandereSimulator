using System;
using UnityEngine;

// Token: 0x020001ED RID: 493
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip> {

  // Token: 0x060008D1 RID: 2257 RVA: 0x0009E1C4 File Offset: 0x0009C5C4
  public AudioClipArrayWrapper(int size) : base(size) {
  }

  // Token: 0x060008D2 RID: 2258 RVA: 0x0009E1CD File Offset: 0x0009C5CD
  public AudioClipArrayWrapper(AudioClip[] elements) : base(elements) {
  }
}