using UnityEngine;

// Token: 0x0200005C RID: 92
public class CautionScript : MonoBehaviour {

  // Token: 0x0600014D RID: 333 RVA: 0x00015BD8 File Offset: 0x00013FD8
  private void Start() {
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
  }

  // Token: 0x0600014E RID: 334 RVA: 0x00015C34 File Offset: 0x00014034
  private void Update() {
    if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.3333321f || this.Yandere.NearBodies > 0) {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime);
      if (this.Sprite.color.a > 1f) {
        this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
      }
    } else {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
      if (this.Sprite.color.a < 0f) {
        this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
      }
    }
  }

  // Token: 0x0400040E RID: 1038
  public YandereScript Yandere;

  // Token: 0x0400040F RID: 1039
  public UISprite Sprite;
}