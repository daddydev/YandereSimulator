using UnityEngine;

// Token: 0x020001E5 RID: 485
public class TranqCaseScript : MonoBehaviour {

  // Token: 0x060008B6 RID: 2230 RVA: 0x0009D48B File Offset: 0x0009B88B
  private void Start() {
    this.Prompt.enabled = false;
  }

  // Token: 0x060008B7 RID: 2231 RVA: 0x0009D49C File Offset: 0x0009B89C
  private void Update() {
    if (this.Yandere.transform.position.x > base.transform.position.x && Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f) {
      if (this.Yandere.Dragging) {
        if (this.Yandere.Ragdoll.GetComponent<RagdollScript>().Tranquil) {
          if (!this.Prompt.enabled) {
            this.Prompt.enabled = true;
          }
        } else if (this.Prompt.enabled) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      } else if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Prompt.enabled && this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.TranquilHiding = true;
      this.Yandere.CanMove = false;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.Yandere.Ragdoll.GetComponent<RagdollScript>().TranqCase = this;
      this.VictimClubType = this.Yandere.Ragdoll.GetComponent<RagdollScript>().Student.Club;
      this.VictimID = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
      this.Door.Prompt.enabled = true;
      this.Door.enabled = true;
      this.Occupied = true;
      this.Open = true;
    }
    this.Hinge.localEulerAngles = new Vector3(this.Hinge.localEulerAngles.x, this.Hinge.localEulerAngles.y, Mathf.Lerp(this.Hinge.localEulerAngles.z, (!this.Open) ? 0f : 135f, Time.deltaTime * 10f));
  }

  // Token: 0x040019CF RID: 6607
  public YandereScript Yandere;

  // Token: 0x040019D0 RID: 6608
  public PromptScript Prompt;

  // Token: 0x040019D1 RID: 6609
  public DoorScript Door;

  // Token: 0x040019D2 RID: 6610
  public Transform Hinge;

  // Token: 0x040019D3 RID: 6611
  public bool Occupied;

  // Token: 0x040019D4 RID: 6612
  public bool Open;

  // Token: 0x040019D5 RID: 6613
  public int VictimID;

  // Token: 0x040019D6 RID: 6614
  public ClubType VictimClubType;
}