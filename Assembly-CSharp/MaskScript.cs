using UnityEngine;

// Token: 0x0200012B RID: 299
public class MaskScript : MonoBehaviour {

  // Token: 0x060005B1 RID: 1457 RVA: 0x0004EFD0 File Offset: 0x0004D3D0
  private void Start() {
    if (GameGlobals.MasksBanned) {
      base.gameObject.SetActive(false);
    } else {
      this.MyFilter.mesh = this.Meshes[this.ID];
      this.MyRenderer.material.mainTexture = this.Textures[this.ID];
    }
    base.enabled = false;
  }

  // Token: 0x060005B2 RID: 1458 RVA: 0x0004F034 File Offset: 0x0004D434
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      Rigidbody component = base.GetComponent<Rigidbody>();
      component.useGravity = false;
      component.isKinematic = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.MyCollider.enabled = false;
      base.transform.parent = this.Yandere.Head;
      base.transform.localPosition = new Vector3(0f, 0.033333f, 0.1f);
      base.transform.localEulerAngles = Vector3.zero;
      this.Yandere.Mask = this;
      this.ClubManager.UpdateMasks();
      this.StudentManager.UpdateStudents();
    }
  }

  // Token: 0x060005B3 RID: 1459 RVA: 0x0004F104 File Offset: 0x0004D504
  public void Drop() {
    this.Prompt.MyCollider.isTrigger = false;
    this.Prompt.MyCollider.enabled = true;
    Rigidbody component = base.GetComponent<Rigidbody>();
    component.useGravity = true;
    component.isKinematic = false;
    this.Prompt.enabled = true;
    base.transform.parent = null;
    this.Yandere.Mask = null;
    this.ClubManager.UpdateMasks();
    this.StudentManager.UpdateStudents();
  }

  // Token: 0x04000DA8 RID: 3496
  public StudentManagerScript StudentManager;

  // Token: 0x04000DA9 RID: 3497
  public ClubManagerScript ClubManager;

  // Token: 0x04000DAA RID: 3498
  public YandereScript Yandere;

  // Token: 0x04000DAB RID: 3499
  public PromptScript Prompt;

  // Token: 0x04000DAC RID: 3500
  public PickUpScript PickUp;

  // Token: 0x04000DAD RID: 3501
  public Projector Blood;

  // Token: 0x04000DAE RID: 3502
  public Renderer MyRenderer;

  // Token: 0x04000DAF RID: 3503
  public MeshFilter MyFilter;

  // Token: 0x04000DB0 RID: 3504
  public Texture[] Textures;

  // Token: 0x04000DB1 RID: 3505
  public Mesh[] Meshes;

  // Token: 0x04000DB2 RID: 3506
  public int ID;
}