using UnityEngine;

// Token: 0x02000241 RID: 577
public class LargeTextScript : MonoBehaviour {

  // Token: 0x06000A1F RID: 2591 RVA: 0x000BA27F File Offset: 0x000B867F
  private void Start() {
    this.Label.text = this.String[this.ID];
  }

  // Token: 0x06000A20 RID: 2592 RVA: 0x000BA299 File Offset: 0x000B8699
  private void Update() {
    if (Input.GetKeyDown("space")) {
      this.ID++;
      this.Label.text = this.String[this.ID];
    }
  }

  // Token: 0x04001EB9 RID: 7865
  public UILabel Label;

  // Token: 0x04001EBA RID: 7866
  public string[] String;

  // Token: 0x04001EBB RID: 7867
  public int ID;
}