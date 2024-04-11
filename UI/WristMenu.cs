using ShibaGTTemplate.Utilities;
using Photon.Pun;
using Photon.Realtime;
using ShibaGTTemplate.Backend;
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

//Template is based off mango
namespace ShibaGTTemplate.UI
{
    public class ButtonInfo
    {
        public string buttonText = "Error";
        public Action method = null;
        public Action disableMethod = null;
        public bool? enabled = false;
        public string toolTip = "This button doesn't have a tooltip/tutorial";
    }

    internal class WristMenu : MonoBehaviour
    {

        public static PhotonView rig2view(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }

        //settings
        public static List<ButtonInfo> settingsbuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go back!"},
            new ButtonInfo { buttonText = "Save Preferences", method =() => Mods.Save(), enabled = false, toolTip = "Save your settings!"},
            new ButtonInfo { buttonText = "First Person Camera", method =() => Mods.fpc(), disableMethod =() => Mods.fpcoff(), enabled = false, toolTip = "First person camera!"},
            new ButtonInfo { buttonText = "RightHand", method =() => Mods.RightHand(), disableMethod =() => Mods.LeftHand(), enabled = false, toolTip = "Right hand!"},
        };
        //norma

        public static List<ButtonInfo> buttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go to settings!"},
            new ButtonInfo { buttonText = "Platforms", method =() => Mods.Platforms(), enabled = false, toolTip = "Platforms!"},
            new ButtonInfo { buttonText = "Invis Platforms", method =() => Mods.InvisPlatforms(), enabled = false, toolTip = "Invisable Platforms!"},
            new ButtonInfo { buttonText = "Sticky Platforms", method =() => Mods.StickyPlatforms(), enabled = false, toolTip = "Sticky Platforms!"},
            new ButtonInfo { buttonText = "GhostMonke", method =() => Mods.Ghost(), enabled = false, toolTip = "Your rig stays in one place (you have to click the leter a)!" },
            new ButtonInfo { buttonText = "InvisMonke", method =() => Mods.Invisible(), enabled = false, toolTip = "Invis!"},
            new ButtonInfo { buttonText = "AntiReport", method =() => Mods.AntiReport(), enabled = false, toolTip = "NO NO REPORT!"},
            new ButtonInfo { buttonText = "Stick (NW)", method =() => Mods.AttempsToActivateAndUseStick(), enabled = false, toolTip = "Gives Stick!"},
            new ButtonInfo { buttonText = "Finger Painter (NW)", method =() => Mods.AttempsToActivateAndUseFingerPainter(), enabled = false, toolTip = "Finger Painter Badge!"},
            new ButtonInfo { buttonText = "Monke Plush Cosmetic", method =() => Mods.GrabMonkeyPlushCosmetic(), enabled = false, toolTip = "Plush!"},
            new ButtonInfo { buttonText = "Animal Ownership", method =() => Mods.AnimalOwnership(), enabled = false, toolTip = "Own Animals!"},
            new ButtonInfo { buttonText = "Grab Bug", method =() => Mods.Grabbug(), enabled = false, toolTip = "Makes you grab dug!"},
            new ButtonInfo { buttonText = "BugGun", method =() => Mods.BugGun(), enabled = false, toolTip = "Bug Gun!"},
            new ButtonInfo { buttonText = "Grab Bat", method =() => Mods.Grabbat(), enabled = false, toolTip = "Grab Matt!"},
            new ButtonInfo { buttonText = "BatGun", method =() => Mods.BatGun(), enabled = false, toolTip = "Bat Gun!"},
            new ButtonInfo { buttonText = "GliderGun", method =() => Mods.GliderGun(), enabled = false, toolTip = "Glider Pistol!"},
            new ButtonInfo { buttonText = "GliderRandom", method =() => Mods.BreakCloudsMap(), enabled = false, toolTip = "OMG GLIDERS!"},
            new ButtonInfo { buttonText = "KickGun", method =() => Mods.KickGunNOTSTUMP(), enabled = false, toolTip = "Kicks people from the lobby if you use it corectly!"},
            new ButtonInfo { buttonText = "Fly", method =() => Mods.Fly(), enabled = false, toolTip = "Fly with B on controler!"},
            new ButtonInfo { buttonText = "Fast Fly", method =() => Mods.FastFly(), enabled = false, toolTip = "Fly with B on controler!"},
            new ButtonInfo { buttonText = "Slow Fly", method =() => Mods.SlothFly(), enabled = false, toolTip = "Fly with B on controler!"},
            new ButtonInfo { buttonText = "NoClip Fly", method =() => Mods.FlyNoclip(), enabled = false, toolTip = "Fly with B on controler!"},
            new ButtonInfo { buttonText = "TpGun", method =() => Mods.GoodTPGUN(), enabled = false, toolTip = "Tp Gun!"},
            new ButtonInfo { buttonText = "JoinCode 4949", method =() => Mods.JoinCodeBotByJaxFixed(), enabled = false, toolTip = "Join My YT Code!"},
            new ButtonInfo { buttonText = "AcidSelf", method =() => Mods.AcidSelf(), enabled = false, toolTip = "Acid :)!"},
            new ButtonInfo { buttonText = "AcidAll", method =() => Mods.AcidAll (), enabled = false, toolTip = "OMG!"},
            new ButtonInfo { buttonText = "TagSelf", method =() => Mods.InfectSelf(), enabled = false, toolTip = "Tag OMG!"},
            new ButtonInfo { buttonText = "TagAura", method =() => Mods.TagAura(), enabled = false, toolTip = "Aura Tag!"},
            new ButtonInfo { buttonText = "TagAll", method =() => Mods.InfectAll(), enabled = false, toolTip = "ALL tag!"},
            new ButtonInfo { buttonText = "TagSpam", method =() => Mods.InfectSpamAll(), enabled = false, toolTip = "ALL!"},
            new ButtonInfo { buttonText = "StickLongArms", method =() => Mods.StickLongArms(), enabled = false, toolTip = "Long Arms But Stick!"},
            new ButtonInfo { buttonText = "Instant Hand Taps", method =() => Mods.EnableInstantHandTaps(), disableMethod =() => Mods.DisableInstantHandTaps(), toolTip = "Removes the hand tap cooldown."},
            new ButtonInfo { buttonText = "Silent Hand Taps", method =() => Mods.SilentHandTaps(), disableMethod =() => Mods.FixHandTaps(), toolTip = "Makes your hand taps really quiet."},
            new ButtonInfo { buttonText = "Loud Hand Taps", method =() => Mods.LoudHandTaps(), disableMethod =() => Mods.FixHandTaps(), toolTip = "Makes your hand taps really loud."},
            new ButtonInfo { buttonText = "Spin Head X", method =() => Mods.SpinHeadX(), disableMethod =() => Mods.FixHead(), toolTip = "Spins your head on the X axis."},
            new ButtonInfo { buttonText = "Spin Head Y", method =() => Mods.SpinHeadY(), disableMethod =() => Mods.FixHead(), toolTip = "Spins your head on the Y axis."},
            new ButtonInfo { buttonText = "Spin Head Z", method =() => Mods.SpinHeadZ(), disableMethod =() => Mods.FixHead(), toolTip = "Spins your head on the Z axis."},
            new ButtonInfo { buttonText = "Flip Hands", method =() => Mods.FlipHands(), toolTip = "Swaps your hands, left is right and right is left."},
            new ButtonInfo { buttonText = "Time Controler", method =() => Mods.TimeControl(), enabled = false, toolTip = "Control time!"},
            new ButtonInfo { buttonText = "FPS Boost", method =() => Mods.EnableFPSBoost(), disableMethod =() => Mods.DisableFPSBoost(), toolTip = "Makes everything low quality in an attempt to boost your FPS."},
            new ButtonInfo { buttonText = "InfShinyRocks", method =() => Mods.ShinyRocks(), toolTip = "Inf Shiny Rocks"},
            new ButtonInfo { buttonText = "Chams", method =() => Mods.ChamsRemastered(), enabled = false, toolTip = "Chams a diffrent ESP!"},
            new ButtonInfo { buttonText = "ChamsOff", method =() => Mods.disableChams(), enabled = false, toolTip = "Chams a diffrent ESP!"},
            new ButtonInfo { buttonText = "Config Speed Boost", method =() => Mods.ConfiguribleSpeedBoost(), enabled = false, toolTip = "Configurable speed boost!"},
            new ButtonInfo { buttonText = "IronMonke", method =() => Mods.IronMonke(), enabled = false, toolTip = "IronMonke!"},
            new ButtonInfo { buttonText = "Frozone", method =() => Mods.Frozone(), enabled = false, toolTip = "Frozone!"},
            new ButtonInfo { buttonText = "FlickTag", method =() => Mods.FlickTag(), enabled = false, toolTip = "FlickTag!"},
            new ButtonInfo { buttonText = "SnakeChams", method =() => Mods.SnakeChams(), enabled = false, toolTip = "SnakeChams!"},
            new ButtonInfo { buttonText = "Nuke", method =() => Mods.QuitGame(), enabled = false, toolTip = "Tricked You LOL"},


