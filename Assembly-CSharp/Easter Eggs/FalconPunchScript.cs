using UnityEngine;

// Token: 0x020000BB RID: 187
public class FalconPunchScript : MonoBehaviour {

  // Token: 0x060002D2 RID: 722 RVA: 0x00036081 File Offset: 0x00034481
  private void Update() {
    if (!this.IgnoreTime) {
      this.Timer += Time.deltaTime;
      if (this.Timer > this.TimeLimit) {
        this.MyCollider.enabled = false;
      }
    }
  }

  // Token: 0x060002D3 RID: 723 RVA: 0x000360C0 File Offset: 0x000344C0
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (component != null && component.StudentID > 1) {
        UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        component.DeathType = DeathType.EasterEgg;
        component.BecomeRagdoll();
        Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
        rigidbody.isKinematic = false;
        if (this.Falcon) {
          rigidbody.AddForce((rigidbody.transform.position - base.transform.position) * this.Strength);
        } else {
          rigidbody.AddForce((rigidbody.transform.root.position - base.transform.root.position) * this.Strength);
          rigidbody.AddForce(Vector3.up * 10000f);
        }
      }
    }
  }

  // Token: 0x040008FE RID: 2302
  public GameObject FalconExplosion;

  // Token: 0x040008FF RID: 2303
  public Collider MyCollider;

  // Token: 0x04000900 RID: 2304
  public float Strength = 100f;

  // Token: 0x04000901 RID: 2305
  public bool IgnoreTime;

  // Token: 0x04000902 RID: 2306
  public bool Falcon;

  // Token: 0x04000903 RID: 2307
  public float TimeLimit = 0.5f;

  // Token: 0x04000904 RID: 2308
  public float Timer;
}