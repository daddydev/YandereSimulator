using UnityEngine;

// Token: 0x020001E8 RID: 488
public class TrashCanScript : MonoBehaviour {

  // Token: 0x060008BF RID: 2239 RVA: 0x0009DB64 File Offset: 0x0009BF64
  private void Update() {
    if (!this.Occupied) {
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.Prompt.Circle[0].fillAmount = 1f;
        if (this.Yandere.PickUp != null) {
          this.Item = this.Yandere.PickUp.gameObject;
          this.Yandere.EmptyHands();
        } else {
          this.Item = this.Yandere.EquippedWeapon.gameObject;
          this.Yandere.DropTimer[this.Yandere.Equipped] = 0.5f;
          this.Yandere.DropWeapon(this.Yandere.Equipped);
          this.Weapon = true;
        }
        this.Item.transform.parent = this.TrashPosition;
        this.Item.GetComponent<Rigidbody>().useGravity = false;
        this.Item.GetComponent<Collider>().enabled = false;
        this.Item.GetComponent<PromptScript>().Hide();
        this.Item.GetComponent<PromptScript>().enabled = false;
        this.Occupied = true;
        this.UpdatePrompt();
      }
    } else if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Item.GetComponent<PromptScript>().Circle[3].fillAmount = -1f;
      this.Item.GetComponent<PromptScript>().enabled = true;
      this.Item = null;
      this.Occupied = false;
      this.Weapon = false;
      this.UpdatePrompt();
    }
    if (this.Item != null) {
      if (this.Weapon) {
        this.Item.transform.localPosition = new Vector3(0f, 0.29f, 0f);
        this.Item.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
      } else {
        this.Item.transform.localPosition = new Vector3(0f, 0f, -0.021f);
        this.Item.transform.localEulerAngles = Vector3.zero;
      }
    }
  }

  // Token: 0x060008C0 RID: 2240 RVA: 0x0009DDC4 File Offset: 0x0009C1C4
  public void UpdatePrompt() {
    if (!this.Occupied) {
      if (this.Yandere.Armed) {
        this.Prompt.Label[0].text = "     Insert";
        this.Prompt.HideButton[0] = false;
      } else if (this.Yandere.PickUp != null) {
        if (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Suspicious) {
          this.Prompt.Label[0].text = "     Insert";
          this.Prompt.HideButton[0] = false;
        } else {
          this.Prompt.HideButton[0] = true;
        }
      } else {
        this.Prompt.HideButton[0] = true;
      }
    } else {
      this.Prompt.Label[0].text = "     Remove";
      this.Prompt.HideButton[0] = false;
    }
  }

  // Token: 0x040019E5 RID: 6629
  public YandereScript Yandere;

  // Token: 0x040019E6 RID: 6630
  public PromptScript Prompt;

  // Token: 0x040019E7 RID: 6631
  public Transform TrashPosition;

  // Token: 0x040019E8 RID: 6632
  public GameObject Item;

  // Token: 0x040019E9 RID: 6633
  public bool Occupied;

  // Token: 0x040019EA RID: 6634
  public bool Weapon;
}