using UnityEngine;

// Token: 0x02000244 RID: 580
public class FoldingChairScript : MonoBehaviour {

  // Token: 0x06000A28 RID: 2600 RVA: 0x000BA548 File Offset: 0x000B8948
  private void Start() {
    int num = UnityEngine.Random.Range(0, this.Student.Length);
    UnityEngine.Object.Instantiate<GameObject>(this.Student[num], base.transform.position - new Vector3(0f, 0.4f, 0f), base.transform.rotation);
  }

  // Token: 0x04001EC6 RID: 7878
  public GameObject[] Student;
}