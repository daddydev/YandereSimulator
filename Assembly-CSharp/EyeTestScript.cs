using UnityEngine;

// Token: 0x02000240 RID: 576
public class EyeTestScript : MonoBehaviour {

  // Token: 0x06000A1D RID: 2589 RVA: 0x000BA218 File Offset: 0x000B8618
  private void Start() {
    this.MyAnimation["moodyEyes_00"].layer = 1;
    this.MyAnimation.Play("moodyEyes_00");
    this.MyAnimation["moodyEyes_00"].weight = 1f;
    this.MyAnimation.Play("moodyEyes_00");
  }

  // Token: 0x04001EB8 RID: 7864
  public Animation MyAnimation;
}