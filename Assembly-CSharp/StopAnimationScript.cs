using UnityEngine;

// Token: 0x020001C4 RID: 452
public class StopAnimationScript : MonoBehaviour {

  // Token: 0x060007D6 RID: 2006 RVA: 0x0007880E File Offset: 0x00076C0E
  private void Start() {
    this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
    this.Anim = base.GetComponent<Animation>();
  }

  // Token: 0x060007D7 RID: 2007 RVA: 0x00078834 File Offset: 0x00076C34
  private void Update() {
    if (this.StudentManager.DisableFarAnims) {
      if (Vector3.Distance(this.Yandere.position, base.transform.position) > 15f) {
        if (this.Anim.enabled) {
          this.Anim.enabled = false;
        }
      } else if (!this.Anim.enabled) {
        this.Anim.enabled = true;
      }
    } else if (!this.Anim.enabled) {
      this.Anim.enabled = true;
    }
  }

  // Token: 0x04001416 RID: 5142
  public StudentManagerScript StudentManager;

  // Token: 0x04001417 RID: 5143
  public Transform Yandere;

  // Token: 0x04001418 RID: 5144
  private Animation Anim;
}