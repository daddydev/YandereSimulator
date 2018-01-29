using UnityEngine;

// Token: 0x0200001E RID: 30
[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour {

  // Token: 0x0600007C RID: 124 RVA: 0x0000A976 File Offset: 0x00008D76
  private void Start() {
    this.mTrans = base.transform;
  }

  // Token: 0x0600007D RID: 125 RVA: 0x0000A984 File Offset: 0x00008D84
  private void LateUpdate() {
    if (this.target != null) {
      Vector3 forward = this.target.position - this.mTrans.position;
      float magnitude = forward.magnitude;
      if (magnitude > 0.001f) {
        Quaternion b = Quaternion.LookRotation(forward);
        this.mTrans.rotation = Quaternion.Slerp(this.mTrans.rotation, b, Mathf.Clamp01(this.speed * Time.deltaTime));
      }
    }
  }

  // Token: 0x04000142 RID: 322
  public int level;

  // Token: 0x04000143 RID: 323
  public Transform target;

  // Token: 0x04000144 RID: 324
  public float speed = 8f;

  // Token: 0x04000145 RID: 325
  private Transform mTrans;
}