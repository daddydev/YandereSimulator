// Token: 0x020000D8 RID: 216
public static class EventGlobals {

  // Token: 0x1700006B RID: 107
  // (get) Token: 0x06000392 RID: 914 RVA: 0x0003B148 File Offset: 0x00039548
  // (set) Token: 0x06000393 RID: 915 RVA: 0x0003B154 File Offset: 0x00039554
  public static bool BefriendConversation {
    get {
      return GlobalsHelper.GetBool("BefriendConversation");
    }
    set {
      GlobalsHelper.SetBool("BefriendConversation", value);
    }
  }

  // Token: 0x1700006C RID: 108
  // (get) Token: 0x06000394 RID: 916 RVA: 0x0003B161 File Offset: 0x00039561
  // (set) Token: 0x06000395 RID: 917 RVA: 0x0003B16D File Offset: 0x0003956D
  public static bool Event1 {
    get {
      return GlobalsHelper.GetBool("Event1");
    }
    set {
      GlobalsHelper.SetBool("Event1", value);
    }
  }

  // Token: 0x1700006D RID: 109
  // (get) Token: 0x06000396 RID: 918 RVA: 0x0003B17A File Offset: 0x0003957A
  // (set) Token: 0x06000397 RID: 919 RVA: 0x0003B186 File Offset: 0x00039586
  public static bool Event2 {
    get {
      return GlobalsHelper.GetBool("Event2");
    }
    set {
      GlobalsHelper.SetBool("Event2", value);
    }
  }

  // Token: 0x1700006E RID: 110
  // (get) Token: 0x06000398 RID: 920 RVA: 0x0003B193 File Offset: 0x00039593
  // (set) Token: 0x06000399 RID: 921 RVA: 0x0003B19F File Offset: 0x0003959F
  public static bool KidnapConversation {
    get {
      return GlobalsHelper.GetBool("KidnapConversation");
    }
    set {
      GlobalsHelper.SetBool("KidnapConversation", value);
    }
  }

  // Token: 0x1700006F RID: 111
  // (get) Token: 0x0600039A RID: 922 RVA: 0x0003B1AC File Offset: 0x000395AC
  // (set) Token: 0x0600039B RID: 923 RVA: 0x0003B1B8 File Offset: 0x000395B8
  public static bool LivingRoom {
    get {
      return GlobalsHelper.GetBool("LivingRoom");
    }
    set {
      GlobalsHelper.SetBool("LivingRoom", value);
    }
  }

  // Token: 0x0600039C RID: 924 RVA: 0x0003B1C5 File Offset: 0x000395C5
  public static void DeleteAll() {
    Globals.Delete("BefriendConversation");
    Globals.Delete("Event1");
    Globals.Delete("Event2");
    Globals.Delete("KidnapConversation");
    Globals.Delete("LivingRoom");
  }

  // Token: 0x040009D6 RID: 2518
  private const string Str_BefriendConversation = "BefriendConversation";

  // Token: 0x040009D7 RID: 2519
  private const string Str_Event1 = "Event1";

  // Token: 0x040009D8 RID: 2520
  private const string Str_Event2 = "Event2";

  // Token: 0x040009D9 RID: 2521
  private const string Str_KidnapConversation = "KidnapConversation";

  // Token: 0x040009DA RID: 2522
  private const string Str_LivingRoom = "LivingRoom";
}