using UnityEngine;

// Token: 0x0200005D RID: 93
public class ChangeTextureScript : MonoBehaviour {

  // Token: 0x06000150 RID: 336 RVA: 0x00015E5C File Offset: 0x0001425C
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.ID++;
      if (this.ID == this.Textures.Length) {
        this.ID = 1;
      }
      this.MyRenderer.material.mainTexture = this.Textures[this.ID];
    }
  }

  // Token: 0x04000410 RID: 1040
  public Renderer MyRenderer;

  // Token: 0x04000411 RID: 1041
  public Texture[] Textures;

  // Token: 0x04000412 RID: 1042
  public int ID = 1;
}