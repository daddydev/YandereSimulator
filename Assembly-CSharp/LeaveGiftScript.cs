using UnityEngine;

// Token: 0x02000121 RID: 289
public class LeaveGiftScript : MonoBehaviour {

  // Token: 0x06000596 RID: 1430 RVA: 0x0004CB8C File Offset: 0x0004AF8C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Box.SetActive(true);
      base.enabled = false;
    }
  }

  // Token: 0x04000D4B RID: 3403
  public PromptScript Prompt;

  // Token: 0x04000D4C RID: 3404
  public GameObject Box;
}