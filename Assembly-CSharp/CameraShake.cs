using UnityEngine;

// Token: 0x0200005A RID: 90
public class CameraShake : MonoBehaviour {

  // Token: 0x06000147 RID: 327 RVA: 0x0001595F File Offset: 0x00013D5F
  private void Awake() {
    if (this.camTransform == null) {
      this.camTransform = base.GetComponent<Transform>();
    }
  }

  // Token: 0x06000148 RID: 328 RVA: 0x0001597E File Offset: 0x00013D7E
  private void OnEnable() {
    this.originalPos = this.camTransform.localPosition;
  }

  // Token: 0x06000149 RID: 329 RVA: 0x00015994 File Offset: 0x00013D94
  private void Update() {
    if (this.shake > 0f) {
      this.camTransform.localPosition = this.originalPos + UnityEngine.Random.insideUnitSphere * this.shakeAmount;
      this.shake -= 0.0166666675f * this.decreaseFactor;
    } else {
      this.shake = 0f;
      this.camTransform.localPosition = this.originalPos;
    }
  }

  // Token: 0x04000408 RID: 1032
  public Transform camTransform;

  // Token: 0x04000409 RID: 1033
  public float shake;

  // Token: 0x0400040A RID: 1034
  public float shakeAmount = 0.7f;

  // Token: 0x0400040B RID: 1035
  public float decreaseFactor = 1f;

  // Token: 0x0400040C RID: 1036
  private Vector3 originalPos;
}