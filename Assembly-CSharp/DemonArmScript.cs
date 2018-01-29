using UnityEngine;

// Token: 0x02000083 RID: 131
public class DemonArmScript : MonoBehaviour {

  // Token: 0x06000214 RID: 532 RVA: 0x0002B300 File Offset: 0x00029700
  private void Update() {
    Animation component = base.GetComponent<Animation>();
    if (!this.Rising) {
      if (!this.Attacking) {
        component.CrossFade(this.IdleAnim);
      } else if (!this.Attacked) {
        if (component["DemonArmAttack"].time >= component["DemonArmAttack"].length * 0.25f) {
          this.ClawCollider.enabled = true;
          this.Attacked = true;
        }
      } else if (component["DemonArmAttack"].time >= component["DemonArmAttack"].length) {
        component.CrossFade(this.IdleAnim);
        this.Attacking = false;
        this.Attacked = false;
      }
    } else if (component["DemonArmRise"].time > component["DemonArmRise"].length) {
      this.Rising = false;
    }
  }

  // Token: 0x06000215 RID: 533 RVA: 0x0002B3FC File Offset: 0x000297FC
  private void OnTriggerEnter(Collider other) {
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (component != null && component.StudentID > 1) {
      AudioSource component2 = base.GetComponent<AudioSource>();
      component2.clip = this.Whoosh;
      component2.pitch = UnityEngine.Random.Range(-0.9f, 1.1f);
      component2.Play();
      base.GetComponent<Animation>().CrossFade("DemonArmAttack");
      this.Attacking = true;
    }
  }

  // Token: 0x04000736 RID: 1846
  public GameObject DismembermentCollider;

  // Token: 0x04000737 RID: 1847
  public Collider ClawCollider;

  // Token: 0x04000738 RID: 1848
  public bool Attacking;

  // Token: 0x04000739 RID: 1849
  public bool Attacked;

  // Token: 0x0400073A RID: 1850
  public bool Rising = true;

  // Token: 0x0400073B RID: 1851
  public string IdleAnim = "DemonArmIdle";

  // Token: 0x0400073C RID: 1852
  public AudioClip Whoosh;
}