using UnityEngine;

// Token: 0x020000C8 RID: 200
public class GateScript : MonoBehaviour {

  // Token: 0x060002FC RID: 764 RVA: 0x00038DBC File Offset: 0x000371BC
  private void Update() {
    if (this.Clock.PresentTime / 60f > 8f && this.Clock.PresentTime / 60f < 15.5f) {
      this.Closed = true;
      if (this.EmergencyDoor.enabled) {
        this.EmergencyDoor.enabled = false;
      }
    } else {
      this.Closed = false;
      if (!this.EmergencyDoor.enabled) {
        this.EmergencyDoor.enabled = true;
      }
    }
    if (!this.Closed) {
      this.RightGate.localPosition = new Vector3(Mathf.Lerp(this.RightGate.localPosition.x, 7f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
      this.LeftGate.localPosition = new Vector3(Mathf.Lerp(this.LeftGate.localPosition.x, -7f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
    } else {
      this.RightGate.localPosition = new Vector3(Mathf.Lerp(this.RightGate.localPosition.x, 2.325f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
      this.LeftGate.localPosition = new Vector3(Mathf.Lerp(this.LeftGate.localPosition.x, -2.325f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
    }
  }

  // Token: 0x04000986 RID: 2438
  public Collider EmergencyDoor;

  // Token: 0x04000987 RID: 2439
  public ClockScript Clock;

  // Token: 0x04000988 RID: 2440
  public Collider GateCollider;

  // Token: 0x04000989 RID: 2441
  public Transform RightGate;

  // Token: 0x0400098A RID: 2442
  public Transform LeftGate;

  // Token: 0x0400098B RID: 2443
  public bool UpdateGates;

  // Token: 0x0400098C RID: 2444
  public bool Closed;
}