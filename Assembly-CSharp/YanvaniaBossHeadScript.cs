using UnityEngine;

// Token: 0x02000226 RID: 550
public class YanvaniaBossHeadScript : MonoBehaviour {

  // Token: 0x060009C4 RID: 2500 RVA: 0x000B2566 File Offset: 0x000B0966
  private void Update() {
    this.Timer -= Time.deltaTime;
  }

  // Token: 0x060009C5 RID: 2501 RVA: 0x000B257C File Offset: 0x000B097C
  private void OnTriggerEnter(Collider other) {
    if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart") {
      UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
      this.Timer = 1f;
      this.Dracula.TakeDamage();
    }
  }

  // Token: 0x04001D84 RID: 7556
  public YanvaniaDraculaScript Dracula;

  // Token: 0x04001D85 RID: 7557
  public GameObject HitEffect;

  // Token: 0x04001D86 RID: 7558
  public float Timer;
}