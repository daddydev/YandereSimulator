using UnityEngine;

// Token: 0x02000028 RID: 40
[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour {

  // Token: 0x0600009A RID: 154 RVA: 0x0000B414 File Offset: 0x00009814
  private void OnEnable() {
    this.mTrans = base.transform;
    this.mLastPos = this.mTrans.position;
  }

  // Token: 0x0600009B RID: 155 RVA: 0x0000B434 File Offset: 0x00009834
  private void Update() {
    Vector3 vector = this.mTrans.position - this.mLastPos;
    this.mLastPos = this.mTrans.position;
    this.mAngle += vector.x * this.degrees;
    this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0f, 20f, Time.deltaTime);
    this.mTrans.localRotation = Quaternion.Euler(0f, 0f, -this.mAngle);
  }

  // Token: 0x04000161 RID: 353
  public int updateOrder;

  // Token: 0x04000162 RID: 354
  public float degrees = 30f;

  // Token: 0x04000163 RID: 355
  private Vector3 mLastPos;

  // Token: 0x04000164 RID: 356
  private Transform mTrans;

  // Token: 0x04000165 RID: 357
  private float mAngle;
}