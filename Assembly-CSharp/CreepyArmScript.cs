using UnityEngine;

// Token: 0x02000079 RID: 121
public class CreepyArmScript : MonoBehaviour {

  // Token: 0x060001C6 RID: 454 RVA: 0x000237A4 File Offset: 0x00021BA4
  private void Update() {
    base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.1f, base.transform.position.z);
  }
}