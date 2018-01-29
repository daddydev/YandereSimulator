using UnityEngine;

// Token: 0x02000061 RID: 97
public class CheeseScript : MonoBehaviour {

  // Token: 0x0600015A RID: 346 RVA: 0x000166B4 File Offset: 0x00014AB4
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Subtitle.text = "Knowing the mouse might one day leave its hole and get the cheese...It fills you with determination.";
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.GlowingEye.SetActive(true);
      this.Timer = 5f;
    }
    if (this.Timer > 0f) {
      this.Timer -= Time.deltaTime;
      if (this.Timer <= 0f) {
        this.Prompt.enabled = true;
        this.Subtitle.text = string.Empty;
      }
    }
  }

  // Token: 0x04000431 RID: 1073
  public GameObject GlowingEye;

  // Token: 0x04000432 RID: 1074
  public PromptScript Prompt;

  // Token: 0x04000433 RID: 1075
  public UILabel Subtitle;

  // Token: 0x04000434 RID: 1076
  public float Timer;
}