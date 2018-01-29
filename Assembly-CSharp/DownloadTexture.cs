using System.Collections;
using UnityEngine;

// Token: 0x02000017 RID: 23
[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour {

  // Token: 0x06000066 RID: 102 RVA: 0x0000A3C8 File Offset: 0x000087C8
  private IEnumerator Start() {
    WWW www = new WWW(this.url);
    yield return www;
    this.mTex = www.texture;
    if (this.mTex != null) {
      UITexture component = base.GetComponent<UITexture>();
      component.mainTexture = this.mTex;
      if (this.pixelPerfect) {
        component.MakePixelPerfect();
      }
    }
    www.Dispose();
    yield break;
  }

  // Token: 0x06000067 RID: 103 RVA: 0x0000A3E3 File Offset: 0x000087E3
  private void OnDestroy() {
    if (this.mTex != null) {
      UnityEngine.Object.Destroy(this.mTex);
    }
  }

  // Token: 0x0400012C RID: 300
  public string url = "http://www.yourwebsite.com/logo.png";

  // Token: 0x0400012D RID: 301
  public bool pixelPerfect = true;

  // Token: 0x0400012E RID: 302
  private Texture2D mTex;
}