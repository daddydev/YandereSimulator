using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
[Serializable]
public class Timer {

  // Token: 0x06000929 RID: 2345 RVA: 0x0009EFED File Offset: 0x0009D3ED
  public Timer(float targetSeconds) {
    this.currentSeconds = 0f;
    this.targetSeconds = targetSeconds;
  }

  // Token: 0x17000105 RID: 261
  // (get) Token: 0x0600092A RID: 2346 RVA: 0x0009F007 File Offset: 0x0009D407
  public float CurrentSeconds {
    get {
      return this.currentSeconds;
    }
  }

  // Token: 0x17000106 RID: 262
  // (get) Token: 0x0600092B RID: 2347 RVA: 0x0009F00F File Offset: 0x0009D40F
  public float TargetSeconds {
    get {
      return this.targetSeconds;
    }
  }

  // Token: 0x17000107 RID: 263
  // (get) Token: 0x0600092C RID: 2348 RVA: 0x0009F017 File Offset: 0x0009D417
  public bool IsDone {
    get {
      return this.currentSeconds >= this.targetSeconds;
    }
  }

  // Token: 0x17000108 RID: 264
  // (get) Token: 0x0600092D RID: 2349 RVA: 0x0009F02A File Offset: 0x0009D42A
  public float Progress {
    get {
      return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
    }
  }

  // Token: 0x0600092E RID: 2350 RVA: 0x0009F03E File Offset: 0x0009D43E
  public void Reset() {
    this.currentSeconds = 0f;
  }

  // Token: 0x0600092F RID: 2351 RVA: 0x0009F04B File Offset: 0x0009D44B
  public void SubtractTarget() {
    this.currentSeconds -= this.targetSeconds;
  }

  // Token: 0x06000930 RID: 2352 RVA: 0x0009F060 File Offset: 0x0009D460
  public void Tick(float dt) {
    this.currentSeconds += dt;
  }

  // Token: 0x04001A1E RID: 6686
  [SerializeField]
  private float currentSeconds;

  // Token: 0x04001A1F RID: 6687
  [SerializeField]
  private float targetSeconds;
}