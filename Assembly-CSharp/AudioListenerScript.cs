using UnityEngine;

// Token: 0x02000039 RID: 57
public class AudioListenerScript : MonoBehaviour {

  // Token: 0x060000D6 RID: 214 RVA: 0x0000FF68 File Offset: 0x0000E368
  private void Update() {
    Camera main = Camera.main;
    if (main != null) {
      base.transform.position = this.Target.position;
      base.transform.eulerAngles = main.transform.eulerAngles;
    }
  }

  // Token: 0x04000308 RID: 776
  public Transform Target;
}