using UnityEngine;

// Token: 0x0200022B RID: 555
public class YanvaniaDoubleFireballScript : MonoBehaviour {

  // Token: 0x060009D1 RID: 2513 RVA: 0x000B29E0 File Offset: 0x000B0DE0
  private void Start() {
    UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
    this.Direction = ((this.Dracula.position.x <= base.transform.position.x) ? 1 : -1);
  }

  // Token: 0x060009D2 RID: 2514 RVA: 0x000B2A58 File Offset: 0x000B0E58
  private void Update() {
    if (this.Timer > 1f && !this.SpawnedFirst) {
      UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
      this.FirstLavaball = UnityEngine.Object.Instantiate<GameObject>(this.Lavaball, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
      this.FirstLavaball.transform.localScale = Vector3.zero;
      this.SpawnedFirst = true;
    }
    if (this.FirstLavaball != null) {
      this.FirstLavaball.transform.localScale = Vector3.Lerp(this.FirstLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.FirstPosition += ((this.FirstPosition != 0f) ? (this.FirstPosition * this.Speed) : Time.deltaTime);
      this.FirstLavaball.transform.position = new Vector3(this.FirstLavaball.transform.position.x + this.FirstPosition * (float)this.Direction, this.FirstLavaball.transform.position.y, this.FirstLavaball.transform.position.z);
      this.FirstLavaball.transform.eulerAngles = new Vector3(this.FirstLavaball.transform.eulerAngles.x, this.FirstLavaball.transform.eulerAngles.y, this.FirstLavaball.transform.eulerAngles.z - this.FirstPosition * (float)this.Direction * 36f);
    }
    if (this.Timer > 2f && !this.SpawnedSecond) {
      this.SecondLavaball = UnityEngine.Object.Instantiate<GameObject>(this.Lavaball, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
      this.SecondLavaball.transform.localScale = Vector3.zero;
      this.SpawnedSecond = true;
    }
    if (this.SecondLavaball != null) {
      this.SecondLavaball.transform.localScale = Vector3.Lerp(this.SecondLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.SecondPosition == 0f) {
        this.SecondPosition += Time.deltaTime;
      } else {
        this.SecondPosition += this.SecondPosition * this.Speed;
      }
      this.SecondLavaball.transform.position = new Vector3(this.SecondLavaball.transform.position.x + this.SecondPosition * (float)this.Direction, this.SecondLavaball.transform.position.y, this.SecondLavaball.transform.position.z);
      this.SecondLavaball.transform.eulerAngles = new Vector3(this.SecondLavaball.transform.eulerAngles.x, this.SecondLavaball.transform.eulerAngles.y, this.SecondLavaball.transform.eulerAngles.z - this.SecondPosition * (float)this.Direction * 36f);
    }
    this.Timer += Time.deltaTime;
    if (this.Timer > 10f) {
      if (this.FirstLavaball != null) {
        UnityEngine.Object.Destroy(this.FirstLavaball);
      }
      if (this.SecondLavaball != null) {
        UnityEngine.Object.Destroy(this.SecondLavaball);
      }
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001D95 RID: 7573
  public GameObject Lavaball;

  // Token: 0x04001D96 RID: 7574
  public GameObject FirstLavaball;

  // Token: 0x04001D97 RID: 7575
  public GameObject SecondLavaball;

  // Token: 0x04001D98 RID: 7576
  public GameObject LightningEffect;

  // Token: 0x04001D99 RID: 7577
  public Transform Dracula;

  // Token: 0x04001D9A RID: 7578
  public bool SpawnedFirst;

  // Token: 0x04001D9B RID: 7579
  public bool SpawnedSecond;

  // Token: 0x04001D9C RID: 7580
  public float FirstPosition;

  // Token: 0x04001D9D RID: 7581
  public float SecondPosition;

  // Token: 0x04001D9E RID: 7582
  public int Direction;

  // Token: 0x04001D9F RID: 7583
  public float Timer;

  // Token: 0x04001DA0 RID: 7584
  public float Speed;
}