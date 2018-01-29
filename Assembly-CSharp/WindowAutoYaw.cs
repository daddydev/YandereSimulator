using UnityEngine;

// Token: 0x02000027 RID: 39
[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour {

  // Token: 0x06000096 RID: 150 RVA: 0x0000B34E File Offset: 0x0000974E
  private void OnDisable() {
    this.mTrans.localRotation = Quaternion.identity;
  }

  // Token: 0x06000097 RID: 151 RVA: 0x0000B360 File Offset: 0x00009760
  private void OnEnable() {
    if (this.uiCamera == null) {
      this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
    }
    this.mTrans = base.transform;
  }

  // Token: 0x06000098 RID: 152 RVA: 0x0000B398 File Offset: 0x00009798
  private void Update() {
    if (this.uiCamera != null) {
      Vector3 vector = this.uiCamera.WorldToViewportPoint(this.mTrans.position);
      this.mTrans.localRotation = Quaternion.Euler(0f, (vector.x * 2f - 1f) * this.yawAmount, 0f);
    }
  }

  // Token: 0x0400015D RID: 349
  public int updateOrder;

  // Token: 0x0400015E RID: 350
  public Camera uiCamera;

  // Token: 0x0400015F RID: 351
  public float yawAmount = 20f;

  // Token: 0x04000160 RID: 352
  private Transform mTrans;
}