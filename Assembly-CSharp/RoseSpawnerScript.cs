using UnityEngine;

// Token: 0x02000247 RID: 583
public class RoseSpawnerScript : MonoBehaviour {

  // Token: 0x06000A30 RID: 2608 RVA: 0x000BA68F File Offset: 0x000B8A8F
  private void Start() {
    this.SpawnRose();
  }

  // Token: 0x06000A31 RID: 2609 RVA: 0x000BA697 File Offset: 0x000B8A97
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 0.1f) {
      this.SpawnRose();
    }
  }

  // Token: 0x06000A32 RID: 2610 RVA: 0x000BA6C4 File Offset: 0x000B8AC4
  private void SpawnRose() {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Rose, base.transform.position, Quaternion.identity);
    gameObject.GetComponent<Rigidbody>().AddForce(base.transform.forward * this.ForwardForce);
    gameObject.GetComponent<Rigidbody>().AddForce(base.transform.up * this.UpwardForce);
    gameObject.transform.localEulerAngles = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f));
    base.transform.localPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.y, base.transform.localPosition.z);
    base.transform.LookAt(this.DramaGirl);
    this.Timer = 0f;
  }

  // Token: 0x04001EC9 RID: 7881
  public Transform DramaGirl;

  // Token: 0x04001ECA RID: 7882
  public Transform Target;

  // Token: 0x04001ECB RID: 7883
  public GameObject Rose;

  // Token: 0x04001ECC RID: 7884
  public float Timer;

  // Token: 0x04001ECD RID: 7885
  public float ForwardForce;

  // Token: 0x04001ECE RID: 7886
  public float UpwardForce;
}