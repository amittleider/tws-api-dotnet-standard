using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBApi;

namespace IBSampleApp.ui
{
    public abstract class DataManager
    {
        protected Control uiControl;
        protected IBClient ibClient;
        protected int currentTicker = 1;

        protected delegate void UpdateUICallback(IBMessage msg);

        public DataManager(IBClient client, Control dataGrid)
        {
            ibClient = client;
            uiControl = dataGrid;
        }

        //public abstract void AddRequest(Contract contract);

        public abstract void NotifyError(int requestId);

        protected abstract void Populate(IBMessage message);

        public abstract void Clear();

        public void UpdateUI(IBMessage message)
        {
            if (uiControl.InvokeRequired)
            {
                UpdateUICallback callback = new UpdateUICallback(UpdateUI);
                uiControl.Invoke(callback, new object[] { message });
            }
            else
            {
                Populate(message);
            }
        }
    }
}
