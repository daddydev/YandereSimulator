using UnityEngine;

// Token: 0x02000223 RID: 547
public class YanvaniaBigFireballScript : MonoBehaviour {

  // Token: 0x060009BC RID: 2492 RVA: 0x000B2324 File Offset: 0x000B0724
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "YanmontChan") {
      other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
      UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001D7D RID: 7549
  public GameObject Explosion;
}