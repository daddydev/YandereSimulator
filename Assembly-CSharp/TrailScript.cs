using UnityEngine;

// Token: 0x020001E4 RID: 484
public class TrailScript : MonoBehaviour {

  // Token: 0x060008B4 RID: 2228 RVA: 0x0009D454 File Offset: 0x0009B854
  private void Start() {
    GameObject gameObject = GameObject.Find("YandereChan");
    Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), base.GetComponent<Collider>());
    UnityEngine.Object.Destroy(this);
  }
}