using UnityEngine;

// Token: 0x02000035 RID: 53
public class ArcScript : MonoBehaviour {

  // Token: 0x060000C0 RID: 192 RVA: 0x0000D034 File Offset: 0x0000B434
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 1f) {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ArcTrail, base.transform.position, base.transform.rotation);
      gameObject.GetComponent<Rigidbody>().AddRelativeForce(ArcScript.NEW_ARC_RELATIVE_FORCE);
      this.Timer = 0f;
    }
  }

  // Token: 0x040002D5 RID: 725
  private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 250f;

  // Token: 0x040002D6 RID: 726
  public GameObject ArcTrail;

  // Token: 0x040002D7 RID: 727
  public float Timer;
}