using UnityEngine;

// Token: 0x020001E6 RID: 486
public class TranqDetectorScript : MonoBehaviour {

  // Token: 0x060008B9 RID: 2233 RVA: 0x0009D720 File Offset: 0x0009BB20
  private void Start() {
    this.Checklist.alpha = 0f;
  }

  // Token: 0x060008BA RID: 2234 RVA: 0x0009D734 File Offset: 0x0009BB34
  private void Update() {
    if (!this.StopChecking) {
      if (this.MyCollider.bounds.Contains(this.Yandere.transform.position)) {
        if (SchoolGlobals.KidnapVictim > 0) {
          this.KidnappingLabel.text = "There is no room for another prisoner in your basement.";
        } else {
          this.TranquilizerIcon.spriteName = ((!this.Yandere.Inventory.Tranquilizer) ? "No" : "Yes");
          if (this.Yandere.Followers != 1) {
            this.FollowerIcon.spriteName = "No";
          } else if (this.Yandere.Follower.Male) {
            this.KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
            this.FollowerIcon.spriteName = "No";
          } else {
            this.KidnappingLabel.text = "Kidnapping Checklist";
            this.FollowerIcon.spriteName = "Yes";
          }
          this.BiologyIcon.spriteName = ((ClassGlobals.BiologyGrade + ClassGlobals.BiologyBonus == 0) ? "No" : "Yes");
          if (!this.Yandere.Armed) {
            this.SyringeIcon.spriteName = "No";
          } else if (this.Yandere.EquippedWeapon.WeaponID != 3) {
            this.SyringeIcon.spriteName = "No";
          } else {
            this.SyringeIcon.spriteName = "Yes";
          }
          if (this.Door.Open) {
            this.DoorIcon.spriteName = "No";
          } else {
            this.DoorIcon.spriteName = "Yes";
          }
        }
        this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 1f, Time.deltaTime);
      } else {
        this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
      }
    } else {
      this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
      if (this.Checklist.alpha == 0f) {
        base.enabled = false;
      }
    }
  }

  // Token: 0x060008BB RID: 2235 RVA: 0x0009D998 File Offset: 0x0009BD98
  public void TranqCheck() {
    if (!this.StopChecking && this.KidnappingLabel.text == "Kidnapping Checklist" && this.TranquilizerIcon.spriteName == "Yes" && this.FollowerIcon.spriteName == "Yes" && this.BiologyIcon.spriteName == "Yes" && this.SyringeIcon.spriteName == "Yes" && this.DoorIcon.spriteName == "Yes") {
      AudioSource component = base.GetComponent<AudioSource>();
      component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
      component.Play();
      this.Door.Prompt.Hide();
      this.Door.Prompt.enabled = false;
      this.Door.enabled = false;
      this.Yandere.Inventory.Tranquilizer = false;
      if (!this.Yandere.Follower.Male) {
        this.Yandere.CanTranq = true;
      }
      this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
      this.Yandere.AttackManager.Stealth = true;
      this.StopChecking = true;
    }
  }

  // Token: 0x040019D7 RID: 6615
  public YandereScript Yandere;

  // Token: 0x040019D8 RID: 6616
  public DoorScript Door;

  // Token: 0x040019D9 RID: 6617
  public UIPanel Checklist;

  // Token: 0x040019DA RID: 6618
  public Collider MyCollider;

  // Token: 0x040019DB RID: 6619
  public UILabel KidnappingLabel;

  // Token: 0x040019DC RID: 6620
  public UISprite TranquilizerIcon;

  // Token: 0x040019DD RID: 6621
  public UISprite FollowerIcon;

  // Token: 0x040019DE RID: 6622
  public UISprite BiologyIcon;

  // Token: 0x040019DF RID: 6623
  public UISprite SyringeIcon;

  // Token: 0x040019E0 RID: 6624
  public UISprite DoorIcon;

  // Token: 0x040019E1 RID: 6625
  public bool StopChecking;

  // Token: 0x040019E2 RID: 6626
  public AudioClip[] TranqClips;
}