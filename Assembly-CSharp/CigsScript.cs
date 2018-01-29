using UnityEngine;

// Token: 0x02000063 RID: 99
public class CigsScript : MonoBehaviour {

  // Token: 0x0600015F RID: 351 RVA: 0x00016A08 File Offset: 0x00014E08
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      SchemeGlobals.SetSchemeStage(3, 3);
      this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.Cigs = true;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x0400043B RID: 1083
  public PromptScript Prompt;
}