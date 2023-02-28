using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Data;
using System.Text;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using Newtonsoft;
using Newtonsoft.Json;
using HarmonyLib;
using ThunderRoad;
using Extensions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;
using Methods = Extensions.Methods;
using static Extensions.Methods;
using Continuum = Extensions.Continuum;
using static Extensions.Continuum;
using Action = System.Action;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Spawner;
public class Spell : SpellCastCharge {
    public string itemID = "DaggerCommon";
    public override void Fire(bool active) {
        base.Fire(active);
        if (!active) return;
        Catalog.GetData<ItemData>(itemID)
               .SpawnAsync(item => {
                   item.transform.position = spellCaster.ragdollHand.AboveIndexTip();
                   spellCaster.ragdollHand.Grab(item.GetMainHandle(spellCaster.ragdollHand.side));
               });
    }
}