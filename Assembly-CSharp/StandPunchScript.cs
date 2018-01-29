using UnityEngine;

// Token: 0x020001BF RID: 447
public class StandPunchScript : MonoBehaviour {

  // Token: 0x060007C5 RID: 1989 RVA: 0x00077178 File Offset: 0x00075578
  private void OnTriggerEnter(Collider other) {
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (component != null && component.StudentID > 1) {
      component.JojoReact();
    }
  }

  // Token: 0x040013F0 RID: 5104
  public Collider MyCollider;
}