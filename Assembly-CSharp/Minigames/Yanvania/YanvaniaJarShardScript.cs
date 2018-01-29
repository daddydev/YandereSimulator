using UnityEngine;

// Token: 0x0200022F RID: 559
public class YanvaniaJarShardScript : MonoBehaviour {

  // Token: 0x060009E1 RID: 2529 RVA: 0x000B4620 File Offset: 0x000B2A20
  private void Start() {
    this.Rotation = UnityEngine.Random.Range(-360f, 360f);
    base.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-100f, 100f));
  }

  // Token: 0x060009E2 RID: 2530 RVA: 0x000B467C File Offset: 0x000B2A7C
  private void Update() {
    this.MyRotation += this.Rotation;
    base.transform.eulerAngles = new Vector3(this.MyRotation, this.MyRotation, this.MyRotation);
    if (base.transform.position.y < 6.5f) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001DD5 RID: 7637
  public float MyRotation;

  // Token: 0x04001DD6 RID: 7638
  public float Rotation;
}