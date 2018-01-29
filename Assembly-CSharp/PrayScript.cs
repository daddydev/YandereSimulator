using UnityEngine;

// Token: 0x02000165 RID: 357
public class PrayScript : MonoBehaviour {

  // Token: 0x0600069A RID: 1690 RVA: 0x00063A78 File Offset: 0x00061E78
  private void Start() {
    if (StudentGlobals.GetStudentDead(16)) {
      this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
    }
    this.PrayWindow.localScale = Vector3.zero;
    if (MissionModeGlobals.MissionMode) {
      this.Disable();
    }
    if (GameGlobals.LoveSick) {
      this.Disable();
    }
  }

  // Token: 0x0600069B RID: 1691 RVA: 0x00063B0F File Offset: 0x00061F0F
  private void Disable() {
    this.GenderPrompt.gameObject.SetActive(false);
    base.enabled = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }

  // Token: 0x0600069C RID: 1692 RVA: 0x00063B40 File Offset: 0x00061F40
  private void Update() {
    if (!this.FemaleVictimChecked) {
      if (this.StudentManager.Students[16] != null && !this.StudentManager.Students[16].Alive) {
        this.FemaleVictimChecked = true;
        this.Victims++;
      }
    } else if (this.StudentManager.Students[16] == null) {
      this.FemaleVictimChecked = false;
      this.Victims--;
    }
    if (!this.MaleVictimChecked) {
      if (this.StudentManager.Students[15] != null && !this.StudentManager.Students[15].Alive) {
        this.MaleVictimChecked = true;
        this.Victims++;
      }
    } else if (this.StudentManager.Students[15] == null) {
      this.MaleVictimChecked = false;
      this.Victims--;
    }
    if (this.JustSummoned) {
      this.StudentManager.UpdateMe(this.StudentID);
      this.JustSummoned = false;
    }
    if (this.GenderPrompt.Circle[0].fillAmount == 0f) {
      this.GenderPrompt.Circle[0].fillAmount = 1f;
      if (!this.SpawnMale) {
        this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, (!StudentGlobals.GetStudentDead(15)) ? 1f : 0.5f);
        this.GenderPrompt.Label[0].text = "     Male Victim";
        this.SpawnMale = true;
      } else {
        this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, (!StudentGlobals.GetStudentDead(16)) ? 1f : 0.5f);
        this.GenderPrompt.Label[0].text = "     Female Victim";
        this.SpawnMale = false;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Yandere.TargetStudent = this.Student;
      this.StudentManager.DisablePrompts();
      this.PrayWindow.gameObject.SetActive(true);
      this.Show = true;
      this.Yandere.ShoulderCamera.OverShoulder = true;
      this.Yandere.WeaponMenu.KeyboardShow = false;
      this.Yandere.Obscurance.enabled = false;
      this.Yandere.WeaponMenu.Show = false;
      this.Yandere.YandereVision = false;
      this.Yandere.CanMove = false;
      this.Yandere.Talking = true;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[4].text = "Choose";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.StudentNumber = ((!this.SpawnMale) ? 16 : 17);
      if (this.StudentManager.Students[16] != null && !this.StudentManager.Students[16].gameObject.activeInHierarchy) {
        this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
      }
      if (this.StudentManager.Students[17] != null && !this.StudentManager.Students[17].gameObject.activeInHierarchy) {
        this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
      }
    }
    if (!this.Show) {
      if (this.PrayWindow.gameObject.activeInHierarchy) {
        if (this.PrayWindow.localScale.x > 0.1f) {
          this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
        } else {
          this.PrayWindow.localScale = Vector3.zero;
          this.PrayWindow.gameObject.SetActive(false);
        }
      }
    } else {
      this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.InputManager.TappedUp) {
        this.Selected--;
        if (this.Selected == 6) {
          this.Selected = 5;
        }
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown) {
        this.Selected++;
        if (this.Selected == 6) {
          this.Selected = 7;
        }
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A")) {
        if (this.Selected == 1) {
          if (!this.Yandere.SanityBased) {
            this.SanityLabel.text = "Disable Sanity Anims";
            this.Yandere.SanityBased = true;
          } else {
            this.SanityLabel.text = "Enable Sanity Anims";
            this.Yandere.SanityBased = false;
          }
          this.Exit();
        } else if (this.Selected == 2) {
          this.Yandere.Sanity -= 50f;
          this.Exit();
        } else if (this.Selected == 3) {
          if (this.VictimLabel.color.a == 1f && this.StudentManager.NPCsSpawned >= this.StudentManager.NPCsTotal) {
            if (this.SpawnMale) {
              this.MaleVictimChecked = false;
              this.StudentID = 15;
            } else {
              this.FemaleVictimChecked = false;
              this.StudentID = 16;
            }
            if (this.StudentManager.Students[this.StudentID] != null) {
              UnityEngine.Object.Destroy(this.StudentManager.Students[this.StudentID].gameObject);
            }
            this.StudentManager.Students[this.StudentID] = null;
            this.StudentManager.ForceSpawn = true;
            this.StudentManager.SpawnPositions[this.StudentID] = this.SummonSpot;
            this.StudentManager.SpawnID = this.StudentID;
            this.StudentManager.SpawnStudent(this.StudentManager.SpawnID);
            this.StudentManager.SpawnID = 0;
            this.Police.Corpses -= this.Victims;
            this.Victims = 0;
            this.JustSummoned = true;
            this.Exit();
          }
        } else if (this.Selected == 4) {
          this.SpawnWeapons();
          this.Exit();
        } else if (this.Selected == 5) {
          this.Police.BloodyClothing = 0;
          this.Yandere.Bloodiness = 0f;
          this.Yandere.Sanity = 100f;
          this.WeaponManager.CleanWeapons();
          this.Exit();
        } else if (this.Selected == 7) {
          this.Exit();
        }
      }
    }
  }

  // Token: 0x0600069D RID: 1693 RVA: 0x000643AC File Offset: 0x000627AC
  private void UpdateHighlight() {
    if (this.Selected < 1) {
      this.Selected = 7;
    } else if (this.Selected > 7) {
      this.Selected = 1;
    }
    this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 200f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
  }

  // Token: 0x0600069E RID: 1694 RVA: 0x0006443C File Offset: 0x0006283C
  private void Exit() {
    this.Selected = 1;
    this.UpdateHighlight();
    this.Yandere.ShoulderCamera.OverShoulder = false;
    this.StudentManager.EnablePrompts();
    this.Yandere.TargetStudent = null;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Show = false;
    this.Uses++;
    if (this.Uses > 9) {
      this.FemaleTurtle.SetActive(true);
    }
  }

  // Token: 0x0600069F RID: 1695 RVA: 0x000644C4 File Offset: 0x000628C4
  public void SpawnWeapons() {
    for (int i = 1; i < 5; i++) {
      if (this.Weapon[i] != null) {
        this.Weapon[i].transform.position = this.WeaponSpot[i].position;
      }
    }
  }

  // Token: 0x0400106A RID: 4202
  public StudentManagerScript StudentManager;

  // Token: 0x0400106B RID: 4203
  public WeaponManagerScript WeaponManager;

  // Token: 0x0400106C RID: 4204
  public InputManagerScript InputManager;

  // Token: 0x0400106D RID: 4205
  public PromptBarScript PromptBar;

  // Token: 0x0400106E RID: 4206
  public StudentScript Student;

  // Token: 0x0400106F RID: 4207
  public YandereScript Yandere;

  // Token: 0x04001070 RID: 4208
  public PoliceScript Police;

  // Token: 0x04001071 RID: 4209
  public UILabel SanityLabel;

  // Token: 0x04001072 RID: 4210
  public UILabel VictimLabel;

  // Token: 0x04001073 RID: 4211
  public PromptScript GenderPrompt;

  // Token: 0x04001074 RID: 4212
  public PromptScript Prompt;

  // Token: 0x04001075 RID: 4213
  public Transform PrayWindow;

  // Token: 0x04001076 RID: 4214
  public Transform SummonSpot;

  // Token: 0x04001077 RID: 4215
  public Transform Highlight;

  // Token: 0x04001078 RID: 4216
  public Transform[] WeaponSpot;

  // Token: 0x04001079 RID: 4217
  public GameObject[] Weapon;

  // Token: 0x0400107A RID: 4218
  public GameObject FemaleTurtle;

  // Token: 0x0400107B RID: 4219
  public int StudentNumber;

  // Token: 0x0400107C RID: 4220
  public int StudentID;

  // Token: 0x0400107D RID: 4221
  public int Selected;

  // Token: 0x0400107E RID: 4222
  public int Victims;

  // Token: 0x0400107F RID: 4223
  public int Uses;

  // Token: 0x04001080 RID: 4224
  public bool FemaleVictimChecked;

  // Token: 0x04001081 RID: 4225
  public bool MaleVictimChecked;

  // Token: 0x04001082 RID: 4226
  public bool JustSummoned;

  // Token: 0x04001083 RID: 4227
  public bool SpawnMale;

  // Token: 0x04001084 RID: 4228
  public bool Show;
}