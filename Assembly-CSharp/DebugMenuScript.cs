using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000080 RID: 128
public class DebugMenuScript : MonoBehaviour {

  // Token: 0x06000204 RID: 516 RVA: 0x0002897C File Offset: 0x00026D7C
  private void Start() {
    base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z);
    this.Window.SetActive(false);
    if (MissionModeGlobals.MissionMode) {
      this.MissionMode = true;
    }
    if (GameGlobals.LoveSick) {
      this.NoDebug = true;
    }
  }

  // Token: 0x06000205 RID: 517 RVA: 0x000289F4 File Offset: 0x00026DF4
  private void Update() {
    if (!this.MissionMode && !this.NoDebug) {
      if (!this.Yandere.InClass && !this.Yandere.Chased && this.Yandere.CanMove) {
        if (Input.GetKeyDown(KeyCode.Backslash) && this.Yandere.transform.position.y < 100f) {
          this.EasterEggWindow.SetActive(false);
          this.Window.SetActive(!this.Window.activeInHierarchy);
        }
      } else if (this.Window.activeInHierarchy) {
        this.Window.SetActive(false);
      }
      if (this.Window.activeInHierarchy) {
        if (Input.GetKeyDown(KeyCode.F1)) {
          StudentGlobals.FemaleUniform = 1;
          StudentGlobals.MaleUniform = 1;
          SceneManager.LoadScene("LoadingScene");
        } else if (Input.GetKeyDown(KeyCode.F2)) {
          StudentGlobals.FemaleUniform = 2;
          StudentGlobals.MaleUniform = 2;
          SceneManager.LoadScene("LoadingScene");
        } else if (Input.GetKeyDown(KeyCode.F3)) {
          StudentGlobals.FemaleUniform = 3;
          StudentGlobals.MaleUniform = 3;
          SceneManager.LoadScene("LoadingScene");
        } else if (Input.GetKeyDown(KeyCode.F4)) {
          StudentGlobals.FemaleUniform = 4;
          StudentGlobals.MaleUniform = 4;
          SceneManager.LoadScene("LoadingScene");
        } else if (Input.GetKeyDown(KeyCode.F5)) {
          StudentGlobals.FemaleUniform = 5;
          StudentGlobals.MaleUniform = 5;
          SceneManager.LoadScene("LoadingScene");
        } else if (Input.GetKeyDown(KeyCode.F6)) {
          StudentGlobals.FemaleUniform = 6;
          StudentGlobals.MaleUniform = 6;
          SceneManager.LoadScene("LoadingScene");
        } else if (!Input.GetKeyDown(KeyCode.F12)) {
          if (Input.GetKeyDown(KeyCode.Alpha1)) {
            DateGlobals.Weekday = DayOfWeek.Monday;
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            DateGlobals.Weekday = DayOfWeek.Tuesday;
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            DateGlobals.Weekday = DayOfWeek.Wednesday;
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            DateGlobals.Weekday = DayOfWeek.Thursday;
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            DateGlobals.Weekday = DayOfWeek.Friday;
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            this.Yandere.transform.position = this.TeleportSpot[1].position;
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            this.Yandere.transform.position = this.TeleportSpot[2].position + new Vector3(0.75f, 0f, 0f);
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            this.Yandere.transform.position = this.TeleportSpot[3].position;
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.Alpha9)) {
            this.Yandere.transform.position = this.TeleportSpot[4].position;
            this.Window.SetActive(false);
            if (this.Clock.HourTime < 7.1f) {
              this.Clock.PresentTime = 426f;
              StudentScript studentScript = this.StudentManager.Students[7];
              if (studentScript != null) {
                if (studentScript.Phase < 2) {
                  studentScript.ShoeRemoval.Start();
                  studentScript.ShoeRemoval.PutOnShoes();
                  studentScript.CanTalk = true;
                  studentScript.Phase = 2;
                  studentScript.CurrentDestination = studentScript.Destinations[2];
                  studentScript.Pathfinding.target = studentScript.Destinations[2];
                }
                studentScript.transform.position = studentScript.Destinations[2].position;
              }
              StudentScript studentScript2 = this.StudentManager.Students[13];
              if (studentScript2 != null) {
                if (studentScript2.Phase < 2) {
                  studentScript2.ShoeRemoval.Start();
                  studentScript2.ShoeRemoval.PutOnShoes();
                  studentScript2.Phase = 2;
                  studentScript2.CurrentDestination = studentScript2.Destinations[2];
                  studentScript2.Pathfinding.target = studentScript2.Destinations[2];
                }
                studentScript2.transform.position = studentScript2.Destinations[2].position;
              }
              StudentScript studentScript3 = this.StudentManager.Students[16];
              if (studentScript3 != null) {
                if (studentScript3.Phase < 2) {
                  studentScript3.ShoeRemoval.Start();
                  studentScript3.ShoeRemoval.PutOnShoes();
                  studentScript3.Phase = 2;
                  studentScript3.CurrentDestination = studentScript3.Destinations[2];
                  studentScript3.Pathfinding.target = studentScript3.Destinations[2];
                }
                studentScript3.transform.position = studentScript3.Destinations[2].position;
              }
            }
          } else if (Input.GetKeyDown(KeyCode.Alpha0)) {
            this.CameraEffects.DisableCamera();
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.A)) {
            if (SchoolAtmosphere.Type == SchoolAtmosphereType.High) {
              SchoolGlobals.SchoolAtmosphere = 0.5f;
            } else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium) {
              SchoolGlobals.SchoolAtmosphere = 0f;
            } else {
              SchoolGlobals.SchoolAtmosphere = 1f;
            }
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.C)) {
            this.ID = 1;
            while (this.ID < 11) {
              CollectibleGlobals.SetTapeCollected(this.ID, true);
              this.ID++;
            }
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.F)) {
            this.FakeStudentSpawner.Spawn();
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.G)) {
            StudentScript studentScript4 = this.StudentManager.Students[this.RooftopStudent];
            if (this.Clock.HourTime < 15f) {
              PlayerGlobals.SetStudentFriend(this.RooftopStudent, true);
              this.Yandere.transform.position = this.RooftopSpot.position + new Vector3(1f, 0f, 0f);
              this.WeaponManager.Weapons[6].transform.position = this.Yandere.transform.position + new Vector3(0f, 0f, 1.915f);
              if (studentScript4 != null) {
                this.StudentManager.OfferHelp.UpdateLocation();
                this.StudentManager.OfferHelp.enabled = true;
                if (!studentScript4.Indoors) {
                  if (studentScript4.ShoeRemoval.Locker == null) {
                    studentScript4.ShoeRemoval.Start();
                  }
                  studentScript4.ShoeRemoval.PutOnShoes();
                }
                studentScript4.CharacterAnimation.Play(studentScript4.IdleAnim);
                studentScript4.transform.position = this.RooftopSpot.position;
                studentScript4.transform.rotation = this.RooftopSpot.rotation;
                studentScript4.Prompt.Label[0].text = "     Push";
                studentScript4.CurrentDestination = this.RooftopSpot;
                studentScript4.Pathfinding.target = this.RooftopSpot;
                studentScript4.Pathfinding.canSearch = false;
                studentScript4.Pathfinding.canMove = false;
                studentScript4.SpeechLines.Stop();
                studentScript4.Pushable = true;
                studentScript4.Routine = false;
                studentScript4.Meeting = true;
                studentScript4.MeetTime = 0f;
              }
              if (this.Clock.HourTime < 7.1f) {
                this.Clock.PresentTime = 426f;
              }
            } else {
              this.Clock.PresentTime = 960f;
              studentScript4.transform.position = this.Lockers.position;
            }
            this.Window.SetActive(false);
          } else if (Input.GetKeyDown(KeyCode.K)) {
            SchoolGlobals.KidnapVictim = 6;
            StudentGlobals.SetStudentSlave(6, true);
            SceneManager.LoadScene("LoadingScene");
          } else if (Input.GetKeyDown(KeyCode.L)) {
            EventGlobals.Event1 = true;
            this.Window.SetActive(false);
          } else if (!Input.GetKeyDown(KeyCode.M)) {
            if (Input.GetKeyDown(KeyCode.O)) {
              this.Yandere.Inventory.RivalPhone = true;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.P)) {
              PlayerGlobals.PantyShots += 20;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.Q)) {
              this.Censor();
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.R)) {
              if (PlayerGlobals.Reputation != 66.66666f) {
                PlayerGlobals.Reputation = 66.66666f;
                this.Reputation.Reputation = PlayerGlobals.Reputation;
              } else {
                PlayerGlobals.Reputation = -66.66666f;
                this.Reputation.Reputation = PlayerGlobals.Reputation;
              }
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.S)) {
              ClassGlobals.PhysicalGrade = 5;
              PlayerGlobals.Seduction = 5;
              this.ID = 1;
              while (this.ID < 101) {
                StudentGlobals.SetStudentPhotographed(this.ID, true);
                this.ID++;
              }
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.T)) {
              this.Zoom.OverShoulder = !this.Zoom.OverShoulder;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.U)) {
              PlayerGlobals.SetStudentFriend(7, true);
              PlayerGlobals.SetStudentFriend(13, true);
              this.ID = 1;
              while (this.ID < 26) {
                ConversationGlobals.SetTopicLearnedByStudent(this.ID, 7, true);
                ConversationGlobals.SetTopicDiscovered(this.ID, true);
                this.ID++;
              }
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.Y)) {
              this.DelinquentManager.Delinquents.SetActive(!this.DelinquentManager.Delinquents.activeInHierarchy);
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.Z)) {
              if (Input.GetKey(KeyCode.LeftShift)) {
                this.ID = 2;
                while (this.ID < 93) {
                  StudentScript x = this.StudentManager.Students[this.ID];
                  if (x != null) {
                    StudentGlobals.SetStudentMissing(this.ID, true);
                  }
                  this.ID++;
                }
              } else {
                this.ID = 2;
                while (this.ID < 101) {
                  StudentScript studentScript5 = this.StudentManager.Students[this.ID];
                  if (studentScript5 != null && studentScript5.Club != ClubType.Council) {
                    studentScript5.SpawnAlarmDisc();
                    studentScript5.BecomeRagdoll();
                    studentScript5.DeathType = DeathType.EasterEgg;
                    StudentGlobals.SetStudentDead(this.ID, true);
                  }
                  this.ID++;
                }
              }
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.X)) {
              OptionGlobals.HighPopulation = !OptionGlobals.HighPopulation;
              SceneManager.LoadScene("LoadingScene");
            } else if (Input.GetKeyDown(KeyCode.Backspace)) {
              Time.timeScale = 1f;
              this.Clock.PresentTime = 1079f;
              this.Clock.HourTime = this.Clock.PresentTime / 60f;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.BackQuote)) {
              Globals.DeleteAll();
              SceneManager.LoadScene("LoadingScene");
            } else if (Input.GetKeyDown(KeyCode.Space)) {
              this.Yandere.transform.position = this.TeleportSpot[5].position;
              if (this.StudentManager.Students[21] != null) {
                this.StudentManager.Students[21].transform.position = this.TeleportSpot[5].position;
              }
              this.Clock.PresentTime = 1015f;
              this.Clock.HourTime = this.Clock.PresentTime / 60f;
              this.Window.SetActive(false);
              this.OsanaEvent1.enabled = false;
              this.OsanaEvent2.enabled = false;
              this.OsanaEvent3.enabled = false;
            } else if (Input.GetKeyDown(KeyCode.LeftAlt)) {
              this.Turtle.SpawnWeapons();
              this.Yandere.transform.position = this.TeleportSpot[6].position;
              this.Clock.PresentTime = 425f;
              this.Clock.HourTime = this.Clock.PresentTime / 60f;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.LeftControl)) {
              this.Yandere.transform.position = this.TeleportSpot[7].position;
              if (this.StudentManager.Students[26] != null) {
                this.StudentManager.Students[26].transform.position = this.TeleportSpot[7].position;
              }
              this.Clock.PresentTime = 1015f;
              this.Clock.HourTime = this.Clock.PresentTime / 60f;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.RightControl)) {
              this.Yandere.transform.position = this.TeleportSpot[8].position;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.Equals)) {
              this.DelinquentManager.Timer -= 30f;
              this.Clock.PresentTime += 30f;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.Return)) {
              this.Yandere.transform.eulerAngles = this.TeleportSpot[10].eulerAngles;
              this.Yandere.transform.position = this.TeleportSpot[10].position;
              this.StudentManager.Students[1].ShoeRemoval.Start();
              this.StudentManager.Students[1].ShoeRemoval.PutOnShoes();
              this.StudentManager.Students[1].transform.position = new Vector3(0f, 12.1f, -25f);
              this.StudentManager.Students[1].Alarmed = true;
              this.StudentManager.Students[33].Lethal = true;
              this.StudentManager.Students[33].ShoeRemoval.Start();
              this.StudentManager.Students[33].ShoeRemoval.PutOnShoes();
              this.StudentManager.Students[33].transform.position = new Vector3(0f, 12.1f, -25f);
              this.Clock.PresentTime = 780f;
              this.Clock.HourTime = this.Clock.PresentTime / 60f;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.B)) {
              DatingGlobals.SuitorProgress = 2;
              SceneManager.LoadScene("LoadingScene");
            } else if (Input.GetKeyDown(KeyCode.Pause)) {
              this.Clock.StopTime = !this.Clock.StopTime;
              this.Window.SetActive(false);
            } else if (Input.GetKeyDown(KeyCode.W)) {
              this.StudentManager.ToggleBookBags();
              this.Window.SetActive(false);
            }
          }
        }
      } else if (Input.GetKeyDown(KeyCode.BackQuote)) {
        this.ID = 0;
        while (this.ID < this.StudentManager.NPCsTotal) {
          if (StudentGlobals.GetStudentDying(this.ID)) {
            StudentGlobals.SetStudentDying(this.ID, false);
          }
          this.ID++;
        }
        SceneManager.LoadScene("LoadingScene");
      }
    } else if (Input.GetKeyDown(KeyCode.Backslash)) {
      this.Censor();
    }
  }

  // Token: 0x06000206 RID: 518 RVA: 0x00029B34 File Offset: 0x00027F34
  public void Censor() {
    if (!this.StudentManager.Censor) {
      if (this.Yandere.Schoolwear == 1 && !this.Yandere.Sans) {
        if (!this.Yandere.FlameDemonic && !this.Yandere.TornadoHair.activeInHierarchy) {
          this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
          this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
        } else {
          this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
          this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
          this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
          this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
        }
      }
      this.StudentManager.Censor = true;
      this.StudentManager.CensorStudents();
    } else {
      this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
      this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
      this.StudentManager.Censor = false;
      this.StudentManager.CensorStudents();
    }
  }

  // Token: 0x06000207 RID: 519 RVA: 0x00029CF9 File Offset: 0x000280F9
  public void UpdateCensor() {
    this.Censor();
    this.Censor();
  }

  // Token: 0x040006D0 RID: 1744
  public FakeStudentSpawnerScript FakeStudentSpawner;

  // Token: 0x040006D1 RID: 1745
  public DelinquentManagerScript DelinquentManager;

  // Token: 0x040006D2 RID: 1746
  public StudentManagerScript StudentManager;

  // Token: 0x040006D3 RID: 1747
  public CameraEffectsScript CameraEffects;

  // Token: 0x040006D4 RID: 1748
  public WeaponManagerScript WeaponManager;

  // Token: 0x040006D5 RID: 1749
  public ReputationScript Reputation;

  // Token: 0x040006D6 RID: 1750
  public YandereScript Yandere;

  // Token: 0x040006D7 RID: 1751
  public BentoScript Bento;

  // Token: 0x040006D8 RID: 1752
  public ClockScript Clock;

  // Token: 0x040006D9 RID: 1753
  public PrayScript Turtle;

  // Token: 0x040006DA RID: 1754
  public ZoomScript Zoom;

  // Token: 0x040006DB RID: 1755
  public AstarPath Astar;

  // Token: 0x040006DC RID: 1756
  public OsanaFridayBeforeClassEvent1Script OsanaEvent1;

  // Token: 0x040006DD RID: 1757
  public OsanaFridayBeforeClassEvent2Script OsanaEvent2;

  // Token: 0x040006DE RID: 1758
  public OsanaFridayLunchEventScript OsanaEvent3;

  // Token: 0x040006DF RID: 1759
  public GameObject EasterEggWindow;

  // Token: 0x040006E0 RID: 1760
  public GameObject SacrificialArm;

  // Token: 0x040006E1 RID: 1761
  public GameObject CircularSaw;

  // Token: 0x040006E2 RID: 1762
  public GameObject Knife;

  // Token: 0x040006E3 RID: 1763
  public Transform[] TeleportSpot;

  // Token: 0x040006E4 RID: 1764
  public Transform RooftopSpot;

  // Token: 0x040006E5 RID: 1765
  public Transform Lockers;

  // Token: 0x040006E6 RID: 1766
  public GameObject Window;

  // Token: 0x040006E7 RID: 1767
  public bool MissionMode;

  // Token: 0x040006E8 RID: 1768
  public bool NoDebug;

  // Token: 0x040006E9 RID: 1769
  public int RooftopStudent = 7;

  // Token: 0x040006EA RID: 1770
  public int ID;

  // Token: 0x040006EB RID: 1771
  public Texture PantyCensorTexture;
}