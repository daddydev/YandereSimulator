using UnityEngine;

// Token: 0x02000228 RID: 552
public class YanvaniaCandlestickHeadScript : MonoBehaviour {

  // Token: 0x060009CA RID: 2506 RVA: 0x000B2818 File Offset: 0x000B0C18
  private void Start() {
    Rigidbody component = base.GetComponent<Rigidbody>();
    component.AddForce(base.transform.up * 100f);
    component.AddForce(base.transform.right * 100f);
    this.Value = UnityEngine.Random.Range(-1f, 1f);
  }

  // Token: 0x060009CB RID: 2507 RVA: 0x000B2878 File Offset: 0x000B0C78
  private void Update() {
    this.Rotation += new Vector3(this.Value, this.Value, this.Value);
    base.transform.localEulerAngles = this.Rotation;
    if (base.transform.localPosition.y < 0.23f) {
      UnityEngine.Object.Instantiate<GameObject>(this.Fire, base.transform.position, Quaternion.identity);
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001D8D RID: 7565
  public GameObject Fire;

  // Token: 0x04001D8E RID: 7566
  public Vector3 Rotation;

  // Token: 0x04001D8F RID: 7567
  public float Value;
}