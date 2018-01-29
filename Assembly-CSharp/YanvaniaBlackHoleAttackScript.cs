using UnityEngine;

// Token: 0x02000224 RID: 548
public class YanvaniaBlackHoleAttackScript : MonoBehaviour {

  // Token: 0x060009BE RID: 2494 RVA: 0x000B238C File Offset: 0x000B078C
  private void Start() {
    this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
  }

  // Token: 0x060009BF RID: 2495 RVA: 0x000B23A4 File Offset: 0x000B07A4
  private void Update() {
    base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
    if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x060009C0 RID: 2496 RVA: 0x000B2430 File Offset: 0x000B0830
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      UnityEngine.Object.Instantiate<GameObject>(this.BlackExplosion, base.transform.position, Quaternion.identity);
      this.Yanmont.TakeDamage(20);
    }
    if (other.gameObject.name == "Heart") {
      UnityEngine.Object.Instantiate<GameObject>(this.BlackExplosion, base.transform.position, Quaternion.identity);
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001D7E RID: 7550
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001D7F RID: 7551
  public GameObject BlackExplosion;
}