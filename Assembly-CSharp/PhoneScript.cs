using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000150 RID: 336
public class PhoneScript : MonoBehaviour {

  // Token: 0x0600062D RID: 1581 RVA: 0x000584D8 File Offset: 0x000568D8
  private void Start() {
    this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, -135f, this.Buttons.localPosition.z);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    if (EventGlobals.KidnapConversation) {
      this.VoiceClips = this.KidnapClip;
      this.Speaker = this.KidnapSpeaker;
      this.Text = this.KidnapText;
      this.Height = this.KidnapHeight;
      EventGlobals.BefriendConversation = true;
      EventGlobals.KidnapConversation = false;
    } else if (EventGlobals.BefriendConversation) {
      this.VoiceClips = this.BefriendClip;
      this.Speaker = this.BefriendSpeaker;
      this.Text = this.BefriendText;
      this.Height = this.BefriendHeight;
      EventGlobals.LivingRoom = true;
      EventGlobals.BefriendConversation = false;
    }
    if (GameGlobals.LoveSick) {
      Camera.main.backgroundColor = Color.black;
      this.LoveSickColorSwap();
    }
  }

  // Token: 0x0600062E RID: 1582 RVA: 0x00058620 File Offset: 0x00056A20
  private void Update() {
    if (!this.FadeOut) {
      if (this.Timer > 0f) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
        if (this.Darkness.color.a == 0f) {
          if (!this.Jukebox.isPlaying) {
            this.Jukebox.Play();
          }
          if (this.NewMessage == null) {
            this.SpawnMessage();
          }
        }
      }
      if (this.NewMessage != null) {
        this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, 0f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
        this.AutoTimer += Time.deltaTime;
        if ((this.Auto && this.AutoTimer > this.VoiceClips[this.ID].length + 1f) || Input.GetButtonDown("A")) {
          this.AutoTimer = 0f;
          if (this.ID < this.Text.Length - 1) {
            this.ID++;
            this.SpawnMessage();
          } else {
            this.Darkness.color = new Color(0f, 0f, 0f, 0f);
            this.FadeOut = true;
          }
        }
        if (Input.GetButtonDown("X")) {
          this.FadeOut = true;
        }
      }
    } else {
      this.Buttons.localPosition = new Vector3(this.Buttons.localPosition.x, Mathf.Lerp(this.Buttons.localPosition.y, -135f, Time.deltaTime * 10f), this.Buttons.localPosition.z);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      base.GetComponent<AudioSource>().volume = 1f - this.Darkness.color.a;
      this.Jukebox.volume = 1f - this.Darkness.color.a;
      if (this.Darkness.color.a >= 1f) {
        if (!EventGlobals.BefriendConversation && !EventGlobals.LivingRoom) {
          SceneManager.LoadScene("CalendarScene");
        } else if (EventGlobals.LivingRoom) {
          SceneManager.LoadScene("LivingRoomScene");
        } else {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
      }
    }
    this.Timer += Time.deltaTime;
  }

  // Token: 0x0600062F RID: 1583 RVA: 0x000589D4 File Offset: 0x00056DD4
  private void SpawnMessage() {
    if (this.NewMessage != null) {
      this.NewMessage.transform.parent = this.OldMessages;
      this.OldMessages.localPosition = new Vector3(this.OldMessages.localPosition.x, this.OldMessages.localPosition.y + (72f + (float)this.Height[this.ID] * 32f), this.OldMessages.localPosition.z);
    }
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.VoiceClips[this.ID];
    component.Play();
    if (this.Speaker[this.ID] == 1) {
      this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.LeftMessage[this.Height[this.ID]]);
      this.NewMessage.transform.parent = this.Panel;
      this.NewMessage.transform.localPosition = new Vector3(-225f, -375f, 0f);
      this.NewMessage.transform.localScale = Vector3.zero;
    } else {
      this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.RightMessage[this.Height[this.ID]]);
      this.NewMessage.transform.parent = this.Panel;
      this.NewMessage.transform.localPosition = new Vector3(225f, -375f, 0f);
      this.NewMessage.transform.localScale = Vector3.zero;
      if (this.Speaker == this.KidnapSpeaker && this.Height[this.ID] == 8) {
        this.NewMessage.GetComponent<TextMessageScript>().Attachment = true;
      }
    }
    this.AutoLimit = (float)(this.Height[this.ID] + 1);
    this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.Text[this.ID];
  }

  // Token: 0x06000630 RID: 1584 RVA: 0x00058BF0 File Offset: 0x00056FF0
  private void LoveSickColorSwap() {
    GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gameObject in array) {
      UISprite component = gameObject.GetComponent<UISprite>();
      if (component != null && component.color != Color.black && component.transform.parent) {
        component.color = new Color(1f, 0f, 0f, component.color.a);
      }
      UILabel component2 = gameObject.GetComponent<UILabel>();
      if (component2 != null && component2.color != Color.black) {
        component2.color = new Color(1f, 0f, 0f, component2.color.a);
      }
      this.Darkness.color = Color.black;
    }
  }

  // Token: 0x04000EF3 RID: 3827
  public GameObject[] RightMessage;

  // Token: 0x04000EF4 RID: 3828
  public GameObject[] LeftMessage;

  // Token: 0x04000EF5 RID: 3829
  public AudioClip[] VoiceClips;

  // Token: 0x04000EF6 RID: 3830
  public GameObject NewMessage;

  // Token: 0x04000EF7 RID: 3831
  public AudioSource Jukebox;

  // Token: 0x04000EF8 RID: 3832
  public Transform OldMessages;

  // Token: 0x04000EF9 RID: 3833
  public Transform Buttons;

  // Token: 0x04000EFA RID: 3834
  public Transform Panel;

  // Token: 0x04000EFB RID: 3835
  public Vignetting Vignette;

  // Token: 0x04000EFC RID: 3836
  public UISprite Darkness;

  // Token: 0x04000EFD RID: 3837
  public UISprite Sprite;

  // Token: 0x04000EFE RID: 3838
  public int[] Speaker;

  // Token: 0x04000EFF RID: 3839
  public string[] Text;

  // Token: 0x04000F00 RID: 3840
  public int[] Height;

  // Token: 0x04000F01 RID: 3841
  public AudioClip[] KidnapClip;

  // Token: 0x04000F02 RID: 3842
  public int[] KidnapSpeaker;

  // Token: 0x04000F03 RID: 3843
  public string[] KidnapText;

  // Token: 0x04000F04 RID: 3844
  public int[] KidnapHeight;

  // Token: 0x04000F05 RID: 3845
  public AudioClip[] BefriendClip;

  // Token: 0x04000F06 RID: 3846
  public int[] BefriendSpeaker;

  // Token: 0x04000F07 RID: 3847
  public string[] BefriendText;

  // Token: 0x04000F08 RID: 3848
  public int[] BefriendHeight;

  // Token: 0x04000F09 RID: 3849
  public bool FadeOut;

  // Token: 0x04000F0A RID: 3850
  public bool Auto;

  // Token: 0x04000F0B RID: 3851
  public float AutoLimit;

  // Token: 0x04000F0C RID: 3852
  public float AutoTimer;

  // Token: 0x04000F0D RID: 3853
  public float Timer;

  // Token: 0x04000F0E RID: 3854
  public int ID;
}