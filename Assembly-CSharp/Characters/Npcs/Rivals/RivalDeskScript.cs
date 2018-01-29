using System;
using UnityEngine;

// Token: 0x0200017A RID: 378
public class RivalDeskScript : MonoBehaviour {

  // Token: 0x060006F5 RID: 1781 RVA: 0x0006BC88 File Offset: 0x0006A088
  private void Update() {
    if (SchemeGlobals.GetSchemeStage(5) == 5 && DateGlobals.Weekday == DayOfWeek.Friday) {
      if (this.Clock.HourTime > 13f) {
        this.Prompt.HideButton[0] = false;
        if (this.Clock.HourTime > 13.5f) {
          SchemeGlobals.SetSchemeStage(5, 100);
          this.Schemes.UpdateInstructions();
          this.Prompt.HideButton[0] = true;
        }
      }
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        SchemeGlobals.SetSchemeStage(5, 6);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.DuplicateSheet = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Cheating = true;
      }
    }
  }

  // Token: 0x04001180 RID: 4480
  public SchemesScript Schemes;

  // Token: 0x04001181 RID: 4481
  public ClockScript Clock;

  // Token: 0x04001182 RID: 4482
  public PromptScript Prompt;

  // Token: 0x04001183 RID: 4483
  public bool Cheating;
}