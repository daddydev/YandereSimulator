using UnityEngine;

// Token: 0x02000162 RID: 354
public class PortraitScript : MonoBehaviour {

  // Token: 0x06000682 RID: 1666 RVA: 0x0005F080 File Offset: 0x0005D480
  private void Start() {
    this.StudentObject[1].SetActive(false);
    this.StudentObject[2].SetActive(false);
    this.Selected = 1;
    this.UpdateHair();
  }

  // Token: 0x06000683 RID: 1667 RVA: 0x0005F0AC File Offset: 0x0005D4AC
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      this.StudentObject[0].SetActive(true);
      this.StudentObject[1].SetActive(false);
      this.StudentObject[2].SetActive(false);
      this.Selected = 1;
    } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
      this.StudentObject[0].SetActive(false);
      this.StudentObject[1].SetActive(true);
      this.StudentObject[2].SetActive(false);
      this.Selected = 2;
    } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
      this.StudentObject[0].SetActive(false);
      this.StudentObject[1].SetActive(false);
      this.StudentObject[2].SetActive(true);
      this.Selected = 3;
    }
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.CurrentHair++;
      if (this.CurrentHair > this.HairSet1.Length - 1) {
        this.CurrentHair = 0;
      }
      this.UpdateHair();
    }
  }

  // Token: 0x06000684 RID: 1668 RVA: 0x0005F1B8 File Offset: 0x0005D5B8
  private void UpdateHair() {
    Texture mainTexture = this.HairSet2[this.CurrentHair];
    this.Renderer1.materials[0].mainTexture = mainTexture;
    this.Renderer1.materials[3].mainTexture = mainTexture;
    this.Renderer2.materials[2].mainTexture = mainTexture;
    this.Renderer2.materials[3].mainTexture = mainTexture;
    this.Renderer3.materials[0].mainTexture = mainTexture;
    this.Renderer3.materials[1].mainTexture = mainTexture;
  }

  // Token: 0x04000FF8 RID: 4088
  public GameObject[] StudentObject;

  // Token: 0x04000FF9 RID: 4089
  public Renderer Renderer1;

  // Token: 0x04000FFA RID: 4090
  public Renderer Renderer2;

  // Token: 0x04000FFB RID: 4091
  public Renderer Renderer3;

  // Token: 0x04000FFC RID: 4092
  public Texture[] HairSet1;

  // Token: 0x04000FFD RID: 4093
  public Texture[] HairSet2;

  // Token: 0x04000FFE RID: 4094
  public Texture[] HairSet3;

  // Token: 0x04000FFF RID: 4095
  public int Selected;

  // Token: 0x04001000 RID: 4096
  public int CurrentHair;
}