using UnityEngine;

// Token: 0x020001AF RID: 431
public class ShadowScript : MonoBehaviour {

  // Token: 0x06000787 RID: 1927 RVA: 0x000717B4 File Offset: 0x0006FBB4
  private void Update() {
    Vector3 position = base.transform.position;
    Vector3 position2 = this.Foot.position;
    position.x = position2.x;
    position.z = position2.z;
    base.transform.position = position;
  }

  // Token: 0x04001324 RID: 4900
  public Transform Foot;
}