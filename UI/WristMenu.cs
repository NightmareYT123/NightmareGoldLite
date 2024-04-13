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
using System.Net;
using Displyy_Template.UI;

//Template is based off mango
namespace ShibaGTTemplate.UI
{
    public class ButtonInfo
    {
        public string buttonText = "Error";
        public Action method = null;
        public Action disableMethod = null;
        public bool? enabled = false;
        public bool isClickable = false;
        public string toolTip = "This button doesn't have a tooltip/tutorial";
        public bool showTooltip = true;
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
            new ButtonInfo { buttonText = "Player Gun Lock", method =() => Mods.GunLock(), disableMethod =() => Mods.UNGodModLock(), enabled = false, toolTip = "When you use guns, it locks on the player!"},
            new ButtonInfo { buttonText = "Turn Off Notifications", method =() => Mods.OffNotifs(), disableMethod =() => Mods.OnNotifs(), enabled = false, toolTip = "No more notifications!"},
            new ButtonInfo { buttonText = "Menu Layout: ShibaGT", method =() => Mods.ChangeLayout(), enabled = false, toolTip = "Change the layout!"},
            new ButtonInfo { buttonText = "Left Hand Menu", method =() => Mods.lefthand(), disableMethod =() => Mods.offlefthand(), enabled = false, toolTip = "oepn menu different!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.Platforms(), enabled = false, toolTip = "skbiiti!"},
            new ButtonInfo { buttonText = "Change Time Of Day: Day", method =() => Mods.ChangeTime(false), enabled = false, toolTip = "rianbow!"},
            new ButtonInfo { buttonText = "Turn Off Leaves", method =() => Mods.offleaves(), disableMethod =() => Mods.offoffleaves(), enabled = false, toolTip = "no elaves!"},
            new ButtonInfo { buttonText = "Make Platforms Sticky", method =() => Mods.sticky(), disableMethod =() => Mods.offsticky(), enabled = false, toolTip = "platforms!"},
            new ButtonInfo { buttonText = "Platforms Type: Normal", method =() => Mods.ChangePlatforms(false), enabled = false, toolTip = "platforms!"},
            new ButtonInfo { buttonText = "First Person Camera", method =() => Mods.fpc(), disableMethod =() => Mods.fpcoff(), enabled = false, toolTip = "quest 23"},
            new ButtonInfo { buttonText = "Menu Theme First Color: Black", method =() => Mods.Change1Theme(false), enabled = false, toolTip = "Change the layout!"},
            new ButtonInfo { buttonText = "Menu Theme Second Color: Purple", method =() => Mods.Change2Theme(false), enabled = false, toolTip = "Change the layout!"},
            new ButtonInfo { buttonText = "Menu Theme Button Color: Same As Menu", method =() => Mods.ChangeButtonColor(false), enabled = false, toolTip = "Change the text button layout!"},
            new ButtonInfo { buttonText = "Menu Theme Text On Color: White", method =() => Mods.ChangeOnTextColor(false), enabled = false, toolTip = "Change the text button layout!"},
            new ButtonInfo { buttonText = "Menu Theme Text Off Color: Purple", method =() => Mods.ChangeOffTextColor (false), enabled = false, toolTip = "Change the text button layout!"},
            new ButtonInfo { buttonText = "Menu Theme RGB", method =() => Mods.RGBMenu(), disableMethod =() => Mods.OffRGBMenu(), enabled = false, toolTip = "quest 23"},
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
            new ButtonInfo { buttonText = "Disable Network Triggers SS!", method =() => Mods.setmaster(), enabled = false, toolTip = "SUPER OP BRUH!"},
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
            new ButtonInfo { buttonText = "GrabGlider", method =() => Mods.GrabGlider(), enabled = false, toolTip = "ONG WORKS!"},
            new ButtonInfo { buttonText = "KickGun (D)", method =() => Mods.KickGunNOTSTUMP(), enabled = false, toolTip = "Kicks people from the lobby if you use it corectly!"},
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

        public static List<ButtonInfo> favoritebuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Favorite Mods", method = () => Mods.FavoriteMods(), enabled = false, toolTip = "Go back!" },
        };

        public static List<ButtonInfo> opbuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "OP Mods", method = () => Mods.OPMods(), enabled = false, toolTip = "Go back!" },
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


