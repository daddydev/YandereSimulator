using UnityEngine;

// Token: 0x0200002E RID: 46
public class AnimatedGifScript : MonoBehaviour {

  // Token: 0x060000A9 RID: 169 RVA: 0x0000C0B4 File Offset: 0x0000A4B4
  private void Awake() {
  }

  // Token: 0x1700000C RID: 12
  // (get) Token: 0x060000AA RID: 170 RVA: 0x0000C0B6 File Offset: 0x0000A4B6
  private float SecondsPerFrame {
    get {
      return 1f / this.FramesPerSecond;
    }
  }

  // Token: 0x060000AB RID: 171 RVA: 0x0000C0C4 File Offset: 0x0000A4C4
  private void Update() {
    this.CurrentSeconds += Time.unscaledDeltaTime;
    while (this.CurrentSeconds >= this.SecondsPerFrame) {
      this.CurrentSeconds -= this.SecondsPerFrame;
      this.Frame++;
      if (this.Frame > this.Limit) {
        this.Frame = this.Start;
      }
    }
    this.Sprite.spriteName = this.SpriteName + this.Frame.ToString();
  }

  // Token: 0x04000295 RID: 661
  [SerializeField]
  private UISprite Sprite;

  // Token: 0x04000296 RID: 662
  [SerializeField]
  private string SpriteName;

  // Token: 0x04000297 RID: 663
  [SerializeField]
  private int Start;

  // Token: 0x04000298 RID: 664
  [SerializeField]
  private int Frame;

  // Token: 0x04000299 RID: 665
  [SerializeField]
  private int Limit;

  // Token: 0x0400029A RID: 666
  [SerializeField]
  private float FramesPerSecond;

  // Token: 0x0400029B RID: 667
  [SerializeField]
  private float CurrentSeconds;
}