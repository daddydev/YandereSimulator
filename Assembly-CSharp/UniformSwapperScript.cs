using UnityEngine;

// Token: 0x020001EB RID: 491
public class UniformSwapperScript : MonoBehaviour {

  // Token: 0x060008C8 RID: 2248 RVA: 0x0009E004 File Offset: 0x0009C404
  private void Start() {
    int maleUniform = StudentGlobals.MaleUniform;
    this.MyRenderer.sharedMesh = this.UniformMeshes[maleUniform];
    Texture mainTexture = this.UniformTextures[maleUniform];
    if (maleUniform == 1) {
      this.SkinID = 0;
      this.UniformID = 1;
      this.FaceID = 2;
    } else if (maleUniform == 2) {
      this.UniformID = 0;
      this.FaceID = 1;
      this.SkinID = 2;
    } else if (maleUniform == 3) {
      this.UniformID = 0;
      this.FaceID = 1;
      this.SkinID = 2;
    } else if (maleUniform == 4) {
      this.FaceID = 0;
      this.SkinID = 1;
      this.UniformID = 2;
    } else if (maleUniform == 5) {
      this.FaceID = 0;
      this.SkinID = 1;
      this.UniformID = 2;
    } else if (maleUniform == 6) {
      this.FaceID = 0;
      this.SkinID = 1;
      this.UniformID = 2;
    }
    this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[this.SkinID].mainTexture = mainTexture;
    this.MyRenderer.materials[this.UniformID].mainTexture = mainTexture;
  }

  // Token: 0x060008C9 RID: 2249 RVA: 0x0009E141 File Offset: 0x0009C541
  private void LateUpdate() {
    if (this.LookTarget != null) {
      this.Head.LookAt(this.LookTarget);
    }
  }

  // Token: 0x040019F2 RID: 6642
  public Texture[] UniformTextures;

  // Token: 0x040019F3 RID: 6643
  public Mesh[] UniformMeshes;

  // Token: 0x040019F4 RID: 6644
  public Texture FaceTexture;

  // Token: 0x040019F5 RID: 6645
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x040019F6 RID: 6646
  public int UniformID;

  // Token: 0x040019F7 RID: 6647
  public int FaceID;

  // Token: 0x040019F8 RID: 6648
  public int SkinID;

  // Token: 0x040019F9 RID: 6649
  public Transform LookTarget;

  // Token: 0x040019FA RID: 6650
  public Transform Head;
}