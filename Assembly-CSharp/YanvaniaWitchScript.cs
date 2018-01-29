using UnityEngine;

// Token: 0x02000238 RID: 568
public class YanvaniaWitchScript : MonoBehaviour {

  // Token: 0x060009FC RID: 2556 RVA: 0x000B693C File Offset: 0x000B4D3C
  private void Update() {
    Animation component = this.Character.GetComponent<Animation>();
    if (this.AttackTimer < 10f) {
      this.AttackTimer += Time.deltaTime;
      if (this.AttackTimer > 0.8f && !this.CastSpell) {
        this.CastSpell = true;
        UnityEngine.Object.Instantiate<GameObject>(this.BlackHole, base.transform.position + Vector3.up * 3f + Vector3.right * 6f, Quaternion.identity);
        UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position + Vector3.right * 1.15f, Quaternion.identity);
      }
      if (component["Staff Spell Ground"].time >= component["Staff Spell Ground"].length) {
        component.CrossFade("Staff Stance");
        this.Casting = false;
      }
    } else if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) < 5f) {
      this.AttackTimer = 0f;
      this.Casting = true;
      this.CastSpell = false;
      component["Staff Spell Ground"].time = 0f;
      component.CrossFade("Staff Spell Ground");
    }
    if (!this.Casting && component["Receive Damage"].time >= component["Receive Damage"].length) {
      component.CrossFade("Staff Stance");
    }
    this.HitReactTimer += Time.deltaTime * 10f;
  }

  // Token: 0x060009FD RID: 2557 RVA: 0x000B6B00 File Offset: 0x000B4F00
  private void OnTriggerEnter(Collider other) {
    if (this.HP > 0f) {
      if (other.gameObject.tag == "Player") {
        this.Yanmont.TakeDamage(5);
      }
      if (other.gameObject.name == "Heart") {
        Animation component = this.Character.GetComponent<Animation>();
        if (!this.Casting) {
          component["Receive Damage"].time = 0f;
          component.Play("Receive Damage");
        }
        if (this.HitReactTimer >= 1f) {
          UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
          this.HitReactTimer = 0f;
          this.HP -= 5f + ((float)this.Yanmont.Level * 5f - 5f);
          AudioSource component2 = base.GetComponent<AudioSource>();
          if (this.HP <= 0f) {
            component2.PlayOneShot(this.DeathScream);
            component.Play("Die 2");
            this.Yanmont.EXP += 100f;
            base.enabled = false;
            UnityEngine.Object.Destroy(this.Wall);
          } else {
            component2.PlayOneShot(this.HitSound);
          }
        }
      }
    }
  }

  // Token: 0x04001E21 RID: 7713
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001E22 RID: 7714
  public GameObject GroundImpact;

  // Token: 0x04001E23 RID: 7715
  public GameObject BlackHole;

  // Token: 0x04001E24 RID: 7716
  public GameObject Character;

  // Token: 0x04001E25 RID: 7717
  public GameObject HitEffect;

  // Token: 0x04001E26 RID: 7718
  public GameObject Wall;

  // Token: 0x04001E27 RID: 7719
  public AudioClip DeathScream;

  // Token: 0x04001E28 RID: 7720
  public AudioClip HitSound;

  // Token: 0x04001E29 RID: 7721
  public float HitReactTimer;

  // Token: 0x04001E2A RID: 7722
  public float AttackTimer = 10f;

  // Token: 0x04001E2B RID: 7723
  public float HP = 100f;

  // Token: 0x04001E2C RID: 7724
  public bool CastSpell;

  // Token: 0x04001E2D RID: 7725
  public bool Casting;
}