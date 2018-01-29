using UnityEngine;

// Token: 0x0200016D RID: 365
public class RadioScript : MonoBehaviour {

  // Token: 0x060006CB RID: 1739 RVA: 0x000677E8 File Offset: 0x00065BE8
  private void Update() {
    if (base.transform.parent == null) {
      if (this.CooldownTimer > 0f) {
        this.CooldownTimer = Mathf.MoveTowards(this.CooldownTimer, 0f, Time.deltaTime);
        if (this.CooldownTimer == 0f) {
          this.Prompt.enabled = true;
        }
      } else {
        UISprite uisprite = this.Prompt.Circle[0];
        if (uisprite.fillAmount == 0f) {
          uisprite.fillAmount = 1f;
          if (!this.On) {
            this.Prompt.Label[0].text = "     Turn Off";
            this.MyRenderer.material.mainTexture = this.OnTexture;
            base.GetComponent<AudioSource>().Play();
            this.On = true;
          } else {
            this.CooldownTimer = 1f;
            this.TurnOff();
          }
        }
      }
      if (this.On && this.Victim == null) {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
        AlarmDiscScript component = gameObject.GetComponent<AlarmDiscScript>();
        component.SourceRadio = this;
        component.NoScream = true;
        component.Radio = true;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
  }

  // Token: 0x060006CC RID: 1740 RVA: 0x0006796C File Offset: 0x00065D6C
  public void TurnOff() {
    this.Prompt.Label[0].text = "     Turn On";
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.MyRenderer.material.mainTexture = this.OffTexture;
    base.GetComponent<AudioSource>().Stop();
    this.CooldownTimer = 1f;
    this.Victim = null;
    this.On = false;
  }

  // Token: 0x040010E7 RID: 4327
  public GameObject AlarmDisc;

  // Token: 0x040010E8 RID: 4328
  public Renderer MyRenderer;

  // Token: 0x040010E9 RID: 4329
  public Texture OffTexture;

  // Token: 0x040010EA RID: 4330
  public Texture OnTexture;

  // Token: 0x040010EB RID: 4331
  public StudentScript Victim;

  // Token: 0x040010EC RID: 4332
  public PromptScript Prompt;

  // Token: 0x040010ED RID: 4333
  public float CooldownTimer;

  // Token: 0x040010EE RID: 4334
  public bool On;
}