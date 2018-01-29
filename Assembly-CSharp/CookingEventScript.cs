using System;
using UnityEngine;

// Token: 0x02000073 RID: 115
public class CookingEventScript : MonoBehaviour {

  // Token: 0x060001A6 RID: 422 RVA: 0x0001DD50 File Offset: 0x0001C150
  private void Start() {
    this.Octodog.SetActive(false);
    this.Sausage.SetActive(false);
    this.Rotation = -90f;
    foreach (Transform transform in this.Octodogs) {
      transform.gameObject.SetActive(false);
    }
    this.EventSubtitle.transform.localScale = Vector3.zero;
    this.EventCheck = true;
  }

  // Token: 0x060001A7 RID: 423 RVA: 0x0001DDC8 File Offset: 0x0001C1C8
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
    }
    if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > this.EventTime) {
      this.EventStudent = this.StudentManager.Students[this.EventStudentID];
      if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Meeting) {
        if (!this.EventStudent.WitnessedMurder) {
          this.Snacks.Prompt.Hide();
          this.Snacks.Prompt.enabled = false;
          this.Snacks.enabled = false;
          this.EventStudent.CurrentDestination = this.EventLocations[0];
          this.EventStudent.Pathfinding.target = this.EventLocations[0];
          this.EventStudent.Obstacle.checkTime = 99f;
          this.EventStudent.CookingEvent = this;
          this.EventStudent.InEvent = true;
          this.EventStudent.Private = true;
          this.EventStudent.Prompt.Hide();
          this.EventCheck = false;
          this.EventActive = true;
          if (this.EventStudent.Following) {
            this.EventStudent.Pathfinding.canMove = true;
            this.EventStudent.Pathfinding.speed = 1f;
            this.EventStudent.Following = false;
            this.EventStudent.Routine = true;
            this.Yandere.Followers--;
            this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
            this.EventStudent.Prompt.Label[0].text = "     Talk";
          }
        } else {
          base.enabled = false;
        }
      }
    }
    if (this.EventActive) {
      if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || this.EventStudent.Yandere.Cooking) {
        this.EndEvent();
      } else if (!this.EventStudent.Pathfinding.canMove) {
        if (!ConversationGlobals.GetTopicLearnedByStudent(1, 7) && Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position) < 5f) {
          if (!ConversationGlobals.GetTopicDiscovered(1)) {
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
            ConversationGlobals.SetTopicDiscovered(1, true);
          }
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
          ConversationGlobals.SetTopicLearnedByStudent(1, 7, true);
        }
        if (this.EventPhase == -1) {
          this.Timer += Time.deltaTime;
          if (this.Timer > 5f) {
            SchemeGlobals.SetSchemeStage(4, 5);
            this.Schemes.UpdateInstructions();
            this.RivalPhone.SetActive(false);
            this.EventSubtitle.text = string.Empty;
            this.EventPhase++;
            this.Timer = 0f;
          }
        } else if (this.EventPhase == 0) {
          if (!this.RivalPhone.activeInHierarchy) {
            this.EventStudent.Character.GetComponent<Animation>().Play("f02_prepareFood_00");
            this.Octodog.transform.parent = this.EventStudent.RightHand;
            this.Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
            this.Octodog.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
            this.Sausage.transform.parent = this.EventStudent.RightHand;
            this.Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
            this.Sausage.transform.localEulerAngles = Vector3.zero;
            this.EventPhase++;
          } else {
            AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
            this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[0]);
            this.EventSubtitle.text = this.EventSpeech[0];
            this.EventPhase--;
          }
        } else if (this.EventPhase == 1) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time > 1f) {
            this.EventPhase++;
          }
        } else if (this.EventPhase == 2) {
          this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time > 3f) {
            this.Jar.transform.parent = this.EventStudent.RightHand;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 3) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time > 5f) {
            this.JarLid.transform.parent = this.EventStudent.LeftHand;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 4) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time > 6f) {
            this.JarLid.transform.parent = this.CookingClub;
            this.JarLid.transform.localPosition = new Vector3(0.334585f, 1f, -0.2528915f);
            this.JarLid.transform.localEulerAngles = new Vector3(0f, 30f, 0f);
            this.Jar.transform.parent = this.CookingClub;
            this.Jar.transform.localPosition = new Vector3(0.29559f, 1f, 0.2029152f);
            this.Jar.transform.localEulerAngles = new Vector3(0f, -150f, 0f);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 5) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time > 7f) {
            this.Knife.GetComponent<WeaponScript>().FingerprintID = this.EventStudent.StudentID;
            this.Knife.parent = this.EventStudent.LeftHand;
            this.Knife.localPosition = new Vector3(0f, -0.01f, 0f);
            this.Knife.localEulerAngles = new Vector3(0f, 0f, -90f);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 6) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time >= this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].length) {
            this.EventStudent.Character.GetComponent<Animation>().CrossFade("f02_cutFood_00");
            this.Sausage.SetActive(true);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 7) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_cutFood_00"].time > 2.66666f) {
            this.Octodog.SetActive(true);
            this.Sausage.SetActive(false);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 8) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_cutFood_00"].time > 3f) {
            this.Rotation = Mathf.MoveTowards(this.Rotation, 90f, Time.deltaTime * 360f);
            this.Octodog.transform.localEulerAngles = new Vector3(this.Rotation, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
            this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, Mathf.MoveTowards(this.Octodog.transform.localPosition.z, 0.012f, Time.deltaTime));
          }
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_cutFood_00"].time > 6f) {
            this.Octodog.SetActive(false);
            this.Octodogs[this.Loop].gameObject.SetActive(true);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 9) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_cutFood_00"].time >= this.EventStudent.Character.GetComponent<Animation>()["f02_cutFood_00"].length) {
            if (this.Loop < this.Octodogs.Length - 1) {
              this.Octodog.transform.localEulerAngles = new Vector3(-90f, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
              this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, 0.0316f);
              this.EventStudent.Character.GetComponent<Animation>()["f02_cutFood_00"].time = 0f;
              this.EventStudent.Character.GetComponent<Animation>().Play("f02_cutFood_00");
              this.Sausage.SetActive(true);
              this.EventPhase = 7;
              this.Rotation = -90f;
              this.Loop++;
            } else {
              this.EventStudent.Character.GetComponent<Animation>().Play("f02_prepareFood_00");
              this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time = this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].length;
              this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].speed = -1f;
              this.EventPhase++;
            }
          }
        } else if (this.EventPhase == 10) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time < this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 1f) {
            this.Knife.parent = this.CookingClub;
            this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
            this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 11) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time < this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 2f) {
            this.JarLid.parent = this.EventStudent.LeftHand;
            this.Jar.parent = this.EventStudent.RightHand;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 12) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time < this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 3f) {
            this.JarLid.parent = this.Jar;
            this.JarLid.localPosition = new Vector3(0f, 0.175f, 0f);
            this.JarLid.localEulerAngles = Vector3.zero;
            this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
            this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].time = this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].length;
            this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].speed = -1f;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 13) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time < this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 5f) {
            this.Jar.parent = this.CookingClub;
            this.Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
            this.Jar.localEulerAngles = new Vector3(0f, 90f, 0f);
            this.EventPhase++;
          }
        } else if (this.EventPhase == 14) {
          if (this.EventStudent.Character.GetComponent<Animation>()["f02_prepareFood_00"].time <= 0f) {
            this.Knife.GetComponent<Collider>().enabled = true;
            this.Plate.parent = this.EventStudent.RightHand;
            this.Plate.localPosition = new Vector3(0f, 0.011f, -0.156765f);
            this.Plate.localEulerAngles = new Vector3(0f, -90f, -180f);
            this.EventStudent.CurrentDestination = this.EventLocations[1];
            this.EventStudent.Pathfinding.target = this.EventLocations[1];
            this.EventStudent.Character.GetComponent<Animation>()[this.EventStudent.CarryAnim].weight = 1f;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 15) {
          this.Plate.parent = this.CookingClub;
          this.Plate.localPosition = new Vector3(-3.66666f, 0.9066666f, -2.379f);
          this.Plate.localEulerAngles = new Vector3(0f, -90f, 0f);
          this.EndEvent();
        }
        float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
        if (num < 10f) {
          float num2 = Mathf.Abs((num - 10f) * 0.2f);
          if (num2 < 0f) {
            num2 = 0f;
          }
          if (num2 > 1f) {
            num2 = 1f;
          }
          this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
        } else {
          this.EventSubtitle.transform.localScale = Vector3.zero;
        }
      }
    }
  }

  // Token: 0x060001A8 RID: 424 RVA: 0x0001EF1C File Offset: 0x0001D31C
  private void EndEvent() {
    if (!this.EventOver) {
      if (this.VoiceClip != null) {
        UnityEngine.Object.Destroy(this.VoiceClip);
      }
      this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
      this.EventStudent.Obstacle.checkTime = 1f;
      if (!this.EventStudent.Dying) {
        this.EventStudent.Prompt.enabled = true;
      }
      if (this.Plate.parent == this.EventStudent.RightHand) {
        this.Plate.parent = null;
        this.Plate.GetComponent<Rigidbody>().useGravity = true;
        this.Plate.GetComponent<BoxCollider>().enabled = true;
      }
      this.EventStudent.Character.GetComponent<Animation>()[this.EventStudent.CarryAnim].weight = 0f;
      this.EventStudent.Pathfinding.speed = 1f;
      this.EventStudent.Phone.SetActive(false);
      this.EventStudent.TargetDistance = 1f;
      this.EventStudent.PhoneEvent = null;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventSubtitle.text = string.Empty;
      if (this.Knife.parent == this.EventStudent.LeftHand) {
        this.Knife.parent = this.CookingClub;
        this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
        this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
        this.Knife.GetComponent<Collider>().enabled = true;
      }
      this.StudentManager.UpdateStudents();
    }
    this.EventActive = false;
    this.EventCheck = false;
  }

  // Token: 0x04000547 RID: 1351
  public StudentManagerScript StudentManager;

  // Token: 0x04000548 RID: 1352
  public RefrigeratorScript Snacks;

  // Token: 0x04000549 RID: 1353
  public SchemesScript Schemes;

  // Token: 0x0400054A RID: 1354
  public YandereScript Yandere;

  // Token: 0x0400054B RID: 1355
  public ClockScript Clock;

  // Token: 0x0400054C RID: 1356
  public GameObject Refrigerator;

  // Token: 0x0400054D RID: 1357
  public GameObject RivalPhone;

  // Token: 0x0400054E RID: 1358
  public GameObject Octodog;

  // Token: 0x0400054F RID: 1359
  public GameObject Sausage;

  // Token: 0x04000550 RID: 1360
  public Transform CookingClub;

  // Token: 0x04000551 RID: 1361
  public Transform JarLid;

  // Token: 0x04000552 RID: 1362
  public Transform Knife;

  // Token: 0x04000553 RID: 1363
  public Transform Plate;

  // Token: 0x04000554 RID: 1364
  public Transform Jar;

  // Token: 0x04000555 RID: 1365
  public Transform[] Octodogs;

  // Token: 0x04000556 RID: 1366
  public StudentScript EventStudent;

  // Token: 0x04000557 RID: 1367
  public UILabel EventSubtitle;

  // Token: 0x04000558 RID: 1368
  public Transform[] EventLocations;

  // Token: 0x04000559 RID: 1369
  public AudioClip[] EventClip;

  // Token: 0x0400055A RID: 1370
  public string[] EventSpeech;

  // Token: 0x0400055B RID: 1371
  public string[] EventAnim;

  // Token: 0x0400055C RID: 1372
  public int[] ClubMembers;

  // Token: 0x0400055D RID: 1373
  public GameObject VoiceClip;

  // Token: 0x0400055E RID: 1374
  public bool EventActive;

  // Token: 0x0400055F RID: 1375
  public bool EventCheck;

  // Token: 0x04000560 RID: 1376
  public bool EventOver;

  // Token: 0x04000561 RID: 1377
  public int EventStudentID;

  // Token: 0x04000562 RID: 1378
  public float EventTime = 7f;

  // Token: 0x04000563 RID: 1379
  public int EventPhase = 1;

  // Token: 0x04000564 RID: 1380
  public DayOfWeek EventDay = DayOfWeek.Tuesday;

  // Token: 0x04000565 RID: 1381
  public int Loop;

  // Token: 0x04000566 RID: 1382
  public float CurrentClipLength;

  // Token: 0x04000567 RID: 1383
  public float Rotation;

  // Token: 0x04000568 RID: 1384
  public float Timer;
}