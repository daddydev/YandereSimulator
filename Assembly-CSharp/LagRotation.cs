using UnityEngine;

// Token: 0x0200001C RID: 28
[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour {

  // Token: 0x06000075 RID: 117 RVA: 0x0000A87C File Offset: 0x00008C7C
  public void OnRepositionEnd() {
    this.Interpolate(1000f);
  }

  // Token: 0x06000076 RID: 118 RVA: 0x0000A88C File Offset: 0x00008C8C
  private void Interpolate(float delta) {
    Transform parent = this.mTrans.parent;
    if (parent != null) {
      this.mAbsolute = Quaternion.Slerp(this.mAbsolute, parent.rotation * this.mRelative, delta * this.speed);
      this.mTrans.rotation = this.mAbsolute;
    }
  }

  // Token: 0x06000077 RID: 119 RVA: 0x0000A8EC File Offset: 0x00008CEC
  private void OnEnable() {
    this.mTrans = base.transform;
    this.mRelative = this.mTrans.localRotation;
    this.mAbsolute = this.mTrans.rotation;
  }

  // Token: 0x06000078 RID: 120 RVA: 0x0000A91C File Offset: 0x00008D1C
  private void Update() {
    this.Interpolate((!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime);
  }

  // Token: 0x0400013C RID: 316
  public float speed = 10f;

  // Token: 0x0400013D RID: 317
  public bool ignoreTimeScale;

  // Token: 0x0400013E RID: 318
  private Transform mTrans;

  // Token: 0x0400013F RID: 319
  private Quaternion mRelative;

  // Token: 0x04000140 RID: 320
  private Quaternion mAbsolute;
}