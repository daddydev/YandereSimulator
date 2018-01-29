using UnityEngine;

// Token: 0x0200008F RID: 143
public class DoorScript : MonoBehaviour {

  // Token: 0x1700002F RID: 47
  // (get) Token: 0x06000234 RID: 564 RVA: 0x0002F239 File Offset: 0x0002D639
  private bool Double {
    get {
      return this.Doors.Length == 2;
    }
  }

  // Token: 0x06000235 RID: 565 RVA: 0x0002F248 File Offset: 0x0002D648
  private void Start() {
    this.TrapSwing = 12.15f;
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    if (this.Swinging) {
      this.OriginX[0] = this.Doors[0].transform.localPosition.z;
      if (this.OriginX.Length > 1) {
        this.OriginX[1] = this.Doors[1].transform.localPosition.z;
      }
    }
    if (this.Labels.Length > 0) {
      this.Labels[0].text = this.RoomName;
      this.Labels[1].text = this.RoomName;
      this.UpdatePlate();
    }
    if (this.Club != ClubType.None && ClubGlobals.GetClubClosed(this.Club)) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      base.enabled = false;
    }
  }

  // Token: 0x06000236 RID: 566 RVA: 0x0002F348 File Offset: 0x0002D748
  private void Update() {
    if ((base.transform.position - this.Yandere.transform.position).sqrMagnitude <= 1f) {
      if (!this.Near) {
        this.TopicCheck();
        this.Yandere.Location.Label.text = this.RoomName;
        this.Yandere.Location.Show = true;
        this.Near = true;
      }
    } else if (this.Near) {
      this.Yandere.Location.Show = false;
      this.Near = false;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Open) {
        this.OpenDoor();
      } else {
        this.CloseDoor();
      }
    }
    if (this.Double && this.Swinging && this.Prompt.Circle[1].fillAmount == 0f) {
      this.Bucket = this.Yandere.PickUp.Bucket;
      this.Yandere.EmptyHands();
      this.Bucket.transform.parent = base.transform;
      this.Bucket.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
      this.Bucket.Trap = true;
      this.Bucket.Prompt.Hide();
      this.Bucket.Prompt.enabled = false;
      this.CheckDirection();
      if (this.North) {
        this.Bucket.transform.localPosition = new Vector3(0f, 2.25f, 0.2975f);
      } else {
        this.Bucket.transform.localPosition = new Vector3(0f, 2.25f, -0.2975f);
      }
      this.Bucket.GetComponent<Rigidbody>().isKinematic = true;
      this.Bucket.GetComponent<Rigidbody>().useGravity = false;
      this.Prompt.HideButton[1] = true;
      this.CanSetBucket = false;
      this.BucketSet = true;
      this.Open = false;
      this.Timer = 0f;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
    if (this.Timer < 2f) {
      this.Timer += Time.deltaTime;
      if (this.BucketSet) {
        for (int i = 0; i < this.Doors.Length; i++) {
          Transform transform = this.Doors[i];
          transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, this.OriginX[i] + ((!this.North) ? this.ShiftNorth : this.ShiftSouth), Time.deltaTime * 3.6f));
          this.Rotation = Mathf.Lerp(this.Rotation, (!this.North) ? this.TrapSwing : (-this.TrapSwing), Time.deltaTime * 3.6f);
          transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (i != 0) ? (-this.Rotation) : this.Rotation, transform.localEulerAngles.z);
        }
      } else if (!this.Open) {
        for (int j = 0; j < this.Doors.Length; j++) {
          Transform transform2 = this.Doors[j];
          if (!this.Swinging) {
            transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, this.ClosedPositions[j], Time.deltaTime * 3.6f), transform2.localPosition.y, transform2.localPosition.z);
          } else {
            this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 3.6f);
            transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, this.OriginX[j], Time.deltaTime * 3.6f));
            transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, (j != 0) ? (-this.Rotation) : this.Rotation, transform2.localEulerAngles.z);
          }
        }
      } else {
        for (int k = 0; k < this.Doors.Length; k++) {
          Transform transform3 = this.Doors[k];
          if (!this.Swinging) {
            transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, this.OpenPositions[k], Time.deltaTime * 3.6f), transform3.localPosition.y, transform3.localPosition.z);
          } else {
            transform3.localPosition = new Vector3(transform3.localPosition.x, transform3.localPosition.y, Mathf.Lerp(transform3.localPosition.z, this.OriginX[k] + ((!this.North) ? this.ShiftSouth : this.ShiftNorth), Time.deltaTime * 3.6f));
            this.Rotation = Mathf.Lerp(this.Rotation, (!this.North) ? (-this.Swing) : this.Swing, Time.deltaTime * 3.6f);
            transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, (k != 0) ? (-this.Rotation) : this.Rotation, transform3.localEulerAngles.z);
          }
        }
      }
    } else if (this.Locked && this.Prompt.Circle[0].fillAmount < 1f) {
      this.Prompt.Label[0].text = "     Locked";
      this.Prompt.Circle[0].fillAmount = 1f;
    }
    if (!this.NoTrap && this.Swinging && this.Double) {
      if (this.Yandere.PickUp != null) {
        if (this.Yandere.PickUp.Bucket != null) {
          if (this.Yandere.PickUp.GetComponent<BucketScript>().Full) {
            this.Prompt.HideButton[1] = false;
            this.CanSetBucket = true;
          } else if (this.CanSetBucket) {
            this.Prompt.HideButton[1] = true;
            this.CanSetBucket = false;
          }
        } else if (this.CanSetBucket) {
          this.Prompt.HideButton[1] = true;
          this.CanSetBucket = false;
        }
      } else if (this.CanSetBucket) {
        this.Prompt.HideButton[1] = true;
        this.CanSetBucket = false;
      }
    }
  }

  // Token: 0x06000237 RID: 567 RVA: 0x0002FB1C File Offset: 0x0002DF1C
  public void OpenDoor() {
    this.Open = true;
    this.Timer = 0f;
    this.UpdateLabel();
    if (this.HidingSpot) {
      UnityEngine.Object.Destroy(this.HideCollider.GetComponent<BoxCollider>());
    }
    this.CheckDirection();
    if (this.BucketSet) {
      this.Bucket.GetComponent<Rigidbody>().isKinematic = false;
      this.Bucket.GetComponent<Rigidbody>().useGravity = true;
      this.Bucket.UpdateAppearance = true;
      this.Bucket.Prompt.enabled = true;
      this.Bucket.Full = false;
      this.Bucket.Fly = true;
      this.Prompt.enabled = true;
      this.BucketSet = false;
    }
  }

  // Token: 0x06000238 RID: 568 RVA: 0x0002FBD7 File Offset: 0x0002DFD7
  private void LockDoor() {
    this.Open = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  // Token: 0x06000239 RID: 569 RVA: 0x0002FBF8 File Offset: 0x0002DFF8
  private void CheckDirection() {
    this.North = false;
    this.RelativeCharacter = ((!(this.Student != null)) ? this.Yandere.transform : this.Student.transform);
    if (this.Facing == "North") {
      if (this.RelativeCharacter.position.z < base.transform.position.z) {
        this.North = true;
      }
    } else if (this.Facing == "South") {
      if (this.RelativeCharacter.position.z > base.transform.position.z) {
        this.North = true;
      }
    } else if (this.Facing == "East") {
      if (this.RelativeCharacter.position.x < base.transform.position.x) {
        this.North = true;
      }
    } else if (this.Facing == "West" && this.RelativeCharacter.position.x > base.transform.position.x) {
      this.North = true;
    }
    this.Student = null;
  }

  // Token: 0x0600023A RID: 570 RVA: 0x0002FD74 File Offset: 0x0002E174
  public void CloseDoor() {
    this.Open = false;
    this.Timer = 0f;
    this.UpdateLabel();
    if (this.HidingSpot) {
      this.HideCollider.gameObject.AddComponent<BoxCollider>();
      BoxCollider component = this.HideCollider.GetComponent<BoxCollider>();
      component.size = new Vector3(component.size.x, component.size.y, 2f);
      component.isTrigger = true;
      this.HideCollider.MyCollider = component;
    }
  }

  // Token: 0x0600023B RID: 571 RVA: 0x0002FE00 File Offset: 0x0002E200
  private void UpdateLabel() {
    if (this.Open) {
      this.Prompt.Label[0].text = "     Close";
    } else {
      this.Prompt.Label[0].text = "     Open";
    }
  }

  // Token: 0x0600023C RID: 572 RVA: 0x0002FE40 File Offset: 0x0002E240
  private void UpdatePlate() {
    switch (this.RoomID) {
      case 1:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
        break;

      case 2:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
        break;

      case 3:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
        break;

      case 4:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0f);
        break;

      case 5:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
        break;

      case 6:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
        break;

      case 7:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
        break;

      case 8:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
        break;

      case 9:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
        break;

      case 10:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
        break;

      case 11:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
        break;

      case 12:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
        break;

      case 13:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
        break;

      case 14:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
        break;

      case 15:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
        break;

      case 16:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
        break;

      case 17:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
        break;

      case 18:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
        break;

      case 19:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
        break;

      case 20:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0f);
        break;

      case 21:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
        break;

      case 22:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
        break;

      case 23:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
        break;

      case 24:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
        break;

      case 25:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
        break;

      case 26:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
        break;

      case 27:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
        break;

      case 28:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
        break;

      case 29:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
        break;

      case 30:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
        break;

      case 31:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
        break;

      case 32:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
        break;

      case 33:
        this.Sign.material.mainTexture = this.Plates[3];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
        break;

      case 34:
        this.Sign.material.mainTexture = this.Plates[3];
        this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
        break;
    }
  }

  // Token: 0x0600023D RID: 573 RVA: 0x000306E8 File Offset: 0x0002EAE8
  private void TopicCheck() {
    switch (this.RoomID) {
      case 3:
        if (!ConversationGlobals.GetTopicDiscovered(12)) {
          ConversationGlobals.SetTopicDiscovered(12, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 13:
        if (!ConversationGlobals.GetTopicDiscovered(21)) {
          ConversationGlobals.SetTopicDiscovered(21, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 15:
        if (!ConversationGlobals.GetTopicDiscovered(16)) {
          ConversationGlobals.SetTopicDiscovered(16, true);
          ConversationGlobals.SetTopicDiscovered(17, true);
          ConversationGlobals.SetTopicDiscovered(18, true);
          ConversationGlobals.SetTopicDiscovered(19, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 26:
        if (!ConversationGlobals.GetTopicDiscovered(1)) {
          ConversationGlobals.SetTopicDiscovered(1, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 27:
        if (!ConversationGlobals.GetTopicDiscovered(2)) {
          ConversationGlobals.SetTopicDiscovered(2, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 28:
        if (!ConversationGlobals.GetTopicDiscovered(3)) {
          ConversationGlobals.SetTopicDiscovered(3, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 29:
        if (!ConversationGlobals.GetTopicDiscovered(4)) {
          ConversationGlobals.SetTopicDiscovered(4, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 30:
        if (!ConversationGlobals.GetTopicDiscovered(5)) {
          ConversationGlobals.SetTopicDiscovered(5, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 31:
        if (!ConversationGlobals.GetTopicDiscovered(6)) {
          ConversationGlobals.SetTopicDiscovered(6, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 32:
        if (!ConversationGlobals.GetTopicDiscovered(7)) {
          ConversationGlobals.SetTopicDiscovered(7, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;

      case 34:
        if (!ConversationGlobals.GetTopicDiscovered(8)) {
          ConversationGlobals.SetTopicDiscovered(8, true);
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        break;
    }
  }

  // Token: 0x0400079A RID: 1946
  [SerializeField]
  private Transform RelativeCharacter;

  // Token: 0x0400079B RID: 1947
  [SerializeField]
  private HideColliderScript HideCollider;

  // Token: 0x0400079C RID: 1948
  public StudentScript Student;

  // Token: 0x0400079D RID: 1949
  [SerializeField]
  private YandereScript Yandere;

  // Token: 0x0400079E RID: 1950
  [SerializeField]
  private BucketScript Bucket;

  // Token: 0x0400079F RID: 1951
  public PromptScript Prompt;

  // Token: 0x040007A0 RID: 1952
  [SerializeField]
  private float[] ClosedPositions;

  // Token: 0x040007A1 RID: 1953
  [SerializeField]
  private float[] OpenPositions;

  // Token: 0x040007A2 RID: 1954
  [SerializeField]
  private Transform[] Doors;

  // Token: 0x040007A3 RID: 1955
  [SerializeField]
  private Texture[] Plates;

  // Token: 0x040007A4 RID: 1956
  [SerializeField]
  private UILabel[] Labels;

  // Token: 0x040007A5 RID: 1957
  [SerializeField]
  private float[] OriginX;

  // Token: 0x040007A6 RID: 1958
  [SerializeField]
  private bool CanSetBucket;

  // Token: 0x040007A7 RID: 1959
  [SerializeField]
  private bool HidingSpot;

  // Token: 0x040007A8 RID: 1960
  [SerializeField]
  private bool BucketSet;

  // Token: 0x040007A9 RID: 1961
  [SerializeField]
  private bool Swinging;

  // Token: 0x040007AA RID: 1962
  public bool Locked;

  // Token: 0x040007AB RID: 1963
  [SerializeField]
  private bool NoTrap;

  // Token: 0x040007AC RID: 1964
  [SerializeField]
  private bool North;

  // Token: 0x040007AD RID: 1965
  public bool Open;

  // Token: 0x040007AE RID: 1966
  [SerializeField]
  private bool Near;

  // Token: 0x040007AF RID: 1967
  [SerializeField]
  private float ShiftNorth = -0.1f;

  // Token: 0x040007B0 RID: 1968
  [SerializeField]
  private float ShiftSouth = 0.1f;

  // Token: 0x040007B1 RID: 1969
  [SerializeField]
  private float Rotation;

  // Token: 0x040007B2 RID: 1970
  [SerializeField]
  private float Timer;

  // Token: 0x040007B3 RID: 1971
  [SerializeField]
  private float TrapSwing = 12.15f;

  // Token: 0x040007B4 RID: 1972
  [SerializeField]
  private float Swing = 150f;

  // Token: 0x040007B5 RID: 1973
  [SerializeField]
  private Renderer Sign;

  // Token: 0x040007B6 RID: 1974
  [SerializeField]
  private string RoomName = string.Empty;

  // Token: 0x040007B7 RID: 1975
  [SerializeField]
  private string Facing = string.Empty;

  // Token: 0x040007B8 RID: 1976
  [SerializeField]
  private int RoomID;

  // Token: 0x040007B9 RID: 1977
  [SerializeField]
  private ClubType Club;
}