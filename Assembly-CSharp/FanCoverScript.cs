using UnityEngine;

// Token: 0x020000BD RID: 189
public class FanCoverScript : MonoBehaviour {

  // Token: 0x060002D8 RID: 728 RVA: 0x0003641C File Offset: 0x0003481C
  private void Start() {
    if (this.StudentManager.Students[33] == null) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      base.enabled = false;
    } else {
      this.Rival = this.StudentManager.Students[33];
    }
  }

  // Token: 0x060002D9 RID: 729 RVA: 0x0003647C File Offset: 0x0003487C
  private void Update() {
    if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 2f) {
      if (this.Yandere.Armed) {
        this.Prompt.HideButton[0] = (this.Yandere.EquippedWeapon.WeaponID != 6 || !this.Rival.Meeting);
      } else {
        this.Prompt.HideButton[0] = true;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.CharacterAnimation.CrossFade("f02_fanMurderA_00");
      this.Rival.CharacterAnimation.CrossFade("f02_fanMurderB_00");
      this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("fanMurderHair");
      this.Yandere.EmptyHands();
      this.Rival.OsanaHair.transform.parent = this.Rival.transform;
      this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
      this.Rival.OsanaHair.transform.localPosition = Vector3.zero;
      this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
      this.Rival.OsanaHairL.enabled = false;
      this.Rival.OsanaHairR.enabled = false;
      this.Rival.Distracted = true;
      this.Yandere.CanMove = false;
      this.Rival.Meeting = false;
      this.FanSFX.enabled = false;
      base.GetComponent<AudioSource>().Play();
      base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z + 15f);
      Rigidbody component = base.GetComponent<Rigidbody>();
      component.isKinematic = false;
      component.useGravity = true;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.Phase++;
    }
    if (this.Phase > 0) {
      if (this.Phase == 1) {
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.MurderSpot.rotation, Time.deltaTime * 10f);
        this.Yandere.MoveTowardsTarget(this.MurderSpot.position);
        if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 3.5f && !this.Reacted) {
          AudioSource.PlayClipAtPoint(this.RivalReaction, Vector3.zero);
          this.Reacted = true;
        }
        if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 5f) {
          this.Rival.LiquidProjector.material.mainTexture = this.Rival.BloodTexture;
          this.Rival.LiquidProjector.enabled = true;
          this.Rival.EyeShrink = 1f;
          this.Yandere.BloodTextures = this.YandereBloodTextures;
          this.Yandere.Bloodiness += 20f;
          this.BloodProjector.gameObject.SetActive(true);
          this.BloodProjector.material.mainTexture = this.BloodTexture[1];
          this.BloodEffects.transform.parent = this.Rival.Head;
          this.BloodEffects.transform.localPosition = new Vector3(0f, 0.1f, 0f);
          this.BloodEffects.Play();
          this.Phase++;
        }
      } else if (this.Phase < 10) {
        if (this.Phase < 6) {
          this.Timer += Time.deltaTime;
          if (this.Timer > 1f) {
            this.Phase++;
            if (this.Phase - 1 < 5) {
              this.BloodProjector.material.mainTexture = this.BloodTexture[this.Phase - 1];
              this.Yandere.Bloodiness += 20f;
              this.Timer = 0f;
            }
          }
        }
        if (this.Rival.CharacterAnimation["f02_fanMurderB_00"].time >= this.Rival.CharacterAnimation["f02_fanMurderB_00"].length) {
          this.BloodProjector.material.mainTexture = this.BloodTexture[5];
          this.Yandere.Bloodiness += 20f;
          this.Rival.Ragdoll.Decapitated = true;
          this.Rival.OsanaHair.SetActive(false);
          this.Rival.DeathType = DeathType.Weapon;
          this.Rival.BecomeRagdoll();
          this.BloodEffects.Stop();
          this.Explosion.SetActive(true);
          this.Smoke.SetActive(true);
          this.Fan.enabled = false;
          this.Phase = 10;
        }
      } else if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length) {
        this.OfferHelp.SetActive(false);
        this.Yandere.CanMove = true;
        base.enabled = false;
      }
    }
  }

  // Token: 0x04000908 RID: 2312
  public StudentManagerScript StudentManager;

  // Token: 0x04000909 RID: 2313
  public YandereScript Yandere;

  // Token: 0x0400090A RID: 2314
  public PromptScript Prompt;

  // Token: 0x0400090B RID: 2315
  public StudentScript Rival;

  // Token: 0x0400090C RID: 2316
  public SM_rotateThis Fan;

  // Token: 0x0400090D RID: 2317
  public ParticleSystem BloodEffects;

  // Token: 0x0400090E RID: 2318
  public Projector BloodProjector;

  // Token: 0x0400090F RID: 2319
  public Rigidbody MyRigidbody;

  // Token: 0x04000910 RID: 2320
  public Transform MurderSpot;

  // Token: 0x04000911 RID: 2321
  public GameObject Explosion;

  // Token: 0x04000912 RID: 2322
  public GameObject OfferHelp;

  // Token: 0x04000913 RID: 2323
  public GameObject Smoke;

  // Token: 0x04000914 RID: 2324
  public AudioClip RivalReaction;

  // Token: 0x04000915 RID: 2325
  public AudioSource FanSFX;

  // Token: 0x04000916 RID: 2326
  public Texture[] YandereBloodTextures;

  // Token: 0x04000917 RID: 2327
  public Texture[] BloodTexture;

  // Token: 0x04000918 RID: 2328
  public bool Reacted;

  // Token: 0x04000919 RID: 2329
  public float Timer;

  // Token: 0x0400091A RID: 2330
  public int Phase;
}