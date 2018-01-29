using UnityEngine;

// Token: 0x02000225 RID: 549
public class YanvaniaBlackHoleScript : MonoBehaviour {

  // Token: 0x060009C2 RID: 2498 RVA: 0x000B24CC File Offset: 0x000B08CC
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 1f) {
      this.SpawnTimer -= Time.deltaTime;
      if (this.SpawnTimer <= 0f && this.Attacks < 5) {
        UnityEngine.Object.Instantiate<GameObject>(this.BlackHoleAttack, base.transform.position, Quaternion.identity);
        this.SpawnTimer = 0.5f;
        this.Attacks++;
      }
    }
  }

  // Token: 0x04001D80 RID: 7552
  public GameObject BlackHoleAttack;

  // Token: 0x04001D81 RID: 7553
  public int Attacks;

  // Token: 0x04001D82 RID: 7554
  public float SpawnTimer;

  // Token: 0x04001D83 RID: 7555
  public float Timer;
}