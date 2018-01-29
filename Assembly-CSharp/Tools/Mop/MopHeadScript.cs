using UnityEngine;

// Token: 0x02000135 RID: 309
public class MopHeadScript : MonoBehaviour {

  // Token: 0x060005D1 RID: 1489 RVA: 0x00050494 File Offset: 0x0004E894
  private void OnTriggerStay(Collider other) {
    if (this.Mop.Bloodiness < 100f && other.tag == "Puddle") {
      this.BloodPool = other.gameObject.GetComponent<BloodPoolScript>();
      if (this.BloodPool != null) {
        this.BloodPool.Grow = false;
        other.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        if (this.BloodPool.Blood) {
          this.Mop.Bloodiness += Time.deltaTime * 10f;
          this.Mop.UpdateBlood();
        }
        if (other.transform.localScale.x < 0.1f) {
          UnityEngine.Object.Destroy(other.gameObject);
        }
      } else {
        UnityEngine.Object.Destroy(other.gameObject);
      }
    }
  }

  // Token: 0x04000DD6 RID: 3542
  public BloodPoolScript BloodPool;

  // Token: 0x04000DD7 RID: 3543
  public MopScript Mop;
}