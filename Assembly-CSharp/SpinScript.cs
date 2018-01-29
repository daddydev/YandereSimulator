using UnityEngine;

// Token: 0x020001BA RID: 442
public class SpinScript : MonoBehaviour {

  // Token: 0x060007B7 RID: 1975 RVA: 0x00076850 File Offset: 0x00074C50
  private void Update() {
    this.RotationX += this.X * Time.deltaTime;
    this.RotationY += this.Y * Time.deltaTime;
    this.RotationZ += this.Z * Time.deltaTime;
    base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
  }

  // Token: 0x040013D2 RID: 5074
  public float X;

  // Token: 0x040013D3 RID: 5075
  public float Y;

  // Token: 0x040013D4 RID: 5076
  public float Z;

  // Token: 0x040013D5 RID: 5077
  private float RotationX;

  // Token: 0x040013D6 RID: 5078
  private float RotationY;

  // Token: 0x040013D7 RID: 5079
  private float RotationZ;
}