using UnityEngine;

// Token: 0x0200023D RID: 573
public class ZoomScript : MonoBehaviour {

  // Token: 0x06000A15 RID: 2581 RVA: 0x000B97C8 File Offset: 0x000B7BC8
  private void Update() {
    if (this.Yandere.FollowHips) {
      base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
    }
    if (this.Yandere.Stance.Current == StanceType.Crawling) {
      this.Height = 0.05f;
    } else if (this.Yandere.Stance.Current == StanceType.Crouching) {
      this.Height = 0.4f;
    } else {
      this.Height = 1f;
    }
    if (!this.Yandere.FollowHips) {
      if (this.Yandere.FlameDemonic) {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, this.Height + this.Zoom + 0.4f, Time.deltaTime * 10f), base.transform.localPosition.z);
      } else if (this.Yandere.Slender) {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, this.Height + this.Zoom + this.Slender, Time.deltaTime * 10f), base.transform.localPosition.z);
      } else if (this.Yandere.Stand.Stand.activeInHierarchy) {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, this.Height - this.Zoom * 0.5f + this.Slender * 0.5f, Time.deltaTime * 10f), base.transform.localPosition.z);
      } else {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, this.Height + this.Zoom, Time.deltaTime * 10f), base.transform.localPosition.z);
      }
    } else if (!this.Yandere.SithLord) {
      base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, this.Yandere.Hips.position.y + this.Zoom, Time.deltaTime * 10f), base.transform.position.z);
    } else {
      base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, this.Yandere.Hips.position.y, Time.deltaTime * 10f), base.transform.position.z);
    }
    if (!this.Yandere.Aiming) {
      this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
    }
    if (this.Yandere.SithLord) {
      this.Slender = Mathf.Lerp(this.Slender, 2.5f, Time.deltaTime);
    } else if (this.Yandere.Slender || this.Yandere.Stand.Stand.activeInHierarchy || this.Yandere.Blasting || this.Yandere.PK || this.TallHat.activeInHierarchy) {
      this.Slender = Mathf.Lerp(this.Slender, 0.5f, Time.deltaTime);
    } else {
      this.Slender = Mathf.Lerp(this.Slender, 0f, Time.deltaTime);
    }
    if (this.TargetZoom < 0f) {
      this.TargetZoom = 0f;
    }
    if (this.Yandere.Stance.Current == StanceType.Crawling) {
      if (this.TargetZoom > 0.3f) {
        this.TargetZoom = 0.3f;
      }
    } else if (this.TargetZoom > 0.4f) {
      this.TargetZoom = 0.4f;
    }
    this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
    if (!this.Yandere.Possessed) {
      this.CameraScript.distance = 2f - this.Zoom * 3.33333f + this.Slender;
      this.CameraScript.distanceMax = 2f - this.Zoom * 3.33333f + this.Slender;
      this.CameraScript.distanceMin = 2f - this.Zoom * 3.33333f + this.Slender;
      if (this.Yandere.TornadoHair.activeInHierarchy || this.CardboardBox.transform.parent == this.Yandere.Hips) {
        this.CameraScript.distanceMax += 3f;
      }
    } else {
      this.CameraScript.distance = 5f;
      this.CameraScript.distanceMax = 5f;
    }
    if (!this.Yandere.TimeSkipping) {
      this.Timer += Time.deltaTime;
      this.ShakeStrength = Mathf.Lerp(this.ShakeStrength, 1f - this.Yandere.Sanity * 0.01f, Time.deltaTime);
      if (this.Timer > 0.1f + this.Yandere.Sanity * 0.01f) {
        this.Target.x = UnityEngine.Random.Range(-this.ShakeStrength, this.ShakeStrength);
        this.Target.y = base.transform.localPosition.y;
        this.Target.z = UnityEngine.Random.Range(-this.ShakeStrength, this.ShakeStrength);
        this.Timer = 0f;
      }
    } else {
      this.Target = new Vector3(0f, base.transform.localPosition.y, 0f);
    }
    if (this.Yandere.RoofPush) {
      base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime * 10f), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime * 10f));
    } else {
      base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, this.Target, Time.deltaTime * this.ShakeStrength * 0.1f);
    }
    base.transform.localPosition = new Vector3((!this.OverShoulder) ? 0f : 0.25f, base.transform.localPosition.y, base.transform.localPosition.z);
  }

  // Token: 0x04001EA9 RID: 7849
  public CardboardBoxScript CardboardBox;

  // Token: 0x04001EAA RID: 7850
  public RPG_Camera CameraScript;

  // Token: 0x04001EAB RID: 7851
  public YandereScript Yandere;

  // Token: 0x04001EAC RID: 7852
  public float TargetZoom;

  // Token: 0x04001EAD RID: 7853
  public float Zoom;

  // Token: 0x04001EAE RID: 7854
  public float ShakeStrength;

  // Token: 0x04001EAF RID: 7855
  public float Slender;

  // Token: 0x04001EB0 RID: 7856
  public float Height;

  // Token: 0x04001EB1 RID: 7857
  public float Timer;

  // Token: 0x04001EB2 RID: 7858
  public Vector3 Target;

  // Token: 0x04001EB3 RID: 7859
  public bool OverShoulder;

  // Token: 0x04001EB4 RID: 7860
  public GameObject TallHat;
}