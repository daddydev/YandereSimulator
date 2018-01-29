using UnityEngine;

// Token: 0x020001BC RID: 444
public class SplashSpawnerScript : MonoBehaviour {

  // Token: 0x060007BC RID: 1980 RVA: 0x00076AA8 File Offset: 0x00074EA8
  private void Update() {
    if (!this.FootUp) {
      if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold) {
        this.FootUp = true;
      }
    } else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold) {
      this.FootUp = false;
      if (this.Bloody) {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodSplash, new Vector3(base.transform.position.x, this.Yandere.position.y, base.transform.position.z), Quaternion.identity);
        gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
        this.Bloody = false;
      }
    }
  }

  // Token: 0x060007BD RID: 1981 RVA: 0x00076BE6 File Offset: 0x00074FE6
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "BloodPool(Clone)") {
      this.Bloody = true;
    }
  }

  // Token: 0x040013DB RID: 5083
  public GameObject BloodSplash;

  // Token: 0x040013DC RID: 5084
  public Transform Yandere;

  // Token: 0x040013DD RID: 5085
  public bool Bloody;

  // Token: 0x040013DE RID: 5086
  public bool FootUp;

  // Token: 0x040013DF RID: 5087
  public float DownThreshold;

  // Token: 0x040013E0 RID: 5088
  public float UpThreshold;

  // Token: 0x040013E1 RID: 5089
  public float Height;
}