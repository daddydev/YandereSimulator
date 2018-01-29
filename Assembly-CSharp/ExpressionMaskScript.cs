using UnityEngine;

// Token: 0x020000B7 RID: 183
public class ExpressionMaskScript : MonoBehaviour {

  // Token: 0x060002C8 RID: 712 RVA: 0x00035434 File Offset: 0x00033834
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      if (this.ID < 3) {
        this.ID++;
      } else {
        this.ID = 0;
      }
      switch (this.ID) {
        case 0:
          this.Mask.material.mainTextureOffset = Vector2.zero;
          break;

        case 1:
          this.Mask.material.mainTextureOffset = new Vector2(0f, 0.5f);
          break;

        case 2:
          this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0f);
          break;

        case 3:
          this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
          break;
      }
    }
  }

  // Token: 0x040008CF RID: 2255
  public Renderer Mask;

  // Token: 0x040008D0 RID: 2256
  public int ID;
}