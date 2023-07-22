using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Net;
using System.IO;


namespace Parkon
{
    public class NetworkAdapter
    {
        public CLS CLS;
        public void Bul(ComboBox CBox)
        {
            CBox.Items.Clear();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) || (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    CBox.Items.Add(nic.Description);
                }
            }
        }
        public void Sec(ComboBox CBox, out string IPAdd, out string SubnetMask, out string AgGecidi, out string DNS1, out string DNS2)
        {
            IPAdd = "";
            SubnetMask = "";
            AgGecidi = "";
            DNS1 = "";
            DNS2 = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                {
                    if (nic.Description == CBox.SelectedItem.ToString())
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            IPAdd       = ip.Address.ToString();
                            SubnetMask  = ip.IPv4Mask.ToString();
                            AgGecidi    = nic.GetIPProperties().GatewayAddresses[0].Address.ToString();
                            DNS1        = nic.GetIPProperties().DnsAddresses[0].ToString();
                            DNS2        = nic.GetIPProperties().DnsAddresses[1].ToString();
                            break;
                        }
                    }
                }

                //foreach (UnicastIPAddressInformation subnetMask in nic.su)
                //{
                //    if (nic.Description == CBox.SelectedItem.ToString())
                //    {
                //        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                //        {
                //            IPAdd = ip.Address.ToString();
                //        }
                //    }
                //}





            }

        }

        public void change()
        {
//            netsh interface ip set address "Local Area Connection" static 192.168.0.10 255.255.255.0 192.168.0.1 1



//            Process p = new Process();
//        ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip set address \"Local Area Connection\" static 192.168.0.10 255.255.255.0 192.168.0.1 1");
//        p.StartInfo = psi;
//p.Start();
        }

        /// <summary>
        /// Sets the ip address.
        /// </summary>
        /// <param name="nicName">Name of the nic.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="subnetMask">The subnet mask.</param>
        /// <param name="gateway">The gateway.</param>
        /// <param name="dns1">The DNS1.</param>
        /// <param name="dns2">The DNS2.</param>
        /// <returns></returns>
        public bool SetIpAddress(
            string nicName,
            string ipAddress,
            string subnetMask,
            bool DHCP,
            string gateway = null,
            string dns1 = null,
            string dns2 = null
            )
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface networkInterface = interfaces.FirstOrDefault(x => x.Description == nicName);

            foreach (ManagementObject mo in moc)
            {
                string ad       = mo["Description"].ToString(); // Caption
                bool IPEnabled  = (bool)mo["IPEnabled"];
                if (IPEnabled  && ad == nicName)
                {
                    try
                    {
                        ManagementBaseObject newIP = mo.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ipAddress };
                        newIP["SubnetMask"] = new string[] { subnetMask };

                        ManagementBaseObject setIP = mo.InvokeMethod("EnableStatic", newIP, null);

                        if (!DHCP && (gateway != null))
                        {
                            ManagementBaseObject newGateway = mo.GetMethodParameters("SetGateways");

                            newGateway["DefaultIPGateway"] = new string[] { gateway };
                            newGateway["GatewayCostMetric"] = new int[] { 1 };

                            ManagementBaseObject setGateway = mo.InvokeMethod("SetGateways", newGateway, null);
                        }


                        if (!DHCP && ( dns1 != null || dns2 != null))
                        {
                            ManagementBaseObject newDns = mo.GetMethodParameters("SetDNSServerSearchOrder");
                            var dns = new List<string>();

                            if (dns1 != null)
                            {
                                dns.Add(dns1);
                            }

                            if (dns2 != null)
                            {
                                dns.Add(dns2);
                            }

                            newDns["DNSServerSearchOrder"] = dns.ToArray();

                            ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDns, null);
                        }


                        if (DHCP)
                        {
                            ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");

                            newDNS["DNSServerSearchOrder"] = null;
                            ManagementBaseObject enableDHCP = mo.InvokeMethod("EnableDHCP", null, null);
                            ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                               
             
                     
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Sets the DHCP.
        /// </summary>
        /// <param name="nicName">Name of the nic.</param>
        public static bool SetDHCP(string nicName)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface networkInterface = interfaces.FirstOrDefault(x => x.Name == nicName);
            string nicDesc = nicName;

            if (networkInterface != null)
            {
                nicDesc = networkInterface.Description;
            }

            foreach (ManagementObject mo in moc)
            {
              
            }

            return true;
        }

        private class listIP
        {
            public String NicName { get; set; }
            public String ip { get; set; }
            public String subnetMask { get; set; }
            public String gateway { get; set; }
            public String dns1 { get; set; }
            public String dns2 { get; set; }
            public String dhcp { get; set; }
            public override string ToString()
            {
                return this.NicName + " IP: " + ip + " SUBNETMASK:" + subnetMask + " GATEWAY: " + gateway + " DNS 1: " + dns1 + " DNS 2: " + dns2;
            }
        }

        public void fillList(ListBox Listbx)
        {
            if (Listbx.Items.Count > 0)
            {
                Listbx.Items.Clear();
            }
          

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (ni.OperationalStatus != OperationalStatus.Up ) // && !checkboxShowInActive.Checked)
                            {
                                continue;
                            }

                            listIP lp               = new listIP();
                            lp.ip                   = ip.Address.ToString();
                            lp.NicName              = ni.Name;
                            lp.subnetMask           = ip.IPv4Mask.ToString();

                            if (ni.GetIPProperties().GatewayAddresses.Count > 0)
                            {
                                lp.gateway = ni.GetIPProperties().GatewayAddresses[0].Address.ToString();
                            }
                            if (ni.GetIPProperties().DnsAddresses.Count > 0)
                            {
                                lp.dns1 = ni.GetIPProperties().DnsAddresses[0].ToString();
                            }
                            if (ni.GetIPProperties().DnsAddresses.Count > 1)
                            {
                                lp.dns2 = ni.GetIPProperties().DnsAddresses[1].ToString();
                            }
                            

                            Listbx.Items.Add(lp);

                        }
                    }
                }
            }

        }

        public void NetworkAdapterListele(DataGridView DGV)
        {
            if (DGV.RowCount > 0)
            {
                DGV.Rows.Clear();
            }


            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (ni.OperationalStatus != OperationalStatus.Up) // && !checkboxShowInActive.Checked)
                            {
                                continue;
                            }

                            listIP lp = new listIP();
                            lp.NicName = ni.Description;
                            lp.ip = ip.Address.ToString();
                         
                            lp.subnetMask = ip.IPv4Mask.ToString();

                            if (ni.GetIPProperties().GatewayAddresses.Count > 0)
                            {
                                lp.gateway = ni.GetIPProperties().GatewayAddresses[0].Address.ToString();
                            }

                            //############################################
                            //############################################



                            if (ni.GetIPProperties().DnsAddresses.Count >= 3)
                            {
                                if (ni.GetIPProperties().DnsAddresses[1].ToString() != "fec0:0:0:ffff::2%1")
                                {
                                    lp.dns1 = ni.GetIPProperties().DnsAddresses[1].ToString();
                                }

                                if (ni.GetIPProperties().DnsAddresses[2].ToString() != "fec0:0:0:ffff::3%1")
                                {
                                    lp.dns2 = ni.GetIPProperties().DnsAddresses[2].ToString();
                                }

                            }
                            else
                            {
                                if (ni.GetIPProperties().DnsAddresses.Count > 0)
                                {
                                    if (ni.GetIPProperties().DnsAddresses[0].ToString() != "fec0:0:0:ffff::1%1")
                                    {
                                        lp.dns1 = ni.GetIPProperties().DnsAddresses[0].ToString();
                                    }

                                    if ((ni.GetIPProperties().DnsAddresses.Count >= 2) && ni.GetIPProperties().DnsAddresses[1].ToString() != "fec0:0:0:ffff::2%1")
                                    {
                                        lp.dns2 = ni.GetIPProperties().DnsAddresses[1].ToString();
                                    }
                                }
                            }
                           
                            //############################################
                            //############################################



                            if (ni.GetIPProperties().DhcpServerAddresses.Count > 0)
                            {
                               lp.dhcp = ni.GetIPProperties().DhcpServerAddresses[0].ToString();
                            }

                            DataGridViewRow row = (DataGridViewRow)DGV.Rows[0].Clone();
                            row.Cells[0].Value = lp.NicName;
                            row.Cells[1].Value = ip.Address.ToString();
                            row.Cells[2].Value = lp.subnetMask;
                            row.Cells[3].Value = lp.gateway;
                            row.Cells[4].Value = lp.dns1;
                            row.Cells[5].Value = lp.dns2;
                            row.Cells[6].Value = lp.dhcp;
                            DGV.Rows.Add(row);


                        }
                    }
                }
            }
        }

        public void ProfilKaydet()
        {
            int sw = 0;
            switch (sw)
            {
                case 0:
                    if (CLS.Form_Main.DGV_NetworkProfilKaydet.RowCount > 1)
                    {
                        CLS.Form_Main.DGV_NetworkProfilKaydet.Rows.Clear();
                    }

                    goto case 1;
                case 1:
                    for (int i = 0; i < CLS.Form_Main.DGV_NetworkProfil.RowCount - 1; i++)
                    {
                        DataGridViewRow rows = (DataGridViewRow)CLS.Form_Main.DGV_NetworkProfil.Rows[0].Clone();
                        rows.Cells[0].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[0].Value;
                        rows.Cells[1].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[1].Value;
                        rows.Cells[2].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[2].Value;
                        rows.Cells[3].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[3].Value;
                        rows.Cells[4].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[4].Value;
                        rows.Cells[5].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[5].Value;
                        rows.Cells[6].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[6].Value;
                        rows.Cells[7].Value = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[7].Value;

                        CLS.Form_Main.DGV_NetworkProfilKaydet.Rows.Add(rows);
                    }
                    goto case 2;
                case 2:
                    DataGridViewRow row = (DataGridViewRow)CLS.Form_Main.DGV_NetworkProfilKaydet.Rows[0].Clone();
                  
                    row.Cells[0].Value = CLS.Form_Main.TB_ProfilAdi_Yeni.Text;
                    row.Cells[1].Value = CLS.Form_Main.CB_AdapterName_Yeni.Text;
                    if (CLS.Form_Main.CHB_DHCP_Yeni.Checked.ToString().ToLower() == "false")
                    {
                    
                        row.Cells[2].Value = CLS.Form_Main.TB_LocalIP_Yeni.Text;
                        row.Cells[3].Value = CLS.Form_Main.TB_SubnetMask_Yeni.Text;
                        row.Cells[4].Value = CLS.Form_Main.TB_Gateway_Yeni.Text;
                        row.Cells[5].Value = CLS.Form_Main.TB_DNS1_Yeni.Text;
                        row.Cells[6].Value = CLS.Form_Main.TB_DNS2_Yeni.Text;
                        row.Cells[7].Value = CLS.Form_Main.CHB_DHCP_Yeni.Checked.ToString();
                    }
                    else
                    {
                        row.Cells[2].Value = "";
                        row.Cells[3].Value = "";
                        row.Cells[4].Value = "";
                        row.Cells[5].Value = "";
                        row.Cells[6].Value = "";
                        row.Cells[7].Value = CLS.Form_Main.CHB_DHCP_Yeni.Checked.ToString();
                    }

                    CLS.Form_Main.DGV_NetworkProfilKaydet.Rows.Add(row);

                    goto case 3;
                case 3:
                    if (File.Exists(CLS.NetworkProfil_ExcelFies))
                    {
                        CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGV_NetworkProfilKaydet, CLS.NetworkProfil_ExcelFies, false);
                    }else
                    {
                        Directory.CreateDirectory(CLS.NetworkProfil_ExcelFies);
                        CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGV_NetworkProfilKaydet, CLS.NetworkProfil_ExcelFies, false);
                    }
                    

                    goto case 4;
                case 4:
                    CLS.NetworkAdapter.NetworkAdapterListele(CLS.Form_Main.DGV_NetworkAdapter);
                    CLS.NetworkAdapter.ProfilListele(CLS.Form_Main.DGV_NetworkProfil);

                    goto case 5;
                case 5:

                    CLS.Form_Main.Grup_YeniProfilOlustur.Visible = false;
                    break;
            }
        }
        public void ProfilListele(DataGridView DGV)
        {
            CLS.EXL.READ_ExcelFile(DGV, CLS.NetworkProfil_ExcelFies, true, CLS.Form_Main.CB_sayfa);
        }
        public void ProfilSecimi(ComboBox CBox)
        {
            for (int i = 0; i < CLS.Form_Main.DGV_NetworkProfil.RowCount - 1; i++)
            {
                if (CBox.Text == CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[0].Value.ToString())
                {
                    CLS.Form_Main.TB_AdapterName_Set.Text   = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[1].Value.ToString();
                    CLS.Form_Main.TB_LocalIP_Set.Text       = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[2].Value.ToString();
                    CLS.Form_Main.TB_SubnetMask_Set.Text    = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[3].Value.ToString();
                    CLS.Form_Main.TB_Gateway_Set.Text       = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[4].Value.ToString();
                    CLS.Form_Main.TB_DNS1_Set.Text          = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[5].Value.ToString();
                    CLS.Form_Main.TB_DNS2_Set.Text          = CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[6].Value.ToString();
                    if (CLS.Form_Main.DGV_NetworkProfil.Rows[i].Cells[7].Value.ToString().ToLower() == "true")
                    {
                        CLS.Form_Main.CHB_DHCP_Set.Checked = true;
                    }
                    else
                    {
                        CLS.Form_Main.CHB_DHCP_Set.Checked = false;
                    }
                    break;
                }
            }
        }


    }


    public class NetworkConnectionManagement
    {


        /// <summary> 
        /// Set's a new IP Address and it's Submask of the local machine 
        /// </summary> 
        /// <param name="ip_address">The IP Address</param> 
        /// <param name="subnet_mask">The Submask IP Address</param> 
        /// <remarks>Requires a reference to the System.Management namespace</remarks> 
        public void setIP(string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP =
                            objMO.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };

                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }


                }
            }
        }
        /// <summary> 
        /// Set's a new Gateway address of the local machine 
        /// </summary> 
        /// <param name="gateway">The Gateway IP Address</param> 
        /// <remarks>Requires a reference to the System.Management namespace</remarks> 
        public void setGateway(string gateway)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setGateway;
                        ManagementBaseObject newGateway =
                            objMO.GetMethodParameters("SetGateways");

                        newGateway["DefaultIPGateway"] = new string[] { gateway };
                        newGateway["GatewayCostMetric"] = new int[] { 1 };

                        setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary> 
        /// Set's the DNS Server of the local machine 
        /// </summary> 
        /// <param name="NIC">NIC address</param> 
        /// <param name="DNS">DNS server address</param> 
        /// <remarks>Requires a reference to the System.Management namespace</remarks> 
        public void setDNS(string NIC, string DNS)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].Equals(NIC))
                    {
                        try
                        {
                            ManagementBaseObject newDNS =
                                objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                            ManagementBaseObject setDNS =
                                objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }
        /// <summary> 
        /// Set's WINS of the local machine 
        /// </summary> 
        /// <param name="NIC">NIC Address</param> 
        /// <param name="priWINS">Primary WINS server address</param> 
        /// <param name="secWINS">Secondary WINS server address</param> 
        /// <remarks>Requires a reference to the System.Management namespace</remarks> 
        public void setWINS(string NIC, string priWINS, string secWINS)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].Equals(NIC))
                    {
                        try
                        {
                            ManagementBaseObject setWINS;
                            ManagementBaseObject wins =
                            objMO.GetMethodParameters("SetWINSServer");
                            wins.SetPropertyValue("WINSPrimaryServer", priWINS);
                            wins.SetPropertyValue("WINSSecondaryServer", secWINS);

                            setWINS = objMO.InvokeMethod("SetWINSServer", wins, null);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }

    }

}