            //thats how u make a button basically
        };




        //making menu settings

        public static bool ChangingColors = true;
        public static Color FirstColor = Color.black;
        public static Color SecondColor = Color.red;

        //if no changing colors:

        public static Color NormalColor = Color.black;

        //button settings

        public static Color ButtonColorDisable = Color.magenta;
        public static Color ButtonColorEnabled = Color.red;
        public static Color ButtonTextColor = Color.white;

        //more menu settings

        public static string MenuTitle = "Nightmare Gold Lite";


        //fuck ton of vars holy shit
        private static int lastPressedButtonIndex = -1;
        public static GameObject menu = null;
        private static GameObject canvasObj = null;
        private static GameObject reference = null;
        private static int pageSize = 4;
        private static int pageNumber = 0;
        public static bool gripDownR;
        public static bool triggerDownR;
        public static bool abuttonDown;
        public static bool bbuttonDown;
        public static bool xbuttonDown;
        public static bool ybuttonDown;
        public static bool gripDownL;
        public static bool triggerDownL;
        public static bool joystickR;
        public static bool joystickL;
        public static Vector2 joystickaxisR;
        public static WristMenu instance = new WristMenu();
        public static GameObject menuObj;
        public static Color colorToFade1 = Color.black;
        public static int selectedButton = 1;
        public static Color colorToFade2 = Color.magenta;
        private static Text tooltipText;
        private static string tooltipString;
        public static bool toggle = false;
        public static bool toggle1 = false;
        public static bool toggle2 = false;
        public static bool toggle3 = false;
        public static bool toggle4 = false;
        public static List<Photon.Realtime.Player> adminList = new List<Photon.Realtime.Player>();
        public static string url = "https://pastebin.com/raw/w8BAXrqj";
        public static bool hasPanel = false;

        public static string CheckSelectedButton()
        {
            string[] buttonss = buttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] settingsbuttonss = settingsbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            if (selectedButton == 1)
            {
                return buttonss[1];
            }
            if (selectedButton == 2)
            {
                return buttonss[2];
            }
            if (selectedButton == 3)
            {
                return buttonss[3];
            }
            if (selectedButton == 4)
            {
                return buttonss[4];
            }
            if (selectedButton == 5)
            {
                return buttonss[5];
            }
            if (selectedButton == 6)
            {
                return buttonss[6];
            }
            return null;
        }

        static bool fun = false;

        void Update()
        {
            try
            {
                gripDownL = ControllerInputPoller.instance.leftGrab;
                gripDownR = ControllerInputPoller.instance.rightGrab;
                triggerDownL = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
                triggerDownR = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
                abuttonDown = ControllerInputPoller.instance.rightControllerPrimaryButton;
                bbuttonDown = ControllerInputPoller.instance.rightControllerSecondaryButton;
                xbuttonDown = ControllerInputPoller.instance.leftControllerPrimaryButton;
                ybuttonDown = ControllerInputPoller.instance.leftControllerSecondaryButton;
                joystickaxisR = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
                if (ybuttonDown)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else
                    {
                        menu.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                        menu.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                        if (reference == null)
                        {
                            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            reference.name = "buttonPresser";
                        }
                        reference.transform.parent = GorillaLocomotion.Player.Instance.rightControllerTransform;
                        reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * GorillaLocomotion.Player.Instance.scale;
                        reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * GorillaLocomotion.Player.Instance.scale;
                    }
                }
                else if (ybuttonDown == false && menu != null)
                {
                    DestroyMenu();
                    Object.Destroy(reference);
                    reference = null;
                    menu = null;
                }

                //button clicking thingys


                foreach (ButtonInfo buttonInfo in settingsbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in buttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
            }
            catch { }
        }

        bool sentbefore = false;

        private static string GetButtonTooltip(int index)
        {
            if (Mods.inSettings)
            {
                ButtonInfo buttonInfo = settingsbuttons[index];
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
            else
            {
                ButtonInfo buttonInfo = buttons[index];
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
        }

        public void Draw()
        {
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menu.GetComponent<Rigidbody>());
            Object.Destroy(menu.GetComponent<BoxCollider>());
            Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f) * 1f;
            menuObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menuObj.GetComponent<Rigidbody>());
            Object.Destroy(menuObj.GetComponent<BoxCollider>());
            menuObj.transform.parent = menu.transform;
            menuObj.transform.rotation = Quaternion.identity;
            menuObj.transform.localScale = new Vector3(0.1f, 1f, 1f) * 1f;
            if (ChangingColors)
            {
                GradientColorKey[] array = new GradientColorKey[4];
                array[0].color = FirstColor;
                array[0].time = 0f;
                array[1].color = FirstColor;
                array[1].time = 0.3f;
                array[2].color = SecondColor;
                array[2].time = 0.6f;
                array[3].color = FirstColor;
                array[3].time = 1f;
                ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                colorChanger.colors = new Gradient
                {
                    colorKeys = array
                };
                colorChanger.Start();
            }
            else
            {
                menuObj.GetComponent<Renderer>().material.color = NormalColor;
            }
            menuObj.transform.position = new Vector3(0.05f, 0f, 0f) * 1f;
            canvasObj = new GameObject();
            canvasObj.transform.parent = menu.transform;
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text.gameObject.name = "name";
            titiel = text;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            int yau = pageNumber + 1;
            text.text = MenuTitle;
            text.fontSize = 1;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.05f);
            component.position = new Vector3(0.06f, 0f, 0.175f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            AddPageButtons();
            string[] array2 = buttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array3 = settingsbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            if (Mods.inSettings)
            {
                for (int i = 0; i < array3.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array3[i]);
                }
            }
            else
            {
                for (int i = 0; i < array2.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array2[i]);
                }
            }
            GameObject tooltipObj = new GameObject();
            tooltipObj.transform.SetParent(canvasObj.transform);
            tooltipObj.transform.localPosition = new Vector3(0, 0, 1) * 1f;

            tooltipText = tooltipObj.GetComponent<Text>();
            if (tooltipText == null)
                tooltipText = tooltipObj.AddComponent<Text>();
            tooltipText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            tooltipText.text = tooltipString;
            tooltipText.fontSize = 20;
            tooltipText.alignment = TextAnchor.MiddleCenter;
            tooltipText.resizeTextForBestFit = true;
            tooltipText.resizeTextMinSize = 0;
            tooltipText.color = ButtonTextColor;

            RectTransform componenttooltip = tooltipObj.GetComponent<RectTransform>();
            componenttooltip.localPosition = Vector3.zero;
            componenttooltip.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            componenttooltip.position = new Vector3(0.06f, 0f, -0.18f) * 1f;
            componenttooltip.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            GameObject gameObject3 = GameObject.CreatePrimitive((PrimitiveType)3);
            gameObject3.name = "disconnect";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>()); float num5 = 0f;
            gameObject3.GetComponent<BoxCollider>().isTrigger = true;
            gameObject3.transform.parent = WristMenu.menu.transform;
            gameObject3.transform.rotation = Quaternion.identity;
            gameObject3.transform.localScale = new Vector3(0.045f, 0.53f, 0.17f);
            gameObject3.transform.localPosition = new Vector3(0.56f, -0.8f, 0.05f - num5);
            gameObject3.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
            gameObject3.GetComponent<Renderer>().material.color = Color.red;
            Text text2 = new GameObject
            {
                name = "disconnect text",
                transform =
                    {
                        parent = WristMenu.canvasObj.transform
                    }
            }.AddComponent<Text>();
            text.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
            text.text = "Disconnect";
            text.fontSize = 1;
            text.alignment = (TextAnchor)4;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component2 = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.06f, -0.24f, 0.02f - num5 / 2.55f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static Text titiel;

        public static void DisableButton(string buttonText)
        {
            if (Mods.inSettings)
            {
                foreach (ButtonInfo btninfo in settingsbuttons)
                {
                    if (btninfo.buttonText == buttonText)
                    {
                        btninfo.enabled = false;
                        instance.Draw();
                    }
                }
            }
            else
            {
                foreach (ButtonInfo btninfo in buttons)
                {
                    if (btninfo.buttonText == buttonText)
                    {
                        btninfo.enabled = false;
                        instance.Draw();
                    }
                }
            }
        }
        private static void AddPageButtons()
        {
            int num = (buttons.Count + pageSize - 1) / pageSize;
            int num2 = pageNumber + 1;
            int num3 = pageNumber - 1;
            if (num2 > num - 1)
            {
                num2 = 0;
            }
            if (num3 < 0)
            {
                num3 = num - 1;
            }
            float num4 = 0f;
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * GorillaLocomotion.Player.Instance.scale;
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num4) * GorillaLocomotion.Player.Instance.scale;
            gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
            GradientColorKey[] array = new GradientColorKey[3];
            array[0].color = new Color32(50, 50, 50, 255);
            array[0].time = 0f;
            array[1].color = new Color32(90, 90, 90, 255);
            array[1].time = 0.5f;
            array[2].color = new Color32(50, 50, 50, 255);
            array[2].time = 1f;
            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colors = new Gradient
            {
                colorKeys = array
            };
            colorChanger.Start();
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
            text.text = "[" + num3.ToString() + "] << Prev";
            text.fontSize = 1;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f) * GorillaLocomotion.Player.Instance.scale;
            component.localPosition = new Vector3(0.064f, 0f, 0.111f - num4 / 2.55f) * GorillaLocomotion.Player.Instance.scale;
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            num4 = 0.13f;
            GameObject gameObject2 = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            gameObject2.GetComponent<BoxCollider>().isTrigger = true;
            gameObject2.transform.parent = menu.transform;
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * GorillaLocomotion.Player.Instance.scale;
            gameObject2.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num4);
            gameObject2.AddComponent<BtnCollider>().relatedText = "NextPage";
            gameObject2.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
            GradientColorKey[] array2 = new GradientColorKey[3];
            array2[0].color = new Color32(50, 50, 50, 255);
            array2[0].time = 0f;
            array2[1].color = new Color32(90, 90, 90, 255);
            array2[1].time = 0.5f;
            array2[2].color = new Color32(50, 50, 50, 255);
            array2[2].time = 1f;
            ColorChanger colorChanger2 = gameObject2.AddComponent<ColorChanger>();
            colorChanger2.colors = new Gradient
            {
                colorKeys = array2
            };
            colorChanger2.Start();
            Text text2 = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text2.text = "Next >> [" + num2.ToString() + "]";
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component2 = text2.GetComponent<RectTransform>();
            component2.localPosition = Vector3.zero;
            component2.sizeDelta = new Vector2(0.2f, 0.03f) * GorillaLocomotion.Player.Instance.scale;
            component2.localPosition = new Vector3(0.064f, 0f, 0.111f - num4 / 2.55f);
            component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
            public static void DestroyMenu()
        {
            Object.Destroy(menu);
            Object.Destroy(canvasObj);
            Object.Destroy(reference);
            menu = null;
            menuObj = null;
            canvasObj = null;
            reference = null;
        }
        private static void AddButton(float offset, string text)
        {
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * 1f;
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<BtnCollider>().relatedText = text;
            int num = -1;
            if (Mods.inSettings)
            {
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    bool flag = text == settingsbuttons[i].buttonText;
                    if (flag)
                    {
                        num = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    bool flag = text == buttons[i].buttonText;
                    if (flag)
                    {
                        num = i;
                        break;
                    }
                }
            }
            Text text2 = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text2.text = text;
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component = text2.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 2.55f) * 1f;
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (Mods.inSettings)
            {
                if (settingsbuttons[num].enabled == true)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                    text2.color = Color.black;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    text2.color = Color.black;
                }
            }
            else
            {
                if (buttons[num].enabled == true)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                    text2.color = Color.black;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    text2.color = Color.black;
                }
            }
        }
        public static bool IsButtonToggled(string relatedText)
        {
            if (Mods.inSettings)
            {
                int num = -1;
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    if (relatedText == settingsbuttons[i].buttonText)
                    {
                        num = i;
                        break;
                    }
                }

                if (settingsbuttons[num].enabled != null)
                {
                    return (bool)settingsbuttons[num].enabled;
                }
                return false;
            }
            else
            {
                int num = -1;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (relatedText == buttons[i].buttonText)
                    {
                        num = i;
                        break;
                    }
                }

                if (buttons[num].enabled != null)
                {
                    return (bool)buttons[num].enabled;
                }
                return false;
            }
        }

        

        public void Start()
        {
            Draw();
        }

        public static void Toggle(string relatedText)
        {
            if (Mods.inSettings)
            {
                int num = (settingsbuttons.Count + pageSize - 1) / pageSize;
                if (relatedText == "NextPage")
                {
                    if (pageNumber < num - 1)
                    {
                        pageNumber++;
                    }
                    else
                    {
                        pageNumber = 0;
                    }
                    DestroyMenu();
                    instance.Draw();
                }
                else
                {
                    if (relatedText == "PreviousPage")
                    {
                        if (pageNumber > 0)
                        {
                            pageNumber--;
                        }
                        else
                        {
                            pageNumber = num - 1;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "DisconnectingButton")
                        {
                            PhotonNetwork.Disconnect();
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                        }
                        else
                        {
                            int num2 = -1;
                            for (int i = 0; i < settingsbuttons.Count; i++)
                            {
                                if (relatedText == settingsbuttons[i].buttonText)
                                {
                                    num2 = i;
                                    break;
                                }
                            }
                            if (settingsbuttons[num2].enabled != null)
                            {
                                settingsbuttons[num2].enabled = !settingsbuttons[num2].enabled;
                                lastPressedButtonIndex = num2;
                                if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < settingsbuttons.Count)
                                {
                                    tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                    tooltipText.text = tooltipString;
                                    lastPressedButtonIndex = -1;
                                }
                                DestroyMenu();
                                instance.Draw();
                            }
                        }
                    }
                }
            }
            else
            {
                int num = (buttons.Count + pageSize - 1) / pageSize;
                if (relatedText == "NextPage")
                {
                    if (pageNumber < num - 1)
                    {
                        pageNumber++;
                    }
                    else
                    {
                        pageNumber = 0;
                    }
                    DestroyMenu();
                    instance.Draw();
                }
                else
                {
                    if (relatedText == "PreviousPage")
                    {
                        if (pageNumber > 0)
                        {
                            pageNumber--;
                        }
                        else
                        {
                            pageNumber = num - 1;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "DisconnectingButton")
                        {
                            PhotonNetwork.Disconnect();
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                        }

                        else
                        {
                            int num2 = -1;
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                if (relatedText == buttons[i].buttonText)
                                {
                                    num2 = i;
                                    break;
                                }
                            }
                            if (buttons[num2].enabled != null)
                            {
                                buttons[num2].enabled = !buttons[num2].enabled;
                                lastPressedButtonIndex = num2;
                                if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < buttons.Count)
                                {
                                    tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                    tooltipText.text = tooltipString;
                                    lastPressedButtonIndex = -1;
                                }
                                DestroyMenu();
                                instance.Draw();
                            }
                        }
                    }
                }
            }
        }
    }
}

internal class BtnCollider : MonoBehaviour
{
    public static int framePressCooldown = 0;
    private void OnTriggerEnter(Collider collider)
    {
        if (Time.frameCount >= framePressCooldown + 20 && collider.name == "buttonPresser")
        {
            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.1f);
            GorillaTagger.Instance.StartVibration(false, .01f, 0.001f);
            WristMenu.Toggle(this.relatedText);
            framePressCooldown = Time.frameCount;
        }
    }

    public string relatedText;
}