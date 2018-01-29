using UnityEngine;

// Token: 0x020000B8 RID: 184
public class EyeShapeScript : MonoBehaviour {

  // Token: 0x060002CA RID: 714 RVA: 0x00035524 File Offset: 0x00033924
  private void Start() {
    this.PosOffsetX = UnityEngine.Random.Range(-0.002f, 0.002f);
    this.PosOffsetY = UnityEngine.Random.Range(-0.002f, 0.002f);
    this.PosOffsetZ = UnityEngine.Random.Range(-0.002f, 0.002f);
    this.RotOffsetX = UnityEngine.Random.Range(-15f, 15f);
    this.RotOffsetY = UnityEngine.Random.Range(-15f, 15f);
    this.RotOffsetZ = UnityEngine.Random.Range(-15f, 15f);
  }

  // Token: 0x060002CB RID: 715 RVA: 0x000355B0 File Offset: 0x000339B0
  private void LateUpdate() {
    this.eyelid_und1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyelid_und1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyelid_und2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyelid_und2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyelid_und_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyelid_und_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyerid1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyerid1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyerid2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyerid2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyerid_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyerid_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.inner_corner_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.inner_corner_of_eye_Reft.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.tail_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.tail_of_eye_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyelid_und1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyelid_und1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyelid_und2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyelid_und2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyelid_und_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyelid_und_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyerid1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyerid1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyerid2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyerid2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyerid_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyerid_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.inner_corner_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.inner_corner_of_eye_Reft.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.tail_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.tail_of_eye_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
  }

  // Token: 0x040008D1 RID: 2257
  public Transform eyelid_und1_Left;

  // Token: 0x040008D2 RID: 2258
  public Transform eyelid_und1_Right;

  // Token: 0x040008D3 RID: 2259
  public Transform eyelid_und2_Left;

  // Token: 0x040008D4 RID: 2260
  public Transform eyelid_und2_Right;

  // Token: 0x040008D5 RID: 2261
  public Transform eyelid_und_Left;

  // Token: 0x040008D6 RID: 2262
  public Transform eyelid_und_Right;

  // Token: 0x040008D7 RID: 2263
  public Transform eyerid1_Left;

  // Token: 0x040008D8 RID: 2264
  public Transform eyerid1_Right;

  // Token: 0x040008D9 RID: 2265
  public Transform eyerid2_Left;

  // Token: 0x040008DA RID: 2266
  public Transform eyerid2_Right;

  // Token: 0x040008DB RID: 2267
  public Transform eyerid_Left;

  // Token: 0x040008DC RID: 2268
  public Transform eyerid_Right;

  // Token: 0x040008DD RID: 2269
  public Transform inner_corner_of_eye_Left;

  // Token: 0x040008DE RID: 2270
  public Transform inner_corner_of_eye_Reft;

  // Token: 0x040008DF RID: 2271
  public Transform tail_of_eye_Left;

  // Token: 0x040008E0 RID: 2272
  public Transform tail_of_eye_Right;

  // Token: 0x040008E1 RID: 2273
  public float PosOffsetX;

  // Token: 0x040008E2 RID: 2274
  public float PosOffsetY;

  // Token: 0x040008E3 RID: 2275
  public float PosOffsetZ;

  // Token: 0x040008E4 RID: 2276
  public float RotOffsetX;

  // Token: 0x040008E5 RID: 2277
  public float RotOffsetY;

  // Token: 0x040008E6 RID: 2278
  public float RotOffsetZ;
}