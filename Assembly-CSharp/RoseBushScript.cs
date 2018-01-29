using UnityEngine;

// Token: 0x02000188 RID: 392
public class RoseBushScript : MonoBehaviour {

  // Token: 0x0600070B RID: 1803 RVA: 0x0006C170 File Offset: 0x0006A570
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Yandere.Inventory.Rose = true;
      base.enabled = false;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }

  // Token: 0x040011E7 RID: 4583
  public PromptScript Prompt;
}