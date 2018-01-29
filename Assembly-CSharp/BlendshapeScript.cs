using UnityEngine;

// Token: 0x0200003F RID: 63
public class BlendshapeScript : MonoBehaviour {

  // Token: 0x060000E6 RID: 230 RVA: 0x00010D78 File Offset: 0x0000F178
  private void LateUpdate() {
    this.Happiness += Time.deltaTime * 10f;
    this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
    this.Blink += Time.deltaTime * 10f;
    this.MyMesh.SetBlendShapeWeight(8, 100f);
  }

  // Token: 0x0400032F RID: 815
  public SkinnedMeshRenderer MyMesh;

  // Token: 0x04000330 RID: 816
  public float Happiness;

  // Token: 0x04000331 RID: 817
  public float Blink;
}