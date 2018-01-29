using UnityEngine;

// Token: 0x020000F7 RID: 247
public class HomeCursorScript : MonoBehaviour {

  // Token: 0x060004E4 RID: 1252 RVA: 0x00041240 File Offset: 0x0003F640
  private void OnTriggerExit(Collider other) {
    if (other.gameObject == this.Photograph) {
      this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
      this.Photograph = null;
      this.PhotoGallery.UpdateButtonPrompts();
    }
  }

  // Token: 0x060004E5 RID: 1253 RVA: 0x000412B0 File Offset: 0x0003F6B0
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name != "SouthWall") {
      this.Photograph = other.gameObject;
      this.Highlight.localEulerAngles = this.Photograph.transform.localEulerAngles;
      this.Highlight.localPosition = this.Photograph.transform.localPosition;
      this.PhotoGallery.UpdateButtonPrompts();
    }
  }

  // Token: 0x04000B24 RID: 2852
  public PhotoGalleryScript PhotoGallery;

  // Token: 0x04000B25 RID: 2853
  public GameObject Photograph;

  // Token: 0x04000B26 RID: 2854
  public Transform Highlight;
}