using UnityEngine;

// Token: 0x020000C5 RID: 197
public class GardenHoleScript : MonoBehaviour {

  // Token: 0x060002EF RID: 751 RVA: 0x00037B5F File Offset: 0x00035F5F
  private void Start() {
    if (SchoolGlobals.GetGardenGraveOccupied(this.ID)) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      base.enabled = false;
    }
  }

  // Token: 0x060002F0 RID: 752 RVA: 0x00037B94 File Offset: 0x00035F94
  private void Update() {
    if (this.Yandere.transform.position.z < base.transform.position.z - 0.5f) {
      if (this.Yandere.Equipped > 0) {
        if (this.Yandere.EquippedWeapon.WeaponID == 10) {
          this.Prompt.enabled = true;
        } else if (this.Prompt.enabled) {
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
      foreach (string name in this.Yandere.ArmedAnims) {
        this.Yandere.CharacterAnimation[name].weight = 0f;
      }
      this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
      this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DigSpot.eulerAngles;
      this.Yandere.RPGCamera.transform.position = this.Yandere.DigSpot.position;
      this.Yandere.EquippedWeapon.gameObject.SetActive(false);
      this.Yandere.CharacterAnimation["f02_shovelBury_00"].time = 0f;
      this.Yandere.CharacterAnimation["f02_shovelDig_00"].time = 0f;
      this.Yandere.FloatingShovel.SetActive(true);
      this.Yandere.RPGCamera.enabled = false;
      this.Yandere.CanMove = false;
      this.Yandere.DigPhase = 1;
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Dug) {
        this.Yandere.FloatingShovel.GetComponent<Animation>()["Dig"].time = 0f;
        this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Dig");
        this.Yandere.Character.GetComponent<Animation>().Play("f02_shovelDig_00");
        this.Yandere.Digging = true;
        this.Prompt.Label[0].text = "     Fill";
        this.MyCollider.isTrigger = true;
        this.MyMesh.mesh = this.HoleMesh;
        this.Pile.SetActive(true);
        this.Dug = true;
      } else {
        this.Yandere.FloatingShovel.GetComponent<Animation>()["Bury"].time = 0f;
        this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Bury");
        this.Yandere.Character.GetComponent<Animation>().Play("f02_shovelBury_00");
        this.Yandere.Burying = true;
        this.Prompt.Label[0].text = "     Dig";
        this.MyCollider.isTrigger = false;
        this.MyMesh.mesh = this.MoundMesh;
        this.Pile.SetActive(false);
        this.Dug = false;
      }
      if (this.Bury) {
        this.Yandere.Police.Corpses--;
        if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1) {
          this.Yandere.Police.MurderScene = false;
        }
        if (this.Yandere.Police.Corpses == 0) {
          this.Yandere.Police.MurderScene = false;
        }
        this.VictimID = this.Corpse.StudentID;
        this.Corpse.Remove();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        base.enabled = false;
      }
    }
  }

  // Token: 0x060002F1 RID: 753 RVA: 0x00038078 File Offset: 0x00036478
  private void OnTriggerEnter(Collider other) {
    if (this.Dug && other.gameObject.layer == 11) {
      this.Prompt.Label[0].text = "     Bury";
      this.Corpse = other.transform.root.gameObject.GetComponent<RagdollScript>();
      this.Bury = true;
    }
  }

  // Token: 0x060002F2 RID: 754 RVA: 0x000380DC File Offset: 0x000364DC
  private void OnTriggerExit(Collider other) {
    if (this.Dug && other.gameObject.layer == 11) {
      this.Prompt.Label[0].text = "     Fill";
      this.Corpse = null;
      this.Bury = false;
    }
  }

  // Token: 0x060002F3 RID: 755 RVA: 0x0003812B File Offset: 0x0003652B
  public void EndOfDayCheck() {
    if (this.VictimID > 0) {
      StudentGlobals.SetStudentMissing(this.VictimID, true);
      SchoolGlobals.SetGardenGraveOccupied(this.ID, true);
    }
  }

  // Token: 0x0400095A RID: 2394
  public YandereScript Yandere;

  // Token: 0x0400095B RID: 2395
  public RagdollScript Corpse;

  // Token: 0x0400095C RID: 2396
  public PromptScript Prompt;

  // Token: 0x0400095D RID: 2397
  public Collider MyCollider;

  // Token: 0x0400095E RID: 2398
  public MeshFilter MyMesh;

  // Token: 0x0400095F RID: 2399
  public GameObject Pile;

  // Token: 0x04000960 RID: 2400
  public Mesh MoundMesh;

  // Token: 0x04000961 RID: 2401
  public Mesh HoleMesh;

  // Token: 0x04000962 RID: 2402
  public bool Bury;

  // Token: 0x04000963 RID: 2403
  public bool Dug;

  // Token: 0x04000964 RID: 2404
  public int VictimID;

  // Token: 0x04000965 RID: 2405
  public int ID;
}