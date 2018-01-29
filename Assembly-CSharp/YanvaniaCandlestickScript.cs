using UnityEngine;

// Token: 0x02000229 RID: 553
public class YanvaniaCandlestickScript : MonoBehaviour {

  // Token: 0x060009CD RID: 2509 RVA: 0x000B290C File Offset: 0x000B0D0C
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 19 && !this.Destroyed) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.DestroyedCandlestick, base.transform.position, Quaternion.identity);
      gameObject.transform.localScale = base.transform.localScale;
      this.Destroyed = true;
      AudioClipPlayer.Play2D(this.Break, base.transform.position);
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001D90 RID: 7568
  public GameObject DestroyedCandlestick;

  // Token: 0x04001D91 RID: 7569
  public bool Destroyed;

  // Token: 0x04001D92 RID: 7570
  public AudioClip Break;
}