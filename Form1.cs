using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Media;

namespace zendeskalerts
{
    public partial class Form1 : Form
    {
        private List<string> _ticketCache = new List<string>();
        private string _soundLocation = "C:/Windows/Media/notify.wav";

        private NotifyIcon _icon = new NotifyIcon();
        private StringBuilder _logs = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemTraySetup();

            //load the remember me user if available
            List<string> loadedData = LoadRememberMe();

            //set the values if user is stored in remember me
            if (string.IsNullOrEmpty(loadedData[0])) return;

            email_val.Text = loadedData[0];

            if (loadedData.Count > 1)
            {
                zendeskUrl.Text = loadedData[1];
            }

            remember.Checked = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TimerController();

            if (remember.Checked)
            {
                //store username in remember me
                RememberMe();
            }
            else
            {
                //remove the username from remember me
                RemoveRememberMe();
            }

            //start loging
            _logs.AppendLine(DateTime.Now + ": Started monitoring new tickets.");

            //hide the application to system tray
            Hide();

            //send a friendly reminder that zenalerts is running in the background
            Notification("Running", "ZenAlerts is running in the background!");
        }

        private void SystemTraySetup()
        {
            //set system tray icon settings
            _icon.Visible = true;
            _icon.Icon = SystemIcons.Application;
            _icon.ContextMenuStrip = menuStrip;
        }

        private void TimerController()
        {
            //time control
            timer.Start();
            clearCache.Start();
        }

        private void Controller()
        {
            FindNewTicket(zendeskUrl.Text, email_val.Text, password_val.Text);
        }

        private void RememberMe()
        {
            List<string> data = new List<string>();

            data.Add(email_val.Text);
            data.Add(zendeskUrl.Text);

            try
            {
                using (var sw = new StreamWriter(Application.StartupPath + "/rememberme.txt"))
                {
                    foreach (var row in data)
                    {
                        sw.WriteLine(row);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void RemoveRememberMe()
        {
            try
            {
                using (var sw = new StreamWriter(Application.StartupPath + "/rememberme.txt"))
                {
                    sw.Write("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static List<string> LoadRememberMe()
        {
            try
            {
                List<string> loadData = new List<string>();
                using (StreamReader sr = new StreamReader(Application.StartupPath + "/rememberme.txt")) {
                    while (!sr.EndOfStream)
                    {
                        loadData.Add(sr.ReadLine());
                    }
                    
                }
                return loadData;
            }
            catch (Exception)
            {
                File.Create(Application.StartupPath + "/rememberme.txt").Close();
                return null;
            }
        }

        private void FindNewTicket(string url, string email, string password)
        {
            //logs.AppendLine(System.DateTime.Now.ToString() + ": Checking for new tickets.");

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                
                var req = WebRequest.Create(url + "/api/v2/search.json?query=status:new");
                var credentials = email + ":" + password;
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
                var res = req.GetResponse();
                var receiveStream = res.GetResponseStream();
                var reader = new StreamReader(receiveStream ?? throw new InvalidOperationException(), Encoding.UTF8);
                var content = reader.ReadToEnd();
                Console.WriteLine(content);
                var json = "[" + content + "]"; // change this to array
                var objects = JArray.Parse(json); // parse as array  
                foreach (var o in objects.Children<JObject>())
                {
                    foreach (var p in o.Properties())
                    {
                        var value = p.Value.ToString().ToLower();

                        if (!value.Contains("new")) continue;

                        //get the ticket ID and check to see if it has been stored in the cache
                        var ticketId = GetTicketId(value, "\"id\": ", ",");
                        var isCached = CheckTicketCache(ticketId);

                        if (isCached) continue;

                        _logs.AppendLine(DateTime.Now + ": New Ticket");

                        //play sound and show notification of new ticket
                        PlaySound();
                        Notification("New Ticket", "A new ticket has arrived");
                    }
                }
            }
            catch(Exception ex)
            {
                Notification("Problem!", "Please check your Zendesk username and password and try again! More details in the log files.");
                _logs.AppendLine(DateTime.Now + ": " + ex);
                Show();
                timer.Stop();
                clearCache.Stop();
            }
        }

        private static string GetTicketId(string strSource, string strStart, string strEnd)
        {
            if (!strSource.Contains(strStart) || !strSource.Contains(strEnd)) return string.Empty;

            var start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
            var end = strSource.IndexOf(strEnd, start, StringComparison.Ordinal);
            return strSource.Substring(start, end - start);
        }

        private bool CheckTicketCache(string id)
        {
            if (_ticketCache.Any(t => t == id))
            {
                return true;
            }

            _ticketCache.Add(id);
            _logs.AppendLine(DateTime.Now + ": Caching ticket #" + id);
            return false;
        }

        private void PlaySound()
        {
            if (!pSound.Checked) return;

            var sp = new SoundPlayer(_soundLocation);
            sp.Play();
        }

        private void Notification(string title, string body)
        {
            //show notification
            _icon.BalloonTipTitle = title;
            _icon.BalloonTipText = body;
            _icon.ShowBalloonTip(10000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Controller();
            timer.Start();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            SaveLogs();
            Application.Exit();
        }

        private void clearCache_Tick(object sender, EventArgs e)
        {
            if (_ticketCache.Count <= 0) return;

            _logs.AppendLine(DateTime.Now + ": dumping the ticket cache.");
            _ticketCache.Clear();
        }

        private void SaveLogs()
        {
            File.Create(Application.StartupPath + "/logs/logs_" + DateTime.Now.ToString("MM-dd-yyyy hh.mm") + ".txt").Close();

            using (var sw = new StreamWriter(Application.StartupPath + "/logs/logs_" + DateTime.Now.ToString("MM-dd-yyyy hh.mm") + ".txt"))
            {
                sw.Write(_logs.ToString());
            }

            ResetLogs();
        }

        private void ResetLogs()
        {
            _logs.Clear();
        }
    }
}
