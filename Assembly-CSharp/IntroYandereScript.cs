using UnityEngine;

// Token: 0x02000113 RID: 275
public class IntroYandereScript : MonoBehaviour {

  // Token: 0x06000545 RID: 1349 RVA: 0x0004A044 File Offset: 0x00048444
  private void LateUpdate() {
    this.Hips.localEulerAngles = new Vector3(this.Hips.localEulerAngles.x + this.X, this.Hips.localEulerAngles.y, this.Hips.localEulerAngles.z);
    this.Spine.localEulerAngles = new Vector3(this.Spine.localEulerAngles.x + this.X, this.Spine.localEulerAngles.y, this.Spine.localEulerAngles.z);
    this.Spine1.localEulerAngles = new Vector3(this.Spine1.localEulerAngles.x + this.X, this.Spine1.localEulerAngles.y, this.Spine1.localEulerAngles.z);
    this.Spine2.localEulerAngles = new Vector3(this.Spine2.localEulerAngles.x + this.X, this.Spine2.localEulerAngles.y, this.Spine2.localEulerAngles.z);
    this.Spine3.localEulerAngles = new Vector3(this.Spine3.localEulerAngles.x + this.X, this.Spine3.localEulerAngles.y, this.Spine3.localEulerAngles.z);
    this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x + this.X, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
    this.Head.localEulerAngles = new Vector3(this.Head.localEulerAngles.x + this.X, this.Head.localEulerAngles.y, this.Head.localEulerAngles.z);
    this.RightUpLeg.localEulerAngles = new Vector3(this.RightUpLeg.localEulerAngles.x - this.X, this.RightUpLeg.localEulerAngles.y, this.RightUpLeg.localEulerAngles.z);
    this.RightLeg.localEulerAngles = new Vector3(this.RightLeg.localEulerAngles.x - this.X, this.RightLeg.localEulerAngles.y, this.RightLeg.localEulerAngles.z);
    this.RightFoot.localEulerAngles = new Vector3(this.RightFoot.localEulerAngles.x - this.X, this.RightFoot.localEulerAngles.y, this.RightFoot.localEulerAngles.z);
    this.LeftUpLeg.localEulerAngles = new Vector3(this.LeftUpLeg.localEulerAngles.x - this.X, this.LeftUpLeg.localEulerAngles.y, this.LeftUpLeg.localEulerAngles.z);
    this.LeftLeg.localEulerAngles = new Vector3(this.LeftLeg.localEulerAngles.x - this.X, this.LeftLeg.localEulerAngles.y, this.LeftLeg.localEulerAngles.z);
    this.LeftFoot.localEulerAngles = new Vector3(this.LeftFoot.localEulerAngles.x - this.X, this.LeftFoot.localEulerAngles.y, this.LeftFoot.localEulerAngles.z);
  }

  // Token: 0x04000CB3 RID: 3251
  public Transform Hips;

  // Token: 0x04000CB4 RID: 3252
  public Transform Spine;

  // Token: 0x04000CB5 RID: 3253
  public Transform Spine1;

  // Token: 0x04000CB6 RID: 3254
  public Transform Spine2;

  // Token: 0x04000CB7 RID: 3255
  public Transform Spine3;

  // Token: 0x04000CB8 RID: 3256
  public Transform Neck;

  // Token: 0x04000CB9 RID: 3257
  public Transform Head;

  // Token: 0x04000CBA RID: 3258
  public Transform RightUpLeg;

  // Token: 0x04000CBB RID: 3259
  public Transform RightLeg;

  // Token: 0x04000CBC RID: 3260
  public Transform RightFoot;

  // Token: 0x04000CBD RID: 3261
  public Transform LeftUpLeg;

  // Token: 0x04000CBE RID: 3262
  public Transform LeftLeg;

  // Token: 0x04000CBF RID: 3263
  public Transform LeftFoot;

  // Token: 0x04000CC0 RID: 3264
  public float X;
}