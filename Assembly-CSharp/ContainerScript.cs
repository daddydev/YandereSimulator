using UnityEngine;

// Token: 0x02000071 RID: 113
public class ContainerScript : MonoBehaviour {

  // Token: 0x0600019F RID: 415 RVA: 0x0001D2C0 File Offset: 0x0001B6C0
  public void Start() {
    this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
    this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
    this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
    this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
    this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
  }

  // Token: 0x060001A0 RID: 416 RVA: 0x0001D338 File Offset: 0x0001B738
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Open = !this.Open;
      this.UpdatePrompts();
    }
    if (this.Prompt.Circle[1].fillAmount == 0f) {
      this.Prompt.Circle[1].fillAmount = 1f;
      if (this.Prompt.Yandere.Armed) {
        this.Weapon = this.Prompt.Yandere.EquippedWeapon.gameObject.GetComponent<WeaponScript>();
        this.Prompt.Yandere.EmptyHands();
        this.Weapon.transform.parent = this.WeaponSpot;
        this.Weapon.transform.localPosition = Vector3.zero;
        this.Weapon.transform.localEulerAngles = Vector3.zero;
        this.Weapon.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.Weapon.MyCollider.enabled = false;
        this.Weapon.Prompt.Hide();
        this.Weapon.Prompt.enabled = false;
      } else {
        this.BodyPart = this.Prompt.Yandere.PickUp;
        this.Prompt.Yandere.EmptyHands();
        this.BodyPart.transform.parent = this.BodyPartPositions[this.BodyPart.GetComponent<BodyPartScript>().Type];
        this.BodyPart.transform.localPosition = Vector3.zero;
        this.BodyPart.transform.localEulerAngles = Vector3.zero;
        this.BodyPart.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.BodyPart.MyCollider.enabled = false;
        this.BodyParts[this.BodyPart.GetComponent<BodyPartScript>().Type] = this.BodyPart;
      }
      this.Contents++;
      this.UpdatePrompts();
    }
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      this.Prompt.Circle[3].fillAmount = 1f;
      if (!this.Open) {
        base.transform.parent = this.Prompt.Yandere.Backpack;
        base.transform.localPosition = Vector3.zero;
        base.transform.localEulerAngles = Vector3.zero;
        this.Prompt.Yandere.Container = this;
        this.Prompt.Yandere.WeaponMenu.UpdateSprites();
        this.Prompt.Yandere.ObstacleDetector.gameObject.SetActive(true);
        this.Prompt.MyCollider.enabled = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        Rigidbody component = base.GetComponent<Rigidbody>();
        component.isKinematic = true;
        component.useGravity = false;
      } else {
        if (this.Weapon != null) {
          this.Weapon.Prompt.Circle[3].fillAmount = -1f;
          this.Weapon.Prompt.enabled = true;
          this.Weapon = null;
        } else {
          this.BodyPart = null;
          this.ID = 1;
          while (this.BodyPart == null) {
            this.BodyPart = this.BodyParts[this.ID];
            this.BodyParts[this.ID] = null;
            this.ID++;
          }
          this.BodyPart.Prompt.Circle[3].fillAmount = -1f;
        }
        this.Contents--;
        this.UpdatePrompts();
      }
    }
    this.Lid.localEulerAngles = new Vector3(this.Lid.localEulerAngles.x, this.Lid.localEulerAngles.y, Mathf.Lerp(this.Lid.localEulerAngles.z, (!this.Open) ? 0f : 90f, Time.deltaTime * 10f));
    if (this.Weapon != null) {
      this.Weapon.transform.localPosition = Vector3.zero;
      this.Weapon.transform.localEulerAngles = Vector3.zero;
    }
    this.ID = 1;
    while (this.ID < this.BodyParts.Length) {
      if (this.BodyParts[this.ID] != null) {
        this.BodyParts[this.ID].transform.localPosition = Vector3.zero;
        this.BodyParts[this.ID].transform.localEulerAngles = Vector3.zero;
      }
      this.ID++;
    }
  }

  // Token: 0x060001A1 RID: 417 RVA: 0x0001D858 File Offset: 0x0001BC58
  public void Drop() {
    base.transform.parent = null;
    base.transform.position = this.Prompt.Yandere.ObstacleDetector.transform.position + new Vector3(0f, 0.5f, 0f);
    base.transform.eulerAngles = this.Prompt.Yandere.ObstacleDetector.transform.eulerAngles;
    this.Prompt.Yandere.Container = null;
    this.Prompt.MyCollider.enabled = true;
    this.Prompt.enabled = true;
    Rigidbody component = base.GetComponent<Rigidbody>();
    component.isKinematic = false;
    component.useGravity = true;
  }

  // Token: 0x060001A2 RID: 418 RVA: 0x0001D918 File Offset: 0x0001BD18
  public void UpdatePrompts() {
    if (this.Open) {
      this.Prompt.Label[0].text = "     Close";
      if (this.Contents > 0) {
        this.Prompt.Label[3].text = "     Remove";
        this.Prompt.HideButton[3] = false;
      } else {
        this.Prompt.HideButton[3] = true;
      }
      if (this.Prompt.Yandere.Armed) {
        if (!this.Prompt.Yandere.EquippedWeapon.Concealable) {
          if (this.Weapon == null) {
            this.Prompt.Label[1].text = "     Insert";
            this.Prompt.HideButton[1] = false;
          } else {
            this.Prompt.HideButton[1] = true;
          }
        } else {
          this.Prompt.HideButton[1] = true;
        }
      } else if (this.Prompt.Yandere.PickUp != null) {
        if (this.Prompt.Yandere.PickUp.BodyPart != null) {
          if (this.BodyParts[this.Prompt.Yandere.PickUp.gameObject.GetComponent<BodyPartScript>().Type] == null) {
            this.Prompt.Label[1].text = "     Insert";
            this.Prompt.HideButton[1] = false;
          } else {
            this.Prompt.HideButton[1] = true;
          }
        } else {
          this.Prompt.HideButton[1] = true;
        }
      } else {
        this.Prompt.HideButton[1] = true;
      }
    } else if (this.Prompt.Label[0] != null) {
      this.Prompt.Label[0].text = "     Open";
      this.Prompt.HideButton[1] = true;
      this.Prompt.Label[3].text = "     Wear";
      this.Prompt.HideButton[3] = false;
    }
  }

  // Token: 0x04000534 RID: 1332
  public Transform[] BodyPartPositions;

  // Token: 0x04000535 RID: 1333
  public Transform WeaponSpot;

  // Token: 0x04000536 RID: 1334
  public Transform Lid;

  // Token: 0x04000537 RID: 1335
  public Collider GardenArea;

  // Token: 0x04000538 RID: 1336
  public Collider NEStairs;

  // Token: 0x04000539 RID: 1337
  public Collider NWStairs;

  // Token: 0x0400053A RID: 1338
  public Collider SEStairs;

  // Token: 0x0400053B RID: 1339
  public Collider SWStairs;

  // Token: 0x0400053C RID: 1340
  public PickUpScript[] BodyParts;

  // Token: 0x0400053D RID: 1341
  public PickUpScript BodyPart;

  // Token: 0x0400053E RID: 1342
  public WeaponScript Weapon;

  // Token: 0x0400053F RID: 1343
  public PromptScript Prompt;

  // Token: 0x04000540 RID: 1344
  public string SpriteName = string.Empty;

  // Token: 0x04000541 RID: 1345
  public bool CanDrop;

  // Token: 0x04000542 RID: 1346
  public bool Open;

  // Token: 0x04000543 RID: 1347
  public int Contents;

  // Token: 0x04000544 RID: 1348
  public int ID;
}