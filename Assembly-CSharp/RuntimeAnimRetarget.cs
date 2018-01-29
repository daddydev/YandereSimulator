using UnityEngine;

// Token: 0x0200018A RID: 394
public class RuntimeAnimRetarget : MonoBehaviour {

  // Token: 0x06000711 RID: 1809 RVA: 0x0006C49C File Offset: 0x0006A89C
  private void Start() {
    Debug.Log(this.Source.name);
    this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
    this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
  }

  // Token: 0x06000712 RID: 1810 RVA: 0x0006C4D0 File Offset: 0x0006A8D0
  private void LateUpdate() {
    this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
    for (int i = 0; i < 154; i++) {
      this.TargetSkelNodes[i].transform.localRotation = this.SourceSkelNodes[i].transform.localRotation;
    }
  }

  // Token: 0x040011F1 RID: 4593
  public GameObject Source;

  // Token: 0x040011F2 RID: 4594
  public GameObject Target;

  // Token: 0x040011F3 RID: 4595
  private Component[] SourceSkelNodes;

  // Token: 0x040011F4 RID: 4596
  private Component[] TargetSkelNodes;
}