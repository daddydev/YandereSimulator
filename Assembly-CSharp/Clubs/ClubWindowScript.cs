using UnityEngine;

// Token: 0x0200006B RID: 107
public class ClubWindowScript : MonoBehaviour {

  // Token: 0x06000185 RID: 389 RVA: 0x0001A2B0 File Offset: 0x000186B0
  private void Start() {
    this.Window.SetActive(false);
    if (SchoolAtmosphere.Type == SchoolAtmosphereType.Low) {
      this.ActivityDescs[7] = this.LowAtmosphereDesc;
    } else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium) {
      this.ActivityDescs[7] = this.MedAtmosphereDesc;
    }
  }

  // Token: 0x06000186 RID: 390 RVA: 0x0001A300 File Offset: 0x00018700
  private void Update() {
    if (this.Window.activeInHierarchy) {
      if (this.Timer > 0.5f) {
        if (Input.GetButtonDown("A")) {
          if (!this.Quitting && !this.Activity) {
            ClubGlobals.Club = this.Club;
            this.Yandere.ClubAccessory();
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
            this.ClubManager.ActivateClubBenefit();
          } else if (this.Quitting) {
            this.ClubManager.DeactivateClubBenefit();
            ClubGlobals.SetQuitClub(this.Club, true);
            ClubGlobals.Club = ClubType.None;
            this.Yandere.ClubAccessory();
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
            this.Quitting = false;
          } else if (this.Activity) {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
          }
          this.Yandere.TargetStudent.TalkTimer = 100f;
          this.Yandere.TargetStudent.ClubPhase = 2;
          this.PromptBar.ClearButtons();
          this.PromptBar.Show = false;
          this.Window.SetActive(false);
        }
        if (Input.GetButtonDown("B")) {
          if (!this.Quitting && !this.Activity) {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
          } else if (this.Quitting) {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
            this.Quitting = false;
          } else if (this.Activity) {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
            this.Activity = false;
          }
          this.Yandere.TargetStudent.TalkTimer = 100f;
          this.Yandere.TargetStudent.ClubPhase = 3;
          this.PromptBar.ClearButtons();
          this.PromptBar.Show = false;
          this.Window.SetActive(false);
        }
        if (Input.GetButtonDown("X") && !this.Quitting && !this.Activity) {
          if (!this.Warning.activeInHierarchy) {
            this.ClubInfo.SetActive(false);
            this.Warning.SetActive(true);
          } else {
            this.ClubInfo.SetActive(true);
            this.Warning.SetActive(false);
          }
        }
      }
      this.Timer += Time.deltaTime;
    }
    if (this.PerformingActivity) {
      this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    } else if (this.ActivityWindow.localScale.x > 0.1f) {
      this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    } else if (this.ActivityWindow.localScale.x != 0f) {
      this.ActivityWindow.localScale = Vector3.zero;
    }
  }

  // Token: 0x06000187 RID: 391 RVA: 0x0001A654 File Offset: 0x00018A54
  public void UpdateWindow() {
    this.ClubName.text = this.ClubNames[(int)this.Club];
    if (!this.Quitting && !this.Activity) {
      this.ClubDesc.text = this.ClubDescs[(int)this.Club];
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Refuse";
      this.PromptBar.Label[2].text = "More Info";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.BottomLabel.text = "Will you join the " + this.ClubNames[(int)this.Club] + "?";
    } else if (this.Activity) {
      this.ClubDesc.text = "Club activities last until 6:00 PM. If you choose to participate in club activities now, the day will end.\n\nIf you don't join by 5:30 PM, you won't be able to participate in club activities today.\n\nIf you don't participate in club activities at least once a week, you will be removed from the club.";
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Yes";
      this.PromptBar.Label[1].text = "No";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.BottomLabel.text = "Will you participate in club activities?";
    } else if (this.Quitting) {
      this.ClubDesc.text = "Are you sure you want to quit this club? If you quit, you will never be allowed to return.";
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Confirm";
      this.PromptBar.Label[1].text = "Deny";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.BottomLabel.text = "Will you quit the " + this.ClubNames[(int)this.Club] + "?";
    }
    this.ClubInfo.SetActive(true);
    this.Warning.SetActive(false);
    this.Window.SetActive(true);
    this.Timer = 0f;
  }

  // Token: 0x040004C2 RID: 1218
  public ClubManagerScript ClubManager;

  // Token: 0x040004C3 RID: 1219
  public PromptBarScript PromptBar;

  // Token: 0x040004C4 RID: 1220
  public YandereScript Yandere;

  // Token: 0x040004C5 RID: 1221
  public Transform ActivityWindow;

  // Token: 0x040004C6 RID: 1222
  public GameObject ClubInfo;

  // Token: 0x040004C7 RID: 1223
  public GameObject Window;

  // Token: 0x040004C8 RID: 1224
  public GameObject Warning;

  // Token: 0x040004C9 RID: 1225
  public string[] ActivityDescs;

  // Token: 0x040004CA RID: 1226
  public string[] ClubNames;

  // Token: 0x040004CB RID: 1227
  public string[] ClubDescs;

  // Token: 0x040004CC RID: 1228
  public string MedAtmosphereDesc;

  // Token: 0x040004CD RID: 1229
  public string LowAtmosphereDesc;

  // Token: 0x040004CE RID: 1230
  public UILabel ActivityLabel;

  // Token: 0x040004CF RID: 1231
  public UILabel BottomLabel;

  // Token: 0x040004D0 RID: 1232
  public UILabel ClubName;

  // Token: 0x040004D1 RID: 1233
  public UILabel ClubDesc;

  // Token: 0x040004D2 RID: 1234
  public bool PerformingActivity;

  // Token: 0x040004D3 RID: 1235
  public bool Activity;

  // Token: 0x040004D4 RID: 1236
  public bool Quitting;

  // Token: 0x040004D5 RID: 1237
  public float Timer;

  // Token: 0x040004D6 RID: 1238
  public ClubType Club;
}