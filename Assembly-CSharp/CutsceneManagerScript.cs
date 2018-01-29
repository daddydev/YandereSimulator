using UnityEngine;

// Token: 0x0200007C RID: 124
public class CutsceneManagerScript : MonoBehaviour {

  // Token: 0x060001E9 RID: 489 RVA: 0x00025B94 File Offset: 0x00023F94
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.Phase == 1) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if (this.Darkness.color.a == 1f) {
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      this.Subtitle.text = this.Text[this.Line];
      component.clip = this.Voice[this.Line];
      component.Play();
      this.Phase++;
    } else if (this.Phase == 3) {
      if (!component.isPlaying || Input.GetButtonDown("A")) {
        if (this.Line < 2) {
          this.Phase--;
          this.Line++;
        } else {
          this.Subtitle.text = string.Empty;
          this.Phase++;
        }
      }
    } else if (this.Phase == 4) {
      this.EndOfDay.gameObject.SetActive(true);
      this.EndOfDay.Phase = 11;
      this.Counselor.LecturePhase = 5;
      this.Phase++;
    } else if (this.Phase == 6) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
      if (this.Darkness.color.a == 0f) {
        this.Phase++;
      }
    } else if (this.Phase == 7) {
      if (this.StudentManager.Students[7] != null) {
        UnityEngine.Object.Destroy(this.StudentManager.Students[7].gameObject);
      }
      this.PromptBar.ClearButtons();
      this.PromptBar.Show = false;
      this.Portal.Proceed = true;
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x0400065E RID: 1630
  public StudentManagerScript StudentManager;

  // Token: 0x0400065F RID: 1631
  public CounselorScript Counselor;

  // Token: 0x04000660 RID: 1632
  public PromptBarScript PromptBar;

  // Token: 0x04000661 RID: 1633
  public EndOfDayScript EndOfDay;

  // Token: 0x04000662 RID: 1634
  public PortalScript Portal;

  // Token: 0x04000663 RID: 1635
  public UISprite Darkness;

  // Token: 0x04000664 RID: 1636
  public UILabel Subtitle;

  // Token: 0x04000665 RID: 1637
  public AudioClip[] Voice;

  // Token: 0x04000666 RID: 1638
  public string[] Text;

  // Token: 0x04000667 RID: 1639
  public int Phase = 1;

  // Token: 0x04000668 RID: 1640
  public int Line = 1;
}