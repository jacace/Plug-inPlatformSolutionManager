using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Intel.Ucrd.SolutionManagerAPI;
using System.Xml.Serialization;
using System.IO;
//using Intel.Ucrd.vProPlatformSolutionManager;
using Intel.Manageability.AgentPresence;
using System.Collections.Generic;
using Intel.Manageability.WSManagement;
using Common;

namespace Plugin_AgentMonitor
{
    /// <summary>
    /// Interaction logic for ctrlAgentMonitor.xaml
    /// </summary>
    public partial class ctrlAgentMonitor : ctrlWPFBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>

        public ctrlAgentMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor injection
        /// </summary>
        /// <param name="plugin"></param>
        public ctrlAgentMonitor(SolutionManagerPlugin plugin)
            : base(plugin)
        {
            InitializeComponent();
            _plugin = plugin;
        }

        /// <summary>
        /// Function to load a list of watch dogs
        /// </summary>
        private void ListWatchdogs()
        {
            IWSManClient wsmanClient = new DotNetWSManClient(_plugin.System.Fqdn, "admin", _plugin.System.Password,
                                                             _plugin.System.UseTls, false, null, null);
            WatchdogWrapper client = new WatchdogWrapper();
            var list = client.List(wsmanClient, null);            
            if (list != null)
            {
                lstAgents.DataContext = list;
            }            
        }

        #region Events

        private bool _isLoaded = false;
        private void ctrlWPFBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_isLoaded)
            {
                //One time stuff here
                ListWatchdogs();
            }
            _isLoaded = true;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ListWatchdogs();
        }

        #endregion
    }
    
}
