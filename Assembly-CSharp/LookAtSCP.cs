using UnityEngine;

// Token: 0x02000246 RID: 582
public class LookAtSCP : MonoBehaviour {

  // Token: 0x06000A2D RID: 2605 RVA: 0x000BA63B File Offset: 0x000B8A3B
  private void Start() {
    if (this.SCP == null) {
      this.SCP = GameObject.Find("SCPTarget").transform;
    }
    base.transform.LookAt(this.SCP);
  }

  // Token: 0x06000A2E RID: 2606 RVA: 0x000BA674 File Offset: 0x000B8A74
  private void LateUpdate() {
    base.transform.LookAt(this.SCP);
  }

  // Token: 0x04001EC8 RID: 7880
  public Transform SCP;
}