using UnityEngine;

// Token: 0x02000086 RID: 134
public class DemonSlashScript : MonoBehaviour {

  // Token: 0x0600021B RID: 539 RVA: 0x0002BDEC File Offset: 0x0002A1EC
  private void Update() {
    if (this.MyCollider.enabled) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 0.333333343f) {
        this.MyCollider.enabled = false;
        this.Timer = 0f;
      }
    }
  }

  // Token: 0x0600021C RID: 540 RVA: 0x0002BE44 File Offset: 0x0002A244
  private void OnTriggerEnter(Collider other) {
    Transform root = other.gameObject.transform.root;
    StudentScript component = root.gameObject.GetComponent<StudentScript>();
    if (component != null && component.StudentID != 1 && component.Alive) {
      component.DeathType = DeathType.EasterEgg;
      if (!component.Male) {
        UnityEngine.Object.Instantiate<GameObject>(this.FemaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
      } else {
        UnityEngine.Object.Instantiate<GameObject>(this.MaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
      }
      component.BecomeRagdoll();
      component.Ragdoll.Dismember();
      base.GetComponent<AudioSource>().Play();
    }
  }

  // Token: 0x04000755 RID: 1877
  public GameObject FemaleBloodyScream;

  // Token: 0x04000756 RID: 1878
  public GameObject MaleBloodyScream;

  // Token: 0x04000757 RID: 1879
  public Collider MyCollider;

  // Token: 0x04000758 RID: 1880
  public float Timer;
}