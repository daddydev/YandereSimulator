using UnityEngine;

// Token: 0x02000107 RID: 263
public class HomeYandereDetectorScript : MonoBehaviour {

  // Token: 0x06000523 RID: 1315 RVA: 0x00046E2F File Offset: 0x0004522F
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      this.YandereDetected = true;
    }
  }

  // Token: 0x06000524 RID: 1316 RVA: 0x00046E4D File Offset: 0x0004524D
  private void OnTriggerExit(Collider other) {
    if (other.tag == "Player") {
      this.YandereDetected = false;
    }
  }

  // Token: 0x04000C23 RID: 3107
  public bool YandereDetected;
}