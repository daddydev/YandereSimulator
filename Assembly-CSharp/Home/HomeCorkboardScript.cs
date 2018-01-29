using UnityEngine;

// Token: 0x020000F6 RID: 246
public class HomeCorkboardScript : MonoBehaviour {

  // Token: 0x060004E2 RID: 1250 RVA: 0x0004111C File Offset: 0x0003F51C
  private void Update() {
    if (!this.HomeYandere.CanMove) {
      if (!this.Loaded) {
        base.StartCoroutine(this.PhotoGallery.GetPhotos());
        this.Loaded = true;
      }
      if (!this.PhotoGallery.Adjusting && !this.PhotoGallery.Viewing && !this.PhotoGallery.LoadingScreen.activeInHierarchy && Input.GetButtonDown("B")) {
        this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
        this.HomeCamera.Target = this.HomeCamera.Targets[0];
        this.HomeCamera.CorkboardLabel.SetActive(true);
        this.PhotoGallery.PromptBar.Show = false;
        this.PhotoGallery.enabled = false;
        this.HomeYandere.CanMove = true;
        this.HomeYandere.gameObject.SetActive(true);
        this.HomeWindow.Show = false;
        base.enabled = false;
        this.Loaded = false;
      }
    }
  }

  // Token: 0x04000B1E RID: 2846
  public InputManagerScript InputManager;

  // Token: 0x04000B1F RID: 2847
  public PhotoGalleryScript PhotoGallery;

  // Token: 0x04000B20 RID: 2848
  public HomeYandereScript HomeYandere;

  // Token: 0x04000B21 RID: 2849
  public HomeCameraScript HomeCamera;

  // Token: 0x04000B22 RID: 2850
  public HomeWindowScript HomeWindow;

  // Token: 0x04000B23 RID: 2851
  public bool Loaded;
}