using UnityEngine;

// Token: 0x02000024 RID: 36
[AddComponentMenu("NGUI/Examples/Spin With Mouse")]
public class SpinWithMouse : MonoBehaviour {

  // Token: 0x0600008E RID: 142 RVA: 0x0000B081 File Offset: 0x00009481
  private void Start() {
    this.mTrans = base.transform;
  }

  // Token: 0x0600008F RID: 143 RVA: 0x0000B090 File Offset: 0x00009490
  private void OnDrag(Vector2 delta) {
    UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
    if (this.target != null) {
      this.target.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * this.speed, 0f) * this.target.localRotation;
    } else {
      this.mTrans.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * this.speed, 0f) * this.mTrans.localRotation;
    }
  }

  // Token: 0x04000156 RID: 342
  public Transform target;

  // Token: 0x04000157 RID: 343
  public float speed = 1f;

  // Token: 0x04000158 RID: 344
  private Transform mTrans;
}