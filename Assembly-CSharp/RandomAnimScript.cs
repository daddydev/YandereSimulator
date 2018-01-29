using UnityEngine;

// Token: 0x02000171 RID: 369
public class RandomAnimScript : MonoBehaviour {

  // Token: 0x060006DB RID: 1755 RVA: 0x000698D0 File Offset: 0x00067CD0
  private void Start() {
    this.PickRandomAnim();
    base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
  }

  // Token: 0x060006DC RID: 1756 RVA: 0x000698EC File Offset: 0x00067CEC
  private void Update() {
    AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
    if (animationState.time >= animationState.length) {
      this.PickRandomAnim();
    }
  }

  // Token: 0x060006DD RID: 1757 RVA: 0x00069922 File Offset: 0x00067D22
  private void PickRandomAnim() {
    this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
    base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
  }

  // Token: 0x04001141 RID: 4417
  public string[] AnimationNames;

  // Token: 0x04001142 RID: 4418
  public string CurrentAnim = string.Empty;
}