using UnityEngine;

// Token: 0x020000E7 RID: 231
public class GradingPaperScript : MonoBehaviour {

  // Token: 0x060004B1 RID: 1201 RVA: 0x0003CE3C File Offset: 0x0003B23C
  private void Start() {
    this.OriginalPosition = this.Chair.position;
  }

  // Token: 0x060004B2 RID: 1202 RVA: 0x0003CE50 File Offset: 0x0003B250
  private void Update() {
    if (!this.Writing) {
      this.Chair.position = Vector3.Lerp(this.Chair.position, this.OriginalPosition, Time.deltaTime * 10f);
    } else if (this.Character != null) {
      this.Chair.position = Vector3.Lerp(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f, Time.deltaTime * 10f);
      if (this.Phase == 1) {
        if (this.Character.GetComponent<Animation>()["f02_deskWrite"].time > this.PickUpTime1) {
          this.Character.GetComponent<Animation>()["f02_deskWrite"].speed = this.Speed;
          this.Paper.parent = this.LeftHand;
          this.Paper.localPosition = this.PickUpPosition1;
          this.Paper.localEulerAngles = this.PickUpRotation1;
          this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
          this.Phase++;
        }
      } else if (this.Phase == 2) {
        if (this.Character.GetComponent<Animation>()["f02_deskWrite"].time > this.SetDownTime1) {
          this.Paper.parent = this.Character.transform;
          this.Paper.localPosition = this.SetDownPosition1;
          this.Paper.localEulerAngles = this.SetDownRotation1;
          this.Phase++;
        }
      } else if (this.Phase == 3) {
        if (this.Character.GetComponent<Animation>()["f02_deskWrite"].time > this.PickUpTime2) {
          this.Paper.parent = this.LeftHand;
          this.Paper.localPosition = this.PickUpPosition2;
          this.Paper.localEulerAngles = this.PickUpRotation2;
          this.Phase++;
        }
      } else if (this.Phase == 4) {
        if (this.Character.GetComponent<Animation>()["f02_deskWrite"].time > this.SetDownTime2) {
          this.Paper.parent = this.Character.transform;
          this.Paper.localScale = Vector3.zero;
          this.Phase++;
        }
      } else if (this.Phase == 5 && this.Character.GetComponent<Animation>()["f02_deskWrite"].time >= this.Character.GetComponent<Animation>()["f02_deskWrite"].length) {
        this.Character.GetComponent<Animation>()["f02_deskWrite"].time = 0f;
        this.Character.GetComponent<Animation>().Play("f02_deskWrite");
        this.Phase = 1;
      }
      if (this.Teacher.Actions[this.Teacher.Phase] != StudentActionType.GradePapers || !this.Teacher.Routine || this.Teacher.Stop) {
        this.Paper.localScale = Vector3.zero;
        this.Teacher.Obstacle.enabled = false;
        this.Teacher.Pen.SetActive(false);
        this.Writing = false;
        this.Phase = 1;
      }
    }
  }

  // Token: 0x04000A4E RID: 2638
  public StudentScript Teacher;

  // Token: 0x04000A4F RID: 2639
  public GameObject Character;

  // Token: 0x04000A50 RID: 2640
  public Transform LeftHand;

  // Token: 0x04000A51 RID: 2641
  public Transform Chair;

  // Token: 0x04000A52 RID: 2642
  public Transform Paper;

  // Token: 0x04000A53 RID: 2643
  public float PickUpTime1;

  // Token: 0x04000A54 RID: 2644
  public float SetDownTime1;

  // Token: 0x04000A55 RID: 2645
  public float PickUpTime2;

  // Token: 0x04000A56 RID: 2646
  public float SetDownTime2;

  // Token: 0x04000A57 RID: 2647
  public Vector3 OriginalPosition;

  // Token: 0x04000A58 RID: 2648
  public Vector3 PickUpPosition1;

  // Token: 0x04000A59 RID: 2649
  public Vector3 SetDownPosition1;

  // Token: 0x04000A5A RID: 2650
  public Vector3 PickUpPosition2;

  // Token: 0x04000A5B RID: 2651
  public Vector3 PickUpRotation1;

  // Token: 0x04000A5C RID: 2652
  public Vector3 SetDownRotation1;

  // Token: 0x04000A5D RID: 2653
  public Vector3 PickUpRotation2;

  // Token: 0x04000A5E RID: 2654
  public int Phase = 1;

  // Token: 0x04000A5F RID: 2655
  public float Speed = 1f;

  // Token: 0x04000A60 RID: 2656
  public bool Writing;
}