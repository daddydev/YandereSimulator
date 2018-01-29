using UnityEngine;

// Token: 0x0200009E RID: 158
public class EmergencyExitScript : MonoBehaviour {

  // Token: 0x06000272 RID: 626 RVA: 0x000325B8 File Offset: 0x000309B8
  private void Update() {
    if (Vector3.Distance(this.Yandere.position, base.transform.position) < 2f) {
      this.Open = true;
    } else if (this.Timer == 0f) {
      this.Student = null;
      this.Open = false;
    }
    if (!this.Open) {
      this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 0f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
    } else {
      this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 90f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
      this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
    }
  }

  // Token: 0x06000273 RID: 627 RVA: 0x000326FD File Offset: 0x00030AFD
  private void OnTriggerStay(Collider other) {
    this.Student = other.gameObject.GetComponent<StudentScript>();
    if (this.Student != null) {
      this.Timer = 1f;
      this.Open = true;
    }
  }

  // Token: 0x04000815 RID: 2069
  public StudentScript Student;

  // Token: 0x04000816 RID: 2070
  public Transform Yandere;

  // Token: 0x04000817 RID: 2071
  public Transform Pivot;

  // Token: 0x04000818 RID: 2072
  public float Timer;

  // Token: 0x04000819 RID: 2073
  public bool Open;
}