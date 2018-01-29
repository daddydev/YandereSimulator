using UnityEngine;

// Token: 0x020001DC RID: 476
public class TextureManagerScript : MonoBehaviour {

  // Token: 0x06000893 RID: 2195 RVA: 0x0009AB5C File Offset: 0x00098F5C
  public Texture2D MergeTextures(Texture2D BackgroundTex, Texture2D TopTex) {
    Texture2D texture2D = new Texture2D(1024, 1024);
    Color32[] pixels = BackgroundTex.GetPixels32();
    Color32[] pixels2 = TopTex.GetPixels32();
    for (int i = 0; i < pixels2.Length; i++) {
      if (pixels2[i].a != 0) {
        pixels[i] = pixels2[i];
      }
    }
    texture2D.SetPixels32(pixels);
    texture2D.Apply();
    return texture2D;
  }

  // Token: 0x04001954 RID: 6484
  public Texture[] UniformTextures;

  // Token: 0x04001955 RID: 6485
  public Texture[] CasualTextures;

  // Token: 0x04001956 RID: 6486
  public Texture[] SocksTextures;

  // Token: 0x04001957 RID: 6487
  public Texture2D PurpleStockings;

  // Token: 0x04001958 RID: 6488
  public Texture2D GreenStockings;

  // Token: 0x04001959 RID: 6489
  public Texture2D Base2D;

  // Token: 0x0400195A RID: 6490
  public Texture2D Overlay2D;
}