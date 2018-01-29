using UnityEngine;

// Token: 0x0200012D RID: 301
public class MatchTriggerScript : MonoBehaviour {

  // Token: 0x060005B7 RID: 1463 RVA: 0x0004F298 File Offset: 0x0004D698
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      this.Student = other.gameObject.GetComponent<StudentScript>();
      if (this.Student == null) {
        GameObject gameObject = other.gameObject.transform.root.gameObject;
        this.Student = gameObject.GetComponent<StudentScript>();
      }
      if (this.Student != null && (this.Student.Gas || this.Fireball)) {
        this.Student.Combust();
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
  }

  // Token: 0x04000DB5 RID: 3509
  public StudentScript Student;

  // Token: 0x04000DB6 RID: 3510
  public bool Fireball;
}