using UnityEngine;

// Token: 0x02000148 RID: 328
public class ActivateOsuScript : MonoBehaviour {

  // Token: 0x06000612 RID: 1554 RVA: 0x000559FD File Offset: 0x00053DFD
  private void Start() {
    this.OsuScripts = this.Osu.GetComponents<OsuScript>();
    this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
    this.OriginalMousePosition = this.Mouse.transform.position;
  }

  // Token: 0x06000613 RID: 1555 RVA: 0x00055A3C File Offset: 0x00053E3C
  private void Update() {
    if (this.Student == null) {
      this.Student = this.StudentManager.Students[this.PlayerID];
    } else if (!this.Osu.activeInHierarchy) {
      if (Vector3.Distance(base.transform.position, this.Student.transform.position) < 0.1f && this.Student.Routine && this.Student.CurrentDestination == this.Student.Destinations[this.Student.Phase] && this.Student.Actions[this.Student.Phase] == StudentActionType.Gaming) {
        this.ActivateOsu();
      }
    } else {
      this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
      if (!this.Student.Routine || this.Student.CurrentDestination != this.Student.Destinations[this.Student.Phase] || this.Student.Actions[this.Student.Phase] != StudentActionType.Gaming) {
        this.DeactivateOsu();
      }
    }
  }

  // Token: 0x06000614 RID: 1556 RVA: 0x00055B8C File Offset: 0x00053F8C
  private void ActivateOsu() {
    this.Osu.transform.parent.gameObject.SetActive(true);
    this.Music.SetActive(true);
    this.Mouse.parent = this.Student.RightHand;
    this.Mouse.transform.localPosition = Vector3.zero;
  }

  // Token: 0x06000615 RID: 1557 RVA: 0x00055BEC File Offset: 0x00053FEC
  private void DeactivateOsu() {
    this.Osu.transform.parent.gameObject.SetActive(false);
    this.Music.SetActive(false);
    foreach (OsuScript osuScript in this.OsuScripts) {
      osuScript.Timer = 0f;
    }
    this.Mouse.parent = base.transform.parent;
    this.Mouse.transform.position = this.OriginalMousePosition;
  }

  // Token: 0x04000E94 RID: 3732
  public StudentManagerScript StudentManager;

  // Token: 0x04000E95 RID: 3733
  public OsuScript[] OsuScripts;

  // Token: 0x04000E96 RID: 3734
  public StudentScript Student;

  // Token: 0x04000E97 RID: 3735
  public ClockScript Clock;

  // Token: 0x04000E98 RID: 3736
  public GameObject Music;

  // Token: 0x04000E99 RID: 3737
  public Transform Mouse;

  // Token: 0x04000E9A RID: 3738
  public GameObject Osu;

  // Token: 0x04000E9B RID: 3739
  public int PlayerID;

  // Token: 0x04000E9C RID: 3740
  public Vector3 OriginalMousePosition;

  // Token: 0x04000E9D RID: 3741
  public Vector3 OriginalMouseRotation;
}