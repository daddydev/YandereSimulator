using UnityEngine;

// Token: 0x0200014F RID: 335
public class PeekScript : MonoBehaviour {

  // Token: 0x0600062B RID: 1579 RVA: 0x00058358 File Offset: 0x00056758
  private void Update() {
    if (this.InfoChanWindow.Drop) {
      this.Prompt.Circle[0].fillAmount = 1f;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Yandere.CanMove = false;
      this.PeekCamera.SetActive(true);
      this.Jukebox.Dip = 0.5f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "Stop";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
    }
    if (this.PeekCamera.activeInHierarchy) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 5f && !this.Spoke) {
        this.Subtitle.UpdateLabel(SubtitleType.InfoNotice, 0, 6.5f);
        this.Spoke = true;
        base.GetComponent<AudioSource>().Play();
      }
      if (Input.GetButtonDown("B")) {
        this.Prompt.Yandere.CanMove = true;
        this.PeekCamera.SetActive(false);
        this.Jukebox.Dip = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Timer = 0f;
      }
    }
  }

  // Token: 0x04000EEB RID: 3819
  public InfoChanWindowScript InfoChanWindow;

  // Token: 0x04000EEC RID: 3820
  public PromptBarScript PromptBar;

  // Token: 0x04000EED RID: 3821
  public SubtitleScript Subtitle;

  // Token: 0x04000EEE RID: 3822
  public JukeboxScript Jukebox;

  // Token: 0x04000EEF RID: 3823
  public PromptScript Prompt;

  // Token: 0x04000EF0 RID: 3824
  public GameObject PeekCamera;

  // Token: 0x04000EF1 RID: 3825
  public bool Spoke;

  // Token: 0x04000EF2 RID: 3826
  public float Timer;
}