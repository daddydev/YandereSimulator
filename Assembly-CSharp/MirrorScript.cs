using UnityEngine;

// Token: 0x02000132 RID: 306
public class MirrorScript : MonoBehaviour {

  // Token: 0x060005CB RID: 1483 RVA: 0x000501C5 File Offset: 0x0004E5C5
  private void Start() {
    this.Limit = this.Idles.Length - 1;
  }

  // Token: 0x060005CC RID: 1484 RVA: 0x000501D8 File Offset: 0x0004E5D8
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.ID++;
      if (this.ID == this.Limit) {
        this.ID = 0;
      }
      if (!this.Prompt.Yandere.Carrying) {
        this.Prompt.Yandere.IdleAnim = this.Idles[this.ID];
      }
      this.Prompt.Yandere.OriginalIdleAnim = this.Idles[this.ID];
    }
  }

  // Token: 0x04000DCE RID: 3534
  public PromptScript Prompt;

  // Token: 0x04000DCF RID: 3535
  public string[] Idles;

  // Token: 0x04000DD0 RID: 3536
  public int ID;

  // Token: 0x04000DD1 RID: 3537
  public int Limit;
}