using System;
using UnityEngine;

// Token: 0x0200015E RID: 350
public class PoliceScript : MonoBehaviour {

  // Token: 0x06000672 RID: 1650 RVA: 0x0005CE30 File Offset: 0x0005B230
  private void Start() {
    if (SchoolGlobals.SchoolAtmosphere > 0.5f) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
      this.Darkness.enabled = false;
    }
    base.transform.localPosition = new Vector3(-260f, base.transform.localPosition.y, base.transform.localPosition.z);
    foreach (UILabel uilabel in this.ResultsLabels) {
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
    }
    this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 0f);
    this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 0f);
    this.Icons.SetActive(false);
  }

  // Token: 0x06000673 RID: 1651 RVA: 0x0005CFFC File Offset: 0x0005B3FC
  private void Update() {
    if (this.Show) {
      if (this.PoisonScene) {
      }
      if (!this.Icons.activeInHierarchy) {
        this.Icons.SetActive(true);
      }
      base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
      if (this.BloodParent.childCount == 0) {
        if (!this.BloodDisposed) {
          this.BloodIcon.spriteName = "Yes";
          this.BloodDisposed = true;
        }
      } else if (this.BloodDisposed) {
        this.BloodIcon.spriteName = "No";
        this.BloodDisposed = false;
      }
      if (this.BloodyClothing == 0) {
        if (!this.UniformDisposed) {
          this.UniformIcon.spriteName = "Yes";
          this.UniformDisposed = true;
        }
      } else if (this.UniformDisposed) {
        this.UniformIcon.spriteName = "No";
        this.UniformDisposed = false;
      }
      if (this.IncineratedWeapons == this.MurderWeapons) {
        if (!this.WeaponDisposed) {
          this.WeaponIcon.spriteName = "Yes";
          this.WeaponDisposed = true;
        }
      } else if (this.WeaponDisposed) {
        this.WeaponIcon.spriteName = "No";
        this.WeaponDisposed = false;
      }
      if (this.Corpses == 0) {
        if (!this.CorpseDisposed) {
          this.CorpseIcon.spriteName = "Yes";
          this.CorpseDisposed = true;
        }
      } else if (this.CorpseDisposed) {
        this.CorpseIcon.spriteName = "No";
        this.CorpseDisposed = false;
      }
      if (this.BodyParts == 0) {
        if (!this.PartsDisposed) {
          this.PartsIcon.spriteName = "Yes";
          this.PartsDisposed = true;
        }
      } else if (this.PartsDisposed) {
        this.PartsIcon.spriteName = "No";
        this.PartsDisposed = false;
      }
      if (this.Yandere.Sanity == 100f) {
        if (!this.SanityRestored) {
          this.SanityIcon.spriteName = "Yes";
          this.SanityRestored = true;
        }
      } else if (this.SanityRestored) {
        this.SanityIcon.spriteName = "No";
        this.SanityRestored = false;
      }
      this.Timer -= Time.deltaTime;
      if (this.Timer <= 0f) {
        this.Timer = 0f;
        if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.FadeOut) {
          this.BeginFadingOut();
        }
      }
      int num = Mathf.CeilToInt(this.Timer);
      this.Minutes = num / 60;
      this.Seconds = num % 60;
      this.TimeLabel.text = string.Format("{0:00}:{1:00}", this.Minutes, this.Seconds);
    }
    if (this.FadeOut) {
      if (this.Clock.TimeSkip || this.Yandere.CanMove) {
        if (this.Clock.TimeSkip) {
          this.Clock.EndTimeSkip();
        }
        this.Yandere.StopAiming();
        this.Yandere.StopLaughing();
        this.Yandere.CanMove = false;
        this.Yandere.YandereVision = false;
        this.Yandere.PauseScreen.enabled = false;
        this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_idleShort_00");
        for (int i = 1; i < 4; i++) {
          if (this.Yandere.Weapon[i] != null) {
          }
        }
      }
      this.PauseScreen.Panel.alpha = Mathf.MoveTowards(this.PauseScreen.Panel.alpha, 0f, Time.deltaTime);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if (this.Darkness.color.a >= 1f && !this.ShowResults) {
        this.HeartbeatCamera.SetActive(false);
        this.DetectionCamera.SetActive(false);
        if (this.ClubActivity) {
          this.ClubManager.Club = ClubGlobals.Club;
          this.ClubManager.ClubActivity();
          this.FadeOut = false;
        } else {
          this.Yandere.enabled = false;
          this.DetermineResults();
          this.ShowResults = true;
          Time.timeScale = 2f;
          this.Jukebox.Volume = 0f;
        }
      }
    }
    if (this.ShowResults) {
      this.ResultsTimer += Time.deltaTime;
      if (this.ResultsTimer > 1f) {
        UILabel uilabel = this.ResultsLabels[0];
        uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime);
      }
      if (this.ResultsTimer > 2f) {
        UILabel uilabel2 = this.ResultsLabels[1];
        uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, uilabel2.color.a + Time.deltaTime);
      }
      if (this.ResultsTimer > 3f) {
        UILabel uilabel3 = this.ResultsLabels[2];
        uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, uilabel3.color.a + Time.deltaTime);
      }
      if (this.ResultsTimer > 4f) {
        UILabel uilabel4 = this.ResultsLabels[3];
        uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, uilabel4.color.a + Time.deltaTime);
      }
      if (this.ResultsTimer > 5f) {
        UILabel uilabel5 = this.ResultsLabels[4];
        uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, uilabel5.color.a + Time.deltaTime);
      }
      if (this.ResultsTimer > 6f) {
        this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a + Time.deltaTime);
        this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a + Time.deltaTime);
        if (this.ContinueButton.color.a > 1f) {
          this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 1f);
        }
        if (this.ContinueLabel.color.a > 1f) {
          this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 1f);
        }
      }
      if (this.ResultsTimer > 7f && Input.GetButtonDown("A")) {
        this.ShowResults = false;
        this.FadeResults = true;
        this.FadeOut = false;
        this.ResultsTimer = 0f;
      }
    }
    foreach (UILabel uilabel6 in this.ResultsLabels) {
      if (uilabel6.color.a > 1f) {
        uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 1f);
      }
    }
    if (this.FadeResults) {
      foreach (UILabel uilabel7 in this.ResultsLabels) {
        uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, uilabel7.color.a - Time.deltaTime);
      }
      this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a - Time.deltaTime);
      this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a - Time.deltaTime);
      if (this.ResultsLabels[0].color.a <= 0f) {
        if (this.GameOver) {
          this.Heartbroken.transform.parent.transform.parent = null;
          this.Heartbroken.transform.parent.gameObject.SetActive(true);
          this.Heartbroken.Noticed = false;
          base.transform.parent.transform.parent.gameObject.SetActive(false);
          if (!this.EndOfDay.gameObject.activeInHierarchy) {
            Time.timeScale = 1f;
          }
        } else if (!this.TeacherReport) {
          if (this.EndOfDay.Phase == 1) {
            this.EndOfDay.gameObject.SetActive(true);
            this.EndOfDay.enabled = true;
            this.EndOfDay.Phase = 11;
            if (this.EndOfDay.PreviouslyActivated) {
              this.EndOfDay.Start();
            }
            for (int l = 0; l < 5; l++) {
              this.ResultsLabels[l].text = string.Empty;
            }
            base.enabled = false;
          }
        } else {
          this.DetermineResults();
          this.TeacherReport = false;
          this.FadeResults = false;
          this.ShowResults = true;
        }
      }
    }
  }

  // Token: 0x06000674 RID: 1652 RVA: 0x0005DCC0 File Offset: 0x0005C0C0
  private void DetermineResults() {
    this.ResultsLabels[0].transform.parent.gameObject.SetActive(true);
    if (this.Show) {
      this.EndOfDay.gameObject.SetActive(true);
      base.enabled = false;
      for (int i = 0; i < 5; i++) {
        this.ResultsLabels[i].text = string.Empty;
      }
    } else if (this.Reputation.Reputation <= -100f) {
      this.ResultsLabels[0].text = "Yandere-chan's bizarre conduct has been observed and discussed by many people.";
      this.ResultsLabels[1].text = "Word of Yandere-chan's strange behavior has reached Senpai.";
      this.ResultsLabels[2].text = "Senpai is now aware that Yandere-chan is a dangerous person.";
      this.ResultsLabels[3].text = "From this day forward, Senpai will fear and avoid Yandere-chan.";
      this.ResultsLabels[4].text = "Yandere-chan will never have her Senpai's love.";
      this.GameOver = true;
    } else if (DateGlobals.Weekday == DayOfWeek.Friday) {
      this.ResultsLabels[0].text = "This is the part where the game will determine whether or not the player has eliminated their rival.";
      this.ResultsLabels[1].text = "This game is still in development.";
      this.ResultsLabels[2].text = "The ''player eliminated rival'' state has not yet been implemented.";
      this.ResultsLabels[3].text = "Thank you for playtesting Yandere Simulator!";
      this.ResultsLabels[4].text = "Please check back soon for more updates!";
      this.GameOver = true;
    } else if (!this.Suicide && !this.PoisonScene) {
      if (this.Clock.HourTime < 18f) {
        if (!this.Yandere.InClass) {
          this.ResultsLabels[0].text = "Yandere-chan stands near the school gate and waits for Senpai to leave school.";
        } else {
          this.ResultsLabels[0].text = "Yandere-chan attempts to attend class without disposing of a corpse.";
        }
      } else {
        this.ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
      }
      if (this.Corpses == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyClothing == 0 && !this.SuicideScene) {
        if (this.Yandere.Sanity > 66.66666f && this.Yandere.Bloodiness == 0f) {
          if (this.Clock.HourTime < 18f) {
            this.ResultsLabels[1].text = "Finally, Senpai exits the school.";
            this.ResultsLabels[2].text = "Yandere-chan's heart skips a beat when she sees him.";
            this.ResultsLabels[3].text = "Yandere-chan leaves school and watches Senpai walk home.";
            this.ResultsLabels[4].text = "Once he is safely home, Yandere-chan returns to her own home.";
          } else {
            this.ResultsLabels[1].text = "Like all other students, Yandere-chan is instructed to leave school.";
            this.ResultsLabels[2].text = "Senpai leaves school, too.";
            this.ResultsLabels[3].text = "Yandere-chan leaves school and watches Senpai walk home.";
            this.ResultsLabels[4].text = "Once he is safely home, Yandere-chan returns to her own home.";
          }
        } else {
          this.ResultsLabels[1].text = "Yandere-chan is approached by a faculty member.";
          if (this.Yandere.Bloodiness > 0f) {
            this.ResultsLabels[2].text = "The faculty member immediately notices the blood staining her clothing.";
            this.ResultsLabels[3].text = "Yandere-chan is not able to convince the faculty member that nothing is wrong.";
            this.ResultsLabels[4].text = "The faculty member calls the police.";
            this.TeacherReport = true;
            this.Show = true;
          } else {
            this.ResultsLabels[2].text = "Yandere-chan exhibited extremely erratic behavior, frightening the faculty member.";
            this.ResultsLabels[3].text = "The faculty member becomes angry with Yandere-chan, but Yandere-chan leaves before the situation gets worse.";
            this.ResultsLabels[4].text = "Yandere-chan returns home.";
          }
        }
      } else if (this.Corpses == 0) {
        if (this.BloodParent.childCount > 0 || this.BloodyClothing > 0) {
          if (this.BloodyWeapons == 0) {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious blood stain.";
            this.ResultsLabels[2].text = "The faculty member decides to call the police.";
            this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
            this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
            this.TeacherReport = true;
            this.Show = true;
          } else {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious bloody weapon.";
            this.ResultsLabels[2].text = "The faculty member decides to call the police.";
            this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
            this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
            this.TeacherReport = true;
            this.Show = true;
          }
        } else if (this.BloodyWeapons > 0) {
          this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious bloody weapon.";
          this.ResultsLabels[2].text = "The faculty member decides to call the police.";
          this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
          this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
          this.TeacherReport = true;
          this.Show = true;
        } else if (this.SuicideScene) {
          this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a pair of shoes on the rooftop.";
          this.ResultsLabels[2].text = "The faculty member fears that there has been a suicide, but cannot find a corpse anywhere. The faculty member does not take any action.";
          this.ResultsLabels[3].text = "Yandere-chan leaves school and watches Senpai walk home.";
          this.ResultsLabels[4].text = "Once he is safely home, Yandere-chan returns to her own home.";
        }
      } else {
        this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
        this.ResultsLabels[2].text = "The faculty member immediately calls the police.";
        this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
        this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
        this.TeacherReport = true;
        this.Show = true;
      }
    } else if (this.Suicide) {
      if (!this.Yandere.InClass) {
        this.ResultsLabels[0].text = "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
      } else {
        this.ResultsLabels[0].text = "Yandere-chan attempts to attend class without disposing of a corpse.";
      }
      this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
      this.ResultsLabels[2].text = "It appears as though a student has committed suicide.";
      this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
      this.ResultsLabels[4].text = "The faculty members agree to call the police and report the student's death.";
      this.TeacherReport = true;
      this.Show = true;
    } else if (this.PoisonScene) {
      this.ResultsLabels[0].text = "A faculty member discovers the student who Yandere-chan poisoned.";
      this.ResultsLabels[1].text = "The faculty member calls for an ambulance immediately.";
      this.ResultsLabels[2].text = "The faculty member suspects that the student's death was a murder.";
      this.ResultsLabels[3].text = "The faculty member also calls for the police.";
      this.ResultsLabels[4].text = "The school's students are not allowed to leave until a police investigation has taken place.";
      this.TeacherReport = true;
      this.Show = true;
    }
  }

  // Token: 0x06000675 RID: 1653 RVA: 0x0005E374 File Offset: 0x0005C774
  public void KillStudents() {
    if (this.Deaths > 0) {
      for (int i = 2; i < this.StudentManager.NPCsTotal + 1; i++) {
        if (StudentGlobals.GetStudentDying(i)) {
          if (i < 90) {
            SchoolGlobals.SchoolAtmosphere -= 0.05f;
          } else {
            SchoolGlobals.SchoolAtmosphere -= 0.1f;
          }
          if (this.JSON.Students[i].Club == ClubType.Council) {
            SchoolGlobals.SchoolAtmosphere -= 1f;
            SchoolGlobals.HighSecurity = true;
          }
          StudentGlobals.SetStudentDead(i, true);
          PlayerGlobals.Kills++;
        }
      }
    } else if (!SchoolGlobals.HighSecurity) {
      SchoolGlobals.SchoolAtmosphere += 0.2f;
    }
    SchoolGlobals.SchoolAtmosphere = Mathf.Clamp01(SchoolGlobals.SchoolAtmosphere);
    for (int j = 1; j < this.StudentManager.StudentsTotal; j++) {
      StudentScript studentScript = this.StudentManager.Students[j];
      if (studentScript != null && studentScript.Grudge) {
        StudentGlobals.SetStudentGrudge(j, true);
      }
    }
  }

  // Token: 0x06000676 RID: 1654 RVA: 0x0005E49C File Offset: 0x0005C89C
  public void BeginFadingOut() {
    this.StudentManager.StopMoving();
    this.Darkness.enabled = true;
    this.Yandere.StopLaughing();
    this.Clock.StopTime = true;
    this.FadeOut = true;
    if (!this.EndOfDay.gameObject.activeInHierarchy) {
      Time.timeScale = 1f;
    }
  }

  // Token: 0x04000FA0 RID: 4000
  public StudentManagerScript StudentManager;

  // Token: 0x04000FA1 RID: 4001
  public ClubManagerScript ClubManager;

  // Token: 0x04000FA2 RID: 4002
  public HeartbrokenScript Heartbroken;

  // Token: 0x04000FA3 RID: 4003
  public PauseScreenScript PauseScreen;

  // Token: 0x04000FA4 RID: 4004
  public ReputationScript Reputation;

  // Token: 0x04000FA5 RID: 4005
  public TranqCaseScript TranqCase;

  // Token: 0x04000FA6 RID: 4006
  public EndOfDayScript EndOfDay;

  // Token: 0x04000FA7 RID: 4007
  public JukeboxScript Jukebox;

  // Token: 0x04000FA8 RID: 4008
  public YandereScript Yandere;

  // Token: 0x04000FA9 RID: 4009
  public ClockScript Clock;

  // Token: 0x04000FAA RID: 4010
  public JsonScript JSON;

  // Token: 0x04000FAB RID: 4011
  public UIPanel Panel;

  // Token: 0x04000FAC RID: 4012
  public GameObject HeartbeatCamera;

  // Token: 0x04000FAD RID: 4013
  public GameObject DetectionCamera;

  // Token: 0x04000FAE RID: 4014
  public GameObject SuicideStudent;

  // Token: 0x04000FAF RID: 4015
  public GameObject Icons;

  // Token: 0x04000FB0 RID: 4016
  public Transform BloodParent;

  // Token: 0x04000FB1 RID: 4017
  public RagdollScript[] CorpseList;

  // Token: 0x04000FB2 RID: 4018
  public UILabel[] ResultsLabels;

  // Token: 0x04000FB3 RID: 4019
  public UILabel ContinueLabel;

  // Token: 0x04000FB4 RID: 4020
  public UILabel TimeLabel;

  // Token: 0x04000FB5 RID: 4021
  public UISprite ContinueButton;

  // Token: 0x04000FB6 RID: 4022
  public UISprite Darkness;

  // Token: 0x04000FB7 RID: 4023
  public UISprite BloodIcon;

  // Token: 0x04000FB8 RID: 4024
  public UISprite UniformIcon;

  // Token: 0x04000FB9 RID: 4025
  public UISprite WeaponIcon;

  // Token: 0x04000FBA RID: 4026
  public UISprite CorpseIcon;

  // Token: 0x04000FBB RID: 4027
  public UISprite PartsIcon;

  // Token: 0x04000FBC RID: 4028
  public UISprite SanityIcon;

  // Token: 0x04000FBD RID: 4029
  public string ElectrocutedStudentName = string.Empty;

  // Token: 0x04000FBE RID: 4030
  public string DrownedStudentName = string.Empty;

  // Token: 0x04000FBF RID: 4031
  public bool BloodDisposed;

  // Token: 0x04000FC0 RID: 4032
  public bool UniformDisposed;

  // Token: 0x04000FC1 RID: 4033
  public bool WeaponDisposed;

  // Token: 0x04000FC2 RID: 4034
  public bool CorpseDisposed;

  // Token: 0x04000FC3 RID: 4035
  public bool PartsDisposed;

  // Token: 0x04000FC4 RID: 4036
  public bool SanityRestored;

  // Token: 0x04000FC5 RID: 4037
  public bool MurderSuicideScene;

  // Token: 0x04000FC6 RID: 4038
  public bool ElectroScene;

  // Token: 0x04000FC7 RID: 4039
  public bool SuicideScene;

  // Token: 0x04000FC8 RID: 4040
  public bool PoisonScene;

  // Token: 0x04000FC9 RID: 4041
  public bool MurderScene;

  // Token: 0x04000FCA RID: 4042
  public bool DrownScene;

  // Token: 0x04000FCB RID: 4043
  public bool TeacherReport;

  // Token: 0x04000FCC RID: 4044
  public bool ClubActivity;

  // Token: 0x04000FCD RID: 4045
  public bool CouncilDeath;

  // Token: 0x04000FCE RID: 4046
  public bool MaskReported;

  // Token: 0x04000FCF RID: 4047
  public bool FadeResults;

  // Token: 0x04000FD0 RID: 4048
  public bool ShowResults;

  // Token: 0x04000FD1 RID: 4049
  public bool GameOver;

  // Token: 0x04000FD2 RID: 4050
  public bool FadeOut;

  // Token: 0x04000FD3 RID: 4051
  public bool Suicide;

  // Token: 0x04000FD4 RID: 4052
  public bool Called;

  // Token: 0x04000FD5 RID: 4053
  public bool Show;

  // Token: 0x04000FD6 RID: 4054
  public int IncineratedWeapons;

  // Token: 0x04000FD7 RID: 4055
  public int BloodyClothing;

  // Token: 0x04000FD8 RID: 4056
  public int BloodyWeapons;

  // Token: 0x04000FD9 RID: 4057
  public int MurderWeapons;

  // Token: 0x04000FDA RID: 4058
  public int HiddenCorpses;

  // Token: 0x04000FDB RID: 4059
  public int BodyParts;

  // Token: 0x04000FDC RID: 4060
  public int Witnesses;

  // Token: 0x04000FDD RID: 4061
  public int Corpses;

  // Token: 0x04000FDE RID: 4062
  public int Deaths;

  // Token: 0x04000FDF RID: 4063
  public float ResultsTimer;

  // Token: 0x04000FE0 RID: 4064
  public float Timer;

  // Token: 0x04000FE1 RID: 4065
  public int Minutes;

  // Token: 0x04000FE2 RID: 4066
  public int Seconds;
}