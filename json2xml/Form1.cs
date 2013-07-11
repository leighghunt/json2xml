using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace json2xml
{
    public partial class Form1 : Form
    {
        private bool _updatingControls = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtJSON_TextChanged(object sender, EventArgs e)
        {
            updateJSON(sender);
        }

        private void txtEmbeddedJSON_TextChanged(object sender, EventArgs e)
        {
            updateJSON(sender);
        }

        private void updateJSON(object sender)
        {
            try
            {
                if (_updatingControls)
                {
                    return;
                }

                _updatingControls = true;
                if (sender is TextBox)
                {
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(((TextBox)sender).Text);

                    if (sender == txtJSON)
                    {
                        txtEmbeddedJSON.Text = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.None).Replace("\"", "'");
                    }

                    if (sender == txtEmbeddedJSON)
                    {
                        txtJSON.Text = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);
                    }
                }
                lblErrorMessage.Text = "";

                _updatingControls = false;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
                _updatingControls = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
        }
    }
}
