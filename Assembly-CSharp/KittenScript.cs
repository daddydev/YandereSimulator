using UnityEngine;

// Token: 0x0200011E RID: 286
public class KittenScript : MonoBehaviour {

  // Token: 0x06000589 RID: 1417 RVA: 0x0004C278 File Offset: 0x0004A678
  private void Start() {
  }

  // Token: 0x0600058A RID: 1418 RVA: 0x0004C27A File Offset: 0x0004A67A
  private void Update() {
  }

  // Token: 0x0600058B RID: 1419 RVA: 0x0004C27C File Offset: 0x0004A67C
  private void PickRandomAnim() {
  }

  // Token: 0x0600058C RID: 1420 RVA: 0x0004C280 File Offset: 0x0004A680
  private void LateUpdate() {
    if (!this.Yandere.Aiming) {
      Vector3 b = (this.Yandere.Head.transform.position.x >= base.transform.position.x) ? (base.transform.position + base.transform.forward + base.transform.up * 0.139854f) : this.Yandere.Head.transform.position;
      this.Target.position = Vector3.Lerp(this.Target.position, b, Time.deltaTime * 5f);
      this.Head.transform.LookAt(this.Target);
    } else {
      this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
    }
  }

  // Token: 0x04000D2D RID: 3373
  public YandereScript Yandere;

  // Token: 0x04000D2E RID: 3374
  public GameObject Character;

  // Token: 0x04000D2F RID: 3375
  public string[] AnimationNames;

  // Token: 0x04000D30 RID: 3376
  public Transform Target;

  // Token: 0x04000D31 RID: 3377
  public Transform Head;

  // Token: 0x04000D32 RID: 3378
  public string CurrentAnim = string.Empty;

  // Token: 0x04000D33 RID: 3379
  public string IdleAnim = string.Empty;

  // Token: 0x04000D34 RID: 3380
  public bool Wait;

  // Token: 0x04000D35 RID: 3381
  public float Timer;
}