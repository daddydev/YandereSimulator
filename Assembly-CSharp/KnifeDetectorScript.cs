using UnityEngine;

// Token: 0x0200011F RID: 287
public class KnifeDetectorScript : MonoBehaviour {

  // Token: 0x0600058E RID: 1422 RVA: 0x0004C3AE File Offset: 0x0004A7AE
  private void Start() {
    this.Disable();
  }

  // Token: 0x0600058F RID: 1423 RVA: 0x0004C3B8 File Offset: 0x0004A7B8
  private void Update() {
    if (this.Blowtorches[1].transform.parent != this.Torches || this.Blowtorches[2].transform.parent != this.Torches || this.Blowtorches[3].transform.parent != this.Torches) {
      this.Prompt.Hide();
      this.Prompt.enabled = true;
      base.enabled = false;
    }
    if (this.Yandere.Armed) {
      if (this.Yandere.EquippedWeapon.WeaponID == 8) {
        this.Prompt.MyCollider.enabled = true;
        this.Prompt.enabled = true;
        if (this.Prompt.Circle[0].fillAmount == 0f) {
          this.Yandere.CharacterAnimation.CrossFade("f02_heating_00");
          this.Yandere.CanMove = false;
          this.Timer = 5f;
          this.Blowtorches[1].enabled = true;
          this.Blowtorches[2].enabled = true;
          this.Blowtorches[3].enabled = true;
          this.Blowtorches[1].GetComponent<AudioSource>().Play();
          this.Blowtorches[2].GetComponent<AudioSource>().Play();
          this.Blowtorches[3].GetComponent<AudioSource>().Play();
        }
      } else {
        this.Disable();
      }
    } else {
      this.Disable();
    }
    if (this.Timer > 0f) {
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.HeatingSpot.rotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(this.HeatingSpot.position);
      WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
      Material material = equippedWeapon.MyRenderer.material;
      material.color = new Color(material.color.r, Mathf.MoveTowards(material.color.g, 0.5f, Time.deltaTime * 0.2f), Mathf.MoveTowards(material.color.b, 0.5f, Time.deltaTime * 0.2f), material.color.a);
      this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
      if (this.Timer == 0f) {
        equippedWeapon.Heated = true;
        base.enabled = false;
        this.Disable();
      }
    }
  }

  // Token: 0x06000590 RID: 1424 RVA: 0x0004C671 File Offset: 0x0004AA71
  private void Disable() {
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Prompt.MyCollider.enabled = false;
  }

  // Token: 0x04000D36 RID: 3382
  public BlowtorchScript[] Blowtorches;

  // Token: 0x04000D37 RID: 3383
  public Transform HeatingSpot;

  // Token: 0x04000D38 RID: 3384
  public Transform Torches;

  // Token: 0x04000D39 RID: 3385
  public YandereScript Yandere;

  // Token: 0x04000D3A RID: 3386
  public PromptScript Prompt;

  // Token: 0x04000D3B RID: 3387
  public float Timer;
}