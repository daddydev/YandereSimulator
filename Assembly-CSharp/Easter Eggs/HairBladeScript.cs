using UnityEngine;

// Token: 0x020000EC RID: 236
public class HairBladeScript : MonoBehaviour {

  // Token: 0x060004BE RID: 1214 RVA: 0x0003D7BA File Offset: 0x0003BBBA
  private void Update() {
  }

  // Token: 0x060004BF RID: 1215 RVA: 0x0003D7BC File Offset: 0x0003BBBC
  private void OnTriggerEnter(Collider other) {
    GameObject gameObject = other.gameObject.transform.root.gameObject;
    if (gameObject.GetComponent<StudentScript>() != null) {
      this.Student = gameObject.GetComponent<StudentScript>();
      if (this.Student.StudentID != 1 && this.Student.Alive) {
        this.Student.DeathType = DeathType.EasterEgg;
        UnityEngine.Object.Instantiate<GameObject>((!this.Student.Male) ? this.FemaleBloodyScream : this.MaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
        this.Student.BecomeRagdoll();
        this.Student.Ragdoll.Dismember();
        base.GetComponent<AudioSource>().Play();
      }
    }
  }

  // Token: 0x04000A7B RID: 2683
  public GameObject FemaleBloodyScream;

  // Token: 0x04000A7C RID: 2684
  public GameObject MaleBloodyScream;

  // Token: 0x04000A7D RID: 2685
  public Vector3 PreviousPosition;

  // Token: 0x04000A7E RID: 2686
  public Collider MyCollider;

  // Token: 0x04000A7F RID: 2687
  public float Timer;

  // Token: 0x04000A80 RID: 2688
  public StudentScript Student;
}