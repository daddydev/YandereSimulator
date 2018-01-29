using UnityEngine;

// Token: 0x020001B1 RID: 433
public class ShoeRemovalScript : MonoBehaviour {

  // Token: 0x0600078C RID: 1932 RVA: 0x000718DC File Offset: 0x0006FCDC
  public void Start() {
    if (this.Locker == null) {
      this.GetHeight(this.Student.StudentID);
      this.Locker = this.Student.StudentManager.Lockers.List[this.Student.StudentID];
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.NewPairOfShoes, base.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.Locker;
      gameObject.transform.localEulerAngles = new Vector3(0f, -180f, 0f);
      gameObject.transform.localPosition = new Vector3(0f, -0.29f + 0.3f * (float)this.Height, (!this.Male) ? 0.05f : 0.04f);
      this.LeftSchoolShoe = gameObject.transform.GetChild(0);
      this.RightSchoolShoe = gameObject.transform.GetChild(1);
      this.RemovalAnim = this.RemoveCasualAnim;
      this.RightCurrentShoe = this.RightCasualShoe;
      this.LeftCurrentShoe = this.LeftCasualShoe;
      this.RightCasualShoe.gameObject.SetActive(true);
      this.LeftCasualShoe.gameObject.SetActive(true);
      this.RightNewShoe = this.RightSchoolShoe;
      this.LeftNewShoe = this.LeftSchoolShoe;
      this.ShoeParent = gameObject.transform;
      this.TargetShoes = this.IndoorShoes;
      this.RightShoePosition = this.RightCurrentShoe.localPosition;
      this.LeftShoePosition = this.LeftCurrentShoe.localPosition;
      this.RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
      this.LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
      this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
      this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
      this.Socks = this.Student.Cosmetic.SocksTexture;
      if (!this.Student.AoT) {
        if (!this.Male) {
          this.MyRenderer.materials[0].mainTexture = this.Socks;
          this.MyRenderer.materials[1].mainTexture = this.Socks;
        } else {
          this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
        }
      }
      this.TargetShoes = this.IndoorShoes;
      this.Locker.gameObject.GetComponent<Animation>().Play(this.LockerAnims[this.Height]);
      this.Character.GetComponent<Animation>().cullingType = AnimationCullingType.AlwaysAnimate;
      this.Character.GetComponent<Animation>().Play(this.RemovalAnim);
    }
  }

