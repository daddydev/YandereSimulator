using UnityEngine;

// Token: 0x02000020 RID: 32
[AddComponentMenu("NGUI/Examples/Pan With Mouse")]
public class PanWithMouse : MonoBehaviour {

  // Token: 0x06000081 RID: 129 RVA: 0x0000AA80 File Offset: 0x00008E80
  private void Start() {
    this.mTrans = base.transform;
    this.mStart = this.mTrans.localRotation;
  }

  // Token: 0x06000082 RID: 130 RVA: 0x0000AAA0 File Offset: 0x00008EA0
  private void Update() {
    float deltaTime = RealTime.deltaTime;
    Vector3 mousePosition = Input.mousePosition;
    float num = (float)Screen.width * 0.5f;
    float num2 = (float)Screen.height * 0.5f;
    if (this.range < 0.1f) {
      this.range = 0.1f;
    }
    float x = Mathf.Clamp((mousePosition.x - num) / num / this.range, -1f, 1f);
    float y = Mathf.Clamp((mousePosition.y - num2) / num2 / this.range, -1f, 1f);
    this.mRot = Vector2.Lerp(this.mRot, new Vector2(x, y), deltaTime * 5f);
    this.mTrans.localRotation = this.mStart * Quaternion.Euler(-this.mRot.y * this.degrees.y, this.mRot.x * this.degrees.x, 0f);
  }

  // Token: 0x04000146 RID: 326
  public Vector2 degrees = new Vector2(5f, 3f);

  // Token: 0x04000147 RID: 327
  public float range = 1f;

  // Token: 0x04000148 RID: 328
  private Transform mTrans;

  // Token: 0x04000149 RID: 329
  private Quaternion mStart;

  // Token: 0x0400014A RID: 330
  private Vector2 mRot = Vector2.zero;
}