using UnityEngine;

// Token: 0x020000BA RID: 186
public class FakeStudentSpawnerScript : MonoBehaviour {

  // Token: 0x060002D0 RID: 720 RVA: 0x00035DD0 File Offset: 0x000341D0
  public void Spawn() {
    if (!this.AlreadySpawned) {
      this.Student = this.FakeFemale;
      this.NESW = 1;
      while (this.Spawned < this.FloorLimit * 3) {
        if (this.NESW == 1) {
          this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(21f, 19f)), Quaternion.identity);
        } else if (this.NESW == 2) {
          this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
        } else if (this.NESW == 3) {
          this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(-21f, -19f)), Quaternion.identity);
        } else if (this.NESW == 4) {
          this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
        }
        this.NewStudent.GetComponent<PlaceholderStudentScript>().NESW = this.NESW;
        this.NewStudent.transform.parent = this.FakeStudentParent;
        this.CurrentFloor++;
        this.CurrentRow++;
        this.Spawned++;
        if (this.CurrentFloor == this.FloorLimit) {
          this.CurrentFloor = 0;
          this.Height += 4;
        }
        if (this.CurrentRow == this.RowLimit) {
          this.CurrentRow = 0;
          this.NESW++;
          if (this.NESW > 4) {
            this.NESW = 1;
          }
        }
        this.Student = ((!(this.Student == this.FakeFemale)) ? this.FakeFemale : this.FakeMale);
      }
      this.AlreadySpawned = true;
    } else {
      this.FakeStudentParent.gameObject.SetActive(!this.FakeStudentParent.gameObject.activeInHierarchy);
    }
  }

  // Token: 0x040008F1 RID: 2289
  public Transform FakeStudentParent;

  // Token: 0x040008F2 RID: 2290
  public GameObject NewStudent;

  // Token: 0x040008F3 RID: 2291
  public GameObject FakeFemale;

  // Token: 0x040008F4 RID: 2292
  public GameObject FakeMale;

  // Token: 0x040008F5 RID: 2293
  public GameObject Student;

  // Token: 0x040008F6 RID: 2294
  public bool AlreadySpawned;

  // Token: 0x040008F7 RID: 2295
  public int CurrentFloor;

  // Token: 0x040008F8 RID: 2296
  public int CurrentRow;

  // Token: 0x040008F9 RID: 2297
  public int FloorLimit;

  // Token: 0x040008FA RID: 2298
  public int RowLimit;

  // Token: 0x040008FB RID: 2299
  public int Spawned;

  // Token: 0x040008FC RID: 2300
  public int Height;

  // Token: 0x040008FD RID: 2301
  public int NESW;
}