using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000003 RID: 3
public class MissionModeScript : MonoBehaviour {

  // Token: 0x06000013 RID: 19 RVA: 0x000066B0 File Offset: 0x00004AB0
  private void Start() {
    if (!SchoolGlobals.HighSecurity) {
      this.SecurityCameraGroup.SetActive(false);
      this.MetalDetectorGroup.SetActive(false);
    }
    this.MissionModeHUD.SetActive(false);
    this.ExitPortal.SetActive(false);
    this.Safe.SetActive(false);
    if (GameGlobals.LoveSick) {
      this.MurderKit.SetActive(false);
      this.Yandere.HeartRate.MediumColour = new Color(1f, 1f, 1f, 1f);
      this.Yandere.HeartRate.NormalColour = new Color(1f, 1f, 1f, 1f);
      this.Clock.PeriodLabel.color = new Color(1f, 0f, 0f, 1f);
      this.Clock.TimeLabel.color = new Color(1f, 0f, 0f, 1f);
      this.Clock.DayLabel.enabled = false;
      this.Reputation.PendingRepMarker.GetComponent<UISprite>().color = new Color(1f, 0f, 0f, 1f);
      this.Reputation.CurrentRepMarker.gameObject.SetActive(false);
      this.Reputation.PendingRepLabel.color = new Color(1f, 0f, 0f, 1f);
      this.ReputationFace1.color = new Color(1f, 0f, 0f, 1f);
      this.ReputationFace2.color = new Color(1f, 0f, 0f, 1f);
      this.ReputationBG.color = new Color(1f, 0f, 0f, 1f);
      this.ReputationLabel.color = new Color(1f, 0f, 0f, 1f);
      this.Watermark.color = new Color(1f, 0f, 0f, 1f);
      this.EventSubtitleLabel.color = new Color(1f, 0f, 0f, 1f);
      this.SubtitleLabel.color = new Color(1f, 0f, 0f, 1f);
      this.CautionSign.color = new Color(1f, 0f, 0f, 1f);
      this.FPS.color = new Color(1f, 0f, 0f, 1f);
      this.ID = 1;
      while (this.ID < this.PoliceLabel.Length) {
        this.PoliceLabel[this.ID].color = new Color(1f, 0f, 0f, 1f);
        this.ID++;
      }
      this.ID = 1;
      while (this.ID < this.PoliceIcon.Length) {
        this.PoliceIcon[this.ID].color = new Color(1f, 0f, 0f, 1f);
        this.ID++;
      }
    }
    if (MissionModeGlobals.MissionMode) {
      this.Headmaster.SetActive(false);
      this.Yandere.HeartRate.MediumColour = new Color(1f, 0.5f, 0.5f, 1f);
      this.Yandere.HeartRate.NormalColour = new Color(1f, 1f, 1f, 1f);
      this.Clock.PeriodLabel.color = new Color(1f, 1f, 1f, 1f);
      this.Clock.TimeLabel.color = new Color(1f, 1f, 1f, 1f);
      this.Clock.DayLabel.enabled = false;
      this.Reputation.PendingRepMarker.GetComponent<UISprite>().color = new Color(1f, 1f, 1f, 1f);
      this.Reputation.CurrentRepMarker.gameObject.SetActive(false);
      this.Reputation.PendingRepLabel.color = new Color(1f, 1f, 1f, 1f);
      this.ReputationLabel.fontStyle = FontStyle.Bold;
      this.ReputationLabel.trueTypeFont = this.Arial;
      this.ReputationLabel.color = new Color(1f, 1f, 1f, 1f);
      this.ReputationLabel.text = "AWARENESS";
      this.ReputationIcons[0].SetActive(true);
      this.ReputationIcons[1].SetActive(false);
      this.ReputationIcons[2].SetActive(false);
      this.ReputationIcons[3].SetActive(false);
      this.ReputationIcons[4].SetActive(false);
      this.ReputationIcons[5].SetActive(false);
      this.Clock.TimeLabel.fontStyle = FontStyle.Bold;
      this.Clock.TimeLabel.trueTypeFont = this.Arial;
      this.Clock.PeriodLabel.fontStyle = FontStyle.Bold;
      this.Clock.PeriodLabel.trueTypeFont = this.Arial;
      this.Watermark.fontStyle = FontStyle.Bold;
      this.Watermark.color = new Color(1f, 1f, 1f, 1f);
      this.Watermark.trueTypeFont = this.Arial;
      this.SubtitleLabel.color = new Color(1f, 1f, 1f, 1f);
      this.CautionSign.color = new Color(1f, 1f, 1f, 1f);
      this.FPS.color = new Color(1f, 1f, 1f, 1f);
      this.ColorCorrections = Camera.main.GetComponents<ColorCorrectionCurves>();
      this.StudentManager.MissionMode = true;
      this.NemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
      this.Difficulty = MissionModeGlobals.MissionDifficulty;
      this.TargetID = MissionModeGlobals.MissionTarget;
      this.ID = 1;
      while (this.ID < this.PoliceLabel.Length) {
        this.PoliceLabel[this.ID].fontStyle = FontStyle.Bold;
        this.PoliceLabel[this.ID].color = new Color(1f, 1f, 1f, 1f);
        this.PoliceLabel[this.ID].trueTypeFont = this.Arial;
        this.ID++;
      }
      this.ID = 1;
      while (this.ID < this.PoliceIcon.Length) {
        this.PoliceIcon[this.ID].color = new Color(1f, 1f, 1f, 1f);
        this.ID++;
      }
      if (this.Difficulty > 1) {
        this.ID = 2;
        while (this.ID < this.Difficulty + 1) {
          int missionCondition = MissionModeGlobals.GetMissionCondition(this.ID);
          if (missionCondition == 1) {
            this.RequiredWeaponID = MissionModeGlobals.MissionRequiredWeapon;
          } else if (missionCondition == 2) {
            this.RequiredClothingID = MissionModeGlobals.MissionRequiredClothing;
          } else if (missionCondition == 3) {
            this.RequiredDisposalID = MissionModeGlobals.MissionRequiredDisposal;
          } else if (missionCondition == 4) {
            this.NoCollateral = true;
          } else if (missionCondition == 5) {
            this.NoWitnesses = true;
          } else if (missionCondition == 6) {
            this.NoCorpses = true;
          } else if (missionCondition == 7) {
            this.NoWeapon = true;
          } else if (missionCondition == 8) {
            this.NoBlood = true;
          } else if (missionCondition == 9) {
            this.TimeLimit = true;
          } else if (missionCondition == 10) {
            this.NoSuspicion = true;
          } else if (missionCondition == 11) {
            this.SecurityCameras = true;
          } else if (missionCondition == 12) {
            this.MetalDetectors = true;
          } else if (missionCondition == 13) {
            this.NoSpeech = true;
          } else if (missionCondition == 14) {
            this.StealDocuments = true;
          }
          this.Conditions[this.ID] = missionCondition;
          this.ID++;
        }
      }
      if (!this.StealDocuments) {
        this.DocumentsStolen = true;
      } else {
        this.Safe.SetActive(true);
      }
      if (this.SecurityCameras) {
        this.SecurityCameraGroup.SetActive(true);
      }
      if (this.MetalDetectors) {
        this.MetalDetectorGroup.SetActive(true);
      }
      if (!this.TimeLimit) {
        this.TimeLabel.gameObject.SetActive(false);
      }
      if (this.NoSpeech) {
        this.StudentManager.NoSpeech = true;
      }
      if (this.RequiredDisposalID == 0) {
        this.CorpseDisposed = true;
      }
      if (this.NemesisDifficulty > 0) {
        this.Nemesis.SetActive(true);
      }
      if (!this.NoWeapon) {
        this.WeaponDisposed = true;
      }
      if (!this.NoBlood) {
        this.BloodCleaned = true;
      }
      this.Jukebox.Egg = true;
      this.Jukebox.KillVolume();
      this.Jukebox.MissionMode.enabled = true;
      this.Jukebox.MissionMode.volume = 0f;
      this.Yandere.FixCamera();
      Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 6.51505f, -76.9222f);
      Camera.main.transform.eulerAngles = new Vector3(15f, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
      this.Yandere.RPGCamera.enabled = false;
      this.Yandere.SanityBased = true;
      this.Yandere.CanMove = false;
      this.HeartbeatCamera.SetActive(false);
      this.TranqDetector.SetActive(false);
      this.MurderKit.SetActive(false);
      this.TargetHeight = 1.51505f;
      this.Yandere.HUD.alpha = 0f;
      this.MusicIcon.color = new Color(this.MusicIcon.color.r, this.MusicIcon.color.g, this.MusicIcon.color.b, 1f);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
      this.MissionModeMenu.UpdateGraphics();
    } else {
      this.MissionModeMenu.gameObject.SetActive(false);
      this.TimeLabel.gameObject.SetActive(false);
      base.enabled = false;
    }
  }

