using UnityEngine;

// Token: 0x0200015F RID: 351
public class PoliceWalk : MonoBehaviour {

  // Token: 0x06000678 RID: 1656 RVA: 0x0005E508 File Offset: 0x0005C908
  private void Update() {
    Vector3 position = base.transform.position;
    position.z += Time.deltaTime;
    base.transform.position = position;
  }
}