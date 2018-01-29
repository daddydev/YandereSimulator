using UnityEngine;

// Token: 0x02000128 RID: 296
public class LocationScript : MonoBehaviour {

  // Token: 0x060005A8 RID: 1448 RVA: 0x0004E250 File Offset: 0x0004C650
  private void Start() {
    this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
    this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
  }

  // Token: 0x060005A9 RID: 1449 RVA: 0x0004E2FC File Offset: 0x0004C6FC
  private void Update() {
    if (this.Show) {
      this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a + Time.deltaTime * 10f);
      if (this.BG.color.a > 1f) {
        this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 1f);
      }
      this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
    } else {
      this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, this.BG.color.a - Time.deltaTime * 10f);
      if (this.BG.color.a < 0f) {
        this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0f);
      }
      this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, this.BG.color.a);
    }
  }

  // Token: 0x04000D8E RID: 3470
  public UILabel Label;

  // Token: 0x04000D8F RID: 3471
  public UISprite BG;

  // Token: 0x04000D90 RID: 3472
  public bool Show;
}