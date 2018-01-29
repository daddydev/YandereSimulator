using UnityEngine;

// Token: 0x020001D5 RID: 469
public class TapePlayerScript : MonoBehaviour {

  // Token: 0x06000879 RID: 2169 RVA: 0x000997C2 File Offset: 0x00097BC2
  private void Start() {
    this.Tape.SetActive(false);
  }

  // Token: 0x0600087A RID: 2170 RVA: 0x000997D0 File Offset: 0x00097BD0
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.HeartCamera.enabled = false;
      this.Yandere.RPGCamera.enabled = false;
      this.TapePlayerMenu.TimeBar.gameObject.SetActive(true);
      this.TapePlayerMenu.List.gameObject.SetActive(true);
      this.TapePlayerCamera.enabled = true;
      this.TapePlayerMenu.UpdateLabels();
      this.TapePlayerMenu.Show = true;
      this.NoteWindow.SetActive(false);
      this.Yandere.CanMove = false;
      this.Yandere.HUD.alpha = 0f;
      Time.timeScale = 0f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "EXIT";
      this.PromptBar.Label[4].text = "CHOOSE";
      this.PromptBar.Label[5].text = "CATEGORY";
      this.TapePlayerMenu.CheckSelection();
      this.PromptBar.Show = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Spin) {
      Transform transform = this.Rolls[0];
      transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 0.0166666675f * (360f * this.SpinSpeed), transform.localEulerAngles.z);
      Transform transform2 = this.Rolls[1];
      transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, transform2.localEulerAngles.y + 0.0166666675f * (360f * this.SpinSpeed), transform2.localEulerAngles.z);
    }
    if (this.FastForward) {
      this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 6.25f, 1.66666663f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
      this.SpinSpeed = 2f;
    } else {
      this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 0f, 1.66666663f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
      this.SpinSpeed = 1f;
    }
    if (this.Rewind) {
      this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 6.25f, 1.66666663f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
      this.SpinSpeed = -2f;
    } else {
      this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 0f, 1.66666663f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
    }
  }

  // Token: 0x04001911 RID: 6417
  public TapePlayerMenuScript TapePlayerMenu;

  // Token: 0x04001912 RID: 6418
  public PromptBarScript PromptBar;

  // Token: 0x04001913 RID: 6419
  public YandereScript Yandere;

  // Token: 0x04001914 RID: 6420
  public PromptScript Prompt;

  // Token: 0x04001915 RID: 6421
  public Transform RWButton;

  // Token: 0x04001916 RID: 6422
  public Transform FFButton;

  // Token: 0x04001917 RID: 6423
  public Camera TapePlayerCamera;

  // Token: 0x04001918 RID: 6424
  public Transform[] Rolls;

  // Token: 0x04001919 RID: 6425
  public GameObject NoteWindow;

  // Token: 0x0400191A RID: 6426
  public GameObject Tape;

  // Token: 0x0400191B RID: 6427
  public bool FastForward;

  // Token: 0x0400191C RID: 6428
  public bool Rewind;

  // Token: 0x0400191D RID: 6429
  public bool Spin;

  // Token: 0x0400191E RID: 6430
  public float SpinSpeed;
}