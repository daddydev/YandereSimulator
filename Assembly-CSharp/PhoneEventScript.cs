using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
public class PhoneEventScript : MonoBehaviour {

  // Token: 0x06000637 RID: 1591 RVA: 0x00058DD8 File Offset: 0x000571D8
  private void Start() {
    this.EventSubtitle.transform.localScale = Vector3.zero;
    if (DateGlobals.Weekday == this.EventDay) {
      this.EventCheck = true;
    }
    if (HomeGlobals.LateForSchool || this.StudentManager.YandereLate) {
      base.enabled = false;
    }
  }

  // Token: 0x06000638 RID: 1592 RVA: 0x00058E34 File Offset: 0x00057234
  private void Update() {
    if (!this.Clock.StopTime && this.EventCheck) {
      if (this.Clock.HourTime > this.EventTime + 0.5f) {
        base.enabled = false;
      } else if (this.Clock.HourTime > this.EventTime) {
        this.EventStudent = this.StudentManager.Students[this.EventStudentID];
        if (this.EventStudent != null && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors) {
          if (!this.EventStudent.WitnessedMurder) {
            this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
            this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
            this.EventStudent.Obstacle.checkTime = 99f;
            this.EventStudent.SpeechLines.Stop();
            this.EventStudent.PhoneEvent = this;
            this.EventStudent.CanTalk = false;
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
    }
    if (this.EventActive) {
      if (this.EventStudent.DistanceToDestination < 0.5f) {
        this.EventStudent.Pathfinding.canSearch = false;
        this.EventStudent.Pathfinding.canMove = false;
      }
      if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive) {
        this.EndEvent();
      } else if (!this.EventStudent.Pathfinding.canMove) {
        if (this.EventPhase == 1) {
          this.Timer += Time.deltaTime;
          this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[0]);
          AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
          this.EventPhase++;
        } else if (this.EventPhase == 2) {
          this.Timer += Time.deltaTime;
          if (this.Timer > 1.5f) {
            if (this.EventStudent.StudentID == 33) {
              this.EventStudent.SmartPhone.SetActive(true);
            } else {
              this.EventStudent.Phone.SetActive(true);
            }
          }
          if (this.Timer > 3f) {
            AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
            this.EventSubtitle.text = this.EventSpeech[1];
            this.Timer = 0f;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 3) {
          this.Timer += Time.deltaTime;
          if (this.Timer > this.CurrentClipLength) {
            this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.RunAnim);
            this.EventStudent.CurrentDestination = this.EventLocation;
            this.EventStudent.Pathfinding.target = this.EventLocation;
            this.EventStudent.Pathfinding.canSearch = true;
            this.EventStudent.Pathfinding.canMove = true;
            this.EventStudent.Pathfinding.speed = 4f;
            this.EventSubtitle.text = string.Empty;
            this.Timer = 0f;
            this.EventPhase++;
          }
        } else if (this.EventPhase == 4) {
          this.DumpPoint.enabled = true;
          this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
          AudioClipPlayer.Play(this.EventClip[2], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
          this.EventPhase++;
        } else if (this.EventPhase < 13) {
          if (this.VoiceClip != null) {
            this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
            this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time = this.VoiceClip.GetComponent<AudioSource>().time;
            if (this.VoiceClip.GetComponent<AudioSource>().time > this.SpeechTimes[this.EventPhase - 3]) {
              this.EventSubtitle.text = this.EventSpeech[this.EventPhase - 3];
              this.EventPhase++;
            }
          }
        } else {
          if (this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length * 90.33333f) {
            if (this.EventStudent.StudentID == 33) {
              this.EventStudent.SmartPhone.SetActive(true);
            } else {
              this.EventStudent.Phone.SetActive(true);
            }
          }
          if (this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length) {
            this.EndEvent();
          }
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
        if (this.EventPhase == 11 && num < 5f && !EventGlobals.Event2) {
          EventGlobals.Event2 = true;
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
          ConversationGlobals.SetTopicDiscovered(25, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
          ConversationGlobals.SetTopicLearnedByStudent(25, this.EventStudentID, true);
        }
      }
    }
  }

  // Token: 0x06000639 RID: 1593 RVA: 0x00059698 File Offset: 0x00057A98
  private void EndEvent() {
    Debug.Log("Osana's phone event ended.");
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
      this.EventStudent.SmartPhone.SetActive(false);
      this.EventStudent.Pathfinding.speed = 1f;
      this.EventStudent.Phone.SetActive(false);
      this.EventStudent.TargetDistance = 1f;
      this.EventStudent.PhoneEvent = null;
      this.EventStudent.InEvent = false;
      this.EventStudent.Private = false;
      this.EventStudent.CanTalk = true;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
      this.DumpPoint.enabled = false;
      this.DumpPoint.Prompt.Hide();
      this.DumpPoint.Prompt.enabled = false;
    }
    this.EventActive = false;
    this.EventCheck = false;
  }

  // Token: 0x04000F12 RID: 3858
  public StudentManagerScript StudentManager;

  // Token: 0x04000F13 RID: 3859
  public BucketPourScript DumpPoint;

  // Token: 0x04000F14 RID: 3860
  public YandereScript Yandere;

  // Token: 0x04000F15 RID: 3861
  public ClockScript Clock;

  // Token: 0x04000F16 RID: 3862
  public StudentScript EventStudent;

  // Token: 0x04000F17 RID: 3863
  public UILabel EventSubtitle;

  // Token: 0x04000F18 RID: 3864
  public Transform EventLocation;

  // Token: 0x04000F19 RID: 3865
  public AudioClip[] EventClip;

  // Token: 0x04000F1A RID: 3866
  public string[] EventSpeech;

  // Token: 0x04000F1B RID: 3867
  public float[] SpeechTimes;

  // Token: 0x04000F1C RID: 3868
  public string[] EventAnim;

  // Token: 0x04000F1D RID: 3869
  public GameObject VoiceClip;

  // Token: 0x04000F1E RID: 3870
  public bool EventActive;

  // Token: 0x04000F1F RID: 3871
  public bool EventCheck;

  // Token: 0x04000F20 RID: 3872
  public bool EventOver;

  // Token: 0x04000F21 RID: 3873
  public int EventStudentID = 7;

  // Token: 0x04000F22 RID: 3874
  public float EventTime = 7.5f;

  // Token: 0x04000F23 RID: 3875
  public int EventPhase = 1;

  // Token: 0x04000F24 RID: 3876
  public DayOfWeek EventDay = DayOfWeek.Monday;

  // Token: 0x04000F25 RID: 3877
  public float CurrentClipLength;

  // Token: 0x04000F26 RID: 3878
  public float FailSafe;

  // Token: 0x04000F27 RID: 3879
  public float Timer;
}