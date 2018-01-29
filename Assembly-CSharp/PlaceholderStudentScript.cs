using UnityEngine;

// Token: 0x0200015B RID: 347
public class PlaceholderStudentScript : MonoBehaviour {

  // Token: 0x06000669 RID: 1641 RVA: 0x0005CB18 File Offset: 0x0005AF18
  private void Start() {
    this.Target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject).transform;
    this.ChooseNewDestination();
  }

  // Token: 0x0600066A RID: 1642 RVA: 0x0005CB38 File Offset: 0x0005AF38
  private void Update() {
    base.transform.LookAt(this.Target.position);
    base.transform.position = Vector3.MoveTowards(base.transform.position, this.Target.position, Time.deltaTime);
    if (Vector3.Distance(base.transform.position, this.Target.position) < 1f) {
      this.ChooseNewDestination();
    }
  }

  // Token: 0x0600066B RID: 1643 RVA: 0x0005CBB4 File Offset: 0x0005AFB4
  private void ChooseNewDestination() {
    if (this.NESW == 1) {
      this.Target.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), base.transform.position.y, UnityEngine.Random.Range(21f, 19f));
    } else if (this.NESW == 2) {
      this.Target.position = new Vector3(UnityEngine.Random.Range(19f, 21f), base.transform.position.y, UnityEngine.Random.Range(29f, -37f));
    } else if (this.NESW == 3) {
      this.Target.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), base.transform.position.y, UnityEngine.Random.Range(-21f, -19f));
    } else if (this.NESW == 4) {
      this.Target.position = new Vector3(UnityEngine.Random.Range(-19f, -21f), base.transform.position.y, UnityEngine.Random.Range(29f, -37f));
    }
  }

  // Token: 0x04000F98 RID: 3992
  public GameObject EmptyGameObject;

  // Token: 0x04000F99 RID: 3993
  public Transform Target;

  // Token: 0x04000F9A RID: 3994
  public int NESW;
}