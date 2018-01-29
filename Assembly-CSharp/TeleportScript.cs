using UnityEngine;

// Token: 0x020001D9 RID: 473
public class TeleportScript : MonoBehaviour {

  // Token: 0x0600088A RID: 2186 RVA: 0x0009A885 File Offset: 0x00098C85
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Yandere.transform.position = this.Destination.position;
    }
  }

  // Token: 0x04001943 RID: 6467
  public PromptScript Prompt;

  // Token: 0x04001944 RID: 6468
  public Transform Destination;
}