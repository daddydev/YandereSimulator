using System;
using UnityEngine;

// Token: 0x020000A8 RID: 168
[Serializable]
public class Persona {

  // Token: 0x0600029A RID: 666 RVA: 0x000343A7 File Offset: 0x000327A7
  public Persona(PersonaType type) {
    this.type = type;
  }

  // Token: 0x1700004B RID: 75
  // (get) Token: 0x0600029B RID: 667 RVA: 0x000343B6 File Offset: 0x000327B6
  public PersonaType Type {
    get {
      return this.type;
    }
  }

  // Token: 0x04000892 RID: 2194
  [SerializeField]
  private PersonaType type;

  // Token: 0x04000893 RID: 2195
  public static readonly PersonaTypeAndStringDictionary PersonaNames = new PersonaTypeAndStringDictionary
  {
    {
      PersonaType.None,
      "None"
    },
    {
      PersonaType.Loner,
      "Loner"
    },
    {
      PersonaType.TeachersPet,
      "Teacher's Pet"
    },
    {
      PersonaType.Heroic,
      "Heroic"
    },
    {
      PersonaType.Coward,
      "Coward"
    },
    {
      PersonaType.Evil,
      "Evil"
    },
    {
      PersonaType.SocialButterfly,
      "Social Butterfly"
    },
    {
      PersonaType.Lovestruck,
      "Lovestruck"
    },
    {
      PersonaType.Dangerous,
      "Dangerous"
    },
    {
      PersonaType.Strict,
      "Strict"
    },
    {
      PersonaType.Nemesis,
      "?????"
    }
  };
}