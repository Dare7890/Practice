using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    internal partial class StatisticForm : Form
    {
        BindingSource source;
        BindingList<ITanks> bindingList;

        public StatisticForm(Kolobok kolobok, Tank[] tanks, Apple[] apples)
        {
            InitializeComponent();
            bindingList = new BindingList<ITanks>();
            bindingList.Add(kolobok);
            foreach (var tank in tanks)
            {
                bindingList.Add(tank);
            }
            foreach (var apple in apples)
            {
                bindingList.Add(apple);
            }
            source = new BindingSource(bindingList, null);

            var result = from t in bindingList
                         select new { t.GetType().Name, t.CurrentPosition.X,
                             t.CurrentPosition.Y };
            dgvStatistic.DataSource = result.ToList();
            timer1.Interval = 200;
            timer1.Start();
        }

        public void Updates()
        {
            var result = from t in bindingList
                         select new { t.GetType().Name, t.CurrentPosition.X,
                             t.CurrentPosition.Y };
            if (dgvStatistic.InvokeRequired)
            {
                try
                {
                    dgvStatistic.Invoke(new MethodInvoker(delegate
                    {
                        dgvStatistic.DataSource = result.ToList();
                    }));
                }
                catch(InvalidAsynchronousStateException)
                {
                    return;
                }
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Updates();
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

    }


}
