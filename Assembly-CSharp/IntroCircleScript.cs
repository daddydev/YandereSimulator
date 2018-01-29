using UnityEngine;

// Token: 0x02000111 RID: 273
public class IntroCircleScript : MonoBehaviour {

  // Token: 0x0600053F RID: 1343 RVA: 0x0004966C File Offset: 0x00047A6C
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.ID < this.StartTime.Length && this.Timer > this.StartTime[this.ID]) {
      this.CurrentTime = this.Duration[this.ID];
      this.LastTime = this.Duration[this.ID];
      this.Label.text = this.Text[this.ID];
      this.ID++;
    }
    if (this.CurrentTime > 0f) {
      this.CurrentTime -= Time.deltaTime;
    }
    if (this.Timer > 1f) {
      this.Sprite.fillAmount = this.CurrentTime / this.LastTime;
      if (this.Sprite.fillAmount == 0f) {
        this.Label.text = string.Empty;
      }
    }
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.CurrentTime -= 5f;
      this.Timer += 5f;
    }
  }

  // Token: 0x04000C9A RID: 3226
  public UISprite Sprite;

  // Token: 0x04000C9B RID: 3227
  public UILabel Label;

  // Token: 0x04000C9C RID: 3228
  public float[] StartTime;

  // Token: 0x04000C9D RID: 3229
  public float[] Duration;

  // Token: 0x04000C9E RID: 3230
  public string[] Text;

  // Token: 0x04000C9F RID: 3231
  public float CurrentTime;

  // Token: 0x04000CA0 RID: 3232
  public float LastTime;

  // Token: 0x04000CA1 RID: 3233
  public float Timer;

  // Token: 0x04000CA2 RID: 3234
  public int ID;
}