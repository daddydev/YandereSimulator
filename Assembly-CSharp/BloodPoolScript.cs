using UnityEngine;

// Token: 0x02000041 RID: 65
public class BloodPoolScript : MonoBehaviour {

  // Token: 0x060000EB RID: 235 RVA: 0x00011044 File Offset: 0x0000F444
  private void Start() {
    if (PlayerGlobals.PantiesEquipped == 7) {
      this.TargetSize *= 0.5f;
    }
    base.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 position = base.transform.position;
    if (position.x > 125f || position.x < -125f || position.z > 200f || position.z < -100f) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x060000EC RID: 236 RVA: 0x000110E8 File Offset: 0x0000F4E8
  private void Update() {
    if (this.Grow) {
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(this.TargetSize, this.TargetSize, this.TargetSize), Time.deltaTime);
      if (base.transform.localScale.x > this.TargetSize * 0.99f) {
        this.Grow = false;
      }
    }
  }

  // Token: 0x060000ED RID: 237 RVA: 0x00011162 File Offset: 0x0000F562
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "BloodSpawner") {
      this.Grow = true;
    }
  }

  // Token: 0x060000EE RID: 238 RVA: 0x00011185 File Offset: 0x0000F585
  private void OnTriggerExit(Collider other) {
    if (other.gameObject.name == "BloodSpawner") {
    }
  }

  // Token: 0x04000339 RID: 825
  public float TargetSize;

  // Token: 0x0400033A RID: 826
  public bool Blood = true;

  // Token: 0x0400033B RID: 827
  public bool Grow;
}