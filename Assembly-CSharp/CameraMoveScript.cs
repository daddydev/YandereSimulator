using UnityEngine;

// Token: 0x02000243 RID: 579
public class CameraMoveScript : MonoBehaviour {

  // Token: 0x06000A24 RID: 2596 RVA: 0x000BA340 File Offset: 0x000B8740
  private void Start() {
    base.transform.position = this.StartPos.position;
    base.transform.rotation = this.StartPos.rotation;
  }

  // Token: 0x06000A25 RID: 2597 RVA: 0x000BA370 File Offset: 0x000B8770
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.Begin = true;
    }
    if (this.Begin) {
      this.Timer += Time.deltaTime * this.Speed;
      if (this.Timer > 0.1f) {
        this.OpenDoors = true;
        if (this.LeftDoor != null) {
          this.LeftDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.LeftDoor.transform.localPosition.x, 1f, Time.deltaTime), this.LeftDoor.transform.localPosition.y, this.LeftDoor.transform.localPosition.z);
          this.RightDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.RightDoor.transform.localPosition.x, -1f, Time.deltaTime), this.RightDoor.transform.localPosition.y, this.RightDoor.transform.localPosition.z);
        }
      }
      base.transform.position = Vector3.Lerp(base.transform.position, this.EndPos.position, Time.deltaTime * this.Timer);
      base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.EndPos.rotation, Time.deltaTime * this.Timer);
    }
  }

  // Token: 0x06000A26 RID: 2598 RVA: 0x000BA51A File Offset: 0x000B891A
  private void LateUpdate() {
    if (this.Target != null) {
      base.transform.LookAt(this.Target);
    }
  }

  // Token: 0x04001EBD RID: 7869
  public Transform StartPos;

  // Token: 0x04001EBE RID: 7870
  public Transform EndPos;

  // Token: 0x04001EBF RID: 7871
  public Transform RightDoor;

  // Token: 0x04001EC0 RID: 7872
  public Transform LeftDoor;

  // Token: 0x04001EC1 RID: 7873
  public Transform Target;

  // Token: 0x04001EC2 RID: 7874
  public bool OpenDoors;

  // Token: 0x04001EC3 RID: 7875
  public bool Begin;

  // Token: 0x04001EC4 RID: 7876
  public float Speed;

  // Token: 0x04001EC5 RID: 7877
  public float Timer;
}