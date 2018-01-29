using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000212 RID: 530
public class WarningScript : MonoBehaviour {

  // Token: 0x0600093D RID: 2365 RVA: 0x000A017C File Offset: 0x0009E57C
  private void Start() {
    this.WarningLabel.gameObject.SetActive(false);
    this.Label.text = string.Empty;
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
  }

  // Token: 0x0600093E RID: 2366 RVA: 0x000A01F8 File Offset: 0x0009E5F8
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.FadeOut) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
      if (this.Darkness.color.a == 0f) {
        if (this.Timer == 0f) {
          this.WarningLabel.gameObject.SetActive(true);
          component.Play();
        }
        this.Timer += Time.deltaTime;
        if (this.ID < this.Triggers.Length && this.Timer > this.Triggers[this.ID]) {
          this.Label.text = this.Text[this.ID];
          this.ID++;
        }
      }
    } else {
      component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if (this.Darkness.color.a == 1f) {
        SceneManager.LoadScene("SponsorScene");
      }
    }
    if (Input.anyKey) {
      this.FadeOut = true;
    }
  }

  // Token: 0x04001A5A RID: 6746
  public float[] Triggers;

  // Token: 0x04001A5B RID: 6747
  public string[] Text;

  // Token: 0x04001A5C RID: 6748
  public UILabel WarningLabel;

  // Token: 0x04001A5D RID: 6749
  public UISprite Darkness;

  // Token: 0x04001A5E RID: 6750
  public UILabel Label;

  // Token: 0x04001A5F RID: 6751
  public bool FadeOut;

  // Token: 0x04001A60 RID: 6752
  public float Timer;

  // Token: 0x04001A61 RID: 6753
  public int ID;
}