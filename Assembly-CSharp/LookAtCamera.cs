using UnityEngine;

// Token: 0x02000245 RID: 581
public class LookAtCamera : MonoBehaviour {

  // Token: 0x06000A2A RID: 2602 RVA: 0x000BA5A9 File Offset: 0x000B89A9
  private void Start() {
    if (this.cameraToLookAt == null) {
      this.cameraToLookAt = Camera.main;
    }
  }

  // Token: 0x06000A2B RID: 2603 RVA: 0x000BA5C8 File Offset: 0x000B89C8
  private void Update() {
    Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
    base.transform.LookAt(this.cameraToLookAt.transform.position - b);
  }

  // Token: 0x04001EC7 RID: 7879
  public Camera cameraToLookAt;
}