using UnityEngine;

// Token: 0x02000106 RID: 262
public class HomeWindowScript : MonoBehaviour {

  // Token: 0x06000520 RID: 1312 RVA: 0x00046D38 File Offset: 0x00045138
  private void Start() {
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
  }

  // Token: 0x06000521 RID: 1313 RVA: 0x00046D94 File Offset: 0x00045194
  private void Update() {
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, (!this.Show) ? 0f : 1f, Time.deltaTime * 10f));
  }

  // Token: 0x04000C21 RID: 3105
  public UISprite Sprite;

  // Token: 0x04000C22 RID: 3106
  public bool Show;
}