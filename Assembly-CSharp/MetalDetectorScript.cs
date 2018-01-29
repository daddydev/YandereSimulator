using UnityEngine;

// Token: 0x02000130 RID: 304
public class MetalDetectorScript : MonoBehaviour {

  // Token: 0x060005BE RID: 1470 RVA: 0x0004F5AD File Offset: 0x0004D9AD
  private void Start() {
    this.MyAudio = base.GetComponent<AudioSource>();
  }

  // Token: 0x060005BF RID: 1471 RVA: 0x0004F5BC File Offset: 0x0004D9BC
  private void Update() {
    if (this.Yandere.Armed) {
      if (this.Yandere.EquippedWeapon.WeaponID == 6) {
        this.Prompt.enabled = true;
        if (this.Prompt.Circle[0].fillAmount == 0f) {
          this.MyAudio.Play();
          this.MyCollider.enabled = false;
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          base.enabled = false;
        }
      } else if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Spraying) {
      this.SprayTimer += Time.deltaTime;
      if ((double)this.SprayTimer > 0.66666) {
        if (this.Yandere.Armed) {
          this.Yandere.EquippedWeapon.Drop();
        }
        this.Yandere.EmptyHands();
        this.PepperSprayEffect.Play();
        this.Spraying = false;
      }
    }
    this.MyAudio.volume -= Time.deltaTime * 0.01f;
  }

  // Token: 0x060005C0 RID: 1472 RVA: 0x0004F730 File Offset: 0x0004DB30
  private void OnTriggerStay(Collider other) {
    bool flag = false;
    if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13) {
      for (int i = 1; i < 4; i++) {
        WeaponScript weaponScript = this.Yandere.Weapon[i];
        flag |= (weaponScript != null && weaponScript.Metal);
        if (!flag && this.Yandere.Container != null && this.Yandere.Container.Weapon != null) {
          weaponScript = this.Yandere.Container.Weapon;
          flag = weaponScript.Metal;
        }
        if (!flag && this.Yandere.PickUp != null && this.Yandere.PickUp.TrashCan != null && this.Yandere.PickUp.TrashCan.Weapon) {
          weaponScript = this.Yandere.PickUp.TrashCan.Item.GetComponent<WeaponScript>();
          flag = weaponScript.Metal;
        }
      }
      if (flag) {
        if (this.MissionMode.enabled) {
          this.MissionMode.GameOverID = 16;
          this.MissionMode.GameOver();
          this.MissionMode.Phase = 4;
          base.enabled = false;
        } else if (!this.Yandere.Sprayed) {
          this.MyAudio.clip = this.Alarm;
          this.MyAudio.loop = true;
          this.MyAudio.Play();
          this.MyAudio.volume = 0.1f;
          AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
          if (this.Yandere.Aiming) {
            this.Yandere.StopAiming();
          }
          this.PepperSprayEffect.transform.position = new Vector3(base.transform.position.x, this.Yandere.transform.position.y + 1.8f, this.Yandere.transform.position.z);
          this.Spraying = true;
          this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
          this.Yandere.FollowHips = true;
          this.Yandere.Punching = false;
          this.Yandere.CanMove = false;
          this.Yandere.Sprayed = true;
          this.Yandere.StudentManager.YandereDying = true;
          this.Yandere.StudentManager.StopMoving();
          this.Yandere.Blur.blurIterations = 1;
          this.Yandere.Jukebox.Volume = 0f;
        }
      }
    }
  }

  // Token: 0x04000DBC RID: 3516
  public MissionModeScript MissionMode;

  // Token: 0x04000DBD RID: 3517
  public YandereScript Yandere;

  // Token: 0x04000DBE RID: 3518
  public PromptScript Prompt;

  // Token: 0x04000DBF RID: 3519
  public ParticleSystem PepperSprayEffect;

  // Token: 0x04000DC0 RID: 3520
  public AudioSource MyAudio;

  // Token: 0x04000DC1 RID: 3521
  public AudioClip PepperSpraySFX;

  // Token: 0x04000DC2 RID: 3522
  public AudioClip Alarm;

  // Token: 0x04000DC3 RID: 3523
  public Collider MyCollider;

  // Token: 0x04000DC4 RID: 3524
  public float SprayTimer;

  // Token: 0x04000DC5 RID: 3525
  public bool Spraying;
}