using UnityEngine;

// Token: 0x02000179 RID: 377
public class RivalBagScript : MonoBehaviour {

  // Token: 0x060006F3 RID: 1779 RVA: 0x0006BAF8 File Offset: 0x00069EF8
  private void Update() {
    if (this.Prompt.Yandere.Inventory.Cigs) {
      this.Prompt.HideButton[0] = false;
    }
    if (this.Prompt.Yandere.Inventory.Ring) {
      this.Prompt.HideButton[1] = false;
    }
    if (SchemeGlobals.GetSchemeStage(3) == 3) {
      this.Prompt.HideButton[0] = (this.Clock.Period == 2 || this.Clock.Period == 4);
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        SchemeGlobals.SetSchemeStage(3, 4);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.Cigs = false;
        this.Prompt.HideButton[0] = true;
        base.enabled = false;
      }
    }
    if (SchemeGlobals.GetSchemeStage(2) == 2) {
      this.Prompt.HideButton[1] = (this.Clock.Period == 2 || this.Clock.Period == 4);
      if (this.Prompt.Circle[1].fillAmount == 0f) {
        SchemeGlobals.SetSchemeStage(2, 3);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.Ring = false;
        this.Prompt.HideButton[1] = true;
        base.enabled = false;
      }
    }
  }

  // Token: 0x0400117D RID: 4477
  public SchemesScript Schemes;

  // Token: 0x0400117E RID: 4478
  public ClockScript Clock;

  // Token: 0x0400117F RID: 4479
  public PromptScript Prompt;
}