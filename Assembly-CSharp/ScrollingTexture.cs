using UnityEngine;

// Token: 0x020001A9 RID: 425
public class ScrollingTexture : MonoBehaviour {

  // Token: 0x06000772 RID: 1906 RVA: 0x00070264 File Offset: 0x0006E664
  private void Update() {
    this.Offset += Time.deltaTime * this.Speed;
    base.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
  }

  // Token: 0x040012E3 RID: 4835
  public float Offset;

  // Token: 0x040012E4 RID: 4836
  public float Speed;
}