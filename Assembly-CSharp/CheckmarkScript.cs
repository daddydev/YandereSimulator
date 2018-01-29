using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheckmarkScript : MonoBehaviour {

  // Token: 0x06000A1A RID: 2586 RVA: 0x000BA14C File Offset: 0x000B854C
  private void Start() {
    while (this.ID < this.Checkmarks.Length) {
      this.Checkmarks[this.ID].SetActive(false);
      this.ID++;
    }
    this.ID = 0;
  }

  // Token: 0x06000A1B RID: 2587 RVA: 0x000BA19C File Offset: 0x000B859C
  private void Update() {
    if (Input.GetKeyDown("space")) {
      this.ID = UnityEngine.Random.Range(0, this.Checkmarks.Length);
      while (this.Checkmarks[this.ID].active) {
        this.ID = UnityEngine.Random.Range(0, this.Checkmarks.Length);
      }
      this.Checkmarks[this.ID].SetActive(true);
    }
  }

  // Token: 0x04001EB6 RID: 7862
  public GameObject[] Checkmarks;

  // Token: 0x04001EB7 RID: 7863
  public int ID;
}