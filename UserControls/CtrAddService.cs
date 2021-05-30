﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using carfixer.DomainModel;

namespace carfixer.UserControls
{
	public partial class CtrAddService : UserControl
	{
		private Form1 form;
		private DataProvider dataProvider = new DataProvider();
		private List<String> profesije = new List<String>() { "mehanicar", "vulkanizer", "veliki/mali servis", "limar", "tehnicki pregled" };

		public CtrAddService(Form1 form)
		{
			InitializeComponent();
			this.form = form;

			foreach (String el in this.profesije)
			{
				comboBox1.Items.Add(el);
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			CtrLoginOrRegister ctr = new CtrLoginOrRegister(form);
			form.setUserControl(ctr);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			String name, city, address, profession;
			int telefon;
			name = tbName.Text;
			city = tbCity.Text;
			address = tbAddress.Text;
			telefon = Int32.Parse(tbTelefon.Text);
		    profession = comboBox1.SelectedItem.ToString();

			Service c = new Service();
			c = dataProvider.CreateService(name,telefon, profession);
			dataProvider.CreateCity(city);
			dataProvider.RelIn(c, city, address);
			MessageBox.Show(" Add service in database");

		}

		
	}
}
