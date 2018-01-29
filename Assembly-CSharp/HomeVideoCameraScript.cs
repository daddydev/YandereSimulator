using UnityEngine;

// Token: 0x02000104 RID: 260
public class HomeVideoCameraScript : MonoBehaviour {

  // Token: 0x0600051A RID: 1306 RVA: 0x0004662C File Offset: 0x00044A2C
  private void Update() {
    if (!this.TextSet && !HomeGlobals.Night) {
      this.Prompt.Label[0].text = "     Only Available At Night";
    }
    if (!HomeGlobals.Night) {
      this.Prompt.Circle[0].fillAmount = 1f;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.HomeCamera.Destination = this.HomeCamera.Destinations[11];
      this.HomeCamera.Target = this.HomeCamera.Targets[11];
      this.HomeCamera.ID = 11;
      this.HomePrisonerChan.LookAhead = true;
      this.HomeYandere.CanMove = false;
      this.HomeYandere.gameObject.SetActive(false);
    }
    if (this.HomeCamera.ID == 11 && !this.HomePrisoner.Bantering) {
      this.Timer += Time.deltaTime;
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.Timer > 2f && !this.AudioPlayed) {
        this.Subtitle.text = "...daddy...please...help...I'm scared...I don't wanna die...";
        this.AudioPlayed = true;
        component.Play();
      }
      if (this.Timer > 2f + component.clip.length) {
        this.Subtitle.text = string.Empty;
      }
      if (this.Timer > 3f + component.clip.length) {
        this.HomeDarkness.FadeSlow = true;
        this.HomeDarkness.FadeOut = true;
      }
    }
  }

  // Token: 0x04000C0A RID: 3082
  public HomePrisonerChanScript HomePrisonerChan;

  // Token: 0x04000C0B RID: 3083
  public HomeDarknessScript HomeDarkness;

  // Token: 0x04000C0C RID: 3084
  public HomePrisonerScript HomePrisoner;

  // Token: 0x04000C0D RID: 3085
  public HomeYandereScript HomeYandere;

  // Token: 0x04000C0E RID: 3086
  public HomeCameraScript HomeCamera;

  // Token: 0x04000C0F RID: 3087
  public PromptScript Prompt;

  // Token: 0x04000C10 RID: 3088
  public UILabel Subtitle;

  // Token: 0x04000C11 RID: 3089
  public bool AudioPlayed;

  // Token: 0x04000C12 RID: 3090
  public bool TextSet;

  // Token: 0x04000C13 RID: 3091
  public float Timer;
}