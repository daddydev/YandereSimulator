using UnityEngine;

// Token: 0x02000034 RID: 52
public class RivalPoseScript : MonoBehaviour {

  // Token: 0x060000BD RID: 189 RVA: 0x0000CD04 File Offset: 0x0000B104
  private void Start() {
    int femaleUniform = StudentGlobals.FemaleUniform;
    this.MyRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
    if (femaleUniform == 1) {
      this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[1].mainTexture = this.HairTexture;
      this.MyRenderer.materials[2].mainTexture = this.HairTexture;
      this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
    } else if (femaleUniform == 2) {
      this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[2].mainTexture = this.HairTexture;
      this.MyRenderer.materials[3].mainTexture = this.HairTexture;
    } else if (femaleUniform == 3) {
      this.MyRenderer.materials[0].mainTexture = this.HairTexture;
      this.MyRenderer.materials[1].mainTexture = this.HairTexture;
      this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
    } else if (femaleUniform == 4) {
      this.MyRenderer.materials[0].mainTexture = this.HairTexture;
      this.MyRenderer.materials[1].mainTexture = this.HairTexture;
      this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
    } else if (femaleUniform == 5) {
      this.MyRenderer.materials[0].mainTexture = this.HairTexture;
      this.MyRenderer.materials[1].mainTexture = this.HairTexture;
      this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
    } else if (femaleUniform == 6) {
      this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
      this.MyRenderer.materials[2].mainTexture = this.HairTexture;
      this.MyRenderer.materials[3].mainTexture = this.HairTexture;
    }
  }

  // Token: 0x060000BE RID: 190 RVA: 0x0000CFC8 File Offset: 0x0000B3C8
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.ID++;
      if (this.ID > this.AnimNames.Length - 1) {
        this.ID = 0;
      }
      this.Character.GetComponent<Animation>().Play(this.AnimNames[this.ID]);
    }
  }

  // Token: 0x040002CD RID: 717
  public GameObject Character;

  // Token: 0x040002CE RID: 718
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x040002CF RID: 719
  public Texture[] FemaleUniformTextures;

  // Token: 0x040002D0 RID: 720
  public Mesh[] FemaleUniforms;

  // Token: 0x040002D1 RID: 721
  public Texture[] TestTextures;

  // Token: 0x040002D2 RID: 722
  public Texture HairTexture;

  // Token: 0x040002D3 RID: 723
  public string[] AnimNames;

  // Token: 0x040002D4 RID: 724
  public int ID = -1;
}