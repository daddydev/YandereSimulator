using UnityEngine;

// Token: 0x020000C7 RID: 199
public class GasterBeamScript : MonoBehaviour {

  // Token: 0x060002FA RID: 762 RVA: 0x00038D10 File Offset: 0x00037110
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (component != null) {
        component.DeathType = DeathType.EasterEgg;
        component.BecomeRagdoll();
        Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
        rigidbody.isKinematic = false;
        rigidbody.AddForce((rigidbody.transform.root.position - base.transform.root.position) * this.Strength);
        rigidbody.AddForce(Vector3.up * 1000f);
      }
    }
  }

  // Token: 0x04000985 RID: 2437
  public float Strength = 1000f;
}