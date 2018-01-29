using UnityEngine;

// Token: 0x02000090 RID: 144
public class DrillScript : MonoBehaviour {

  // Token: 0x0600023F RID: 575 RVA: 0x00030A1A File Offset: 0x0002EE1A
  private void LateUpdate() {
    base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
  }
}