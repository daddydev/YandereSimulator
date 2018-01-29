using UnityEngine;

// Token: 0x020000F3 RID: 243
public class HidingSpotScript : MonoBehaviour {

  // Token: 0x060004D8 RID: 1240 RVA: 0x0004029C File Offset: 0x0003E69C
  private void Update() {
    if (this.Prompt.Yandere.Chased || this.Prompt.Yandere.StudentManager.PinningDown) {
      if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (!this.Prompt.enabled) {
      this.Prompt.enabled = true;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
      this.Prompt.Yandere.MyController.radius = 0f;
      this.Prompt.Yandere.MyController.height = 0.5f;
      this.Prompt.Yandere.HideAnim = this.AnimName;
      this.Prompt.Yandere.HidingSpot = this.Spot;
      this.Prompt.Yandere.ExitSpot = this.Exit;
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.Hiding = true;
      this.Prompt.Yandere.EmptyHands();
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "Stop";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
    }
  }

  // Token: 0x04000AEC RID: 2796
  public PromptBarScript PromptBar;

  // Token: 0x04000AED RID: 2797
  public PromptScript Prompt;

  // Token: 0x04000AEE RID: 2798
  public Transform Exit;

  // Token: 0x04000AEF RID: 2799
  public Transform Spot;

  // Token: 0x04000AF0 RID: 2800
  public string AnimName;
}