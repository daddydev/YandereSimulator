using UnityEngine;

// Token: 0x0200013E RID: 318
public class NoteLockerScript : MonoBehaviour {

  // Token: 0x060005F1 RID: 1521 RVA: 0x000533AC File Offset: 0x000517AC
  private void Start() {
    if (StudentGlobals.GetStudentDead(this.LockerOwner)) {
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x060005F2 RID: 1522 RVA: 0x000533CC File Offset: 0x000517CC
  private void Update() {
    if (this.Student != null) {
      Vector3 b = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
      if (this.Prompt.enabled) {
        if (Vector3.Distance(this.Student.transform.position, b) < 1f || this.Yandere.Armed) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      } else if (this.CanLeaveNote && Vector3.Distance(this.Student.transform.position, b) > 1f && !this.Yandere.Armed) {
        this.Prompt.enabled = true;
      }
    } else {
      this.Student = this.StudentManager.Students[this.LockerOwner];
    }
    if (this.Prompt != null && this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.NoteWindow.NoteLocker = this;
      this.Yandere.Blur.enabled = true;
      this.NoteWindow.gameObject.SetActive(true);
      this.Yandere.CanMove = false;
      this.NoteWindow.Show = true;
      this.Yandere.HUD.alpha = 0f;
      this.PromptBar.Show = true;
      Time.timeScale = 0f;
      this.PromptBar.Label[0].text = "Confirm";
      this.PromptBar.Label[1].text = "Cancel";
      this.PromptBar.Label[4].text = "Select";
      this.PromptBar.UpdateButtons();
    }
    if (this.NoteLeft) {
      if (this.Student != null && (this.Student.Phase == 2 || this.Student.Phase == 7) && this.Student.Routine && Vector3.Distance(base.transform.position, this.Student.transform.position) < 2f && !this.Student.InEvent) {
        this.Student.Character.GetComponent<Animation>().cullingType = AnimationCullingType.AlwaysAnimate;
        if (!this.Success) {
          this.Student.Character.GetComponent<Animation>().CrossFade("f02_tossNote_00");
          this.Locker.GetComponent<Animation>().CrossFade("lockerTossNote");
        } else {
          this.Student.Character.GetComponent<Animation>().CrossFade("f02_keepNote_00");
          this.Locker.GetComponent<Animation>().CrossFade("lockerKeepNote");
        }
        this.Student.Pathfinding.canSearch = false;
        this.Student.Pathfinding.canMove = false;
        this.Student.CheckingNote = true;
        this.Student.Routine = false;
        this.Student.InEvent = true;
        this.CheckingNote = true;
      }
      if (this.CheckingNote) {
        this.Timer += Time.deltaTime;
        this.Student.MoveTowardsTarget(this.Student.MyLocker.position);
        this.Student.transform.rotation = Quaternion.Slerp(this.Student.transform.rotation, this.Student.MyLocker.rotation, 10f * Time.deltaTime);
        if (this.Student != null) {
          Animation component = this.Student.Character.GetComponent<Animation>();
          if (component["f02_tossNote_00"].time >= component["f02_tossNote_00"].length) {
            this.Finish();
          }
          if (component["f02_keepNote_00"].time >= component["f02_keepNote_00"].length) {
            this.DetermineSchedule();
            this.Finish();
          }
        }
        if (this.Timer > 4.66666651f && this.NewNote == null) {
          this.NewNote = UnityEngine.Object.Instantiate<GameObject>(this.Note, base.transform.position, Quaternion.identity);
          this.NewNote.transform.parent = this.Student.LeftHand;
          this.NewNote.transform.localPosition = new Vector3(-0.06f, -0.01f, 0f);
          this.NewNote.transform.localEulerAngles = new Vector3(-75f, -90f, 180f);
          this.NewNote.transform.localScale = new Vector3(0.1f, 0.2f, 1f);
        }
        if (!this.Success) {
          if (this.Timer > 11.666667f) {
            this.NewNote.transform.localScale = ((this.NewNote.transform.localScale.x <= 0.1f) ? Vector3.zero : Vector3.Lerp(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime));
          }
          if (this.Timer > 13.333333f && this.NewBall == null) {
            this.NewBall = UnityEngine.Object.Instantiate<GameObject>(this.Ball, this.Student.LeftHand.position, Quaternion.identity);
            Rigidbody component2 = this.NewBall.GetComponent<Rigidbody>();
            component2.AddRelativeForce(Vector3.right * 100f);
            component2.AddRelativeForce(Vector3.up * 100f);
            this.Phase++;
          }
        } else if (this.Timer > 12.833333f) {
          this.NewNote.transform.localScale = Vector3.Lerp(this.NewNote.transform.localScale, Vector3.zero, Time.deltaTime);
        }
        if (this.Phase == 1) {
          if (this.Timer > 2.33333325f) {
            this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 1, 3f);
            this.Phase++;
          }
        } else if (this.Phase == 2) {
          if (!this.Success) {
            if (this.Timer > 9.666667f) {
              this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 2, 3f);
              this.Phase++;
            }
          } else if (this.Timer > 10.166667f) {
            this.Yandere.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 3, 3f);
            this.Phase++;
          }
        }
      }
    }
  }

  // Token: 0x060005F3 RID: 1523 RVA: 0x00053B2C File Offset: 0x00051F2C
  private void Finish() {
    if (this.Success && this.Student.Clock.HourTime > this.Student.MeetTime) {
      this.Student.CurrentDestination = this.Student.MeetSpot;
      this.Student.Pathfinding.target = this.Student.MeetSpot;
      this.Student.Pathfinding.canSearch = true;
      this.Student.Pathfinding.canMove = true;
      this.Student.Meeting = true;
      this.Student.MeetTime = 0f;
    }
    Animation component = this.Student.Character.GetComponent<Animation>();
    component.cullingType = AnimationCullingType.BasedOnRenderers;
    component.CrossFade(this.Student.IdleAnim);
    this.Student.DistanceToDestination = 100f;
    this.Student.CheckingNote = false;
    this.Student.InEvent = false;
    this.Student.Routine = true;
    this.CheckingNote = false;
    this.NoteLeft = false;
    this.Phase++;
  }

  // Token: 0x060005F4 RID: 1524 RVA: 0x00053C4C File Offset: 0x0005204C
  private void DetermineSchedule() {
    this.Student.MeetSpot = this.MeetSpots.List[this.MeetID];
    this.Student.MeetTime = this.MeetTime;
  }

  // Token: 0x04000E28 RID: 3624
  public StudentManagerScript StudentManager;

  // Token: 0x04000E29 RID: 3625
  public NoteWindowScript NoteWindow;

  // Token: 0x04000E2A RID: 3626
  public PromptBarScript PromptBar;

  // Token: 0x04000E2B RID: 3627
  public StudentScript Student;

  // Token: 0x04000E2C RID: 3628
  public YandereScript Yandere;

  // Token: 0x04000E2D RID: 3629
  public ListScript MeetSpots;

  // Token: 0x04000E2E RID: 3630
  public PromptScript Prompt;

  // Token: 0x04000E2F RID: 3631
  public GameObject NewBall;

  // Token: 0x04000E30 RID: 3632
  public GameObject NewNote;

  // Token: 0x04000E31 RID: 3633
  public GameObject Locker;

  // Token: 0x04000E32 RID: 3634
  public GameObject Ball;

  // Token: 0x04000E33 RID: 3635
  public GameObject Note;

  // Token: 0x04000E34 RID: 3636
  public AudioClip NoteSuccess;

  // Token: 0x04000E35 RID: 3637
  public AudioClip NoteFail;

  // Token: 0x04000E36 RID: 3638
  public AudioClip NoteFind;

  // Token: 0x04000E37 RID: 3639
  public bool CheckingNote;

  // Token: 0x04000E38 RID: 3640
  public bool CanLeaveNote = true;

  // Token: 0x04000E39 RID: 3641
  public bool NoteLeft;

  // Token: 0x04000E3A RID: 3642
  public bool Success;

  // Token: 0x04000E3B RID: 3643
  public float MeetTime;

  // Token: 0x04000E3C RID: 3644
  public float Timer;

  // Token: 0x04000E3D RID: 3645
  public int LockerOwner;

  // Token: 0x04000E3E RID: 3646
  public int MeetID;

  // Token: 0x04000E3F RID: 3647
  public int Phase = 1;
}