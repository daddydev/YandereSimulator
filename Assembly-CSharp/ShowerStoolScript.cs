using UnityEngine;

// Token: 0x020001B3 RID: 435
public class ShowerStoolScript : MonoBehaviour {

  // Token: 0x06000796 RID: 1942 RVA: 0x000740FB File Offset: 0x000724FB
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
  }

  // Token: 0x06000797 RID: 1943 RVA: 0x00074114 File Offset: 0x00072514
  private void Update() {
    if (this.Yandere.Schoolwear > 0 || this.Yandere.PickUp != null || this.Yandere.Dragging) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    } else {
      this.Prompt.enabled = true;
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Yandere.EmptyHands();
        this.Yandere.Stool = this.StoolSpot;
        this.Yandere.CanMove = false;
        this.Yandere.Bathing = true;
        this.Water.Play();
      }
    }
  }

  // Token: 0x04001375 RID: 4981
  public YandereScript Yandere;

  // Token: 0x04001376 RID: 4982
  public PromptScript Prompt;

  // Token: 0x04001377 RID: 4983
  public Transform StoolSpot;

  // Token: 0x04001378 RID: 4984
  public ParticleSystem Water;
}