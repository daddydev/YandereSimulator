using UnityEngine;

// Token: 0x02000187 RID: 391
public class RooftopScript : MonoBehaviour {

  // Token: 0x06000709 RID: 1801 RVA: 0x0006C110 File Offset: 0x0006A510
  private void Start() {
    if (SchoolGlobals.RoofFence) {
      foreach (GameObject gameObject in this.DumpPoints) {
        gameObject.SetActive(false);
      }
      this.Railing.SetActive(false);
      this.Fence.SetActive(true);
    }
  }

  // Token: 0x040011E4 RID: 4580
  public GameObject[] DumpPoints;

  // Token: 0x040011E5 RID: 4581
  public GameObject Railing;

  // Token: 0x040011E6 RID: 4582
  public GameObject Fence;
}