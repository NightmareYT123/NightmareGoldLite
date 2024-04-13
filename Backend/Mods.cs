using ShibaGTTemplate.Utilities;
using Photon.Pun;   
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using ExitGames.Client.Photon;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using ShibaGTTemplate.UI;
using GorillaNetworking;
using dark.efijiPOIWikjek;
using GorillaLocomotion.Gameplay;
using GorillaExtensions;
using Steamworks;
using HarmonyLib;
using System.Reflection;
using GorillaTag;
using static UnityEngine.UI.GridLayoutGroup;
using Photon.Pun.UtilityScripts;
using System.IO;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using Oculus.Interaction.HandGrab;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using GorillaTagScripts;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Voice.Unity;
using System.ComponentModel;
using UnityEngine.UIElements;
using OVRSimpleJSON;
using GTAG_NotificationLib;
using System.Threading;
using UnityEngine.XR;
using UnityEngine.InputSystem.HID;
using System.Runtime.InteropServices;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static Mono.Security.X509.PKCS12.DeriveBytes;
using Displyy_Template.UI;
using static Mono.Security.X509.X509Stores;
using PlayFab;
using System.Text.RegularExpressions;

namespace ShibaGTTemplate.Backend
{
    internal class Mods : MonoBehaviour
    {
        public static bool oiwefkwenfjk;

        public static void HeadSpin()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.y += 15f;
        }

