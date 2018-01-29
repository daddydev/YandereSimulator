using UnityEngine;

// Token: 0x02000054 RID: 84
public class BuildingDestructionScript : MonoBehaviour {

  // Token: 0x06000133 RID: 307 RVA: 0x00013E54 File Offset: 0x00012254
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.Phase++;
      this.Sink = true;
    }
    if (this.Sink) {
      if (this.Phase == 1) {
        base.transform.position = new Vector3(UnityEngine.Random.Range(-1f, 1f), base.transform.position.y - Time.deltaTime * 10f, UnityEngine.Random.Range(-19f, -21f));
      } else if (this.NewSchool.position.y != 0f) {
        this.NewSchool.position = new Vector3(this.NewSchool.position.x, Mathf.MoveTowards(this.NewSchool.position.y, 0f, Time.deltaTime * 10f), this.NewSchool.position.z);
        base.transform.position = new Vector3(UnityEngine.Random.Range(-1f, 1f), base.transform.position.y, UnityEngine.Random.Range(13f, 15f));
      } else {
        base.transform.position = new Vector3(0f, base.transform.position.y, 14f);
      }
    }
  }

  // Token: 0x040003CB RID: 971
  public Transform NewSchool;

  // Token: 0x040003CC RID: 972
  public bool Sink;

  // Token: 0x040003CD RID: 973
  public int Phase;
}