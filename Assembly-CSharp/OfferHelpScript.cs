using UnityEngine;

// Token: 0x02000146 RID: 326
public class OfferHelpScript : MonoBehaviour {

  // Token: 0x0600060D RID: 1549 RVA: 0x00055371 File Offset: 0x00053771
  private void Start() {
    this.Prompt.enabled = true;
  }

  // Token: 0x0600060E RID: 1550 RVA: 0x00055380 File Offset: 0x00053780
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Jukebox.Dip = 0.1f;
      this.Yandere.EmptyHands();
      this.Yandere.CanMove = false;
      this.Student = this.StudentManager.Students[7];
      this.Student.Prompt.Label[0].text = "     Talk";
      this.Student.Pushable = false;
      this.Student.Meeting = false;
      this.Student.Routine = false;
      this.Student.MeetTimer = 0f;
      this.Offering = true;
    }
    if (this.Offering) {
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, base.transform.rotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(base.transform.position + Vector3.down);
      Quaternion b = Quaternion.LookRotation(this.Yandere.transform.position - this.Student.transform.position);
      this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, b, Time.deltaTime * 10f);
      Animation component = this.Yandere.Character.GetComponent<Animation>();
      Animation component2 = this.Student.Character.GetComponent<Animation>();
      if (!this.Spoken) {
        if (this.EventSpeaker[this.EventPhase] == 1) {
          component.CrossFade(this.EventAnim[this.EventPhase]);
          component2.CrossFade(this.Student.IdleAnim, 1f);
        } else {
          component2.CrossFade(this.EventAnim[this.EventPhase]);
          component.CrossFade(this.Yandere.IdleAnim, 1f);
        }
        this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
        this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
        AudioSource component3 = base.GetComponent<AudioSource>();
        component3.clip = this.EventClip[this.EventPhase];
        component3.Play();
        this.Spoken = true;
      } else {
        if (Input.GetButtonDown("A")) {
          this.Timer += this.EventClip[this.EventPhase].length + 1f;
        }
        if (this.EventSpeaker[this.EventPhase] == 1) {
          if (component[this.EventAnim[this.EventPhase]].time >= component[this.EventAnim[this.EventPhase]].length) {
            component.CrossFade(this.Yandere.IdleAnim);
          }
        } else if (component2[this.EventAnim[this.EventPhase]].time >= component2[this.EventAnim[this.EventPhase]].length) {
          component2.CrossFade(this.Student.IdleAnim);
        }
        this.Timer += Time.deltaTime;
        if (this.Timer > this.EventClip[this.EventPhase].length) {
          this.EventSubtitle.text = string.Empty;
        }
        if (this.Timer > this.EventClip[this.EventPhase].length + 1f) {
          this.Spoken = false;
          this.EventPhase++;
          this.Timer = 0f;
          if (this.EventPhase == 14) {
            if (!ConversationGlobals.GetTopicDiscovered(23)) {
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
              ConversationGlobals.SetTopicDiscovered(23, true);
            }
            if (!ConversationGlobals.GetTopicLearnedByStudent(23, 7)) {
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
              ConversationGlobals.SetTopicLearnedByStudent(23, 7, true);
            }
          }
          if (this.EventPhase == this.EventSpeech.Length) {
            SchemeGlobals.SetSchemeStage(6, 5);
            this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
            this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase];
            this.Student.Pathfinding.canSearch = true;
            this.Student.Pathfinding.canMove = true;
            this.Student.Routine = true;
            this.EventSubtitle.transform.localScale = Vector3.zero;
            this.Yandere.CanMove = true;
            this.Jukebox.Dip = 1f;
            UnityEngine.Object.Destroy(base.gameObject);
          }
        }
      }
    } else if (this.StudentManager.Students[7].Pushed || !this.StudentManager.Students[7].Alive) {
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x0600060F RID: 1551 RVA: 0x000558BC File Offset: 0x00053CBC
  public void UpdateLocation() {
    this.Student = this.StudentManager.Students[7];
    if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[8]) {
      base.transform.position = this.Locations[1].position;
      base.transform.eulerAngles = this.Locations[1].eulerAngles;
    } else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[9]) {
      base.transform.position = this.Locations[2].position;
      base.transform.eulerAngles = this.Locations[2].eulerAngles;
    } else if (this.Student.CurrentDestination == this.StudentManager.MeetSpots.List[10]) {
      base.transform.position = this.Locations[3].position;
      base.transform.eulerAngles = this.Locations[3].eulerAngles;
    }
  }

  // Token: 0x04000E85 RID: 3717
  public StudentManagerScript StudentManager;

  // Token: 0x04000E86 RID: 3718
  public JukeboxScript Jukebox;

  // Token: 0x04000E87 RID: 3719
  public StudentScript Student;

  // Token: 0x04000E88 RID: 3720
  public YandereScript Yandere;

  // Token: 0x04000E89 RID: 3721
  public PromptScript Prompt;

  // Token: 0x04000E8A RID: 3722
  public UILabel EventSubtitle;

  // Token: 0x04000E8B RID: 3723
  public Transform[] Locations;

  // Token: 0x04000E8C RID: 3724
  public AudioClip[] EventClip;

  // Token: 0x04000E8D RID: 3725
  public string[] EventSpeech;

  // Token: 0x04000E8E RID: 3726
  public string[] EventAnim;

  // Token: 0x04000E8F RID: 3727
  public int[] EventSpeaker;

  // Token: 0x04000E90 RID: 3728
  public bool Offering;

  // Token: 0x04000E91 RID: 3729
  public bool Spoken;

  // Token: 0x04000E92 RID: 3730
  public int EventPhase = 1;

  // Token: 0x04000E93 RID: 3731
  public float Timer;
}