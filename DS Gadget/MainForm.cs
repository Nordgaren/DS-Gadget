using Octokit;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;

namespace DS_Gadget
{
    partial class MainForm : Form
    {
        private static Properties.Settings settings = Properties.Settings.Default;

        public DSHook Hook { get; private set; }
        public bool Loaded { get; private set; }
        public bool Reading { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            Hook = new DSHook(5000, 5000);
            Hook.OnHooked += Hook_OnHooked;
            Hook.OnUnhooked += Hook_OnUnhooked;
            Hook.Start();
        }

        private void Hook_OnHooked(object sender, PropertyHook.PHEventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblProcess.Text = Hook.ID.ToString();
                lblVersion.Text = Hook.Version;
                lblVersion.ForeColor = Hook.AOBScanSucceeded ? Color.DarkGreen : Color.DarkOrange;
            }));
        }

        private void Hook_OnUnhooked(object sender, PropertyHook.PHEventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblProcess.Text = "None";
                lblVersion.Text = "None";
                lblVersion.ForeColor = Color.Black;
                lblLoaded.Text = "No";
                EnableTabs(false);
                Loaded = false;
            }));
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Location = settings.WindowLocation;
            Text = "DS Gadget for Remastest " + System.Windows.Forms.Application.ProductVersion;
            EnableTabs(false);
            InitAllTabs();

            try
            {
                GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("DS-Gadget-for-Remastest"));
                Release release = await gitHubClient.Repository.Release.GetLatest("Nordgaren", "DS-Gadget");
                Version gitVersion = Version.Parse(release.TagName.ToLower().Replace("v", ""));
                Version exeVersion = Version.Parse(System.Windows.Forms.Application.ProductVersion);
                if (gitVersion > exeVersion) //Compare latest version to current version
                {
                    labelCheckVersion.Visible = false;
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = release.HtmlUrl;
                    llbNewVersion.Links.Add(link);
                    llbNewVersion.Visible = true;
                }
                else if (gitVersion == exeVersion)
                {
                    labelCheckVersion.Text = "App up to date";
                }
                else
                {
                    labelCheckVersion.Text = "App version unreleased. Be wary of bugs!";
                }
            }
            catch (Exception ex) when(ex is HttpRequestException || ex is ApiException || ex is ArgumentException)
            {
                labelCheckVersion.Text = "Current app version unknown";
            }
            catch (Exception ex)
            {
                labelCheckVersion.Text = "Something is very broke, contact DS Gadget repo owner";
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabelNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                settings.WindowLocation = Location;
            else
                settings.WindowLocation = RestoreBounds.Location;

            Hook.InfiniteDurabilityToggle(false);
            Hook.InfiniteDurabilitySpecToggle(false);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveAllTabs();
            ResetAllTabs();
        }

        private void EnableTabs(bool enable)
        {
            gadgetTabPlayer.EnableStats(enable);
            gadgetTabItems.EnableStats(enable);
            gadgetTabStats.EnabledStats(enable);
            gadgetTabMisc.EnableStats(enable);
        }

        private void timerUpdateProcess_Tick(object sender, EventArgs e)
        {
            if (Hook.Hooked)
            {
                if (Hook.Loaded)
                {
                    if (!Loaded)
                    {
                        lblLoaded.Text = "Yes";
                        Loaded = true;
                        Reading = true;
                        ReloadAllTabs();
                        Reading = false;
                        EnableTabs(true);
                    }
                    else
                    {
                        Reading = true;
                        UpdateAllTabs();
                        Reading = false;
                    }
                }
                else if (Loaded)
                {
                    lblLoaded.Text = "No";
                    EnableTabs(false);
                    Loaded = false;
                }
            }
        }

        private void InitAllTabs()
        {
            gadgetTabPlayer.InitTab(this);
            gadgetTabStats.InitTab(this);
            gadgetTabItems.InitTab(this);
            gadgetTabGraphics.InitTab(this);
            gadgetTabCheats.InitTab(this);
            gadgetTabInternals.InitTab(this);
            gadgetTabMisc.InitTab(this);
            initHotkeys();
        }

        private void ReloadAllTabs()
        {
            gadgetTabPlayer.ReloadTab();
            gadgetTabStats.ReloadTab();
            gadgetTabItems.ReloadTab();
            gadgetTabGraphics.ReloadTab();
            gadgetTabCheats.ReloadTab();
            gadgetTabInternals.ReloadTab();
            gadgetTabMisc.ReloadTab();
            reloadHotkeys();
        }

        private void UpdateAllTabs()
        {
            gadgetTabPlayer.UpdateTab();
            gadgetTabStats.UpdateTab();
            gadgetTabItems.UpdateTab();
            gadgetTabGraphics.UpdateTab();
            gadgetTabCheats.UpdateTab();
            gadgetTabInternals.UpdateTab();
            gadgetTabMisc.UpdateTab();
            updateHotkeys();
        }

        private void SaveAllTabs()
        {
            gadgetTabPlayer.SaveTab();
            gadgetTabStats.SaveTab();
            gadgetTabItems.SaveTab();
            gadgetTabGraphics.SaveTab();
            gadgetTabCheats.SaveTab();
            gadgetTabInternals.SaveTab();
            gadgetTabMisc.SaveTab();
            saveHotkeys();
        }

        private void ResetAllTabs()
        {
            gadgetTabPlayer.ResetTab();
            gadgetTabStats.ResetTab();
            gadgetTabItems.ResetTab();
            gadgetTabGraphics.ResetTab();
            gadgetTabCheats.ResetTab();
            gadgetTabInternals.ResetTab();
            gadgetTabMisc.ResetTab();
            resetHotkeys();
        }
    }
}