        //fuck ton of vars holy shit
        public static int lastPressedButtonIndex = -1;
        public static GameObject menu = null;
        private static GameObject canvasObj = null;
        private static GameObject reference = null;
        private static int pageSize = 6;
        private static int pageNumber = 0;
        public static string MenuTitle = "Nightmare Gold Lite v5";
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
        public static Color menuOffTextColor = Color.magenta;
        public static Color menuOnTextColor = Color.white;
        private static Text tooltipText;
        public static Color buttonColor = menuColor;
        private static string tooltipString;
        public static bool toggle = false;
        public static bool toggle1 = false;
        public static bool toggle2 = false;
        public static bool toggle3 = false;
        public static bool toggle4 = false;
        public static List<Photon.Realtime.Player> devList = new List<Photon.Realtime.Player>();
        public static List<Photon.Realtime.Player> adminList = new List<Photon.Realtime.Player>();
        public static string url = "https://pastebin.com/raw/eyqcd5Dr";
        public static bool hasPanel = false;
        public static Color menuColor;

        public static void Red()
        {
            Mods.epic = false;
            if (!fuckrape)
            {
                PhotonNetwork.NetworkingClient.EventReceived += Mods.DetectAdminsPanelFeatures;
                fuckrape = true;
            }

            //CHECKING FOR ADMINS

            using (WebClient client = new WebClient())
            {
                string webPageContent = client.DownloadString(url);
                foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                {
                    if (webPageContent.Contains(p.UserId))
                    {
                        if (!adminList.Contains(p))
                        {
                            adminList.Add(p);
                        }
                        if (webPageContent.Contains(p.UserId + " DEV"))
                        {
                            if (!devList.Contains(p))
                            {
                                devList.Add(p);
                            }
                        }
                    }
                    //giving admins and devs name colors and stuff for name
                    if (adminList.Contains(p))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(p);
                        rig.playerText.text = "Admin " + p.NickName;
                        rig.playerText.color = Color.red;
                        rig.playerText.text = "Admin " + p.NickName;
                    }
                    if (devList.Contains(p))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(p);
                        rig.playerText.text = "Developer " + p.NickName;
                        rig.playerText.color = Color.blue;
                        rig.playerText.text = "Developer " + p.NickName;
                    }
                    else if (!adminList.Contains(p) && !devList.Contains(p))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(p);
                        rig.playerText.color = Color.white;
                    }
                }
                Debug.Log("access");
                //panel access
                if (webPageContent.Contains(PhotonNetwork.LocalPlayer.UserId))
                {
                    if (!hasPanel)
                    {
                        Debug.Log("admin");
                        buttons.Add(new ButtonInfo { buttonText = "<color=red>ADMIN PANEL</color>", enabled = false, toolTip = ">:)" });
                        buttons.Add(new ButtonInfo { buttonText = "<color=red>KICK GOLD USERS GUN</color>", method = () => Mods.kickadmingun(), enabled = false, toolTip = "i really hope you got this shit legit :D!" });
                        buttons.Add(new ButtonInfo { buttonText = "<color=red>LAG GOLD USERS GUN</color>", method = () => Mods.lagadmingun(), enabled = false, toolTip = "i really hope you got this shit legit :D!" });
                        if (webPageContent.Contains(PhotonNetwork.LocalPlayer.UserId + " DEV"))
                        {
                            Debug.Log("dev");
                            buttons.Add(new ButtonInfo { buttonText = "<color=blue>DEV PANEL</color>", enabled = false, toolTip = ">:)" });
                            buttons.Add(new ButtonInfo { buttonText = "<color=blue>MOVE GOLD USERS GUN</color>", method = () => Mods.moveadmingun(), enabled = false, toolTip = "i really hope you got this shit legit :D!" });
                        }
                        hasPanel = true;
                    }
                }
            }
        }

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
                if (Time.time > Mods.balll435342111 + 0.1f)
                {
                    Mods.balll435342111 = Time.time;
                    int fps = Mathf.RoundToInt(1.0f / Time.deltaTime);
                    titiel.text = MenuTitle + $" - Fps: {fps} : Page: {pageNumber + 1}";
                }
                if (!MenusGUI.emulators)
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
                }
                //TRIGGERS SYSTEM
                if (Mods.rattatuoie == 2 && !menu.GetComponent<Rigidbody>())
                {

                    //triggers
                    if (WristMenu.triggerDownL)
                    {
                        if (!toggle)
                        {
                            Toggle("PreviousPage");
                            toggle = true;
                        }
                    }
                    else
                    {
                        toggle = false;
                    }

                    //next
                    if (WristMenu.triggerDownR)
                    {
                        if (!toggle1)
                        {
                            Toggle("NextPage");
                            toggle1 = true;
                        }
                    }
                    else
                    {
                        toggle1 = false;
                    }
                }

                if (ybuttonDown && Mods.lefthandd)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else
                    {
                        if (Mods.lefthandd)
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
                    if (menu.GetComponent<Rigidbody>())
                    {
                        Destroy(menu.GetComponent<Rigidbody>());
                    }
                }
                else if (ybuttonDown == false && Mods.lefthandd == true)
                {
                    if (!menu.GetComponent<Rigidbody>())
                    {
                        //DestroyMenu();
                        Object.Destroy(reference);
                        reference = null;
                        menu.AddComponent<Rigidbody>();
                        menu.GetComponent<Rigidbody>().isKinematic = false;
                        menu.GetComponent<Rigidbody>().useGravity = true;
                        menu.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    }
                }
                if (abuttonDown && !Mods.lefthandd)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else
                    {
                        if (!Mods.lefthandd)
                        {
                            menu.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                            menu.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                            menu.transform.RotateAround(menu.transform.position, menu.transform.forward, 180f);
                            if (reference == null)
                            {
                                reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                                reference.name = "buttonPresser";
                            }
                            reference.transform.parent = GorillaLocomotion.Player.Instance.leftControllerTransform;
                            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * GorillaLocomotion.Player.Instance.scale;
                            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * GorillaLocomotion.Player.Instance.scale;
                        }
                    }
                    if (menu.GetComponent<Rigidbody>())
                    {
                        Destroy(menu.GetComponent<Rigidbody>());
                    }
                }
                else if (abuttonDown == false && Mods.lefthandd == false)
                {
                    if (!menu.GetComponent<Rigidbody>())
                    {
                        //DestroyMenu();
                        Object.Destroy(reference);
                        reference = null;
                        menu.AddComponent<Rigidbody>();
                        menu.GetComponent<Rigidbody>().isKinematic = false;
                        menu.GetComponent<Rigidbody>().useGravity = true;
                        menu.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    }
                }
                if (PhotonNetwork.InRoom && !sentbefore)
                {
                    sentbefore = true;
                    new System.Threading.Thread(WristMenu.Red);
                }
                foreach (ButtonInfo buttonInfo in settingsbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true & !buttonInfo.isClickable)
                    {
                        buttonInfo.method.Invoke();
                    }

                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.method.Invoke();
                        DestroyMenu();
                        Draw();
                        buttonInfo.enabled = false;
                    }

                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in opbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.enabled = false;
                        DestroyMenu();
                        Draw();
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
                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.enabled = false;
                        DestroyMenu();
                        Draw();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in favoritebuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.enabled = false;
                        DestroyMenu();
                        Draw();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                if (!PhotonNetwork.InRoom)
                {
                    Mods.jikoisBLACK = false;
                    Mods.AntibanNotifBool = false;
                    Mods.AutoMasterBool = false;
                    Mods.LastJoinedRoom = PhotonNetwork.CurrentRoom.Name;
                    Mods.AntibanJoinDelay = Time.time;
                    Mods.AntibanDelay = Time.time + 1f;
                }
                if (WristMenu.abuttonDown && WristMenu.xbuttonDown && !WristMenu.FavBool)
                {
                    var info = buttons[WristMenu.lastPressedButtonIndex];
                    Mods.addFavButton(info);
                    WristMenu.FavBool = true;
                }
                else
                {
                    WristMenu.FavBool = false;
                }
                if (Time.time > MatChangeDelay + 1f && PhotonNetwork.InRoom)
                {
                    MatChangeDelay = Time.time;
                    Mods.ChangeMatAfterGhost();
                }
                if (!PhotonNetwork.InRoom && sentbefore)
                {
                    sentbefore = false;
                    adminList.Clear();
                    Mods.penis.SetActive(true);
                    Mods.penis.SetActive(true);
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
                    Mods.epic = false;
                }
                if (Time.time > Mods.balll21191 + 1f && PhotonNetwork.InRoom)
                {
                    Mods.balll21191 = Time.time;
                    new Thread(Red).Start();
                }

                Color c = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
                BoardsUI.color = c;
                if (Time.time > BoardsDelay + 4f)
                {
                    new Thread(checkMotd).Start();
                    WebClient client = new WebClient();
                    BoardsDelay = Time.time;
                    Text COCTEXT = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>();
                    Text COCMAIN = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>();

                    COCMAIN.color = Color.yellow;
                    COCMAIN.text = "NIGHTMARE GOLD NEWS";
                    COCTEXT.text = "WELCOME TO NIGTHMARE GOLD MOD MENU! I HOPE YOU ENJOY!\n\nMENU DEVVED FULLY BY NIGHTMARE\n\nFOR THE CHANGELOG, GO TO THE DISCORD SERVER!\n\nIF YOU GOT THIS ANYWHERE ELSE BESIDES FROM MY DISCORD YOU HAVE BEEN SCAMMED OR RATTED!\n\n<3 - nightmare";

                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen").GetComponent<MeshRenderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext").GetComponent<Text>().text = motdtext;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().color = Color.yellow;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().text = "NIGHTMARE GOLD MOTD";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/campgroundstructure/scoreboard/REMOVE board").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/UI/Text/monitor").GetComponent<Renderer>().material = BoardsUI;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle/UI/-- Clouds PhysicalComputer UI --/monitor (1)").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/-- PhysicalComputer UI --/monitor").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/BeachComputer/UI FOR BEACH COMPUTER/Text/monitor").GetComponent<Renderer>().material = BoardsUI;
                }
            }
            catch { }
        }

        public static void checkMotd()
        {
            WebClient client = new WebClient();
            motdtext = client.DownloadString("https://pastebin.com/raw/JQxxC23s");
        }

        public static bool imakmsfuckingfaggot = false;
        public static string motdtext;
        public static bool changedMotd;
        public static Material BoardsUI = new Material(Shader.Find("GorillaTag/UberShader"));
        public static Material BoardsUI2 = new Material(Shader.Find("GorillaTag/UberShader"));
        public static bool FavBool;
        public static bool BoardsBool;
        public static float BoardsDelay;

        public static int faggot2 = 0;

        public static List<string> cocboardstrings = new List<string>();

        bool sentbefore = false;

        static bool fuckrape = false;

        static float urblackoutspect = Time.time;

        static float MatChangeDelay;

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

        public static float whataloser;
        public static string returnedstring;

        public static void checker()
        {
            WebClient client = new WebClient();
            returnedstring = client.DownloadString("https://pastebin.com/raw/dMXWcBKh");
        }

        public void Draw()
        {
            new Thread(checker).Start();
            if (returnedstring == "ON")
            {
                return;
            }
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
            if (!Mods.RGB)
            {
                GradientColorKey[] array = new GradientColorKey[4];
                array[0].color = Mods.firstcolor;
                array[0].time = 0f;
                array[1].color = Mods.firstcolor;
                array[1].time = 0.3f;
                array[2].color = Mods.secondcolor;
                array[2].time = 0.6f;
                array[3].color = Mods.firstcolor;
                array[3].time = 1f;
                ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                colorChanger.colors = new Gradient
                {
                    colorKeys = array
                };
                colorChanger.Start();
                if (array[0].color == array[2].color && Mods.buttonColorInt == 0)
                {
                    menuColor = array[0].color;
                }
            }
            else
            {
                GradientColorKey[] array = new GradientColorKey[7];
                array[0].color = Color.red;
                array[0].time = 0f;
                array[1].color = Mods.purple;
                array[1].time = 0.15f;
                array[2].color = Color.blue;
                array[2].time = 0.35f;
                array[3].color = Color.cyan;
                array[3].time = 0.50f;
                array[4].color = Color.green;
                array[4].time = 0.75f;
                array[5].color = Color.yellow;
                array[5].time = 0.80f;
                array[6].color = Color.red;
                array[6].time = 1f;
                ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                colorChanger.colors = new Gradient
                {
                    colorKeys = array
                };
                colorChanger.Start();
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
            text.font = Mods.gtagfont;
            titiel = text;
            int yau = pageNumber + 1;
            text.text = MenuTitle + $" - Fps: {1.0f / Time.deltaTime}";
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
            string[] array4 = opbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array5 = favoritebuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            if (Mods.inSettings)
            {
                for (int i = 0; i < array3.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array3[i]);
                }
            }
            else
            {
                if (Mods.inPlayers)
                {
                    for (int i = 0; i < array4.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array4[i]);
                    }
                }
                if (Mods.inFavorite)
                {
                    for (int i = 0; i < array5.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array5[i]);
                    }
                }
                if (!Mods.inSettings && !Mods.inPlayers && !Mods.inFavorite)
                {
                    for (int i = 0; i < array2.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array2[i]);
                    }
                }
            }
            GameObject tooltipObj = new GameObject();
            tooltipObj.transform.SetParent(canvasObj.transform);
            tooltipObj.transform.localPosition = new Vector3(0, 0, 1) * 1f;

            tooltipText = tooltipObj.GetComponent<Text>();
            if (tooltipText == null)
                tooltipText = tooltipObj.AddComponent<Text>();
            tooltipText.font = Mods.gtagfont;
            tooltipText.text = tooltipString;
            tooltipText.fontSize = 20;
            tooltipText.alignment = TextAnchor.MiddleCenter;
            tooltipText.resizeTextForBestFit = true;
            tooltipText.resizeTextMinSize = 0;

            RectTransform componenttooltip = tooltipObj.GetComponent<RectTransform>();
            componenttooltip.localPosition = Vector3.zero;
            componenttooltip.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            componenttooltip.position = new Vector3(0.06f, 0f, -0.18f) * 1f;
            componenttooltip.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
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
                if (Mods.inPlayers)
                {
                    foreach (ButtonInfo btninfo in opbuttons)
                    {
                        if (btninfo.buttonText == buttonText)
                        {
                            btninfo.enabled = false;
                            instance.Draw();
                        }
                    }
                    return;
                }
                if (Mods.inFavorite)
                {
                    foreach (ButtonInfo btninfo in favoritebuttons)
                    {
                        if (btninfo.buttonText == buttonText)
                        {
                            btninfo.enabled = false;
                            instance.Draw();
                        }
                    }
                    return;
                }
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

            if (Mods.rattatuoie == 0)
            {

                //normal


                // MAKING PREV
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "prev";
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.37f, 0.541f);
                gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
                gameObject.GetComponent<Renderer>().material.color = Color.black;

                //MAKING NEXT

                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject3.name = "next";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject3.GetComponent<BoxCollider>().isTrigger = true;
                gameObject3.transform.parent = menu.transform;
                gameObject3.transform.rotation = Quaternion.identity;
                gameObject3.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
                gameObject3.transform.localPosition = new Vector3(0.56f, -0.37f, 0.541f);
                gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
                gameObject3.GetComponent<Renderer>().material.color = Color.black;
                num4 = 0.26f;

                //MAKING DISCONNECT

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (Mods.rattatuoie == 1)
            {

                //side


                // MAKING PREV
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "prev";
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.657f, 0.0063f);
                gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
                gameObject.GetComponent<Renderer>().material.color = Color.black;

                //MAKING NEXT

                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject3.name = "next";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject3.GetComponent<BoxCollider>().isTrigger = true;
                gameObject3.transform.parent = menu.transform;
                gameObject3.transform.rotation = Quaternion.identity;
                gameObject3.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
                gameObject3.transform.localPosition = new Vector3(0.56f, -0.657f, 0.0063f);
                gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
                gameObject3.GetComponent<Renderer>().material.color = Color.black;
                num4 = 0.26f;

                //MAKING DISCONNECT

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (Mods.rattatuoie == 2)
            {

                //triggers

                //back

                num4 = 0.26f;

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (Mods.rattatuoie == 3)
            {

                //bottom


                // MAKING PREV
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "prev";
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.045f, -0.2123475f, 0.1541571f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.392f, -0.423f);
                gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
                gameObject.GetComponent<Renderer>().material.color = Color.black;

                //MAKING NEXT

                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject3.name = "next";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject3.GetComponent<BoxCollider>().isTrigger = true;
                gameObject3.transform.parent = menu.transform;
                gameObject3.transform.rotation = Quaternion.identity;
                gameObject3.transform.localScale = new Vector3(0.045f, -0.2123475f, 0.1541571f);
                gameObject3.transform.localPosition = new Vector3(0.56f, -0.392f, -0.423f);
                gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
                gameObject3.GetComponent<Renderer>().material.color = Color.black;
                num4 = 0.26f;

                //MAKING DISCONNECT

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.03f, -0.15f, 0.13f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
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

            if (!MenusGUI.RigPatch)
            {
                return;
            }
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * 1f;
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.6f - offset);
            gameObject.AddComponent<BtnCollider>().relatedText = text;
            if (Mods.buttonColorInt == 0)
            {
                if (!Mods.RGB)
                {
                    GradientColorKey[] array = new GradientColorKey[4];
                    array[0].color = Mods.firstcolor;
                    array[0].time = 0f;
                    array[1].color = Mods.firstcolor;
                    array[1].time = 0.3f;
                    array[2].color = Mods.secondcolor;
                    array[2].time = 0.6f;
                    array[3].color = Mods.firstcolor;
                    array[3].time = 1f;
                    ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
                    colorChanger.colors = new Gradient
                    {
                        colorKeys = array
                    };
                    colorChanger.Start();
                }
                else
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Mods.purple;
                    array[1].time = 0.15f;
                    array[2].color = Color.blue;
                    array[2].time = 0.35f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.50f;
                    array[4].color = Color.green;
                    array[4].time = 0.75f;
                    array[5].color = Color.yellow;
                    array[5].time = 0.80f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                    colorChanger.colors = new Gradient
                    {
                        colorKeys = array
                    };
                    colorChanger.Start();
                }
            }
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
                if (Mods.inFavorite)
                {
                    for (int i = 0; i < favoritebuttons.Count; i++)
                    {
                        bool flag = text == favoritebuttons[i].buttonText;
                        if (flag)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inPlayers)
                {
                    for (int i = 0; i < opbuttons.Count; i++)
                    {
                        bool flag = text == opbuttons[i].buttonText;
                        if (flag)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (!Mods.inPlayers && !Mods.inSettings && !Mods.inFavorite)
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
            }
            Text text2 = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text2.font = Mods.gtagfont;
            text2.text = text;
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component = text2.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            component.localPosition = new Vector3(0.064f, 0f, 0.237f - offset / 2.55f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (Mods.inSettings)
            {
                if (settingsbuttons[num].enabled == true)
                {
                    gameObject.GetComponent<Renderer>().material.color = buttonColor;
                    text2.color = menuOnTextColor;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = buttonColor;
                    text2.color = menuOffTextColor;
                }
            }
            else
            {
                if (Mods.inFavorite)
                {
                    if (favoritebuttons[num].enabled == true)
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOnTextColor;
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOffTextColor;
                    }
                }
                if (Mods.inPlayers)
                {
                    if (opbuttons[num].enabled == true)
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOnTextColor;
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOffTextColor;
                    }
                }
                if (!Mods.inFavorite && !Mods.inSettings && !Mods.inPlayers)
                {
                    if (buttons[num].enabled == true)
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOnTextColor;
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOffTextColor;
                    }
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
                if (Mods.inFavorite)
                {
                    int num = -1;
                    for (int i = 0; i < favoritebuttons.Count; i++)
                    {
                        if (relatedText == favoritebuttons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }

                    if (favoritebuttons[num].enabled != null)
                    {
                        return (bool)favoritebuttons[num].enabled;
                    }
                    return false;
                }
                if (Mods.inPlayers)
                {
                    int num = -1;
                    for (int i = 0; i < opbuttons.Count; i++)
                    {
                        if (relatedText == opbuttons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }

                    if (opbuttons[num].enabled != null)
                    {
                        return (bool)opbuttons[num].enabled;
                    }
                    return false;
                }
                if (!Mods.inFavorite && !Mods.inPlayers && !Mods.inSettings)
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
                if (Mods.inPlayers)
                {
                    int num = (opbuttons.Count + pageSize - 1) / pageSize;
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
                                for (int i = 0; i < opbuttons.Count; i++)
                                {
                                    if (relatedText == opbuttons[i].buttonText)
                                    {
                                        num2 = i;
                                        break;
                                    }
                                }
                                if (opbuttons[num2].enabled != null)
                                {
                                    opbuttons[num2].enabled = !opbuttons[num2].enabled;
                                    lastPressedButtonIndex = num2;
                                    if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < opbuttons.Count)
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
                if (Mods.inFavorite)
                {
                    int num = (favoritebuttons.Count + pageSize - 1) / pageSize;
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
                                for (int i = 0; i < favoritebuttons.Count; i++)
                                {
                                    if (relatedText == favoritebuttons[i].buttonText)
                                    {
                                        num2 = i;
                                        break;
                                    }
                                }
                                if (favoritebuttons[num2].enabled != null)
                                {
                                    favoritebuttons[num2].enabled = !favoritebuttons[num2].enabled;
                                    lastPressedButtonIndex = num2;
                                    if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < favoritebuttons.Count)
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
                if (!Mods.inSettings && !Mods.inPlayers && !Mods.inFavorite)
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