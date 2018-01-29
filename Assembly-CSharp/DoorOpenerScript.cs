using UnityEngine;

// Token: 0x0200008E RID: 142
public class DoorOpenerScript : MonoBehaviour {

  // Token: 0x06000232 RID: 562 RVA: 0x0002F154 File Offset: 0x0002D554
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      this.Student = other.gameObject.GetComponent<StudentScript>();
      if (this.Student != null && !this.Student.Dying && !this.Door.Open && !this.Door.Locked) {
        this.Door.Student = this.Student;
        this.Door.OpenDoor();
      }
    }
  }

  // Token: 0x04000798 RID: 1944
  public StudentScript Student;

  // Token: 0x04000799 RID: 1945
  public DoorScript Door;
}