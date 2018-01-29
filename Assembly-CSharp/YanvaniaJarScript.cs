using UnityEngine;

// Token: 0x0200022E RID: 558
public class YanvaniaJarScript : MonoBehaviour {

  // Token: 0x060009DF RID: 2527 RVA: 0x000B4528 File Offset: 0x000B2928
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 19 && !this.Destroyed) {
      UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position + Vector3.up * 0.5f, Quaternion.identity);
      this.Destroyed = true;
      AudioClipPlayer.Play2D(this.Break, base.transform.position);
      for (int i = 1; i < 11; i++) {
        UnityEngine.Object.Instantiate<GameObject>(this.Shard, base.transform.position + Vector3.up * UnityEngine.Random.Range(0f, 1f) + Vector3.right * UnityEngine.Random.Range(-0.5f, 0.5f), Quaternion.identity);
      }
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001DD1 RID: 7633
  public GameObject Explosion;

  // Token: 0x04001DD2 RID: 7634
  public bool Destroyed;

  // Token: 0x04001DD3 RID: 7635
  public AudioClip Break;

  // Token: 0x04001DD4 RID: 7636
  public GameObject Shard;
}