using UnityEngine;

// Token: 0x02000077 RID: 119
public class CreditsLabelScript : MonoBehaviour {

  // Token: 0x060001BF RID: 447 RVA: 0x000233C8 File Offset: 0x000217C8
  private void Start() {
    this.Rotation = -90f;
    base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
  }

  // Token: 0x060001C0 RID: 448 RVA: 0x0002341C File Offset: 0x0002181C
  private void Update() {
    this.Rotation += Time.deltaTime * this.RotationSpeed;
    base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
    base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + Time.deltaTime * this.MovementSpeed, base.transform.localPosition.z);
    if (this.Rotation > 90f) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04000608 RID: 1544
  public float RotationSpeed;

  // Token: 0x04000609 RID: 1545
  public float MovementSpeed;

  // Token: 0x0400060A RID: 1546
  public float Rotation;
}