  // Token: 0x06000014 RID: 20 RVA: 0x00007268 File Offset: 0x00005668
  private void Update() {
    if (this.Phase == 1) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime / 3f));
      if (this.Darkness.color.a == 0f) {
        this.Speed += Time.deltaTime / 3f;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Mathf.Lerp(Camera.main.transform.position.y, this.TargetHeight, Time.deltaTime * this.Speed), Camera.main.transform.position.z);
        if (Camera.main.transform.position.y < this.TargetHeight + 0.1f) {
          this.Yandere.HUD.alpha = Mathf.MoveTowards(this.Yandere.HUD.alpha, 1f, Time.deltaTime / 3f);
          if (this.Yandere.HUD.alpha == 1f) {
            this.Yandere.RPGCamera.enabled = true;
            this.HeartbeatCamera.SetActive(true);
            this.Yandere.CanMove = true;
            this.Phase++;
          }
        }
      }
      if (Input.GetButtonDown("A")) {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.TargetHeight, Camera.main.transform.position.z);
        this.Yandere.RPGCamera.enabled = true;
        this.HeartbeatCamera.SetActive(true);
        this.Yandere.CanMove = true;
        this.Yandere.HUD.alpha = 1f;
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      if (!this.TargetDead && this.StudentManager.Students[this.TargetID] != null) {
        if (!this.StudentManager.Students[this.TargetID].Alive) {
          if (this.Yandere.Equipped > 0) {
            this.MurderWeaponID = this.Yandere.EquippedWeapon.WeaponID;
          }
          this.TargetDead = true;
        }
        if (this.StudentManager.Students[this.TargetID].transform.position.y < -2f) {
          this.GameOverID = 1;
          this.GameOver();
          this.Phase = 4;
        }
      }
      if (this.RequiredWeaponID > 0 && this.StudentManager.Students[this.TargetID] != null && !this.StudentManager.Students[this.TargetID].Alive && this.StudentManager.Students[this.TargetID].DeathCause != this.RequiredWeaponID) {
        this.Chastise = true;
        this.GameOverID = 2;
        this.GameOver();
        this.Phase = 4;
      }
      if (!this.CorrectClothingConfirmed && this.RequiredClothingID > 0 && this.StudentManager.Students[this.TargetID] != null && !this.StudentManager.Students[this.TargetID].Alive) {
        if (this.Yandere.Schoolwear != this.RequiredClothingID) {
          this.Chastise = true;
          this.GameOverID = 3;
          this.GameOver();
          this.Phase = 4;
        } else {
          this.CorrectClothingConfirmed = true;
        }
      }
      if (this.RequiredDisposalID > 0 && this.DisposalMethod == 0 && this.TargetDead) {
        this.ID = 1;
        while (this.ID < this.Incinerator.Victims + 1) {
          if (this.Incinerator.VictimList[this.ID] == this.TargetID) {
            this.DisposalMethod = 1;
          }
          this.ID++;
        }
        int num = 0;
        this.ID = 1;
        while (this.ID < this.Incinerator.Limbs + 1) {
          if (this.Incinerator.LimbList[this.ID] == this.TargetID) {
            num++;
          }
          if (num == 6) {
            this.DisposalMethod = 1;
          }
          this.ID++;
        }
        this.ID = 1;
        while (this.ID < this.WoodChipper.Victims + 1) {
          if (this.WoodChipper.VictimList[this.ID] == this.TargetID) {
            this.DisposalMethod = 2;
          }
          this.ID++;
        }
        this.ID = 1;
        while (this.ID < this.GardenHoles.Length) {
          if (this.GardenHoles[this.ID].VictimID == this.TargetID) {
            this.DisposalMethod = 3;
          }
          this.ID++;
        }
        if (this.DisposalMethod > 0) {
          if (this.DisposalMethod != this.RequiredDisposalID) {
            this.Chastise = true;
            this.GameOverID = 4;
            this.GameOver();
            this.Phase = 4;
          } else {
            this.CorpseDisposed = true;
          }
        }
      }
      if (this.NoCollateral) {
        if (this.Police.Corpses == 1) {
          if (this.StudentManager.Students[this.TargetID] != null && this.StudentManager.Students[this.TargetID].Alive) {
            this.Chastise = true;
            this.GameOverID = 5;
            this.GameOver();
            this.Phase = 4;
          }
        } else if (this.Police.Corpses > 1) {
          this.GameOverID = 5;
          this.GameOver();
          this.Phase = 4;
        }
      }
      if (this.NoWitnesses) {
        this.ID = 1;
        while (this.ID < this.StudentManager.Students.Length) {
          if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].WitnessedMurder) {
            this.Chastise = true;
            this.GameOverID = 6;
            this.GameOver();
            this.Phase = 4;
          }
          this.ID++;
        }
      }
      if (this.NoCorpses) {
        this.ID = 1;
        while (this.ID < this.StudentManager.Students.Length) {
          if (this.StudentManager.Students[this.ID] != null && (this.StudentManager.Students[this.ID].WitnessedCorpse || this.StudentManager.Students[this.ID].WitnessedMurder)) {
            this.Chastise = true;
            this.GameOverID = 7;
            this.GameOver();
            this.Phase = 4;
          }
          this.ID++;
        }
      }
      if (this.NoBlood) {
        if (this.Police.BloodParent.childCount > 0) {
          this.CheckForBlood = true;
        }
        if (this.CheckForBlood) {
          if (this.Police.BloodParent.childCount == 0) {
            this.BloodTimer += Time.deltaTime;
            if (this.BloodTimer > 1f) {
              this.BloodCleaned = true;
            }
          } else {
            this.BloodTimer = 0f;
          }
        }
      }
      if (this.NoWeapon && !this.WeaponDisposed && this.Incinerator.Timer > 0f) {
        this.ID = 1;
        while (this.ID < this.Incinerator.DestroyedEvidence + 1) {
          if (this.Incinerator.EvidenceList[this.ID] == this.MurderWeaponID) {
            this.WeaponDisposed = true;
          }
          this.ID++;
        }
      }
      if (this.TimeLimit) {
        if (!this.Yandere.PauseScreen.Show) {
          this.TimeRemaining = Mathf.MoveTowards(this.TimeRemaining, 0f, 0.0166666675f);
        }
        int num2 = Mathf.CeilToInt(this.TimeRemaining);
        int num3 = num2 / 60;
        int num4 = num2 % 60;
        this.TimeLabel.text = string.Format("{0:00}:{1:00}", num3, num4);
        if (this.TimeRemaining == 0f) {
          this.Chastise = true;
          this.GameOverID = 10;
          this.GameOver();
          this.Phase = 4;
        }
      }
      if (this.Reputation.Reputation + this.Reputation.PendingRep <= -100f) {
        this.GameOverID = 14;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.NoSuspicion && this.Reputation.Reputation + this.Reputation.PendingRep < 0f) {
        this.GameOverID = 14;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.HeartbrokenCamera.activeInHierarchy) {
        this.HeartbrokenCamera.SetActive(false);
        this.GameOverID = 0;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.Clock.PresentTime > 1080f) {
        this.GameOverID = 11;
        this.GameOver();
        this.Phase = 4;
      } else if (this.Police.FadeOut) {
        this.GameOverID = 12;
        this.GameOver();
        this.Phase = 4;
      }
      if (this.ExitPortal.activeInHierarchy) {
        if (this.Yandere.Chased) {
          this.ExitPortalPrompt.Label[0].text = "     Cannot Exfiltrate!";
          this.ExitPortalPrompt.Circle[0].fillAmount = 1f;
        } else {
          this.ExitPortalPrompt.Label[0].text = "     Exfiltrate";
          if (this.ExitPortalPrompt.Circle[0].fillAmount == 0f) {
            Camera.main.transform.position = new Vector3(0.5f, 2.25f, -100.5f);
            Camera.main.transform.eulerAngles = Vector3.zero;
            this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            this.Yandere.transform.position = new Vector3(0f, 0f, -94.5f);
            this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.WalkAnim);
            this.Yandere.RPGCamera.enabled = false;
            this.Yandere.HUD.gameObject.SetActive(false);
            this.Yandere.CanMove = false;
            AudioSource component = this.Jukebox.MissionMode.GetComponent<AudioSource>();
            component.clip = this.StealthMusic[7];
            component.loop = false;
            component.Play();
            base.GetComponent<AudioSource>().PlayOneShot(this.InfoAccomplished);
            this.HeartbeatCamera.SetActive(false);
            this.Boundary.enabled = false;
            this.Phase++;
          }
        }
      }
      if (this.TargetDead && this.CorpseDisposed && this.BloodCleaned && this.WeaponDisposed && this.DocumentsStolen && this.GameOverID == 0 && !this.ExitPortal.activeInHierarchy) {
        this.NotificationManager.DisplayNotification(NotificationType.Complete);
        this.NotificationManager.DisplayNotification(NotificationType.Exfiltrate);
        base.GetComponent<AudioSource>().PlayOneShot(this.InfoExfiltrate);
        this.ExitPortal.SetActive(true);
      }
      if (this.NoBlood && this.BloodCleaned && this.Police.BloodParent.childCount > 0) {
        this.ExitPortal.SetActive(false);
        this.BloodCleaned = false;
        this.BloodTimer = 0f;
      }
      if (!this.InfoRemark && this.GameOverID == 0 && this.TargetDead && (!this.CorpseDisposed || !this.BloodCleaned || !this.WeaponDisposed)) {
        base.GetComponent<AudioSource>().PlayOneShot(this.InfoObjective);
        this.InfoRemark = true;
      }
    } else if (this.Phase == 3) {
      this.Timer += Time.deltaTime;
      Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Time.deltaTime * 0.2f, Camera.main.transform.position.z);
      this.Yandere.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y, this.Yandere.transform.position.z - Time.deltaTime);
      if (this.Timer > 5f) {
        this.Success();
        this.Timer = 0f;
        this.Phase++;
      }
    } else if (this.Phase == 4) {
      this.Timer += 0.0166666675f;
      if (this.Timer > 1f) {
        if (!this.FadeOut) {
          if (!this.PromptBar.Show) {
            this.PromptBar.Show = true;
          } else if (Input.GetButtonDown("A")) {
            this.PromptBar.Show = false;
            this.Destination = 1;
            this.FadeOut = true;
          } else if (Input.GetButtonDown("B")) {
            this.PromptBar.Show = false;
            this.Destination = 2;
            this.FadeOut = true;
          } else if (Input.GetButtonDown("X")) {
            this.PromptBar.Show = false;
            this.Destination = 3;
            this.FadeOut = true;
          }
        } else {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, 0.0166666675f));
          this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 0f, 0.0166666675f);
          if (this.Darkness.color.a > 0.9921875f) {
            if (this.Destination == 1) {
              this.ResetGlobals();
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } else if (this.Destination == 2) {
              Globals.DeleteAll();
              SceneManager.LoadScene("MissionModeScene");
            } else if (this.Destination == 3) {
              Globals.DeleteAll();
              SceneManager.LoadScene("TitleScene");
            }
          }
        }
      }
      if (this.GameOverPhase == 1) {
        if (this.Timer > 2.5f) {
          if (this.Chastise) {
            base.GetComponent<AudioSource>().PlayOneShot(this.InfoFailure);
            this.GameOverPhase++;
          } else {
            this.GameOverPhase++;
            this.Timer += 5f;
          }
        }
      } else if (this.GameOverPhase == 2 && this.Timer > 7.5f) {
        this.Jukebox.MissionMode.GetComponent<AudioSource>().clip = this.StealthMusic[0];
        this.Jukebox.MissionMode.GetComponent<AudioSource>().Play();
        this.Jukebox.Volume = 0.5f;
        this.GameOverPhase++;
      }
    }
  }

  // Token: 0x06000015 RID: 21 RVA: 0x00008444 File Offset: 0x00006844
  public void GameOver() {
    if (this.Yandere.Aiming) {
      this.Yandere.StopAiming();
      this.Yandere.enabled = false;
    }
    this.GameOverReason.text = this.GameOverReasons[this.GameOverID];
    this.ColorCorrections[2].enabled = true;
    base.GetComponent<AudioSource>().PlayOneShot(this.GameOverSound);
    this.DetectionCamera.SetActive(false);
    this.HeartbeatCamera.SetActive(false);
    this.WitnessCamera.SetActive(false);
    this.GameOverText.SetActive(true);
    this.Yandere.HUD.gameObject.SetActive(false);
    this.Subtitle.SetActive(false);
    Time.timeScale = 0f;
    this.GameOverPhase = 1;
    this.Jukebox.MissionMode.GetComponent<AudioSource>().Stop();
  }

  // Token: 0x06000016 RID: 22 RVA: 0x00008528 File Offset: 0x00006928
  private void Success() {
    this.GameOverHeader.transform.localPosition = new Vector3(this.GameOverHeader.transform.localPosition.x, 0f, this.GameOverHeader.transform.localPosition.z);
    this.GameOverHeader.text = "MISSION ACCOMPLISHED";
    this.GameOverReason.gameObject.SetActive(false);
    this.ColorCorrections[2].enabled = true;
    this.DetectionCamera.SetActive(false);
    this.WitnessCamera.SetActive(false);
    this.GameOverText.SetActive(true);
    this.GameOverReason.text = string.Empty;
    this.Subtitle.SetActive(false);
    this.Jukebox.Volume = 1f;
    Time.timeScale = 0f;
  }

  // Token: 0x06000017 RID: 23 RVA: 0x00008608 File Offset: 0x00006A08
  public void ChangeMusic() {
    this.MusicID++;
    if (this.MusicID > 5) {
      this.MusicID = 1;
    }
    this.Jukebox.MissionMode.GetComponent<AudioSource>().clip = this.StealthMusic[this.MusicID];
    this.Jukebox.MissionMode.GetComponent<AudioSource>().Play();
  }

  // Token: 0x06000018 RID: 24 RVA: 0x00008670 File Offset: 0x00006A70
  private void ResetGlobals() {
    bool disableFarAnimations = OptionGlobals.DisableFarAnimations;
    bool disablePostAliasing = OptionGlobals.DisablePostAliasing;
    bool disableOutlines = OptionGlobals.DisableOutlines;
    int lowDetailStudents = OptionGlobals.LowDetailStudents;
    int particleCount = OptionGlobals.ParticleCount;
    bool disableShadows = OptionGlobals.DisableShadows;
    int drawDistance = OptionGlobals.DrawDistance;
    int drawDistanceLimit = OptionGlobals.DrawDistanceLimit;
    bool disableBloom = OptionGlobals.DisableBloom;
    bool fog = OptionGlobals.Fog;
    string missionTargetName = MissionModeGlobals.MissionTargetName;
    bool highPopulation = OptionGlobals.HighPopulation;
    Globals.DeleteAll();
    SchoolGlobals.SchoolAtmosphere = 1f - (float)this.Difficulty * 0.1f;
    MissionModeGlobals.MissionTargetName = missionTargetName;
    MissionModeGlobals.MissionDifficulty = this.Difficulty;
    OptionGlobals.HighPopulation = highPopulation;
    MissionModeGlobals.MissionTarget = this.TargetID;
    SchoolGlobals.SchoolAtmosphereSet = true;
    MissionModeGlobals.MissionMode = true;
    MissionModeGlobals.MissionRequiredWeapon = this.RequiredWeaponID;
    MissionModeGlobals.MissionRequiredClothing = this.RequiredClothingID;
    MissionModeGlobals.MissionRequiredDisposal = this.RequiredDisposalID;
    ClassGlobals.BiologyGrade = 1;
    ClassGlobals.ChemistryGrade = 1;
    ClassGlobals.LanguageGrade = 1;
    ClassGlobals.PhysicalGrade = 1;
    ClassGlobals.PsychologyGrade = 1;
    this.ID = 2;
    while (this.ID < 11) {
      MissionModeGlobals.SetMissionCondition(this.ID, this.Conditions[this.ID]);
      this.ID++;
    }
    MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
    OptionGlobals.DisableFarAnimations = disableFarAnimations;
    OptionGlobals.DisablePostAliasing = disablePostAliasing;
    OptionGlobals.DisableOutlines = disableOutlines;
    OptionGlobals.LowDetailStudents = lowDetailStudents;
    OptionGlobals.ParticleCount = particleCount;
    OptionGlobals.DisableShadows = disableShadows;
    OptionGlobals.DrawDistance = drawDistance;
    OptionGlobals.DrawDistanceLimit = drawDistanceLimit;
    OptionGlobals.DisableBloom = disableBloom;
    OptionGlobals.Fog = fog;
  }

  // Token: 0x06000019 RID: 25 RVA: 0x000087E8 File Offset: 0x00006BE8
  private void ChangeAllText() {
    UILabel[] array = UnityEngine.Object.FindObjectsOfType<UILabel>();
    foreach (UILabel uilabel in array) {
      float a = uilabel.color.a;
      uilabel.color = new Color(1f, 1f, 1f, a);
      uilabel.trueTypeFont = this.Arial;
    }
    UISprite[] array3 = UnityEngine.Object.FindObjectsOfType<UISprite>();
    foreach (UISprite uisprite in array3) {
      float a2 = uisprite.color.a;
      if (uisprite.color != new Color(0f, 0f, 0f, a2)) {
        uisprite.color = new Color(1f, 1f, 1f, a2);
      }
    }
  }

  // Token: 0x04000057 RID: 87
  public NotificationManagerScript NotificationManager;

  // Token: 0x04000058 RID: 88
  public MissionModeMenuScript MissionModeMenu;

  // Token: 0x04000059 RID: 89
  public StudentManagerScript StudentManager;

  // Token: 0x0400005A RID: 90
  public WeaponManagerScript WeaponManager;

  // Token: 0x0400005B RID: 91
  public PromptScript ExitPortalPrompt;

  // Token: 0x0400005C RID: 92
  public IncineratorScript Incinerator;

  // Token: 0x0400005D RID: 93
  public WoodChipperScript WoodChipper;

  // Token: 0x0400005E RID: 94
  public ReputationScript Reputation;

  // Token: 0x0400005F RID: 95
  public GrayscaleEffect Grayscale;

  // Token: 0x04000060 RID: 96
  public PromptBarScript PromptBar;

  // Token: 0x04000061 RID: 97
  public BoundaryScript Boundary;

  // Token: 0x04000062 RID: 98
  public JukeboxScript Jukebox;

  // Token: 0x04000063 RID: 99
  public YandereScript Yandere;

  // Token: 0x04000064 RID: 100
  public PoliceScript Police;

  // Token: 0x04000065 RID: 101
  public ClockScript Clock;

  // Token: 0x04000066 RID: 102
  public UISprite ReputationFace1;

  // Token: 0x04000067 RID: 103
  public UISprite ReputationFace2;

  // Token: 0x04000068 RID: 104
  public UISprite ReputationBG;

  // Token: 0x04000069 RID: 105
  public UILabel EventSubtitleLabel;

  // Token: 0x0400006A RID: 106
  public UILabel ReputationLabel;

  // Token: 0x0400006B RID: 107
  public UILabel GameOverHeader;

  // Token: 0x0400006C RID: 108
  public UILabel GameOverReason;

  // Token: 0x0400006D RID: 109
  public UILabel SubtitleLabel;

  // Token: 0x0400006E RID: 110
  public UISprite CautionSign;

  // Token: 0x0400006F RID: 111
  public UISprite MusicIcon;

  // Token: 0x04000070 RID: 112
  public UILabel TimeLabel;

  // Token: 0x04000071 RID: 113
  public UISprite Darkness;

  // Token: 0x04000072 RID: 114
  public GUIText FPS;

  // Token: 0x04000073 RID: 115
  public GardenHoleScript[] GardenHoles;

  // Token: 0x04000074 RID: 116
  public GameObject[] ReputationIcons;

  // Token: 0x04000075 RID: 117
  public string[] GameOverReasons;

  // Token: 0x04000076 RID: 118
  public AudioClip[] StealthMusic;

  // Token: 0x04000077 RID: 119
  public Transform[] SpawnPoints;

  // Token: 0x04000078 RID: 120
  public UISprite[] PoliceIcon;

  // Token: 0x04000079 RID: 121
  public UILabel[] PoliceLabel;

  // Token: 0x0400007A RID: 122
  public int[] Conditions;

  // Token: 0x0400007B RID: 123
  public GameObject SecurityCameraGroup;

  // Token: 0x0400007C RID: 124
  public GameObject MetalDetectorGroup;

  // Token: 0x0400007D RID: 125
  public GameObject HeartbrokenCamera;

  // Token: 0x0400007E RID: 126
  public GameObject DetectionCamera;

  // Token: 0x0400007F RID: 127
  public GameObject HeartbeatCamera;

  // Token: 0x04000080 RID: 128
  public GameObject MissionModeHUD;

  // Token: 0x04000081 RID: 129
  public GameObject TranqDetector;

  // Token: 0x04000082 RID: 130
  public GameObject WitnessCamera;

  // Token: 0x04000083 RID: 131
  public GameObject GameOverText;

  // Token: 0x04000084 RID: 132
  public GameObject Headmaster;

  // Token: 0x04000085 RID: 133
  public GameObject ExitPortal;

  // Token: 0x04000086 RID: 134
  public GameObject MurderKit;

  // Token: 0x04000087 RID: 135
  public GameObject Subtitle;

  // Token: 0x04000088 RID: 136
  public GameObject Nemesis;

  // Token: 0x04000089 RID: 137
  public GameObject Safe;

  // Token: 0x0400008A RID: 138
  public Transform LastKnownPosition;

  // Token: 0x0400008B RID: 139
  public int RequiredClothingID;

  // Token: 0x0400008C RID: 140
  public int RequiredDisposalID;

  // Token: 0x0400008D RID: 141
  public int RequiredWeaponID;

  // Token: 0x0400008E RID: 142
  public int NemesisDifficulty;

  // Token: 0x0400008F RID: 143
  public int DisposalMethod;

  // Token: 0x04000090 RID: 144
  public int MurderWeaponID;

  // Token: 0x04000091 RID: 145
  public int GameOverPhase;

  // Token: 0x04000092 RID: 146
  public int Destination;

  // Token: 0x04000093 RID: 147
  public int Difficulty;

  // Token: 0x04000094 RID: 148
  public int GameOverID;

  // Token: 0x04000095 RID: 149
  public int TargetID;

  // Token: 0x04000096 RID: 150
  public int MusicID = 1;

  // Token: 0x04000097 RID: 151
  public int Phase = 1;

  // Token: 0x04000098 RID: 152
  public int ID;

  // Token: 0x04000099 RID: 153
  public bool SecurityCameras;

  // Token: 0x0400009A RID: 154
  public bool MetalDetectors;

  // Token: 0x0400009B RID: 155
  public bool StealDocuments;

  // Token: 0x0400009C RID: 156
  public bool NoCollateral;

  // Token: 0x0400009D RID: 157
  public bool NoSuspicion;

  // Token: 0x0400009E RID: 158
  public bool NoWitnesses;

  // Token: 0x0400009F RID: 159
  public bool NoCorpses;

  // Token: 0x040000A0 RID: 160
  public bool NoSpeech;

  // Token: 0x040000A1 RID: 161
  public bool NoWeapon;

  // Token: 0x040000A2 RID: 162
  public bool NoBlood;

  // Token: 0x040000A3 RID: 163
  public bool TimeLimit;

  // Token: 0x040000A4 RID: 164
  public bool CorrectClothingConfirmed;

  // Token: 0x040000A5 RID: 165
  public bool DocumentsStolen;

  // Token: 0x040000A6 RID: 166
  public bool CorpseDisposed;

  // Token: 0x040000A7 RID: 167
  public bool WeaponDisposed;

  // Token: 0x040000A8 RID: 168
  public bool CheckForBlood;

  // Token: 0x040000A9 RID: 169
  public bool BloodCleaned;

  // Token: 0x040000AA RID: 170
  public bool InfoRemark;

  // Token: 0x040000AB RID: 171
  public bool TargetDead;

  // Token: 0x040000AC RID: 172
  public bool Chastise;

  // Token: 0x040000AD RID: 173
  public bool FadeOut;

  // Token: 0x040000AE RID: 174
  public string CauseOfFailure = string.Empty;

  // Token: 0x040000AF RID: 175
  public float TimeRemaining = 300f;

  // Token: 0x040000B0 RID: 176
  public float TargetHeight;

  // Token: 0x040000B1 RID: 177
  public float BloodTimer;

  // Token: 0x040000B2 RID: 178
  public float Speed;

  // Token: 0x040000B3 RID: 179
  public float Timer;

  // Token: 0x040000B4 RID: 180
  public AudioClip InfoAccomplished;

  // Token: 0x040000B5 RID: 181
  public AudioClip InfoExfiltrate;

  // Token: 0x040000B6 RID: 182
  public AudioClip InfoObjective;

  // Token: 0x040000B7 RID: 183
  public AudioClip InfoFailure;

  // Token: 0x040000B8 RID: 184
  public AudioClip GameOverSound;

  // Token: 0x040000B9 RID: 185
  public ColorCorrectionCurves[] ColorCorrections;

  // Token: 0x040000BA RID: 186
  public UILabel Watermark;

  // Token: 0x040000BB RID: 187
  public Font Arial;

  // Token: 0x040000BC RID: 188
  public int Frame;
}