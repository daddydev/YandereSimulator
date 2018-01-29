using UnityEngine;

// Token: 0x0200006A RID: 106
public class ClubManagerScript : MonoBehaviour {

  // Token: 0x0600017C RID: 380 RVA: 0x000192CC File Offset: 0x000176CC
  private void Start() {
    this.ClubWindow.ActivityWindow.localScale = Vector3.zero;
    this.ClubWindow.ActivityWindow.gameObject.SetActive(false);
    this.ActivateClubBenefit();
    this.ID = 0;
    while (this.ID < this.ClubArray.Length) {
      if (ClubGlobals.GetClubClosed(this.ClubArray[this.ID])) {
        this.ClubPatrolPoints[this.ID].transform.position = new Vector3(this.ClubPatrolPoints[this.ID].transform.position.x, this.ClubPatrolPoints[this.ID].transform.position.y, 20f);
      }
      this.ID++;
    }
    this.ID = 0;
  }

  // Token: 0x0600017D RID: 381 RVA: 0x000193B4 File Offset: 0x000177B4
  private void Update() {
    if (this.Club != ClubType.None) {
      if (this.Phase == 1) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
      }
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.Darkness.color.a == 0f) {
        if (this.Phase == 1) {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          this.ClubWindow.PerformingActivity = true;
          this.ClubWindow.ActivityWindow.gameObject.SetActive(true);
          this.ClubWindow.ActivityLabel.text = this.ClubWindow.ActivityDescs[(int)this.Club];
          this.Phase++;
        } else if (this.Phase == 2) {
          if (this.ClubWindow.ActivityWindow.localScale.x > 0.9f) {
            if (this.Club == ClubType.MartialArts) {
              if (this.ClubPhase == 0) {
                component.clip = this.MotivationalQuotes[UnityEngine.Random.Range(0, this.MotivationalQuotes.Length)];
                component.Play();
                this.ClubEffect = true;
                this.ClubPhase++;
                this.TimeLimit = component.clip.length;
              } else if (this.ClubPhase == 1) {
                this.Timer += Time.deltaTime;
                if (this.Timer > this.TimeLimit) {
                  this.ID = 0;
                  while (this.ID < this.Club6Students.Length) {
                    if (this.StudentManager.Students[this.ID] != null && !this.StudentManager.Students[this.ID].Tranquil) {
                      this.StudentManager.Students[this.Club6Students[this.ID]].GetComponent<AudioSource>().volume = 1f;
                    }
                    this.ID++;
                  }
                  this.ClubPhase++;
                }
              }
            }
            if (Input.GetButtonDown("A")) {
              this.ClubWindow.PerformingActivity = false;
              this.PromptBar.Show = false;
              this.Phase++;
            }
          }
        } else if (this.ClubWindow.ActivityWindow.localScale.x < 0.1f) {
          this.Police.Darkness.enabled = true;
          this.Police.ClubActivity = false;
          this.Police.FadeOut = true;
        }
      }
      if (this.Club == ClubType.Occult) {
        component.volume = 1f - this.Darkness.color.a;
      }
    }
  }

  // Token: 0x0600017E RID: 382 RVA: 0x00019718 File Offset: 0x00017B18
  public void ClubActivity() {
    this.StudentManager.StopMoving();
    this.ShoulderCamera.enabled = false;
    this.MainCamera.enabled = false;
    this.MainCamera.transform.position = this.ClubVantages[(int)this.Club].position;
    this.MainCamera.transform.rotation = this.ClubVantages[(int)this.Club].rotation;
    if (this.Club == ClubType.Occult) {
      this.ID = 0;
      while (this.ID < this.Club3Students.Length) {
        StudentScript studentScript = this.StudentManager.Students[this.Club3Students[this.ID]];
        if (studentScript != null && !studentScript.Tranquil) {
          studentScript.gameObject.SetActive(false);
        }
        this.ID++;
      }
      this.MainCamera.GetComponent<AudioListener>().enabled = true;
      AudioSource component = base.GetComponent<AudioSource>();
      component.clip = this.OccultAmbience;
      component.loop = true;
      component.volume = 0f;
      component.Play();
      this.Yandere.gameObject.SetActive(false);
      this.Ritual.SetActive(true);
    } else if (this.Club == ClubType.MartialArts) {
      this.ID = 0;
      while (this.ID < this.Club6Students.Length) {
        StudentScript studentScript2 = this.StudentManager.Students[this.Club6Students[this.ID]];
        if (studentScript2 != null && !studentScript2.Tranquil && studentScript2.Alive) {
          studentScript2.transform.position = this.Club6ActivitySpots[this.ID].position;
          studentScript2.transform.rotation = this.Club6ActivitySpots[this.ID].rotation;
          studentScript2.ClubActivity = true;
          studentScript2.GetComponent<AudioSource>().volume = 0.1f;
          if (!studentScript2.ClubAttire) {
            studentScript2.ChangeClubwear();
          }
        }
        this.ID++;
      }
      this.Yandere.CanMove = false;
      this.Yandere.ClubActivity = true;
      this.Yandere.transform.position = this.Club6ActivitySpots[5].position;
      this.Yandere.transform.rotation = this.Club6ActivitySpots[5].rotation;
      if (!this.Yandere.ClubAttire) {
        this.Yandere.ChangeClubwear();
      }
    }
    this.Clock.SetActive(false);
    this.Reputation.SetActive(false);
    this.Heartrate.SetActive(false);
    this.Watermark.SetActive(false);
  }

  // Token: 0x0600017F RID: 383 RVA: 0x000199D4 File Offset: 0x00017DD4
  public void CheckClub(ClubType Check) {
    if (Check == ClubType.Occult) {
      this.ClubIDs = this.Club3IDs;
    } else if (Check == ClubType.MartialArts) {
      this.ClubIDs = this.Club6IDs;
    }
    this.LeaderMissing = false;
    this.LeaderDead = false;
    this.ClubMembers = 0;
    this.ID = 1;
    while (this.ID < this.ClubIDs.Length) {
      if (!StudentGlobals.GetStudentDead(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentDying(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentKidnapped(this.ClubIDs[this.ID]) && !StudentGlobals.GetStudentArrested(this.ClubIDs[this.ID]) && StudentGlobals.GetStudentReputation(this.ClubIDs[this.ID]) > -100) {
        this.ClubMembers++;
      }
      this.ID++;
    }
    if (this.TranqCase.VictimClubType == Check) {
      this.ClubMembers--;
    }
    if (ClubGlobals.Club == Check) {
      this.ClubMembers++;
    }
    if (Check == ClubType.Occult) {
      int num = 26;
      if (StudentGlobals.GetStudentDead(num) || StudentGlobals.GetStudentDying(num) || StudentGlobals.GetStudentArrested(num) || StudentGlobals.GetStudentReputation(num) <= -100) {
        this.LeaderDead = true;
      }
      if (StudentGlobals.GetStudentMissing(num) || StudentGlobals.GetStudentKidnapped(num) || this.TranqCase.VictimID == num) {
        this.LeaderMissing = true;
      }
    } else if (Check == ClubType.MartialArts) {
      int num2 = 21;
      if (StudentGlobals.GetStudentDead(num2) || StudentGlobals.GetStudentDying(num2) || StudentGlobals.GetStudentArrested(num2) || StudentGlobals.GetStudentReputation(num2) <= -100) {
        this.LeaderDead = true;
      }
      if (StudentGlobals.GetStudentMissing(num2) || StudentGlobals.GetStudentKidnapped(num2) || this.TranqCase.VictimID == num2) {
        this.LeaderMissing = true;
      }
    }
  }

  // Token: 0x06000180 RID: 384 RVA: 0x00019BE8 File Offset: 0x00017FE8
  public void CheckGrudge(ClubType Check) {
    if (Check == ClubType.Occult) {
      this.ClubIDs = this.Club3IDs;
    } else if (Check == ClubType.MartialArts) {
      this.ClubIDs = this.Club6IDs;
    }
    this.LeaderGrudge = false;
    this.ClubGrudge = false;
    this.ID = 1;
    while (this.ID < this.ClubIDs.Length) {
      if (this.StudentManager.Students[this.ClubIDs[this.ID]] != null && this.StudentManager.Students[this.ClubIDs[this.ID]].Grudge) {
        this.ClubGrudge = true;
      }
      this.ID++;
    }
    if (Check == ClubType.Occult) {
      if (this.StudentManager.Students[26].Grudge) {
        this.LeaderGrudge = true;
      }
    } else if (Check == ClubType.MartialArts && this.StudentManager.Students[21].Grudge) {
      this.LeaderGrudge = true;
    }
  }

  // Token: 0x06000181 RID: 385 RVA: 0x00019CFC File Offset: 0x000180FC
  public void ActivateClubBenefit() {
    if (ClubGlobals.Club == ClubType.Cooking) {
      this.Refrigerator.enabled = true;
      this.Refrigerator.Prompt.enabled = true;
    } else if (ClubGlobals.Club == ClubType.Drama) {
      this.ID = 1;
      while (this.ID < this.Masks.Length) {
        this.Masks[this.ID].enabled = true;
        this.Masks[this.ID].Prompt.enabled = true;
        this.ID++;
      }
      this.Gloves.enabled = true;
      this.Gloves.Prompt.enabled = true;
    } else if (ClubGlobals.Club == ClubType.Occult) {
      this.StudentManager.UpdatePerception();
      this.Yandere.Numbness -= 0.5f;
    } else if (ClubGlobals.Club == ClubType.Art) {
      this.StudentManager.UpdateBooths();
    } else if (ClubGlobals.Club == ClubType.LightMusic) {
      this.Container.enabled = true;
      this.Container.Prompt.enabled = true;
    } else if (ClubGlobals.Club == ClubType.MartialArts) {
      this.StudentManager.UpdateBooths();
    } else if (ClubGlobals.Club != ClubType.Photography) {
      if (ClubGlobals.Club == ClubType.Science) {
        this.BloodCleaner.Prompt.enabled = true;
      } else if (ClubGlobals.Club == ClubType.Sports) {
        this.Yandere.RunSpeed += 1f;
        if (this.Yandere.Armed) {
          this.Yandere.EquippedWeapon.SuspicionCheck();
        }
      } else if (ClubGlobals.Club == ClubType.Gardening) {
        this.ShedDoor.Prompt.Label[0].text = "     Open";
        this.Padlock.SetActive(false);
        this.ShedDoor.Locked = false;
        if (this.Yandere.Armed) {
          this.Yandere.EquippedWeapon.SuspicionCheck();
        }
      } else if (ClubGlobals.Club == ClubType.Gaming) {
        this.ComputerGames.EnableGames();
      }
    }
  }

  // Token: 0x06000182 RID: 386 RVA: 0x00019F48 File Offset: 0x00018348
  public void DeactivateClubBenefit() {
    if (ClubGlobals.Club == ClubType.Cooking) {
      this.Refrigerator.enabled = false;
      this.Refrigerator.Prompt.Hide();
      this.Refrigerator.Prompt.enabled = false;
    } else if (ClubGlobals.Club == ClubType.Drama) {
      this.ID = 1;
      while (this.ID < this.Masks.Length) {
        if (this.Masks[this.ID] != null) {
          this.Masks[this.ID].enabled = false;
          this.Masks[this.ID].Prompt.Hide();
          this.Masks[this.ID].Prompt.enabled = false;
        }
        this.ID++;
      }
      this.Gloves.enabled = false;
      this.Gloves.Prompt.Hide();
      this.Gloves.Prompt.enabled = false;
    } else if (ClubGlobals.Club == ClubType.Occult) {
      ClubGlobals.Club = ClubType.None;
      this.StudentManager.UpdatePerception();
      this.Yandere.Numbness += 0.5f;
    } else if (ClubGlobals.Club == ClubType.Art) {
      this.StudentManager.UpdateBooths();
    } else if (ClubGlobals.Club == ClubType.LightMusic) {
      this.Container.enabled = false;
      this.Container.Prompt.Hide();
      this.Container.Prompt.enabled = false;
    } else if (ClubGlobals.Club == ClubType.MartialArts) {
      this.StudentManager.UpdateBooths();
    } else if (ClubGlobals.Club != ClubType.Photography) {
      if (ClubGlobals.Club == ClubType.Science) {
        this.BloodCleaner.enabled = false;
        this.BloodCleaner.Prompt.Hide();
        this.BloodCleaner.Prompt.enabled = false;
      } else if (ClubGlobals.Club == ClubType.Sports) {
        this.Yandere.RunSpeed -= 1f;
        if (this.Yandere.Armed) {
          ClubGlobals.Club = ClubType.None;
          this.Yandere.EquippedWeapon.SuspicionCheck();
        }
      } else if (ClubGlobals.Club == ClubType.Gardening) {
        if (!this.Yandere.Inventory.ShedKey) {
          this.ShedDoor.Prompt.Label[0].text = "     Locked";
          this.Padlock.SetActive(true);
          this.ShedDoor.Locked = true;
        }
        if (this.Yandere.Armed) {
          ClubGlobals.Club = ClubType.None;
          this.Yandere.EquippedWeapon.SuspicionCheck();
        }
      } else if (ClubGlobals.Club == ClubType.Gaming) {
        this.ComputerGames.DeactivateAllBenefits();
        this.ComputerGames.DisableGames();
      }
    }
  }

  // Token: 0x06000183 RID: 387 RVA: 0x0001A240 File Offset: 0x00018640
  public void UpdateMasks() {
    bool flag = this.Yandere.Mask != null;
    this.ID = 1;
    while (this.ID < this.Masks.Length) {
      this.Masks[this.ID].Prompt.HideButton[0] = flag;
      this.ID++;
    }
  }

  // Token: 0x04000495 RID: 1173
  public ShoulderCameraScript ShoulderCamera;

  // Token: 0x04000496 RID: 1174
  public StudentManagerScript StudentManager;

  // Token: 0x04000497 RID: 1175
  public ComputerGamesScript ComputerGames;

  // Token: 0x04000498 RID: 1176
  public BloodCleanerScript BloodCleaner;

  // Token: 0x04000499 RID: 1177
  public RefrigeratorScript Refrigerator;

  // Token: 0x0400049A RID: 1178
  public ClubWindowScript ClubWindow;

  // Token: 0x0400049B RID: 1179
  public ContainerScript Container;

  // Token: 0x0400049C RID: 1180
  public PromptBarScript PromptBar;

  // Token: 0x0400049D RID: 1181
  public TranqCaseScript TranqCase;

  // Token: 0x0400049E RID: 1182
  public YandereScript Yandere;

  // Token: 0x0400049F RID: 1183
  public RPG_Camera MainCamera;

  // Token: 0x040004A0 RID: 1184
  public DoorScript ShedDoor;

  // Token: 0x040004A1 RID: 1185
  public PoliceScript Police;

  // Token: 0x040004A2 RID: 1186
  public GloveScript Gloves;

  // Token: 0x040004A3 RID: 1187
  public UISprite Darkness;

  // Token: 0x040004A4 RID: 1188
  public GameObject Reputation;

  // Token: 0x040004A5 RID: 1189
  public GameObject Heartrate;

  // Token: 0x040004A6 RID: 1190
  public GameObject Watermark;

  // Token: 0x040004A7 RID: 1191
  public GameObject Padlock;

  // Token: 0x040004A8 RID: 1192
  public GameObject Ritual;

  // Token: 0x040004A9 RID: 1193
  public GameObject Clock;

  // Token: 0x040004AA RID: 1194
  public AudioClip[] MotivationalQuotes;

  // Token: 0x040004AB RID: 1195
  public Transform[] ClubPatrolPoints;

  // Token: 0x040004AC RID: 1196
  public Transform[] ClubVantages;

  // Token: 0x040004AD RID: 1197
  public MaskScript[] Masks;

  // Token: 0x040004AE RID: 1198
  public Transform[] Club6ActivitySpots;

  // Token: 0x040004AF RID: 1199
  public int[] Club3Students;

  // Token: 0x040004B0 RID: 1200
  public int[] Club6Students;

  // Token: 0x040004B1 RID: 1201
  public bool ClubEffect;

  // Token: 0x040004B2 RID: 1202
  public AudioClip OccultAmbience;

  // Token: 0x040004B3 RID: 1203
  public int ClubPhase;

  // Token: 0x040004B4 RID: 1204
  public int Phase = 1;

  // Token: 0x040004B5 RID: 1205
  public ClubType Club;

  // Token: 0x040004B6 RID: 1206
  public int ID;

  // Token: 0x040004B7 RID: 1207
  public float TimeLimit;

  // Token: 0x040004B8 RID: 1208
  public float Timer;

  // Token: 0x040004B9 RID: 1209
  public ClubType[] ClubArray;

  // Token: 0x040004BA RID: 1210
  public bool LeaderMissing;

  // Token: 0x040004BB RID: 1211
  public bool LeaderDead;

  // Token: 0x040004BC RID: 1212
  public int ClubMembers;

  // Token: 0x040004BD RID: 1213
  public int[] Club3IDs;

  // Token: 0x040004BE RID: 1214
  public int[] Club6IDs;

  // Token: 0x040004BF RID: 1215
  public int[] ClubIDs;

  // Token: 0x040004C0 RID: 1216
  public bool LeaderGrudge;

  // Token: 0x040004C1 RID: 1217
  public bool ClubGrudge;
}