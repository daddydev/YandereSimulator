using UnityEngine;

// Token: 0x020001C5 RID: 453
public class StruggleBarScript : MonoBehaviour {

  // Token: 0x060007D9 RID: 2009 RVA: 0x000788F2 File Offset: 0x00076CF2
  private void Start() {
    base.transform.localScale = Vector3.zero;
    this.ChooseButton();
  }

  // Token: 0x060007DA RID: 2010 RVA: 0x0007890C File Offset: 0x00076D0C
  private void Update() {
    if (this.Struggling) {
      this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Spikes.localEulerAngles = new Vector3(this.Spikes.localEulerAngles.x, this.Spikes.localEulerAngles.y, this.Spikes.localEulerAngles.z - Time.deltaTime * 360f);
      this.Victory -= Time.deltaTime * 20f * this.Strength * this.Intensity;
      if (ClubGlobals.Club == ClubType.MartialArts) {
        this.Victory = 100f;
      }
      if (Input.GetButtonDown(this.CurrentButton)) {
        if (this.Invincible) {
          this.Victory += 100f;
        }
        this.Victory += Time.deltaTime * (500f + (float)(ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus) * 150f) * this.Intensity;
      }
      if (this.Victory >= 100f) {
        this.Victory = 100f;
      }
      if (this.Victory <= -100f) {
        this.Victory = -100f;
      }
      UISprite uisprite = this.ButtonPrompts[this.ButtonID];
      uisprite.transform.localPosition = new Vector3(Mathf.Lerp(uisprite.transform.localPosition.x, this.Victory * 6.5f, Time.deltaTime * 10f), uisprite.transform.localPosition.y, uisprite.transform.localPosition.z);
      this.Spikes.localPosition = new Vector3(uisprite.transform.localPosition.x, this.Spikes.localPosition.y, this.Spikes.localPosition.z);
      if (this.Victory == 100f) {
        this.Yandere.Won = true;
        this.Student.Lost = true;
        this.Struggling = false;
        this.Victory = 0f;
      } else if (this.Victory == -100f) {
        if (!this.Invincible) {
          this.HeroWins();
        }
      } else {
        this.ButtonTimer += Time.deltaTime;
        if (this.ButtonTimer >= 1f) {
          this.ChooseButton();
          this.ButtonTimer = 0f;
        }
      }
    } else if (base.transform.localScale.x > 0.1f) {
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
    } else {
      base.transform.localScale = Vector3.zero;
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x060007DB RID: 2011 RVA: 0x00078C68 File Offset: 0x00077068
  public void HeroWins() {
    if (this.Yandere.Armed) {
      this.Yandere.EquippedWeapon.Drop();
    }
    this.Yandere.Lost = true;
    this.Student.Won = true;
    this.Struggling = false;
    this.Victory = 0f;
  }

  // Token: 0x060007DC RID: 2012 RVA: 0x00078CC0 File Offset: 0x000770C0
  private void ChooseButton() {
    int buttonID = this.ButtonID;
    for (int i = 1; i < 5; i++) {
      this.ButtonPrompts[i].enabled = false;
      this.ButtonPrompts[i].transform.localPosition = this.ButtonPrompts[buttonID].transform.localPosition;
    }
    while (this.ButtonID == buttonID) {
      this.ButtonID = UnityEngine.Random.Range(1, 5);
    }
    if (this.ButtonID == 1) {
      this.CurrentButton = "A";
    } else if (this.ButtonID == 2) {
      this.CurrentButton = "B";
    } else if (this.ButtonID == 3) {
      this.CurrentButton = "X";
    } else if (this.ButtonID == 4) {
      this.CurrentButton = "Y";
    }
    this.ButtonPrompts[this.ButtonID].enabled = true;
  }

  // Token: 0x04001419 RID: 5145
  public ShoulderCameraScript ShoulderCamera;

  // Token: 0x0400141A RID: 5146
  public PromptSwapScript ButtonPrompt;

  // Token: 0x0400141B RID: 5147
  public UISprite[] ButtonPrompts;

  // Token: 0x0400141C RID: 5148
  public YandereScript Yandere;

  // Token: 0x0400141D RID: 5149
  public StudentScript Student;

  // Token: 0x0400141E RID: 5150
  public Transform Spikes;

  // Token: 0x0400141F RID: 5151
  public string CurrentButton = string.Empty;

  // Token: 0x04001420 RID: 5152
  public bool Struggling;

  // Token: 0x04001421 RID: 5153
  public bool Invincible;

  // Token: 0x04001422 RID: 5154
  public float ButtonTimer;

  // Token: 0x04001423 RID: 5155
  public float Intensity;

  // Token: 0x04001424 RID: 5156
  public float Strength = 1f;

  // Token: 0x04001425 RID: 5157
  public float Struggle;

  // Token: 0x04001426 RID: 5158
  public float Victory;

  // Token: 0x04001427 RID: 5159
  public int ButtonID;
}