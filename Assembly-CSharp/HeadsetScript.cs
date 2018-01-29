using UnityEngine;

// Token: 0x020000EF RID: 239
public class HeadsetScript : MonoBehaviour {

  // Token: 0x060004CD RID: 1229 RVA: 0x0003E8C0 File Offset: 0x0003CCC0
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      PlayerGlobals.Headset = true;
      this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.Headset = true;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04000ABF RID: 2751
  public PromptScript Prompt;
}