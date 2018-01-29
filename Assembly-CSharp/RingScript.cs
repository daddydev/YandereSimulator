using UnityEngine;

// Token: 0x02000178 RID: 376
public class RingScript : MonoBehaviour {

  // Token: 0x060006F1 RID: 1777 RVA: 0x0006BA84 File Offset: 0x00069E84
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      SchemeGlobals.SetSchemeStage(2, 2);
      this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.Ring = true;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x0400117C RID: 4476
  public PromptScript Prompt;
}