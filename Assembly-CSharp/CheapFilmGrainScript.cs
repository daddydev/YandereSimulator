using UnityEngine;

// Token: 0x02000060 RID: 96
public class CheapFilmGrainScript : MonoBehaviour {

  // Token: 0x06000158 RID: 344 RVA: 0x00016672 File Offset: 0x00014A72
  private void Update() {
    this.MyRenderer.material.mainTextureScale = new Vector2(UnityEngine.Random.Range(this.Floor, this.Ceiling), UnityEngine.Random.Range(this.Floor, this.Ceiling));
  }

  // Token: 0x0400042E RID: 1070
  public Renderer MyRenderer;

  // Token: 0x0400042F RID: 1071
  public float Floor = 100f;

  // Token: 0x04000430 RID: 1072
  public float Ceiling = 200f;
}