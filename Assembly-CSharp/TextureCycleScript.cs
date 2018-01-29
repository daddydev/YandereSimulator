using UnityEngine;

// Token: 0x020001DB RID: 475
public class TextureCycleScript : MonoBehaviour {

  // Token: 0x0600088F RID: 2191 RVA: 0x0009AACF File Offset: 0x00098ECF
  private void Awake() {
  }

  // Token: 0x170000EF RID: 239
  // (get) Token: 0x06000890 RID: 2192 RVA: 0x0009AAD1 File Offset: 0x00098ED1
  private float SecondsPerFrame {
    get {
      return 1f / this.FramesPerSecond;
    }
  }

  // Token: 0x06000891 RID: 2193 RVA: 0x0009AAE0 File Offset: 0x00098EE0
  private void Update() {
    this.ID++;
    if (this.ID > 1) {
      this.ID = 0;
      this.Frame++;
      if (this.Frame > this.Limit) {
        this.Frame = this.Start;
      }
    }
    this.Sprite.mainTexture = this.Textures[this.Frame];
  }

  // Token: 0x0400194C RID: 6476
  public UITexture Sprite;

  // Token: 0x0400194D RID: 6477
  [SerializeField]
  private int Start;

  // Token: 0x0400194E RID: 6478
  [SerializeField]
  private int Frame;

  // Token: 0x0400194F RID: 6479
  [SerializeField]
  private int Limit;

  // Token: 0x04001950 RID: 6480
  [SerializeField]
  private float FramesPerSecond;

  // Token: 0x04001951 RID: 6481
  [SerializeField]
  private float CurrentSeconds;

  // Token: 0x04001952 RID: 6482
  [SerializeField]
  private Texture[] Textures;

  // Token: 0x04001953 RID: 6483
  public int ID;
}