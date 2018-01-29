using UnityEngine;

// Token: 0x0200012C RID: 300
public class MatchScript : MonoBehaviour {

  // Token: 0x060005B5 RID: 1461 RVA: 0x0004F18C File Offset: 0x0004D58C
  private void Update() {
    if (base.GetComponent<Rigidbody>().useGravity) {
      base.transform.Rotate(Vector3.right * (Time.deltaTime * 360f));
      if (this.Timer > 0f && this.MyCollider.isTrigger) {
        this.MyCollider.isTrigger = false;
      }
      this.Timer += Time.deltaTime;
      if (this.Timer > 5f) {
        base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z - Time.deltaTime);
        if (base.transform.localScale.z < 0f) {
          UnityEngine.Object.Destroy(base.gameObject);
        }
      }
    }
  }

  // Token: 0x04000DB3 RID: 3507
  public float Timer;

  // Token: 0x04000DB4 RID: 3508
  public Collider MyCollider;
}