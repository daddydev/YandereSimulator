using UnityEngine;

// Token: 0x0200013F RID: 319
public class NoteWindowScript : MonoBehaviour {

  // Token: 0x060005F6 RID: 1526 RVA: 0x00053C8C File Offset: 0x0005208C
  private void Start() {
    this.SubMenu.transform.localScale = Vector3.zero;
    base.transform.localPosition = new Vector3(455f, -965f, 0f);
    base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
    this.OriginalText[1] = this.SlotLabels[1].text;
    this.OriginalText[2] = this.SlotLabels[2].text;
    this.OriginalText[3] = this.SlotLabels[3].text;
    this.UpdateHighlights();
    this.UpdateSubLabels();
  }

  // Token: 0x060005F7 RID: 1527 RVA: 0x00053D38 File Offset: 0x00052138
  private void Update() {
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show) {
      if (this.Rotation > -90f) {
        base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(455f, -965f, 0f), t);
        this.Rotation = Mathf.Lerp(this.Rotation, -91f, t);
        base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
      } else {
        base.gameObject.SetActive(false);
      }
    } else {
      base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, Vector3.zero, t);
      this.Rotation = Mathf.Lerp(this.Rotation, 0f, t);
      base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
      if (!this.Selecting) {
        if (this.SubMenu.transform.localScale.x > 0.1f) {
          this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, Vector3.zero, t);
        } else {
          this.SubMenu.transform.localScale = Vector3.zero;
        }
        if (this.InputManager.TappedDown) {
          this.Slot++;
          if (this.Slot > 3) {
            this.Slot = 1;
          }
          this.UpdateHighlights();
        }
        if (this.InputManager.TappedUp) {
          this.Slot--;
          if (this.Slot < 1) {
            this.Slot = 3;
          }
          this.UpdateHighlights();
        }
        if (Input.GetButtonDown("A")) {
          this.PromptBar.Label[2].text = string.Empty;
          this.PromptBar.UpdateButtons();
          this.Selecting = true;
          this.UpdateSubLabels();
        }
        if (Input.GetButtonDown("B")) {
          this.Slot = 1;
          this.UpdateHighlights();
          this.SlotLabels[1].text = this.OriginalText[1];
          this.SlotLabels[2].text = this.OriginalText[2];
          this.SlotLabels[3].text = this.OriginalText[3];
          this.SlotsFilled[1] = false;
          this.SlotsFilled[2] = false;
          this.SlotsFilled[3] = false;
          this.Exit();
        }
        if (Input.GetButtonDown("X") && this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3]) {
          this.NoteLocker.MeetID = this.MeetID;
          this.NoteLocker.MeetTime = this.TimeID;
          this.NoteLocker.Prompt.enabled = false;
          this.NoteLocker.CanLeaveNote = false;
          this.NoteLocker.NoteLeft = true;
          if (this.SlotLabels[1].text == this.Subjects[10]) {
            this.NoteLocker.Success = true;
          }
          this.Exit();
        }
      } else {
        this.SubMenu.transform.localScale = Vector3.Lerp(this.SubMenu.transform.localScale, new Vector3(1f, 1f, 1f), t);
        if (this.InputManager.TappedDown) {
          this.SubSlot++;
          if (this.SubSlot > 10) {
            this.SubSlot = 1;
          }
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 550f - 100f * (float)this.SubSlot, this.SubHighlight.localPosition.z);
        }
        if (this.InputManager.TappedUp) {
          this.SubSlot--;
          if (this.SubSlot < 1) {
            this.SubSlot = 10;
          }
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 550f - 100f * (float)this.SubSlot, this.SubHighlight.localPosition.z);
        }
        if (Input.GetButtonDown("A") && this.SubLabels[this.SubSlot].color.a > 0.5f && this.SubLabels[this.SubSlot].text != string.Empty && this.SubLabels[this.SubSlot].text != "??????????") {
          this.SlotLabels[this.Slot].text = this.SubLabels[this.SubSlot].text;
          this.SlotsFilled[this.Slot] = true;
          if (this.Slot == 2) {
            this.MeetID = this.SubSlot;
          }
          if (this.Slot == 3) {
            this.TimeID = this.Hours[this.SubSlot];
          }
          this.CheckForCompletion();
          this.Selecting = false;
          this.SubSlot = 1;
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
        }
        if (Input.GetButtonDown("B")) {
          this.CheckForCompletion();
          this.Selecting = false;
          this.SubSlot = 1;
          this.SubHighlight.localPosition = new Vector3(this.SubHighlight.localPosition.x, 450f, this.SubHighlight.localPosition.z);
        }
      }
      UISprite uisprite = this.SlotHighlights[this.Slot];
      if (!this.Fade) {
        uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, uisprite.color.a + 0.0166666675f);
        if (uisprite.color.a >= 0.5f) {
          this.Fade = true;
        }
      } else {
        uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, uisprite.color.a - 0.0166666675f);
        if (uisprite.color.a <= 0f) {
          this.Fade = false;
        }
      }
    }
  }

  // Token: 0x060005F8 RID: 1528 RVA: 0x00054498 File Offset: 0x00052898
  private void UpdateHighlights() {
    for (int i = 1; i < this.SlotHighlights.Length; i++) {
      UISprite uisprite = this.SlotHighlights[i];
      uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
    }
  }

  // Token: 0x060005F9 RID: 1529 RVA: 0x00054504 File Offset: 0x00052904
  private void UpdateSubLabels() {
    if (this.Slot == 1) {
      this.ID = 1;
      while (this.ID < this.SubLabels.Length) {
        UILabel uilabel = this.SubLabels[this.ID];
        uilabel.text = this.Subjects[this.ID];
        uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
        this.ID++;
      }
      if (!EventGlobals.Event1) {
        this.SubLabels[10].text = "??????????";
      }
    } else if (this.Slot == 2) {
      this.ID = 1;
      while (this.ID < this.SubLabels.Length) {
        UILabel uilabel2 = this.SubLabels[this.ID];
        uilabel2.text = this.Locations[this.ID];
        uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 1f);
        this.ID++;
      }
    } else if (this.Slot == 3) {
      this.ID = 1;
      while (this.ID < this.SubLabels.Length) {
        UILabel uilabel3 = this.SubLabels[this.ID];
        uilabel3.text = this.Times[this.ID];
        uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 1f);
        this.ID++;
      }
      this.DisableOptions();
    }
  }

  // Token: 0x060005FA RID: 1530 RVA: 0x0005470C File Offset: 0x00052B0C
  private void CheckForCompletion() {
    if (this.SlotsFilled[1] && this.SlotsFilled[2] && this.SlotsFilled[3]) {
      this.PromptBar.Label[2].text = "Finish";
      this.PromptBar.UpdateButtons();
    }
  }

  // Token: 0x060005FB RID: 1531 RVA: 0x00054764 File Offset: 0x00052B64
  private void Exit() {
    this.Yandere.Blur.enabled = false;
    this.Yandere.CanMove = true;
    this.Show = false;
    this.Yandere.HUD.alpha = 1f;
    Time.timeScale = 1f;
    this.PromptBar.Label[0].text = string.Empty;
    this.PromptBar.Label[1].text = string.Empty;
    this.PromptBar.Label[2].text = string.Empty;
    this.PromptBar.Label[4].text = string.Empty;
    this.PromptBar.Show = false;
    this.PromptBar.UpdateButtons();
  }

  // Token: 0x060005FC RID: 1532 RVA: 0x00054828 File Offset: 0x00052C28
  private void DisableOptions() {
    if (this.Clock.HourTime >= 7.25f) {
      UILabel uilabel = this.SubLabels[1];
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 7.5f) {
      UILabel uilabel2 = this.SubLabels[2];
      uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 7.75f) {
      UILabel uilabel3 = this.SubLabels[3];
      uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 8f) {
      UILabel uilabel4 = this.SubLabels[4];
      uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 8.25f) {
      UILabel uilabel5 = this.SubLabels[5];
      uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 15.5f) {
      UILabel uilabel6 = this.SubLabels[6];
      uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 16f) {
      UILabel uilabel7 = this.SubLabels[7];
      uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 16.5f) {
      UILabel uilabel8 = this.SubLabels[8];
      uilabel8.color = new Color(uilabel8.color.r, uilabel8.color.g, uilabel8.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 17f) {
      UILabel uilabel9 = this.SubLabels[9];
      uilabel9.color = new Color(uilabel9.color.r, uilabel9.color.g, uilabel9.color.b, 0.5f);
    }
    if (this.Clock.HourTime >= 17.5f) {
      UILabel uilabel10 = this.SubLabels[10];
      uilabel10.color = new Color(uilabel10.color.r, uilabel10.color.g, uilabel10.color.b, 0.5f);
    }
  }

  // Token: 0x04000E40 RID: 3648
  public InputManagerScript InputManager;

  // Token: 0x04000E41 RID: 3649
  public NoteLockerScript NoteLocker;

  // Token: 0x04000E42 RID: 3650
  public PromptBarScript PromptBar;

  // Token: 0x04000E43 RID: 3651
  public YandereScript Yandere;

  // Token: 0x04000E44 RID: 3652
  public ClockScript Clock;

  // Token: 0x04000E45 RID: 3653
  public Transform SubHighlight;

  // Token: 0x04000E46 RID: 3654
  public Transform SubMenu;

  // Token: 0x04000E47 RID: 3655
  public UISprite[] SlotHighlights;

  // Token: 0x04000E48 RID: 3656
  public UILabel[] SlotLabels;

  // Token: 0x04000E49 RID: 3657
  public UILabel[] SubLabels;

  // Token: 0x04000E4A RID: 3658
  public string[] OriginalText;

  // Token: 0x04000E4B RID: 3659
  public string[] Subjects;

  // Token: 0x04000E4C RID: 3660
  public string[] Locations;

  // Token: 0x04000E4D RID: 3661
  public string[] Times;

  // Token: 0x04000E4E RID: 3662
  public float[] Hours;

  // Token: 0x04000E4F RID: 3663
  public bool[] SlotsFilled;

  // Token: 0x04000E50 RID: 3664
  public int SubSlot;

  // Token: 0x04000E51 RID: 3665
  public int MeetID;

  // Token: 0x04000E52 RID: 3666
  public int Slot = 1;

  // Token: 0x04000E53 RID: 3667
  public float Rotation;

  // Token: 0x04000E54 RID: 3668
  public float TimeID;

  // Token: 0x04000E55 RID: 3669
  public int ID;

  // Token: 0x04000E56 RID: 3670
  public bool Selecting;

  // Token: 0x04000E57 RID: 3671
  public bool Fade;

  // Token: 0x04000E58 RID: 3672
  public bool Show;
}