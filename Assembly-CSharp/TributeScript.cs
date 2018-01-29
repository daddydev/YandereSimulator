using UnityEngine;

// Token: 0x020001EA RID: 490
public class TributeScript : MonoBehaviour {

  // Token: 0x060008C5 RID: 2245 RVA: 0x0009DF96 File Offset: 0x0009C396
  private void Start() {
    this.Rainey.SetActive(false);
  }

  // Token: 0x060008C6 RID: 2246 RVA: 0x0009DFA4 File Offset: 0x0009C3A4
  private void Update() {
    if (Input.GetKeyDown(this.Letter[this.ID])) {
      this.ID++;
      if (this.ID == this.Letter.Length) {
        this.Rainey.SetActive(true);
        base.enabled = false;
      }
    }
  }

  // Token: 0x040019EF RID: 6639
  public GameObject Rainey;

  // Token: 0x040019F0 RID: 6640
  public string[] Letter;

  // Token: 0x040019F1 RID: 6641
  public int ID;
}