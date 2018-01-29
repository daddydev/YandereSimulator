using UnityEngine;

// Token: 0x02000087 RID: 135
public class DetectionCameraScript : MonoBehaviour {

  // Token: 0x0600021E RID: 542 RVA: 0x0002BF18 File Offset: 0x0002A318
  private void Update() {
    base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
    base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
  }

  // Token: 0x04000759 RID: 1881
  public Transform YandereChan;
}