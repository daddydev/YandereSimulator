using UnityEngine;

// Token: 0x020001B5 RID: 437
public class SinkScript : MonoBehaviour {

  // Token: 0x060007A5 RID: 1957 RVA: 0x0007596D File Offset: 0x00073D6D
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
  }

  // Token: 0x060007A6 RID: 1958 RVA: 0x00075984 File Offset: 0x00073D84
  private void Update() {
    if (this.Yandere.PickUp != null) {
      if (this.Yandere.PickUp.Bucket != null) {
        if (this.Yandere.PickUp.Bucket.Dumbbells == 0) {
          this.Prompt.enabled = true;
          if (!this.Yandere.PickUp.Bucket.Full) {
            this.Prompt.Label[0].text = "     Fill Bucket";
          } else {
            this.Prompt.Label[0].text = "     Empty Bucket";
          }
        } else if (this.Prompt.enabled) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      } else if (this.Yandere.PickUp.BloodCleaner != null) {
        if (this.Yandere.PickUp.BloodCleaner.Blood > 0f) {
          this.Prompt.Label[0].text = "     Empty Robot";
          this.Prompt.enabled = true;
        } else {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      } else if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      if (this.Yandere.PickUp.Bucket != null) {
        if (!this.Yandere.PickUp.Bucket.Full) {
          this.Yandere.PickUp.Bucket.Fill();
        } else {
          this.Yandere.PickUp.Bucket.Empty();
        }
        if (!this.Yandere.PickUp.Bucket.Full) {
          this.Prompt.Label[0].text = "     Fill Bucket";
        } else {
          this.Prompt.Label[0].text = "     Empty Bucket";
        }
      } else if (this.Yandere.PickUp.BloodCleaner != null) {
        this.Yandere.PickUp.BloodCleaner.Blood = 0f;
        this.Yandere.PickUp.BloodCleaner.Lens.SetActive(false);
      }
      this.Prompt.Circle[0].fillAmount = 1f;
    }
  }

  // Token: 0x040013AC RID: 5036
  public YandereScript Yandere;

  // Token: 0x040013AD RID: 5037
  public PromptScript Prompt;
}