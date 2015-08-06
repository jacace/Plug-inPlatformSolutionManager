using Intel.Ucrd.SolutionManagerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin_AgentMonitor
{
    /// <summary>
    /// Class to integrate via abstraction the AgentMonitor plug in with 
    /// the PlugIn Manager/API provided by PSM
    /// </summary>
    public class AgentMonitor_Impl : SolutionManagerPlugin
    {
        ctrlAgentMonitor ctrl = null;

        public override void ExecuteNoUI() { }

        public AgentMonitor_Impl()
        {
            _properties.Icon = Plugin_AgentMonitor.Resource1.AgentIcon;
            _properties.Name = "Agent Monitor";
            _properties.Category = Categories.MISC | Categories.AMT;
        }

        public override bool RequiresAMT
        {
            get
            {
                return true;
            }
        }        

        public override System.Windows.Controls.UserControl PluginWPFControl
        {
            get
            {
                lock (this)
                {
                    if (ctrl == null)
                    {
                        ctrl = new ctrlAgentMonitor(this);
                    }
                }
                return ctrl;
            }
        }

        public override SolutionManagerPlugin CreateInstance()
        {
            return new AgentMonitor_Impl();
        }
    }
}
