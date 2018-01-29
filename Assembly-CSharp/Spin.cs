using UnityEngine;

// Token: 0x02000023 RID: 35
[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour {

  // Token: 0x06000089 RID: 137 RVA: 0x0000AF8D File Offset: 0x0000938D
  private void Start() {
    this.mTrans = base.transform;
    this.mRb = base.GetComponent<Rigidbody>();
  }

  // Token: 0x0600008A RID: 138 RVA: 0x0000AFA7 File Offset: 0x000093A7
  private void Update() {
    if (this.mRb == null) {
      this.ApplyDelta((!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime);
    }
  }

  // Token: 0x0600008B RID: 139 RVA: 0x0000AFDA File Offset: 0x000093DA
  private void FixedUpdate() {
    if (this.mRb != null) {
      this.ApplyDelta(Time.deltaTime);
    }
  }

  // Token: 0x0600008C RID: 140 RVA: 0x0000AFF8 File Offset: 0x000093F8
  public void ApplyDelta(float delta) {
    delta *= 360f;
    Quaternion rhs = Quaternion.Euler(this.rotationsPerSecond * delta);
    if (this.mRb == null) {
      this.mTrans.rotation = this.mTrans.rotation * rhs;
    } else {
      this.mRb.MoveRotation(this.mRb.rotation * rhs);
    }
  }

  // Token: 0x04000152 RID: 338
  public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

  // Token: 0x04000153 RID: 339
  public bool ignoreTimeScale;

  // Token: 0x04000154 RID: 340
  private Rigidbody mRb;

  // Token: 0x04000155 RID: 341
  private Transform mTrans;
}