        public static void nuhuhheadspin()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0.0f;

        }

        public static bool inSettings = false;

        public static void Settings()
        {
            WristMenu.settingsbuttons[0].enabled = false;
            WristMenu.buttons[0].enabled = false;
            inSettings = !inSettings;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static bool invisplat = false;
        public static bool stickyplatforms = false;
        public static GameObject funn;
        public static bool fpcc;

        public static void Platforms()
        {
            PlatformsThing(invisplat, stickyplatforms);
        }

        public static void InvisPlatforms()
        {
            PlatformsThing(true, false);
        }

        public static void StickyPlatforms()
        {
            PlatformsThing(false, true);
        }

        public static void Ghost()
        {
            bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
            if (rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject = GameObject.CreatePrimitive(0);
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = new Color32(255, 168, 255, 1);
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = new Color32(255, 168, 255, 1);
                UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;

            }
        }

        public static void Invisible()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || ControllerInputPoller.instance.leftControllerPrimaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(999f, 999f, 999f);
                GameObject righth = GameObject.CreatePrimitive(0);
                GameObject lefth = GameObject.CreatePrimitive(0);

                Object.Destroy(righth.GetComponent<Rigidbody>());
                Object.Destroy(righth.GetComponent<SphereCollider>());
                Object.Destroy(lefth.GetComponent<Rigidbody>());
                Object.Destroy(lefth.GetComponent<SphereCollider>());

                righth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                lefth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                righth.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                lefth.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                righth.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                lefth.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

                Object.Destroy(righth, Time.deltaTime);
                Object.Destroy(lefth, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
            //RigShit.rigpatcher();
            Backend.GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
        }

        public static void AttempsToActivateAndUseStick()
        {

        }

        public static void AttempsToActivateAndUseFingerPainter()
        {

        }

        //Animal Mods
        public static void AnimalOwnership()
        {
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();

            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
        }

        //Seperate from ownership
        public static void BatGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                pointer.GetComponent<Renderer>().material.color = Color.white;
                pointer.transform.position = hitInfo.point;
                GameObject.Destroy(pointer.GetComponent<BoxCollider>());
                GameObject.Destroy(pointer.GetComponent<Rigidbody>());
                GameObject.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {
                    GameObject.Find("Cave Bat Holdable").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }



        public static void Grabbug()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }

        }

        public static void Grabbat()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }

        }

        public static void BugGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                pointer.GetComponent<Renderer>().material.color = Color.white;
                pointer.transform.position = hitInfo.point;
                GameObject.Destroy(pointer.GetComponent<BoxCollider>());
                GameObject.Destroy(pointer.GetComponent<Rigidbody>());
                GameObject.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {
                    GameObject.Find("Floating Bug Holdable").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }



        //End

        public static void KickGunNOTSTUMP()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                pointer.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                pointer.GetComponent<Renderer>().material.color = Color.white;
                pointer.transform.position = hitInfo.point;
                GameObject.Destroy(pointer.GetComponent<BoxCollider>());
                GameObject.Destroy(pointer.GetComponent<Rigidbody>());
                GameObject.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {

                    pointer.GetComponent<Renderer>().material.color = Color.red;
                    PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                }
                else
                {
                }
            }
            if (pointer != null)
            {
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static void SlothFly()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 2;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 15;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void FastFly()
        {
            bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
            if (rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 35.5f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void FlyNoclip()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 13f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }

        public static void GoodTPGUN() //Made By Zapz (Discord=♪-♪)
        {
            if (WristMenu.gripDownR)
            {
                {
                    //Sphere Hit Area
                    RaycastHit raycastHit;
                    Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward, out raycastHit);
                    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    gameObject.transform.position = raycastHit.point;
                    Object.Destroy(gameObject.GetComponent<BoxCollider>());
                    Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    Object.Destroy(gameObject.GetComponent<Collider>());
                    Object.Destroy(gameObject, Time.deltaTime);
                    //Line
                    GameObject line = new GameObject("Line");
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = Color.white;
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, raycastHit.point);
                    liner.SetPosition(1, GorillaTagger.Instance.rightHandTransform.position);
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                    if (WristMenu.triggerDownR)
                    {
                        GorillaLocomotion.Player.Instance.transform.position = gameObject.transform.position;
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = gameObject.transform.position;
                    }
                }
            }
        }

        public static void IronMonke()
        {
            if (WristMenu.gripDownR)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * GorillaLocomotion.Player.Instance.rightControllerTransform.right.x, 15f * GorillaLocomotion.Player.Instance.rightControllerTransform.right.y, 15f * GorillaLocomotion.Player.Instance.rightControllerTransform.right.z), ForceMode.Acceleration);
            }
            if (WristMenu.gripDownL)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, true, 0.1f);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * GorillaLocomotion.Player.Instance.leftControllerTransform.right.x * -1f, 15f * GorillaLocomotion.Player.Instance.leftControllerTransform.right.y * -1f, 15f * GorillaLocomotion.Player.Instance.leftControllerTransform.right.z * -1f), ForceMode.Acceleration);
            }
        }

        public static void JoinCodeBotByJaxFixed()
        {
            PhotonNetwork.JoinRoom("4949");
        }

        public static void StickLongArms()
        {
            GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position = GorillaTagger.Instance.leftHandTransform.position + GorillaTagger.Instance.leftHandTransform.forward * 0.333f;
            GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.forward * 0.333f;
        }

        public static void FixHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0.1f;
        }

        public static void LoudHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = int.MaxValue;
        }

        public static void SilentHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0;
        }

        public static void EnableInstantHandTaps()
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
        }

        public static void DisableInstantHandTaps()
        {
            GorillaTagger.Instance.tapCoolDown = 0.33f;
        }

        public static void SpinHeadZ()
        {
            VRMap head = GorillaTagger.Instance.offlineVRRig.head;
            head.trackingRotationOffset.z = head.trackingRotationOffset.z + 10f;
        }

        public static void SpinHeadY()
        {
            VRMap head = GorillaTagger.Instance.offlineVRRig.head;
            head.trackingRotationOffset.y = head.trackingRotationOffset.y + 10f;
        }

        public static void SpinHeadX()
        {
            VRMap head = GorillaTagger.Instance.offlineVRRig.head;
            head.trackingRotationOffset.x = head.trackingRotationOffset.x + 10f;
        }



        public static void FixHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
        }

        public static void FlipHands()
        {
            Vector3 lh = GorillaTagger.Instance.leftHandTransform.position;
            Vector3 rh = GorillaTagger.Instance.rightHandTransform.position;
            Quaternion lhr = GorillaTagger.Instance.leftHandTransform.rotation;
            Quaternion rhr = GorillaTagger.Instance.rightHandTransform.rotation;

            GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position = lh;
            GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position = rh;

            GorillaLocomotion.Player.Instance.rightControllerTransform.transform.rotation = lhr;
            GorillaLocomotion.Player.Instance.leftControllerTransform.transform.rotation = rhr;
        }

        public static void EnableFPSBoost()
        {
            QualitySettings.globalTextureMipmapLimit = 99999;
        }

        public static void DisableFPSBoost()
        {
            QualitySettings.globalTextureMipmapLimit = 1;
        }

        public static void NightTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
        }

        public static void DayTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }

        public static void ShinyRocks()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                CosmeticsController.instance.currencyBalance = 9999999;
            }
        }

        public static bool casual = false;
        public static bool fected = false;
        public static bool ifDisabled = true;

        public static GameObject AntireportBlock = null;
        public static void AntiReport()
        {
            GorillaScoreBoard[] ScoreBoard = GameObject.FindObjectsOfType<GorillaScoreBoard>();
            if (AntireportBlock == null)
            {
                foreach (GorillaScoreBoard boardObject in ScoreBoard)
                {
                    AntireportBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    AntireportBlock.transform.localScale = new Vector3(float.MinValue, float.MinValue, float.MinValue);
                    AntireportBlock.transform.position = boardObject.transform.position;
                    AntireportBlock.transform.rotation = boardObject.transform.rotation;
                    Object.Destroy(AntireportBlock.GetComponent<BoxCollider>());
                }
            }
            foreach (VRRig i in GorillaParent.instance.vrrigs)
            {
                if (i != GorillaTagger.Instance.offlineVRRig && Vector3.Distance(i.transform.position, AntireportBlock.transform.position) < 1.7f)
                {
                    PhotonNetwork.Disconnect();
                    NotifiLib.SendNotification("Somebody attempted to report you, you've been disconnected.");
                }
            }
        }

        public static void GliderPosition(Vector3 position)
        {
            int i = UnityEngine.Random.Range(0, Gliders.Length);
            GameObject.Find(Gliders[i]).GetComponent<GliderHoldable>().transform.position = position;
        }

        public static void GliderGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                pointer.GetComponent<Renderer>().material.color = Color.white;
                pointer.transform.position = hitInfo.point;
                GameObject.Destroy(pointer.GetComponent<BoxCollider>());
                GameObject.Destroy(pointer.GetComponent<Rigidbody>());
                GameObject.Destroy(pointer.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {
                    GameObject.Find("GliderHoldable").transform.position = pointer.transform.position;
                }
            }
            if (pointer != null)
            {
                GameObject.Destroy(pointer, Time.deltaTime);
            }
        }

        public static string[] Gliders = new string[]
        {
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (1)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (4)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (5)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (6)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (7)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (8)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (9)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (10)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (11)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (12)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (17)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (18)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (19)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (20)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (21)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (23)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (24)/GliderHoldable",
        };

        public static void BreakCloudsMap()
        {
            List<GameObject> gameObjects = new List<GameObject>();

            // All the gliders

            gameObjects.Add(GameObject.Find("GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (1)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (4)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (5)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (7)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (8)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (9)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (10)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (11)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (12)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (17)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (19)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (20)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (21)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (23)/GliderHoldable"));
            gameObjects.Add(GameObject.Find("LeafGliderFunctional (24)/GliderHoldable"));

            //end of the gliders
            List<VRRig> vrrigs = new List<VRRig>();
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                vrrigs.Add(rig);
            }
            vrrigs = vrrigs.OrderBy(x => UnityEngine.Random.value).ToList();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                TeleportGameObjectToPlayer(gameObjects[i], vrrigs[i % vrrigs.Count]);
            }
        }
        public static void AcidSelf()
        {
            bool flag = ! Mods.AcidEnabled;
            if (flag)
            {
                Mods.AcidPlayer(PhotonNetwork.LocalPlayer);
                Mods.AcidEnabled = true;
            }
            else
            {
                Mods.RemoveAcidPlayer(PhotonNetwork.LocalPlayer);
                Mods.AcidEnabled = false;
            }
        }

        public static void AcidAll()
        {
            int countOfPlayers = PhotonNetwork.CountOfPlayers;
            bool flag = !Mods.AcidAllEnabled;
            if (flag)
            {
                int num = PhotonNetwork.PlayerList.Length;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(num);
                ScienceExperimentManager.PlayerGameState[] array = new ScienceExperimentManager.PlayerGameState[num];
                for (int i = 0; i < num; i++)
                {
                    ScienceExperimentManager.PlayerGameState playerGameState = default(ScienceExperimentManager.PlayerGameState);
                    playerGameState.touchedLiquid = true;
                    playerGameState.playerId = ((PhotonNetwork.PlayerList[i] == null) ? 0 : PhotonNetwork.PlayerList[i].ActorNumber);
                    array[i] = playerGameState;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(array);
                Mods.AcidAllEnabled = true;
            }
            else
            {
                int num2 = PhotonNetwork.PlayerList.Length;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(num2);
                ScienceExperimentManager.PlayerGameState[] array2 = new ScienceExperimentManager.PlayerGameState[num2];
                for (int j = 0; j < num2; j++)
                {
                    ScienceExperimentManager.PlayerGameState playerGameState2 = default(ScienceExperimentManager.PlayerGameState);
                    playerGameState2.touchedLiquid = false;
                    playerGameState2.playerId = ((PhotonNetwork.PlayerList[j] == null) ? 0 : PhotonNetwork.PlayerList[j].ActorNumber);
                    array2[j] = playerGameState2;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(array2);
                Mods.AcidAllEnabled = false;
            }
        }

        public static bool AcidAllEnabled = false;
        public static bool AcidEnabled = false;

        public static void AcidPlayer(Player player)
        {
            bool inRoom = PhotonNetwork.InRoom;
            if (inRoom)
            {
                int countOfPlayers = PhotonNetwork.CountOfPlayers;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(countOfPlayers);
                ScienceExperimentManager.PlayerGameState[] array = new ScienceExperimentManager.PlayerGameState[countOfPlayers];
                for (int i = 0; i < countOfPlayers; i++)
                {
                    ScienceExperimentManager.PlayerGameState playerGameState = default(ScienceExperimentManager.PlayerGameState);
                    playerGameState.touchedLiquid = true;
                    playerGameState.playerId = ((player != null) ? player.ActorNumber : 0);
                    array[i] = playerGameState;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(array);
            }
        }

        public static void RemoveAcidPlayer(Player player)
        {
            bool inRoom = PhotonNetwork.InRoom;
            if (inRoom)
            {
                int countOfPlayers = PhotonNetwork.CountOfPlayers;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(countOfPlayers);
                ScienceExperimentManager.PlayerGameState[] array = new ScienceExperimentManager.PlayerGameState[countOfPlayers];
                for (int i = 0; i < countOfPlayers; i++)
                {
                    ScienceExperimentManager.PlayerGameState playerGameState = default(ScienceExperimentManager.PlayerGameState);
                    playerGameState.touchedLiquid = false;
                    playerGameState.playerId = ((player != null) ? player.ActorNumber : 0);
                    array[i] = playerGameState;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(array);
            }
        }

        public static void InfectSelf()
        {
            Object.FindObjectOfType<GorillaTagManager>().AddInfectedPlayer(PhotonNetwork.LocalPlayer);
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0000948C File Offset: 0x0000768C
        public static void InfectSpamAll()
        {
            Player randomPlayer =   Mods.GetRandomPlayer(true);
            bool flag = Mods.GetVRRigFromPlayer(randomPlayer).mainSkin.material.name.Contains("fected");
            if (flag)
            {
                Object.FindObjectOfType<GorillaTagManager>().currentInfected.Remove(randomPlayer);
            }
            else
            {
                Object.FindObjectOfType<GorillaTagManager>().AddInfectedPlayer(randomPlayer);
            }
        }

        public static void TagAura()
        {
            float num = 4f;
            VRRig vrrig = null;
            foreach (VRRig vrrig2 in GorillaParent.instance.vrrigs)
            {
                bool flag = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && vrrig2 != GorillaTagger.Instance.offlineVRRig && Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig2.transform.position) < num && !vrrig2.mainSkin.material.name.Contains("fected");
                if (flag)
                {
                    num = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig2.transform.position) * 4f;
                    vrrig = vrrig2;
                }
            }
            GorillaTagger.Instance.leftHandTransform.position = vrrig.transform.position;
            GorillaTagger.Instance.rightHandTransform.position = vrrig.transform.position;
        }

        // Token: 0x0400003D RID: 61
        public static bool AllowedToGhost = true;

        // Token: 0x0400003E RID: 62
        public static bool AllowedToInvis = true;

        // Token: 0x0400003F RID: 63
        public static GameObject gameObject = null;

        // Token: 0x04000040 RID: 64
        public static GameObject checkPoint = null;

        // Token: 0x04000041 RID: 65
        public static bool IsHolding = false;

        // Token: 0x04000042 RID: 66
        public static bool doneDid = false;

        // Token: 0x04000043 RID: 67
        public static VRRig ghostRig = null;

        // Token: 0x04000044 RID: 68
        private static GameObject bug = GameObject.Find("Floating Bug Holdable");

        // Token: 0x04000045 RID: 69
        private static GameObject bat = GameObject.Find("Cave Bat Holdable");

        // Token: 0x04000046 RID: 70
        public static string info = "[<color=yellow>Rift</color>]";

        public static VRRig GetVRRigFromPlayer(Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }

        public static Player GetRandomPlayer(bool includeSelf)
        {
            Player result;
            if (includeSelf)
            {
                result = PhotonNetwork.PlayerList[Random.Range(0, PhotonNetwork.PlayerList.Length - 1)];
            }
            else
            {
                result = PhotonNetwork.PlayerListOthers[Random.Range(0, PhotonNetwork.PlayerListOthers.Length - 1)];
            }
            return result;
        }

        // Token: 0x060000DE RID: 222 RVA: 0x000094E8 File Offset: 0x000076E8
        public static void InfectAll()
        {
            bool flag = PhotonNetwork.InRoom || PhotonNetwork.InLobby;
            if (flag)
            {
                bool isMasterClient = PhotonNetwork.IsMasterClient;
                if (isMasterClient)
                {
                    foreach (Player player in PhotonNetwork.PlayerListOthers)
                    {
                        Object.FindAnyObjectByType<GorillaTagManager>().currentInfected.Add(player);
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        bool flag2 = vrrig != GorillaTagger.Instance.offlineVRRig;
                        if (flag2)
                        {
                            bool flag3 = !vrrig.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected");
                            if (flag3)
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position + new Vector3(0f, 1f, 0f);
                                GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position + new Vector3(0f, 1f, 0f);
                                GorillaTagger.Instance.leftHandTransform.transform.position = vrrig.transform.position;
                                GorillaTagger.Instance.rightHandTransform.transform.position = vrrig.transform.position;
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                            }
                        }
                    }
                }
            }
        }


        private static void TeleportGameObjectToPlayer(GameObject gameObject, VRRig player)
        {
            gameObject.transform.position = player.transform.position;
        }

        public static void ChamsRemastered()
        {
            ifDisabled = false;
            float x = 0f; float y = 0f; float z = 0f; float scale = 1.85f;
            foreach (VRRig Players in GorillaParent.instance.vrrigs)
            {
                if (Players.mainSkin.material.name.Contains("fected"))
                {
                    fected = true;
                }
                else
                {
                    casual = true;
                }

                if (!ifDisabled)
                {
                    if (fected)
                    {
                        x = scale; y = scale; z = scale;

                        Vector3 Position = GorillaTagger.Instance.bodyCollider.transform.position;

                        GameObject bodySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        UnityEngine.Color sphereColor = new Color32(0, 255, 0, 125);
                        UnityEngine.Color lineColor = new Color32(0, 255, 0, 125);
                        UnityEngine.Color lineColor1 = new Color32(0, 255, 0, 125);

                        lineUser.startColor = lineColor; lineUser.endColor = lineColor1;
                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;
                        bodySphere.transform.localScale = new Vector3(x, y, z);

                        lineUser.useWorldSpace = true;

                        bodySphere.transform.position = Players.transform.position;
                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, Position);
                        lineUser.SetPosition(1, bodySphere.transform.position);

                        bodySphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        UnityEngine.Object.Destroy(bodySphere.GetComponent<BoxCollider>());
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<Collider>());
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<Rigidbody>());

                        UnityEngine.Object.Destroy(bodySphere, Time.deltaTime);
                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                    else { x = 0f; y = 0f; z = 0f; }

                    if (casual)
                    {
                        x = scale; y = scale; z = scale;

                        Vector3 Position = GorillaTagger.Instance.bodyCollider.transform.position;

                        GameObject bodySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        UnityEngine.Color sphereColor = new Color32(0, 255, 0, 125);
                        UnityEngine.Color lineColor = new Color32(0, 255, 0, 125);
                        UnityEngine.Color lineColor1 = new Color32(0, 255, 0, 125);

                        lineUser.startColor = lineColor; lineUser.endColor = lineColor1;
                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;
                        bodySphere.transform.localScale = new Vector3(x, y, z);

                        lineUser.useWorldSpace = true;

                        bodySphere.transform.position = Players.transform.position;
                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, Position);
                        lineUser.SetPosition(1, bodySphere.transform.position);

                        bodySphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        UnityEngine.Object.Destroy(bodySphere.GetComponent<BoxCollider>());
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<Collider>());
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<Rigidbody>());

                        UnityEngine.Object.Destroy(bodySphere, Time.deltaTime);
                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                    else { x = 0f; y = 0f; z = 0f; }
                }
                else { Debug.Log("ur cooked ggs.   [RE ENABLE or fix by disabling and undisabling.]"); break; }
            }
        }

        public static void disableChams()
        {
            ifDisabled = true;
            casual = false; fected = false;
        }

        public static void GrabMonkeyPlushCosmetic()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject MonkeyCosmetic = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/Holdables/GTMonkePlushAnchor/LMAJA.");
                MonkeyCosmetic.transform.IsChildOf(GorillaTagger.Instance.transform);
                if (MonkeyCosmetic.transform.IsChildOf(GorillaTagger.Instance.transform))
                {
                    MonkeyCosmetic.SetActive(true);

                    MonkeyCosmetic.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    MonkeyCosmetic.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject MonkeyCosmetic = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/Holdables/GTMonkePlushAnchor/LMAJA.");
                MonkeyCosmetic.transform.IsChildOf(GorillaTagger.Instance.transform);
                if (MonkeyCosmetic.transform.IsChildOf(GorillaTagger.Instance.transform))
                {
                    MonkeyCosmetic.SetActive(true);

                    MonkeyCosmetic.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    MonkeyCosmetic.transform.rotation = Quaternion.Euler(rotation);
                }
            }
        }

        public static void GrabGlider()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("LeafGliderFunctional (1)/GliderHoldable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }

        public static void Change1Theme(bool loading)
        {
            if (!loading)
            {
                fucking1++;
            }
            if (fucking1 == 0)
            {
                //normal
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Black";
                firstcolor = Color.black;
            }
            if (fucking1 == 1)
            {
                //side
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Blue";
                firstcolor = Color.blue;
            }
            if (fucking1 == 2)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Green";
                firstcolor = Color.green;
            }
            if (fucking1 == 3)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: White";
                firstcolor = Color.white;
            }
            if (fucking1 == 4)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Magenta";
                firstcolor = Color.magenta;
            }
            if (fucking1 == 5)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Cyan";
                firstcolor = Color.cyan;
            }
            if (fucking1 == 6)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Gray";
                firstcolor = Color.gray;
            }
            if (fucking1 == 7)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Red";
                firstcolor = Color.red;
            }
            if (fucking1 == 8)
            {
                //back to normal
                fucking1 = 0;
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Black";
                firstcolor = Color.black;
            }
            WristMenu.settingsbuttons[30].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static Color firstcolor = Color.black;
        public static int fucking = 0;
        public static int fucking1 = 0;

        public static void Change2Theme(bool loading)
        {
            if (!loading)
            {
                fucking++;
            }
            if (fucking == 0)
            {
                //normal
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Purple";
                secondcolor = purple;
            }
            if (fucking == 1)
            {
                //side
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Blue";
                secondcolor = Color.blue;
            }
            if (fucking == 2)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Green";
                secondcolor = Color.green;
            }
            if (fucking == 3)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: White";
                secondcolor = Color.white;
            }
            if (fucking == 4)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Magenta";
                secondcolor = Color.magenta;
            }
            if (fucking == 5)
            {
                //Second
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Cyan";
                secondcolor = Color.cyan;
            }
            if (fucking == 6)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Black";
                secondcolor = Color.black;
            }
            if (fucking == 7)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Red";
                secondcolor = Color.red;
            }
            if (fucking == 8)
            {
                //back to normal
                fucking = 0;
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Purple";
                secondcolor = purple;
            }
            WristMenu.settingsbuttons[31].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static Color secondcolor = purple;
        public static Color purple
        {
            get
            {
                return new Color32(114, 0, 143, 255);
            }
        }

        public static int buttonColorInt;

        public static int textColorOnInt;

        public static int textColorOffInt;

        public static void ChangeButtonColor(bool loading)
        {
            if (!loading)
            {
                buttonColorInt++;
            }
            if (buttonColorInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Same As Menu";
                WristMenu.buttonColor = WristMenu.menuColor;
            }
            if (buttonColorInt == 1)
            {
                //side
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Blue";
                WristMenu.buttonColor = Color.blue;
            }
            if (buttonColorInt == 2)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Green";
                WristMenu.buttonColor = Color.green;
            }
            if (buttonColorInt == 3)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: White";
                WristMenu.buttonColor = Color.white;
            }
            if (buttonColorInt == 4)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Magenta";
                WristMenu.buttonColor = Color.magenta;
            }
            if (buttonColorInt == 5)
            {
                //Second
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Cyan";
                WristMenu.buttonColor = Color.cyan;
            }
            if (buttonColorInt == 6)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Gray";
                WristMenu.buttonColor = Color.gray;
            }
            if (buttonColorInt == 7)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Red";
                WristMenu.buttonColor = Color.red;
            }
            if (buttonColorInt == 8)
            {
                //back to normal
                buttonColorInt = 0;
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Same As Menu";
                WristMenu.buttonColor = WristMenu.menuColor;
            }
            WristMenu.settingsbuttons[32].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void lagadmingun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (lockedrig == null)
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        object[] eventContent = new object[3]
                        {
                            "Lag",
                            PhotonNetwork.LocalPlayer,
                            owner
                        };
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
            }
            else
            {
                lockedrig = null;
                GameObject.Destroy(pointer);
            }
        }

        static Player uefh;

        public static void moveadmingun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (uefh != null)
                {
                    if (Time.time > balll2111 + 0.05f && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;
                        object[] eventContent = new object[4]
                        {
                                "Move",
                                PhotonNetwork.LocalPlayer,
                                uefh,
                                pointer.transform.position
                        };
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (lockedrig == null)
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        uefh = owner;
                    }
                }
            }
            else
            {
                lockedrig = null;
                uefh = null;
                GameObject.Destroy(pointer);
            }
        }

        public static void kickadmingun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (lockedrig == null)
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        object[] eventContent = new object[3]
                        {
                            "kick",
                            PhotonNetwork.LocalPlayer,
                            owner
                        };
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
            }
            else
            {
                lockedrig = null;
                GameObject.Destroy(pointer);
            }
        }

        public static GameObject penis;
        public static object obj;

        public static void addFavButton(ButtonInfo info)
        {
            if (info != null && !WristMenu.favoritebuttons.Contains(info))
            {
                WristMenu.favoritebuttons.Add(info);
                saveFavs(info);
                NotifiLib.SendNotification("<color=yellow>[FAV MODS]</color> Added " + info.buttonText + " To Favorite Mods");

            }
        }

        public static void saveFavs(ButtonInfo infoo)
        {
            names.Clear();
            if (System.IO.File.Exists("GoldPrefs\\goldSavedFavorites.txt"))
            {
                foreach (string s in System.IO.File.ReadAllLines("GoldPrefs\\goldSavedFavorites.txt"))
                {
                    names.Add(s);
                }
            }
            names.Add(infoo.buttonText);
            System.IO.Directory.CreateDirectory("GoldPrefs");
            System.IO.File.WriteAllLines("GoldPrefs\\goldSavedFavorites.txt", names);
        }

        static List<string> names = new List<string>();


        public static float AntibanJoinDelay;
        public static bool AntibanBool;
        public static bool AntibanNotifBool;
        public static float AntibanDelay;
        public static bool AntibanDoneBool;
        public static bool jikoisBLACK;
        public static bool AutoMasterBool;
        public static string LastJoinedRoom;
        public static float HopFloat;
        public static bool isJoiningRandom;
        public static string RejoinRoomCode;

        public static float NameDelay;

        public static float SettingNameDelay;

        public static string NameChangerString = null;

        public static void NameChangeAll()
        {
            if (NameChangerString == null)
            {
                if (SettingNameDelay < Time.time)
                {
                    SettingNameDelay = Time.time + 5f;
                    NotifiLib.SendNotification("<color=blue>[NAME CHANGER]</color> Assign the thing to change their names to on the gui!");
                    return;
                }
            }
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban!");
                return;
            }
            if (NameDelay < Time.time)
            {
                NameDelay = Time.time + 0.05f;
                foreach (Player p in PhotonNetwork.PlayerList)
                {
                    Hashtable hashtable = new Hashtable();
                    hashtable[byte.MaxValue] = NameChangerString;
                    Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
                    dictionary.Add(251, hashtable);
                    dictionary.Add(254, p.ActorNumber);
                    dictionary.Add(250, true);
                    PhotonNetwork.CurrentRoom.LoadBalancingClient.LoadBalancingPeer.SendOperation(252, dictionary, SendOptions.SendUnreliable);
                }
            }
        }

        public static void AutoSetMaster()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                if (!AutoMasterBool)
                {
                    PhotonNetwork.CurrentRoom.SetMasterClient(PhotonNetwork.LocalPlayer);
                    NotifiLib.SendNotification("<color=red>[SET MASTER]</color> Set Master enabled!");
                    AutoMasterBool = true;
                }
            }
        }

        public static void ChangeMatAfterGhost()
        {
            string gamemode = "INFECTION";
            var infgamemode = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
            var huntgamemode = GameObject.Find("GT Systems/GameModeSystem/Gorilla Hunt Manager").GetComponent<GorillaHuntManager>();
            PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("gameMode", out obj);
            if (obj.ToString().Contains("INFECTION"))
            {
                gamemode = "INFECTION";
            }
            if (obj.ToString().Contains("HUNT"))
            {
                gamemode = "HUNT";
            }
            if (obj.ToString().Contains("CASUAL"))
            {
                gamemode = "CASUAL";
            }
            if (gamemode == "INFECTION")
            {
                if (infgamemode.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(2);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(0);
                }
            }
            if (gamemode == "HUNT")
            {
                if (huntgamemode.currentHunted.Contains(PhotonNetwork.LocalPlayer))
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(3);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(0);
                }
            }
            if (gamemode == "CASUAL")
            {
                GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(0);
            }
        }

        public static RaycastHit raycastHit;
        static float fillAmount;
        public static VRRig lockedrig;
        static GorillaRopeSwing lockdedrope;
        static bool gunLock;
        public static void GunLock()
        {
            gunLock = true;
        }

        public static void ChangeOnTextColor(bool loading)
        {
            if (!loading)
            {
                textColorOnInt++;
            }
            if (textColorOnInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: White";
                WristMenu.menuOnTextColor = Color.white;
            }
            if (textColorOnInt == 1)
            {
                //side
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Blue";
                WristMenu.menuOnTextColor = Color.blue;
            }
            if (textColorOnInt == 2)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Green";
                WristMenu.menuOnTextColor = Color.green;
            }
            if (textColorOnInt == 3)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Purple";
                WristMenu.menuOnTextColor = purple;
            }
            if (textColorOnInt == 4)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Magenta";
                WristMenu.menuOnTextColor = Color.magenta;
            }
            if (textColorOnInt == 5)
            {
                //Second
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Cyan";
                WristMenu.menuOnTextColor = Color.cyan;
            }
            if (textColorOnInt == 6)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Gray";
                WristMenu.menuOnTextColor = Color.gray;
            }
            if (textColorOnInt == 7)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Red";
                WristMenu.menuOnTextColor = Color.red;
            }
            if (textColorOnInt == 8)
            {
                //back to normal
                textColorOnInt = 0;
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: White";
                WristMenu.menuOnTextColor = Color.white;
            }
            WristMenu.settingsbuttons[33].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static bool lefthandd;

        public static void lefthand()
        {
            lefthandd = true;
        }

        public static void offlefthand()
        {
            lefthandd = false;
        }

        public static bool inFavorite = false;

        public static string[] favoriteButtons;

        static bool favBool;

        public static void FavoriteMods()
        {
            if (File.Exists("GoldPrefs\\goldSavedFavorites.txt") && !favBool)
            {
                foreach (string name in System.IO.File.ReadAllLines("GoldPrefs\\goldSavedFavorites.txt"))
                {
                    WristMenu.favoritebuttons.Add(GetButton(name));
                    WristMenu.favoritebuttons.Add(GetButtonOP(name));
                }
                favBool = true;
            }
            GetButton("Favorite Mod").enabled = false;
            WristMenu.favoritebuttons[0].enabled = false;
            inFavorite = !inFavorite;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static bool RGB;

        public static void RGBMenu()
        {
            RGB = true;
        }

        public static int rattatuoie = 0;
        public static bool epic;
        static bool wieufhwf;

        public static void DetectAdminsPanelFeatures(EventData eventData)
        {
            if (eventData.Code == 70)
            {
                object[] array2 = (object[])eventData.CustomData;
                if ((string)array2[0] == "kick" && (Player)array2[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array2[1]))
                {
                    PhotonNetwork.Disconnect();
                }
                if ((string)array2[0] == "Lag" && (Player)array2[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array2[1]))
                {
                    Thread.Sleep(500);
                }
                if ((string)array2[0] == "Move" && (Player)array2[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array2[1]))
                {
                    GorillaLocomotion.Player.Instance.transform.position = (Vector3)array2[3];
                }
            }
        }

        public static bool toggleon = false;

        static bool toggletoggletoggle;

        public static void ChangeLayout()
        {
            System.IO.Directory.CreateDirectory("GoldPrefs");
            rattatuoie++;
            if (rattatuoie == 0)
            {
                //normal
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "shibagt");
            }
            if (rattatuoie == 1)
            {
                //side
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Side";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "side");
            }
            if (rattatuoie == 2)
            {
                //crsh
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Triggers";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "triggers");
            }
            if (rattatuoie == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Bottom";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "bottom");
            }
            if (rattatuoie == 4)
            {
                //back to normal
                rattatuoie = 0;
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "shibagt");
            }
            WristMenu.settingsbuttons[4].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static BetterDayNightManager.WeatherType ww;
        public static void ChangeTime(bool loading)
        {
            if (!loading)
            {
                fucking2++;
            }
            if (fucking2 == 0)
            {
                //normal
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Untouched";
            }
            if (fucking2 == 1)
            {
                //normal
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Day";
                BetterDayNightManager.instance.SetTimeOfDay(1);
            }
            if (fucking2 == 2)
            {
                //side
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Dawn";
                BetterDayNightManager.instance.SetTimeOfDay(6);
            }
            if (fucking2 == 3)
            {
                //crsh
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Night";
                BetterDayNightManager.instance.SetTimeOfDay(0);
            }
            if (fucking2 == 4)
            {
                //back to normal
                fucking2 = 0;
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Untouched";
            }
            WristMenu.settingsbuttons[11].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void offleaves()
        {
            if (!erihu)
            {
                erihu = true;
                foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
                {
                    if (g.activeSelf && g.name.Contains("smallleaves"))
                    {
                        g.SetActive(false);
                        leaves.Add(g);
                    }
                }
            }
        }

        public static void sticky()
        {
            stickyplatforms = true;
        }

        public static void offsticky()
        {
            stickyplatforms = false;
        }

        public static bool triggerplat = false;
        public static bool toggleplat = false;

        public static int platformstype = 0;

        public static void ChangePlatforms(bool loading)
        {
            if (!loading)
            {
                platformstype++;
            }
            if (platformstype == 0)
            {
                //normal
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal";
                invisplat = false;
            }
            if (platformstype == 1)
            {
                //side
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Invis";
                invisplat = true;
            }
            if (platformstype == 2)
            {
                //crsh
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Trigger Normal";
                triggerplat = true;
                invisplat = false;
            }
            if (platformstype == 3)
            {
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Trigger Invis";
                triggerplat = true;
                invisplat = true;
            }
            if (platformstype == 4)
            {
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal Trigger Toggle";
                invisplat = false;
                triggerplat = false;
                toggleplat = true;
            }
            if (platformstype == 5)
            {
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Invis Trigger Toggle";
                invisplat = true;
                triggerplat = false;
                toggleplat = true;
            }
            if (platformstype == 6)
            {
                platformstype = 0;
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal";
                invisplat = false;
                triggerplat = false;
                toggleplat = false;
            }
            WristMenu.settingsbuttons[14].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static bool NetworkTrigDisableBool;

        public static void setmaster()
        {
            if (PhotonNetwork.CurrentRoom != null && !PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("forestmountainscavescitycloudscanyonsbeachbasementCOMPETITIVEINFECTION"))
            {
                if (NetworkTrigDisableBool)
                {
                    string value = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Replace(GorillaComputer.instance.currentQueue, "forestmountainscavescitycloudscanyonsbeachbasementCOMPETITIVEINFECTION");
                    Hashtable propertiesToSet = new Hashtable
                                {
                                    {
                                        "gameMode",
                                        value
                                    }
                                };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(propertiesToSet, null, null);
                    NetworkTrigDisableBool = false;
                }
                Debug.Log("starting");
                PlayFabClientAPI.ExecuteCloudScript(new PlayFab.ClientModels.ExecuteCloudScriptRequest
                {
                    FunctionName = "RoomClosed",
                    FunctionParameter = new
                    {
                        GameId = PhotonNetwork.CurrentRoom.Name,
                        Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                        UserId = -1,
                        ActorNr = -1,
                        ActorCount = PhotonNetwork.ViewCount + 1,
                        AppVersion = PhotonNetwork.AppVersion
                    },
                }, result =>
                {
                    NetworkTrigDisableBool = true;
                }, null);
            }
            foreach (ButtonInfo b in WristMenu.buttons)
            {
                if (b.buttonText.Contains("Disable Network Triggers SS!"))
                {
                    b.enabled = false;
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        public static void offoffleaves()
        {
            if (erihu)
            {
                erihu = false;
                foreach (GameObject l in leaves)
                {
                    l.SetActive(true);
                }
                leaves.Clear();
            }
        }

        public static void UNGodModLock()
        {
            gunLock = false;
        }

        public static bool notifs = true;

        public static void OnNotifs()
        {
            notifs = true;
        }

        public static void OffNotifs()
        {
            notifs = false;
        }

        public static void OffRGBMenu()
        {
            RGB = false;
        }

        public static float balll2111;

        public static float balll435342111;

        public static float balll21191;

        static float balll21111;

        static float balll2;

        static float balll3;

        public static bool inPlayers = false;

        public static void OPMods()
        {
            GetButton("OP Mods").enabled = false;
            GetButtonOP("OP Mods").enabled = false;
            inPlayers = !inPlayers;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw(); ;
        }

        public static ButtonInfo GetButton(string name)
        {
            foreach (ButtonInfo buttons in WristMenu.buttons)
            {
                if (buttons.buttonText.Contains(name))
                {
                    return buttons;
                }
                if (buttons.buttonText == name)
                {
                    return buttons;
                }
            }
            return null;
        }

        public static ButtonInfo GetButtonOP(string name)
        {
            foreach (ButtonInfo buttons in WristMenu.opbuttons)
            {
                if (buttons.buttonText.Contains(name))
                {
                    return buttons;
                }
                if (buttons.buttonText == name)
                {
                    return buttons;
                }
            }
            return null;
        }


        public static Font gtagfont = Resources.GetBuiltinResource<Font>("Arial.ttf");

        public static void ChangeOffTextColor(bool loading)
        {
            if (!loading)
            {
                textColorOffInt++;
            }
            if (textColorOffInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Magenta";
                WristMenu.menuOffTextColor = Color.magenta;
            }
            if (textColorOffInt == 1)
            {
                //side
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Blue";
                WristMenu.menuOffTextColor = Color.blue;
            }
            if (textColorOffInt == 2)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Green";
                WristMenu.menuOffTextColor = Color.green;
            }
            if (textColorOffInt == 3)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Purple";
                WristMenu.menuOffTextColor = purple;
            }
            if (textColorOffInt == 4)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: White";
                WristMenu.menuOffTextColor = Color.white;
            }
            if (textColorOffInt == 5)
            {
                //Second
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Cyan";
                WristMenu.menuOffTextColor = Color.cyan;
            }
            if (textColorOffInt == 6)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Gray";
                WristMenu.menuOffTextColor = Color.gray;
            }
            if (textColorOffInt == 7)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Red";
                WristMenu.menuOffTextColor = Color.red;
            }
            if (textColorOffInt == 8)
            {
                //back to normal
                textColorOffInt = 0;
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Magenta";
                WristMenu.menuOffTextColor = Color.magenta;
            }
            WristMenu.settingsbuttons[34].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void ConfiguribleSpeedBoost()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = Boost_Count;
            GorillaLocomotion.Player.Instance.jumpMultiplier = Boost_Count;
            if (Boost_Count < 1)
            {
                Boost_RESET();
                NotifiLib.SendNotification("<color=yellow> ERROR </color> <color=cyan> Cannot Set Speed Multiplier Lower Than 1 </color>");
            }
            else
            {
                if (Boost_Count > 14)
                {
                    Boost_RESET();
                    NotifiLib.SendNotification("<color=yellow> ERROR </color> <color=cyan> Speed Multiplier Over 14 Will Become Detected. </color>");
                }
            }
            if (WristMenu.abuttonDown)
            {
                Boost_Count++;
                NotifiLib.SendNotification("<color=yellow> INFO </color> <color=cyan> Speed Boost Multiplier Set To [ </color>" + Boost_Count + "<color=cyan> ] </color>");
            }
            else
            {
                if (WristMenu.xbuttonDown)
                {
                    Boost_Count--;
                    NotifiLib.SendNotification("<color=yellow> INFO </color> <color=cyan> Speed Boost Multiplier Set To [ </color>" + Boost_Count + "<color=cyan> ] </color>");
                }
                else
                {
                    if (WristMenu.bbuttonDown)
                    {
                        NotifiLib.ClearAllNotifications();
                    }
                }
            }
        }
        public static int Boost_Count = 8;
        public static void Boost_RESET()
        {
            Boost_Count = 8;
        }

        public static void TimeControl()
        {
            BetterDayNightManager.instance.SetTimeOfDay(TimeToSet);
            if (WristMenu.abuttonDown)
            {
                TimeToSet = 3;
                NotifiLib.SendNotification("<color=yellow> INFO </color> <color=cyan> Time Set To [ Day ]</color>");
            }
            else
            {
                if (WristMenu.bbuttonDown)
                {
                    TimeToSet = 0;
                    NotifiLib.SendNotification("<color=yellow> INFO </color> <color=cyan> Time To Set [ Night ]</color>");
                }
                else
                {
                    if (WristMenu.xbuttonDown)
                    {
                        TimeToSet = 1;
                        NotifiLib.SendNotification("<color=yellow> INFO </color> <color=cyan> Time To Change To [ Sunrise ]</color>");
                    }
                }
            }
        }
        public static int TimeToSet;

        public static void Frozone()
        {
            if (WristMenu.gripDownL)
            {
                GameObject lol = GameObject.CreatePrimitive(PrimitiveType.Cube);
                lol.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                lol.transform.localPosition = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.05f, 0f);
                lol.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;

                lol.AddComponent<GorillaSurfaceOverride>().overrideIndex = 61;
                UnityEngine.Object.Destroy(lol, 1);
            }

            if (WristMenu.gripDownR)
            {
                GameObject lol = GameObject.CreatePrimitive(PrimitiveType.Cube);
                lol.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                lol.transform.localPosition = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.05f, 0f);
                lol.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;

                lol.AddComponent<GorillaSurfaceOverride>().overrideIndex = 61;
                UnityEngine.Object.Destroy(lol, 1);
            }
        }

        public static void FlickTag()
        {
            if (ControllerInputPoller.instance.rightGrab == true)
            {

                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                pointer.transform.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                pointer.transform.position = hitInfo.point;
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.6f)
                {
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = hitInfo.point;
                }
            }
        }

        public static void SnakeChams()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        if (FullPlayers.mainSkin.material.name.Contains("fected"))
                        {
                            GameObject ThePointer1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            ThePointer1.transform.localScale = new Vector3(0.085f, 0.085f, 0.085f);
                            ThePointer1.transform.position = FullPlayers.transform.position;
                            ThePointer1.transform.rotation = FullPlayers.transform.rotation;
                            Shader ESPShader = Shader.Find("GUI/Text Shader");
                            ThePointer1.GetComponent<Renderer>().material.shader = ESPShader;
                            ThePointer1.GetComponent<Renderer>().material.color = Color.red;
                            UnityEngine.Object.Destroy(ThePointer1, 0.175f);
                            UnityEngine.Object.Destroy(ThePointer1.GetComponent<BoxCollider>());
                            UnityEngine.Object.Destroy(ThePointer1.GetComponent<Rigidbody>());
                        }
                        else
                        {
                            GameObject ThePointer1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            ThePointer1.transform.localScale = new Vector3(0.085f, 0.085f, 0.085f);
                            ThePointer1.transform.position = FullPlayers.transform.position;
                            ThePointer1.transform.rotation = FullPlayers.transform.rotation;
                            Shader ESPShader = Shader.Find("GUI/Text Shader");
                            ThePointer1.GetComponent<Renderer>().material.shader = ESPShader;
                            ThePointer1.GetComponent<Renderer>().material.color = FullPlayers.mainSkin.material.color;
                            UnityEngine.Object.Destroy(ThePointer1, 0.175f);
                            UnityEngine.Object.Destroy(ThePointer1.GetComponent<BoxCollider>());
                            UnityEngine.Object.Destroy(ThePointer1.GetComponent<Rigidbody>());
                        }
                    }
                }
            }
        }

        public static void QuitGame() 
        {
        UnityEngine.Application.Quit();
        }

        static int fucking2;
        static Color projcolor = Color.black;
        static bool erihu = false;
        static int colorproj;
        static int guntype;
        static List<GameObject> leaves = new List<GameObject>();
        public static bool crashtp = true;
        public static bool cycle = false;

        public static GameObject pointer;
        public static void fpc()
        {
            fpcc = true;
            if (GameObject.Find("Third Person Camera") != null)
            {
                funn = GameObject.Find("Third Person Camera");
                funn.SetActive(false);
            }
            if (GameObject.Find("CameraTablet(Clone)") != null)
            {
                funn = GameObject.Find("CameraTablet(Clone)");
                funn.SetActive(false);
            }
        }

        public static void fpcoff()
        {
            fpcc = false;
            if (funn != null)
            {
                funn.SetActive(true);
                funn = null;
            }
        }
        
        public static void Save()
        {
            WristMenu.settingsbuttons[1].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
            List<String> list = new List<String>();
            foreach (ButtonInfo info in WristMenu.settingsbuttons)
            {
                if (info.enabled == true)
                {
                    list.Add(info.buttonText);
                }
            }
            System.IO.Directory.CreateDirectory("TemplatePrefs");
            System.IO.File.WriteAllLines("TemplatePrefs\\templateSavedPrefs.txt", list);
        }

        public static void Load()
        {
            String[] thing = System.IO.File.ReadAllLines("TemplatePrefs\\templateSavedPrefs.txt");
            foreach (String thing2 in thing)
            {
                foreach (ButtonInfo b in WristMenu.settingsbuttons)
                {
                    if (b.buttonText == thing2)
                    {
                        b.enabled = true;
                    }
                }
            }
        }

        private static void PlatformsThing(bool invis, bool sticky)
        {
            colorKeysPlatformMonke[0].color = Color.red;
            colorKeysPlatformMonke[0].time = 0f;
            colorKeysPlatformMonke[1].color = Color.green;
            colorKeysPlatformMonke[1].time = 0.3f;
            colorKeysPlatformMonke[2].color = Color.blue;
            colorKeysPlatformMonke[2].time = 0.6f;
            colorKeysPlatformMonke[3].color = Color.red;
            colorKeysPlatformMonke[3].time = 1f;
            bool inputr;
            bool inputl;
                inputr = WristMenu.gripDownR;
                inputl = WristMenu.gripDownL;
            if (inputr)
            {
                if (!once_right && jump_right_local == null)
                {
                    if (sticky)
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_right_local.GetComponent<Renderer>());
                    }
                    jump_right_local.transform.localScale = scale;
                    jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    object[] eventContent = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                    GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    once_right = true;
                    once_right_false = false;
                    ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorKeysPlatformMonke;
                    colorChanger.colors = gradient;
                    colorChanger.Start();
                }
            }
            else if (!once_right_false && jump_right_local != null)
            {
                UnityEngine.Object.Destroy(jump_right_local);
                jump_right_local = null;
                once_right = false;
                once_right_false = true;
                RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
            }
            if (inputl)
            {
                if (!once_left && jump_left_local == null)
                {
                    if (sticky)
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_left_local.GetComponent<Renderer>());
                    }
                    jump_left_local.transform.localScale = scale;
                    jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    object[] eventContent2 = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                    GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                    once_left = true;
                    once_left_false = false;
                    ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                    Gradient gradient2 = new Gradient();
                    gradient2.colorKeys = colorKeysPlatformMonke;
                    colorChanger2.colors = gradient2;
                    colorChanger2.Start();
                }
            }
            else if (!once_left_false && jump_left_local != null)
            {
                UnityEngine.Object.Destroy(jump_left_local);
                jump_left_local = null;
                once_left = false;
                once_left_false = true;
                RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
            }
            if (!PhotonNetwork.InRoom)
            {
                for (int i = 0; i < jump_right_network.Length; i++)
                {
                    UnityEngine.Object.Destroy(jump_right_network[i]);
                }
                for (int j = 0; j < jump_left_network.Length; j++)
                {
                    UnityEngine.Object.Destroy(jump_left_network[j]);
                }
            }
        }

        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

        private static bool once_left;

        private static bool once_right;

        private static bool once_left_false;

        private static bool once_right_false;

        private static bool once_networking;

        private static GameObject[] jump_left_network = new GameObject[9999];

        private static GameObject[] jump_right_network = new GameObject[9999];

        private static GameObject jump_left_local = null;

        private static GameObject jump_right_local = null;

        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

        private static Vector3? checkpointPos;

        public static bool rightHanded = false;

    }
}
