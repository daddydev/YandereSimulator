using UnityEngine;

// Token: 0x02000057 RID: 87
public class ChallengeIconScript : MonoBehaviour {

  // Token: 0x0600013C RID: 316 RVA: 0x00014BC4 File Offset: 0x00012FC4
  private void Start() {
    if (GameGlobals.LoveSick) {
      this.R = 1f;
      this.G = 0f;
      this.B = 0f;
    } else {
      this.R = 1f;
      this.G = 1f;
      this.B = 1f;
    }
  }

  // Token: 0x0600013D RID: 317 RVA: 0x00014C24 File Offset: 0x00013024
  private void Update() {
    if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f) {
      if (this.Icon != null) {
        this.LargeIcon.mainTexture = this.Icon.mainTexture;
      }
      this.Dark -= Time.deltaTime * 10f;
      if (this.Dark < 0f) {
        this.Dark = 0f;
      }
    } else {
      this.Dark += Time.deltaTime * 10f;
      if (this.Dark > 1f) {
        this.Dark = 1f;
      }
    }
    this.IconFrame.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
    this.NameFrame.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
    this.Name.color = new Color(this.Dark * this.R, this.Dark * this.G, this.Dark * this.B, 1f);
    if (GameGlobals.LoveSick) {
      if (base.transform.position.x > -0.125f && base.transform.position.x < 0.125f) {
        this.IconFrame.color = Color.white;
        this.NameFrame.color = Color.white;
        this.Name.color = Color.white;
      } else {
        this.IconFrame.color = new Color(this.R, this.G, this.B, 1f);
        this.NameFrame.color = new Color(this.R, this.G, this.B, 1f);
        this.Name.color = new Color(this.R, this.G, this.B, 1f);
      }
    }
  }

  // Token: 0x040003E3 RID: 995
  public UITexture LargeIcon;

  // Token: 0x040003E4 RID: 996
  public UISprite IconFrame;

  // Token: 0x040003E5 RID: 997
  public UISprite NameFrame;

  // Token: 0x040003E6 RID: 998
  public UITexture Icon;

  // Token: 0x040003E7 RID: 999
  public UILabel Name;

  // Token: 0x040003E8 RID: 1000
  public float Dark;

  // Token: 0x040003E9 RID: 1001
  private float R;

  // Token: 0x040003EA RID: 1002
  private float G;

  // Token: 0x040003EB RID: 1003
  private float B;
}