using IBApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBSampleApp.ui
{
    public partial class ConditionDialog : Form
    {
        Dictionary<RadioButton, Tuple<Panel, OrderConditionType>> radioMap = new Dictionary<RadioButton, Tuple<Panel, OrderConditionType>>();
        IEnumerable<RadioButton> radioButtons;
        
        public OrderCondition Condition { get; private set; }

        public ConditionDialog(OrderCondition condition, IBClient ibClient)
        {
            InitializeComponent();

            radioMap[priceRb] = Tuple.Create(pricePanel, OrderConditionType.Price);
            radioMap[marginRb] = Tuple.Create(marginPanel, OrderConditionType.Margin);
            radioMap[tradeRb] = Tuple.Create(tradePanel, OrderConditionType.Execution);
            radioMap[timeRb] = Tuple.Create(timePanel, OrderConditionType.Time);
            radioMap[volumeRb] = Tuple.Create(volumePanel, OrderConditionType.Volume);
            radioMap[percentRb] = Tuple.Create(percentPanel, OrderConditionType.PercentCange);

            radioButtons = conditionTypePage.Controls.OfType<RadioButton>().ToArray();
            this.Condition = condition != null ? condition : OrderCondition.Create(OrderConditionType.Price);

            priceMethod.Items.AddRange(CTriggerMethod.friendlyNames.Where(n => !string.IsNullOrWhiteSpace(n)).ToArray());

            foreach (var tab in tabControl1.TabPages.OfType<TabPage>().ToList())
            {
                foreach (var panel in tab.Controls.OfType<Panel>().ToList())
                {
                    var cscs = panel.Controls.OfType<ContractSearchControl>().ToList();
                    
                    cscs.ForEach(csc => 
                        csc.IBClient = ibClient);
                }
            }
            
            tabControl1.TabPages.OfType<TabPage>().Skip(2).ToList().ForEach(page => tabControl1.TabPages.Remove(page));

            switch (this.Condition.Type)
            {
                case OrderConditionType.Execution:
                    fillFromCondition(this.Condition as ExecutionCondition);
                    break;  
  
                case OrderConditionType.Margin:
                    fillFromCondition(this.Condition as MarginCondition);
                    break;

                case OrderConditionType.PercentCange:
                    fillFromCondition(this.Condition as PercentChangeCondition);
                    break;

                case OrderConditionType.Price:
                    fillFromCondition(this.Condition as PriceCondition);
                    break;

                case OrderConditionType.Time:
                    fillFromCondition(this.Condition as TimeCondition);
                    break;

                case OrderConditionType.Volume:
                    fillFromCondition(this.Condition as VolumeCondition);
                    break;
            }

            if (condition != null)
            {
                tabControl1.TabPages.RemoveAt(0);

                back.Visible = false;
                tabControl1.SelectedTab = conditionPage;

                tabControl1_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        private void fillFromCondition(VolumeCondition volumeCondition)
        {
            fillOperator(volumeOperator, volumeCondition);
            fillUnderlyingContract(volumeUnderlying, volumeCondition);

            volume.Text = volumeCondition.Volume.ToString();
            volumeRb.Checked = true;
        }

        private void fillFromCondition(TimeCondition timeCondition)
        {
            fillOperator(timeOperator, timeCondition);

            time.Text = timeCondition.Time;
            timeRb.Checked = true;
        }

        private void fillFromCondition(PriceCondition priceCondition)
        {
            fillOperator(priceOperator, priceCondition);
            fillUnderlyingContract(priceUnderlying, priceCondition);

            price.Text = priceCondition.Price.ToString();
            priceMethod.Text = priceCondition.TriggerMethod.ToFriendlyString();
            priceRb.Checked = true;
        }

        private void fillFromCondition(PercentChangeCondition percentChangeCondition)
        {
            percent.Text = percentChangeCondition.ChangePercent.ToString();
            percentRb.Checked = true;

            fillUnderlyingContract(percentUnderlying, percentChangeCondition);
            fillOperator(percentOperator, percentChangeCondition);
        }

        private void fillFromCondition(MarginCondition marginCondition)
        {
            fillOperator(marginOperator, marginCondition);

            marginCushion.Text = marginCondition.Percent.ToString();
            marginRb.Checked = true;
        }

        private void fillFromCondition(ExecutionCondition orderCondition)
        {
            tradeUnderlying.Text = orderCondition.Symbol;
            tradeExchange.Text = orderCondition.Exchange;
            tradeType.Text = orderCondition.SecType;
            tradeRb.Checked = true;
        }

        private void fillOperator(ComboBox op, OperatorCondition condition)
        {
            op.SelectedIndex = condition.IsMore ? 1 : 0;
        }

        private void fillUnderlyingContract(ContractSearchControl underlyingControl, ContractCondition condition)
        {
            underlyingControl.Contract = new Contract() { ConId = condition.ConId, Exchange = condition.Exchange };
        }

        private void next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = conditionPage;
        }

        private void back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = conditionTypePage;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != conditionPage)
                return;

            var panel = radioMap[radioButtons.FirstOrDefault(rb => rb.Checked)].Item1;

            conditionPanel.Controls.Clear();
            conditionPanel.Controls.Add(panel);
            panel.Controls.OfType<ComboBox>().ToList().ForEach(cb => cb.SelectedIndex = 0);
        }

        private void apply_Click(object sender, EventArgs e)
        {
            var type = radioMap[radioButtons.FirstOrDefault(rb => rb.Checked)].Item2;

            if (type != Condition.Type)
                Condition = OrderCondition.Create(type);

            switch (type)
            {
                case OrderConditionType.Execution:
                    fillCondition(Condition as ExecutionCondition);
                    break;

                case OrderConditionType.Margin:
                    fillCondition(Condition as MarginCondition);
                    break;

                case OrderConditionType.PercentCange:
                    fillCondition(Condition as PercentChangeCondition);
                    break;

                case OrderConditionType.Price:
                    fillCondition(Condition as PriceCondition);
                    break;

                case OrderConditionType.Time:
                    fillCondition(Condition as TimeCondition);
                    break;

                case OrderConditionType.Volume:
                    fillCondition(Condition as VolumeCondition);
                    break;
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void fillCondition(VolumeCondition volumeCondition)
        {
            fillOperator(volumeCondition, volumeOperator);
            fillUnderlyingContract(volumeCondition, volumeUnderlying);

            volumeCondition.Volume = int.Parse(volume.Text);
        }

        private void fillCondition(TimeCondition timeCondition)
        {
            fillOperator(timeCondition, timeOperator);

            timeCondition.Time = time.Text;
        }

        private void fillCondition(PriceCondition priceCondition)
        {
            fillOperator(priceCondition, priceOperator);
            fillUnderlyingContract(priceCondition, priceUnderlying);

            priceCondition.TriggerMethod = CTriggerMethod.FromFriendlyString(priceMethod.Text);
            priceCondition.Price = double.Parse(price.Text);
        }

        private void fillCondition(PercentChangeCondition percentChangeCondition)
        {
            fillOperator(percentChangeCondition, percentOperator);
            fillUnderlyingContract(percentChangeCondition, percentUnderlying);
        }

        private void fillCondition(MarginCondition marginCondition)
        {
            fillOperator(marginCondition, marginOperator);

            marginCondition.Percent = int.Parse(marginCushion.Text);
        }

        private void fillCondition(ExecutionCondition executionCondition)
        {
            executionCondition.Symbol = tradeUnderlying.Text;
            executionCondition.Exchange = tradeExchange.Text;
            executionCondition.SecType = tradeType.Text;
        }

        private void fillUnderlyingContract(ContractCondition condition, ContractSearchControl underlying)
        {
            if (underlying == null || underlying.Contract == null)
                return;

            condition.ConId = underlying.Contract.ConId;
            condition.Exchange = underlying.Contract.Exchange;
        }

        private void fillOperator(OperatorCondition condition, ComboBox op)
        {
            condition.IsMore = op.SelectedIndex == 1;
        }
    }
}
