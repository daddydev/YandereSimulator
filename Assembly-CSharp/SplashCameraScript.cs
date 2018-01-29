using UnityEngine;

// Token: 0x020001BB RID: 443
public class SplashCameraScript : MonoBehaviour {

  // Token: 0x060007B9 RID: 1977 RVA: 0x000768D2 File Offset: 0x00074CD2
  private void Start() {
    this.MyCamera.enabled = false;
    this.MyCamera.rect = new Rect(0f, 0.219f, 0f, 0f);
  }

  // Token: 0x060007BA RID: 1978 RVA: 0x00076904 File Offset: 0x00074D04
  private void Update() {
    if (this.Show) {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.4f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.71104f, Time.deltaTime * 10f));
      this.Timer += Time.deltaTime;
      if (this.Timer > 15f) {
        this.Show = false;
        this.Timer = 0f;
      }
    } else {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0f, Time.deltaTime * 10f));
      if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f) {
        this.MyCamera.enabled = false;
      }
    }
  }

  // Token: 0x040013D8 RID: 5080
  public Camera MyCamera;

  // Token: 0x040013D9 RID: 5081
  public bool Show;

  // Token: 0x040013DA RID: 5082
  public float Timer;
}