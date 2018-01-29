using UnityEngine;

// Token: 0x02000064 RID: 100
public class CirnoIceAttackScript : MonoBehaviour {

  // Token: 0x06000161 RID: 353 RVA: 0x00016A7B File Offset: 0x00014E7B
  private void Start() {
    Physics.IgnoreLayerCollision(18, 13, true);
    Physics.IgnoreLayerCollision(18, 18, true);
  }

  // Token: 0x06000162 RID: 354 RVA: 0x00016A94 File Offset: 0x00014E94
  private void OnCollisionEnter(Collision collision) {
    UnityEngine.Object.Instantiate<GameObject>(this.IceExplosion, base.transform.position, Quaternion.identity);
    if (collision.gameObject.layer == 9) {
      StudentScript component = collision.gameObject.GetComponent<StudentScript>();
      if (component != null) {
        component.SpawnAlarmDisc();
        component.BecomeRagdoll();
      }
    }
    UnityEngine.Object.Destroy(base.gameObject);
  }

  // Token: 0x0400043C RID: 1084
  public GameObject IceExplosion;
}