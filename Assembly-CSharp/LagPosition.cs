using UnityEngine;

// Token: 0x0200001B RID: 27
[AddComponentMenu("NGUI/Examples/Lag Position")]
public class LagPosition : MonoBehaviour {

  // Token: 0x06000070 RID: 112 RVA: 0x0000A718 File Offset: 0x00008B18
  public void OnRepositionEnd() {
    this.Interpolate(1000f);
  }

  // Token: 0x06000071 RID: 113 RVA: 0x0000A728 File Offset: 0x00008B28
  private void Interpolate(float delta) {
    Transform parent = this.mTrans.parent;
    if (parent != null) {
      Vector3 vector = parent.position + parent.rotation * this.mRelative;
      this.mAbsolute.x = Mathf.Lerp(this.mAbsolute.x, vector.x, Mathf.Clamp01(delta * this.speed.x));
      this.mAbsolute.y = Mathf.Lerp(this.mAbsolute.y, vector.y, Mathf.Clamp01(delta * this.speed.y));
      this.mAbsolute.z = Mathf.Lerp(this.mAbsolute.z, vector.z, Mathf.Clamp01(delta * this.speed.z));
      this.mTrans.position = this.mAbsolute;
    }
  }

  // Token: 0x06000072 RID: 114 RVA: 0x0000A817 File Offset: 0x00008C17
  private void OnEnable() {
    this.mTrans = base.transform;
    this.mAbsolute = this.mTrans.position;
    this.mRelative = this.mTrans.localPosition;
  }

  // Token: 0x06000073 RID: 115 RVA: 0x0000A847 File Offset: 0x00008C47
  private void Update() {
    this.Interpolate((!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime);
  }

  // Token: 0x04000137 RID: 311
  public Vector3 speed = new Vector3(10f, 10f, 10f);

  // Token: 0x04000138 RID: 312
  public bool ignoreTimeScale;

  // Token: 0x04000139 RID: 313
  private Transform mTrans;

  // Token: 0x0400013A RID: 314
  private Vector3 mRelative;

  // Token: 0x0400013B RID: 315
  private Vector3 mAbsolute;
}