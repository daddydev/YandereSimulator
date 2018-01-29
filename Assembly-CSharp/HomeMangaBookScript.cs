using UnityEngine;

// Token: 0x020000FB RID: 251
public class HomeMangaBookScript : MonoBehaviour {

  // Token: 0x060004F5 RID: 1269 RVA: 0x000435FC File Offset: 0x000419FC
  private void Start() {
    base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
  }

  // Token: 0x060004F6 RID: 1270 RVA: 0x00043644 File Offset: 0x00041A44
  private void Update() {
    float y = (this.Manga.Selected != this.ID) ? 0f : (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed);
    base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
  }

  // Token: 0x04000B68 RID: 2920
  public HomeMangaScript Manga;

  // Token: 0x04000B69 RID: 2921
  public float RotationSpeed;

  // Token: 0x04000B6A RID: 2922
  public int ID;
}