  // Token: 0x0600078D RID: 1933 RVA: 0x00071BCC File Offset: 0x0006FFCC
  private void Update() {
    if (!this.Student.DiscCheck && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Splashed && !this.Student.TurnOffRadio) {
      this.Student.MoveTowardsTarget(this.Student.CurrentDestination.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Student.CurrentDestination.rotation, 10f * Time.deltaTime);
      if (this.Phase == 1) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 1.1f) {
          this.ShoeParent.parent = this.LeftHand;
          this.Phase++;
        }
      } else if (this.Phase == 2) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 2f) {
          this.ShoeParent.parent = this.Locker;
          this.X = this.ShoeParent.localEulerAngles.x;
          this.Y = this.ShoeParent.localEulerAngles.y;
          this.Z = this.ShoeParent.localEulerAngles.z;
          this.Phase++;
        }
      } else if (this.Phase == 3) {
        this.X = Mathf.MoveTowards(this.X, 0f, Time.deltaTime * 360f);
        this.Y = Mathf.MoveTowards(this.Y, 186.878f, Time.deltaTime * 360f);
        this.Z = Mathf.MoveTowards(this.Z, 0f, Time.deltaTime * 360f);
        this.ShoeParent.localEulerAngles = new Vector3(this.X, this.Y, this.Z);
        this.ShoeParent.localPosition = Vector3.MoveTowards(this.ShoeParent.localPosition, new Vector3(0.272f, 0f, 0.552f), Time.deltaTime);
        if (this.ShoeParent.localPosition.y == 0f) {
          this.ShoeParent.localPosition = new Vector3(0.272f, 0f, 0.552f);
          this.ShoeParent.localEulerAngles = new Vector3(0f, 186.878f, 0f);
          this.Phase++;
        }
      } else if (this.Phase == 4) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 3.4f) {
          this.RightCurrentShoe.parent = null;
          this.RightCurrentShoe.position = new Vector3(this.RightCurrentShoe.position.x, 0.05f, this.RightCurrentShoe.position.z);
          this.RightCurrentShoe.localEulerAngles = new Vector3(0f, this.RightCurrentShoe.localEulerAngles.y, 0f);
          this.Phase++;
        }
      } else if (this.Phase == 5) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 4.4f) {
          this.LeftCurrentShoe.parent = null;
          this.LeftCurrentShoe.position = new Vector3(this.LeftCurrentShoe.position.x, 0.05f, this.LeftCurrentShoe.position.z);
          this.LeftCurrentShoe.localEulerAngles = new Vector3(0f, this.LeftCurrentShoe.localEulerAngles.y, 0f);
          this.Phase++;
        }
      } else if (this.Phase == 6) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 5.6f) {
          this.LeftNewShoe.parent = this.LeftFoot;
          this.LeftNewShoe.localPosition = this.LeftShoePosition;
          this.LeftNewShoe.localEulerAngles = Vector3.zero;
          this.Phase++;
        }
      } else if (this.Phase == 7) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 6.8f) {
          if (!this.Student.AoT) {
            if (!this.Male) {
              this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
              this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
            } else {
              this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
            }
          }
          this.RightNewShoe.parent = this.RightFoot;
          this.RightNewShoe.localPosition = this.RightShoePosition;
          this.RightNewShoe.localEulerAngles = Vector3.zero;
          this.RightNewShoe.gameObject.SetActive(false);
          this.LeftNewShoe.gameObject.SetActive(false);
          this.Phase++;
        }
      } else if (this.Phase == 8) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 7.6f) {
          this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
          this.RightCurrentShoe.parent = this.ShoeParent;
          this.LeftCurrentShoe.parent = this.ShoeParent;
          this.ShoeParent.parent = this.RightHand;
          this.Phase++;
        }
      } else if (this.Phase == 9) {
        if (this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= 8.5f) {
          this.ShoeParent.parent = this.Locker;
          this.ShoeParent.localPosition = new Vector3(0f, ((!(this.TargetShoes == this.IndoorShoes)) ? -0.29f : -0.14f) + 0.3f * (float)this.Height, -0.01f);
          this.ShoeParent.localEulerAngles = new Vector3(0f, 180f, 0f);
          this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0f);
          this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0f);
          this.RightCurrentShoe.localEulerAngles = Vector3.zero;
          this.LeftCurrentShoe.localEulerAngles = Vector3.zero;
          this.Phase++;
        }
      } else if (this.Phase == 10 && this.Character.GetComponent<Animation>()[this.RemovalAnim].time >= this.Character.GetComponent<Animation>()[this.RemovalAnim].length) {
        this.Character.GetComponent<Animation>().cullingType = AnimationCullingType.BasedOnRenderers;
        this.Student.Routine = true;
        base.enabled = false;
        if (!this.Student.Indoors) {
          this.Student.Indoors = true;
          this.Student.CanTalk = true;
        } else {
          this.Student.CurrentDestination = this.Student.StudentManager.Hangouts.List[0];
          this.Student.Pathfinding.target = this.Student.StudentManager.Hangouts.List[0];
          this.Locker.gameObject.GetComponent<Animation>().Stop();
          this.Student.CanTalk = false;
          this.Student.Leaving = true;
          this.Student.Phase++;
          base.enabled = false;
          this.Phase++;
        }
      }
    } else {
      this.PutOnShoes();
      this.Student.Routine = false;
    }
  }

  // Token: 0x0600078E RID: 1934 RVA: 0x000724B8 File Offset: 0x000708B8
  private void LateUpdate() {
    if (this.Phase < 7) {
      this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
      this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
    }
  }

  // Token: 0x0600078F RID: 1935 RVA: 0x00072510 File Offset: 0x00070910
  public void PutOnShoes() {
    this.Locker.gameObject.GetComponent<Animation>()[this.LockerAnims[this.Height]].time = this.Locker.gameObject.GetComponent<Animation>()[this.LockerAnims[this.Height]].length;
    this.Locker.gameObject.GetComponent<Animation>().Stop();
    this.ShoeParent.parent = this.LeftHand;
    this.ShoeParent.parent = this.Locker;
    this.ShoeParent.localPosition = new Vector3(0.272f, 0f, 0.552f);
    this.ShoeParent.localEulerAngles = new Vector3(0f, 186.878f, 0f);
    this.RightCurrentShoe.parent = null;
    this.RightCurrentShoe.position = new Vector3(this.RightCurrentShoe.position.x, 0.05f, this.RightCurrentShoe.position.z);
    this.RightCurrentShoe.localEulerAngles = new Vector3(0f, this.RightCurrentShoe.localEulerAngles.y, 0f);
    this.LeftCurrentShoe.parent = null;
    this.LeftCurrentShoe.position = new Vector3(this.LeftCurrentShoe.position.x, 0.05f, this.LeftCurrentShoe.position.z);
    this.LeftCurrentShoe.localEulerAngles = new Vector3(0f, this.LeftCurrentShoe.localEulerAngles.y, 0f);
    this.LeftNewShoe.parent = this.LeftFoot;
    this.LeftNewShoe.localPosition = this.LeftShoePosition;
    this.LeftNewShoe.localEulerAngles = Vector3.zero;
    if (!this.Student.AoT) {
      if (!this.Male) {
        this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
        this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
      } else {
        this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
      }
    }
    this.RightNewShoe.parent = this.RightFoot;
    this.RightNewShoe.localPosition = this.RightShoePosition;
    this.RightNewShoe.localEulerAngles = Vector3.zero;
    this.RightNewShoe.gameObject.SetActive(false);
    this.LeftNewShoe.gameObject.SetActive(false);
    this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
    this.RightCurrentShoe.parent = this.ShoeParent;
    this.LeftCurrentShoe.parent = this.ShoeParent;
    this.ShoeParent.parent = this.RightHand;
    this.ShoeParent.parent = this.Locker;
    this.ShoeParent.localPosition = new Vector3(0f, ((!(this.TargetShoes == this.IndoorShoes)) ? -0.29f : -0.14f) + 0.3f * (float)this.Height, -0.01f);
    this.ShoeParent.localEulerAngles = new Vector3(0f, 180f, 0f);
    this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0f);
    this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0f);
    this.RightCurrentShoe.localEulerAngles = Vector3.zero;
    this.LeftCurrentShoe.localEulerAngles = Vector3.zero;
    this.Student.Indoors = true;
    this.Student.CanTalk = true;
    base.enabled = false;
    this.Character.GetComponent<Animation>().cullingType = AnimationCullingType.BasedOnRenderers;
  }

  // Token: 0x06000790 RID: 1936 RVA: 0x0007293C File Offset: 0x00070D3C
  private void UpdateShoes() {
    this.Student.Indoors = true;
    if (!this.Student.AoT) {
      if (!this.Male) {
        this.MyRenderer.materials[0].mainTexture = this.IndoorShoes;
        this.MyRenderer.materials[1].mainTexture = this.IndoorShoes;
      } else {
        this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.IndoorShoes;
      }
    }
  }

  // Token: 0x06000791 RID: 1937 RVA: 0x000729CC File Offset: 0x00070DCC
  public void LeavingSchool() {
    this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
    this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
    this.Socks = this.Student.Cosmetic.SocksTexture;
    this.RemovalAnim = this.RemoveSchoolAnim;
    this.Locker.gameObject.GetComponent<Animation>()[this.LockerAnims[this.Height]].time = 0f;
    this.Locker.gameObject.GetComponent<Animation>().Play(this.LockerAnims[this.Height]);
    if (!this.Student.AoT) {
      if (!this.Male) {
        this.MyRenderer.materials[0].mainTexture = this.Socks;
        this.MyRenderer.materials[1].mainTexture = this.Socks;
      } else {
        this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
      }
    }
    this.Character.GetComponent<Animation>().Play(this.RemovalAnim);
    this.RightNewShoe.gameObject.SetActive(true);
    this.LeftNewShoe.gameObject.SetActive(true);
    this.RightCurrentShoe = this.RightSchoolShoe;
    this.LeftCurrentShoe = this.LeftSchoolShoe;
    this.RightNewShoe = this.RightCasualShoe;
    this.LeftNewShoe = this.LeftCasualShoe;
    this.TargetShoes = this.OutdoorShoes;
    this.Phase = 1;
    this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
    this.LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
  }

  // Token: 0x06000792 RID: 1938 RVA: 0x00072BF8 File Offset: 0x00070FF8
  private void GetHeight(int StudentID) {
    this.Height = 6;
    while (StudentID > 0) {
      this.Height--;
      StudentID--;
      if (this.Height == 0) {
        this.Height = 5;
      }
    }
    if (this.Student.StudentID == 7 || this.Student.StudentID == this.Student.StudentManager.RivalID || this.Student.StudentID == this.Student.StudentManager.SuitorID) {
      this.Height = 5;
    }
    this.RemoveCasualAnim = this.RemoveCasualAnim + this.Height.ToString() + "_00";
    this.RemoveSchoolAnim = this.RemoveSchoolAnim + this.Height.ToString() + "_01";
  }

  // Token: 0x04001328 RID: 4904
  public StudentScript Student;

  // Token: 0x04001329 RID: 4905
  public Vector3 RightShoePosition;

  // Token: 0x0400132A RID: 4906
  public Vector3 LeftShoePosition;

  // Token: 0x0400132B RID: 4907
  public Transform RightCurrentShoe;

  // Token: 0x0400132C RID: 4908
  public Transform LeftCurrentShoe;

  // Token: 0x0400132D RID: 4909
  public Transform RightCasualShoe;

  // Token: 0x0400132E RID: 4910
  public Transform LeftCasualShoe;

  // Token: 0x0400132F RID: 4911
  public Transform RightSchoolShoe;

  // Token: 0x04001330 RID: 4912
  public Transform LeftSchoolShoe;

  // Token: 0x04001331 RID: 4913
  public Transform RightNewShoe;

  // Token: 0x04001332 RID: 4914
  public Transform LeftNewShoe;

  // Token: 0x04001333 RID: 4915
  public Transform RightFoot;

  // Token: 0x04001334 RID: 4916
  public Transform LeftFoot;

  // Token: 0x04001335 RID: 4917
  public Transform RightHand;

  // Token: 0x04001336 RID: 4918
  public Transform LeftHand;

  // Token: 0x04001337 RID: 4919
  public Transform ShoeParent;

  // Token: 0x04001338 RID: 4920
  public Transform Locker;

  // Token: 0x04001339 RID: 4921
  public GameObject NewPairOfShoes;

  // Token: 0x0400133A RID: 4922
  public GameObject Character;

  // Token: 0x0400133B RID: 4923
  public string[] LockerAnims;

  // Token: 0x0400133C RID: 4924
  public Texture OutdoorShoes;

  // Token: 0x0400133D RID: 4925
  public Texture IndoorShoes;

  // Token: 0x0400133E RID: 4926
  public Texture TargetShoes;

  // Token: 0x0400133F RID: 4927
  public Texture Socks;

  // Token: 0x04001340 RID: 4928
  public Renderer MyRenderer;

  // Token: 0x04001341 RID: 4929
  public bool RemovingCasual = true;

  // Token: 0x04001342 RID: 4930
  public bool Male;

  // Token: 0x04001343 RID: 4931
  public int Height;

  // Token: 0x04001344 RID: 4932
  public int Phase = 1;

  // Token: 0x04001345 RID: 4933
  public float X;

  // Token: 0x04001346 RID: 4934
  public float Y;

  // Token: 0x04001347 RID: 4935
  public float Z;

  // Token: 0x04001348 RID: 4936
  public string RemoveCasualAnim = string.Empty;

  // Token: 0x04001349 RID: 4937
  public string RemoveSchoolAnim = string.Empty;

  // Token: 0x0400134A RID: 4938
  public string RemovalAnim = string.Empty;
}