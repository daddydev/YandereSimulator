using UnityEngine;

// Token: 0x020001E3 RID: 483
public class TornadoScript : MonoBehaviour {

  // Token: 0x060008B1 RID: 2225 RVA: 0x0009D2D4 File Offset: 0x0009B6D4
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 0.5f) {
      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
      this.MyCollider.enabled = true;
    }
  }

  // Token: 0x060008B2 RID: 2226 RVA: 0x0009D360 File Offset: 0x0009B760
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (component != null && component.StudentID > 1) {
        this.Scream = UnityEngine.Object.Instantiate<GameObject>((!component.Male) ? this.FemaleBloodyScream : this.MaleBloodyScream, component.transform.position + Vector3.up, Quaternion.identity);
        this.Scream.transform.parent = component.HipCollider.transform;
        this.Scream.transform.localPosition = Vector3.zero;
        component.DeathType = DeathType.EasterEgg;
        component.BecomeRagdoll();
        Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
        rigidbody.isKinematic = false;
        rigidbody.AddForce(Vector3.up * this.Strength);
      }
    }
  }

  // Token: 0x040019C9 RID: 6601
  public GameObject FemaleBloodyScream;

  // Token: 0x040019CA RID: 6602
  public GameObject MaleBloodyScream;

  // Token: 0x040019CB RID: 6603
  public GameObject Scream;

  // Token: 0x040019CC RID: 6604
  public Collider MyCollider;

  // Token: 0x040019CD RID: 6605
  public float Strength = 10000f;

  // Token: 0x040019CE RID: 6606
  public float Timer;
}