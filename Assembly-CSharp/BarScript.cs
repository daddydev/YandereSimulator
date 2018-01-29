using UnityEngine;

// Token: 0x0200023E RID: 574
public class BarScript : MonoBehaviour {

  // Token: 0x06000A17 RID: 2583 RVA: 0x000BA09B File Offset: 0x000B849B
  private void Start() {
    base.transform.localScale = new Vector3(0f, 1f, 1f);
  }

  // Token: 0x06000A18 RID: 2584 RVA: 0x000BA0BC File Offset: 0x000B84BC
  private void Update() {
    base.transform.localScale = new Vector3(base.transform.localScale.x + this.Speed * Time.deltaTime, 1f, 1f);
    if ((double)base.transform.localScale.x > 0.1) {
      base.transform.localScale = new Vector3(0f, 1f, 1f);
    }
  }

  // Token: 0x04001EB5 RID: 7861
  public float Speed;
}