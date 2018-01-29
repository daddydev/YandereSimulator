using UnityEngine;

// Token: 0x0200012A RID: 298
public class LowPolyStudentScript : MonoBehaviour {

  // Token: 0x060005AF RID: 1455 RVA: 0x0004EEDC File Offset: 0x0004D2DC
  private void Update() {
    if ((float)this.Student.StudentManager.LowDetailThreshold > 0f) {
      float num = Vector3.Distance(this.Student.Yandere.MainCamera.transform.position, base.transform.position);
      if (num > (float)this.Student.StudentManager.LowDetailThreshold) {
        if (!this.MyMesh.enabled) {
          this.CharacterMesh.enabled = false;
          this.MyMesh.enabled = true;
        }
      } else if (this.MyMesh.enabled) {
        this.CharacterMesh.enabled = true;
        this.MyMesh.enabled = false;
      }
    } else if (this.MyMesh.enabled) {
      this.CharacterMesh.enabled = true;
      this.MyMesh.enabled = false;
    }
  }

  // Token: 0x04000DA4 RID: 3492
  public StudentScript Student;

  // Token: 0x04000DA5 RID: 3493
  public SkinnedMeshRenderer CharacterMesh;

  // Token: 0x04000DA6 RID: 3494
  public Renderer TeacherMesh;

  // Token: 0x04000DA7 RID: 3495
  public Renderer MyMesh;
}