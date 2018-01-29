using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class BatheEventScript : MonoBehaviour {

  // Token: 0x060000DB RID: 219 RVA: 0x000102B3 File Offset: 0x0000E6B3
  private void Start() {
    this.RivalPhone.SetActive(false);
    if (DateGlobals.Weekday != this.EventDay) {
      base.enabled = false;
    }
  }

  // Token: 0x060000DC RID: 220 RVA: 0x000102D8 File Offset: 0x0000E6D8
  private void Update() {
    if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime) {
      this.EventStudent = this.StudentManager.Students[7];
      if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors) {
        if (!this.EventStudent.WitnessedMurder) {
          this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
          this.EventStudent.CurrentDestination = this.StudentManager.StripSpot;
          this.EventStudent.Pathfinding.target = this.StudentManager.StripSpot;
          this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.WalkAnim);
          this.EventStudent.Pathfinding.canSearch = true;
          this.EventStudent.Pathfinding.canMove = true;
          this.EventStudent.Pathfinding.speed = 1f;
          this.EventStudent.DistanceToDestination = 100f;
          this.EventStudent.Obstacle.checkTime = 99f;
          this.EventStudent.InEvent = true;
          this.EventStudent.Private = true;
          this.EventStudent.Prompt.Hide();
          this.EventStudent.Hearts.Stop();
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
      if (this.Clock.HourTime > this.EventTime + 1f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive) {
        this.EndEvent();
      } else {
        if (this.EventStudent.DistanceToDestination < 0.5f) {
          if (this.EventPhase == 1) {
            this.EventStudent.Routine = false;
            this.EventStudent.BathePhase = 1;
            this.EventStudent.Wet = true;
            this.EventPhase++;
          } else if (this.EventPhase == 2) {
            if (this.EventStudent.BathePhase == 4) {
              this.RivalPhone.SetActive(true);
              this.EventPhase++;
            }
          } else if (this.EventPhase == 3 && !this.EventStudent.Wet) {
            if (!this.RivalPhone.activeInHierarchy) {
              this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[0]);
              this.EventStudent.Pathfinding.canSearch = false;
              this.EventStudent.Pathfinding.canMove = false;
              this.EventStudent.Routine = false;
              this.StudentManager.CommunalLocker.Open = true;
              this.EventSubtitle.text = this.EventSpeech[0];
              AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
              this.EventPhase++;
            } else {
              this.EndEvent();
            }
          }
        }
        if (this.EventPhase == 4) {
          this.Timer += Time.deltaTime;
          if (this.Timer > this.CurrentClipLength + 1f) {
            this.EventStudent.Routine = true;
            this.EndEvent();
          }
        }
        float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
        if (num < 11f) {
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
  }

  // Token: 0x060000DD RID: 221 RVA: 0x0001082C File Offset: 0x0000EC2C
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
        this.EventStudent.Pathfinding.canSearch = true;
        this.EventStudent.Pathfinding.canMove = true;
        this.EventStudent.Pathfinding.speed = 1f;
        this.EventStudent.TargetDistance = 1f;
        this.EventStudent.Private = false;
      }
      this.EventStudent.InEvent = false;
      this.EventSubtitle.text = string.Empty;
      this.StudentManager.UpdateStudents();
    }
    this.EventActive = false;
    base.enabled = false;
  }

  // Token: 0x04000314 RID: 788
  public StudentManagerScript StudentManager;

  // Token: 0x04000315 RID: 789
  public YandereScript Yandere;

  // Token: 0x04000316 RID: 790
  public ClockScript Clock;

  // Token: 0x04000317 RID: 791
  public StudentScript EventStudent;

  // Token: 0x04000318 RID: 792
  public UILabel EventSubtitle;

  // Token: 0x04000319 RID: 793
  public AudioClip[] EventClip;

  // Token: 0x0400031A RID: 794
  public string[] EventSpeech;

  // Token: 0x0400031B RID: 795
  public string[] EventAnim;

  // Token: 0x0400031C RID: 796
  public GameObject RivalPhone;

  // Token: 0x0400031D RID: 797
  public GameObject VoiceClip;

  // Token: 0x0400031E RID: 798
  public bool EventActive;

  // Token: 0x0400031F RID: 799
  public bool EventOver;

  // Token: 0x04000320 RID: 800
  public float EventTime = 15.1f;

  // Token: 0x04000321 RID: 801
  public int EventPhase = 1;

  // Token: 0x04000322 RID: 802
  public DayOfWeek EventDay = DayOfWeek.Thursday;

  // Token: 0x04000323 RID: 803
  public Vector3 OriginalPosition;

  // Token: 0x04000324 RID: 804
  public float CurrentClipLength;

  // Token: 0x04000325 RID: 805
  public float Timer;
}