using UnityEngine;

// Token: 0x020000CC RID: 204
public class GhostScript : MonoBehaviour {

  // Token: 0x06000307 RID: 775 RVA: 0x00039AC8 File Offset: 0x00037EC8
  private void Update() {
    if (Time.timeScale > 0f) {
      if (this.Frame > 0) {
        base.GetComponent<Animation>().enabled = false;
        base.gameObject.SetActive(false);
        this.Frame = 0;
      }
      this.Frame++;
    }
  }

  // Token: 0x06000308 RID: 776 RVA: 0x00039B1D File Offset: 0x00037F1D
  public void Look() {
    this.Neck.LookAt(this.SmartphoneCamera.position);
  }

  // Token: 0x040009A2 RID: 2466
  public Transform SmartphoneCamera;

  // Token: 0x040009A3 RID: 2467
  public Transform Neck;

  // Token: 0x040009A4 RID: 2468
  public Transform GhostEyeLocation;

  // Token: 0x040009A5 RID: 2469
  public Transform GhostEye;

  // Token: 0x040009A6 RID: 2470
  public int Frame;
}