using UnityEngine;

// Token: 0x02000032 RID: 50
public class DontLetSenpaiNoticeYouScript : MonoBehaviour {

  // Token: 0x060000B8 RID: 184 RVA: 0x0000CA70 File Offset: 0x0000AE70
  private void Start() {
    while (this.ID < this.Letters.Length) {
      UILabel uilabel = this.Letters[this.ID];
      uilabel.transform.localScale = new Vector3(10f, 10f, 1f);
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
      this.Origins[this.ID] = uilabel.transform.localPosition;
      this.ID++;
    }
    this.ID = 0;
  }

  // Token: 0x060000B9 RID: 185 RVA: 0x0000CB34 File Offset: 0x0000AF34
  private void Update() {
    if (Input.GetButtonDown("A")) {
      this.Proceed = true;
    }
    if (this.Proceed) {
      if (this.ID < this.Letters.Length) {
        UILabel uilabel = this.Letters[this.ID];
        uilabel.transform.localScale = Vector3.MoveTowards(uilabel.transform.localScale, Vector3.one, Time.deltaTime * 100f);
        uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime * 10f);
        if (uilabel.transform.localScale == Vector3.one) {
          base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
          this.ID++;
        }
      }
      this.ShakeID = 0;
      while (this.ShakeID < this.Letters.Length) {
        UILabel uilabel2 = this.Letters[this.ShakeID];
        Vector3 vector = this.Origins[this.ShakeID];
        uilabel2.transform.localPosition = new Vector3(vector.x + UnityEngine.Random.Range(-5f, 5f), vector.y + UnityEngine.Random.Range(-5f, 5f), uilabel2.transform.localPosition.z);
        this.ShakeID++;
      }
    }
  }

  // Token: 0x040002AF RID: 687
  public UILabel[] Letters;

  // Token: 0x040002B0 RID: 688
  public Vector3[] Origins;

  // Token: 0x040002B1 RID: 689
  public AudioClip Slam;

  // Token: 0x040002B2 RID: 690
  public bool Proceed;

  // Token: 0x040002B3 RID: 691
  public int ShakeID;

  // Token: 0x040002B4 RID: 692
  public int ID;
}