using UnityEngine;

// Token: 0x02000103 RID: 259
public class HomeTriggerScript : MonoBehaviour {

  // Token: 0x06000514 RID: 1300 RVA: 0x00046474 File Offset: 0x00044874
  private void Start() {
    this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
  }

  // Token: 0x06000515 RID: 1301 RVA: 0x000464CF File Offset: 0x000448CF
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      this.HomeCamera.ID = this.ID;
      this.FadeIn = true;
    }
  }

  // Token: 0x06000516 RID: 1302 RVA: 0x000464FE File Offset: 0x000448FE
  private void OnTriggerExit(Collider other) {
    if (other.tag == "Player") {
      this.HomeCamera.ID = 0;
      this.FadeIn = false;
    }
  }

  // Token: 0x06000517 RID: 1303 RVA: 0x00046528 File Offset: 0x00044928
  private void Update() {
    this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, (!this.FadeIn) ? 0f : 1f, Time.deltaTime * 10f));
  }

  // Token: 0x06000518 RID: 1304 RVA: 0x000465BC File Offset: 0x000449BC
  public void Disable() {
    this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
    base.gameObject.SetActive(false);
  }

  // Token: 0x04000C06 RID: 3078
  public HomeCameraScript HomeCamera;

  // Token: 0x04000C07 RID: 3079
  public UILabel Label;

  // Token: 0x04000C08 RID: 3080
  public bool FadeIn;

  // Token: 0x04000C09 RID: 3081
  public int ID;
}