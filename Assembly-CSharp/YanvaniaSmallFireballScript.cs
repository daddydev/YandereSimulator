using UnityEngine;

// Token: 0x02000231 RID: 561
public class YanvaniaSmallFireballScript : MonoBehaviour {

  // Token: 0x060009E7 RID: 2535 RVA: 0x000B4798 File Offset: 0x000B2B98
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "Heart") {
      UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
      UnityEngine.Object.Destroy(base.gameObject);
    }
    if (other.gameObject.name == "YanmontChan") {
      other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(10);
      UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001DDC RID: 7644
  public GameObject Explosion;
}