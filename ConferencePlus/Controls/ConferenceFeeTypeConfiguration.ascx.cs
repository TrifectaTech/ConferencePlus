using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Controls;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities.Common;
using Telerik.Web.UI;

namespace ConferencePlus.Controls
{
    public partial class ConferenceFeeTypeConfiguration : BaseControl
    {

        public int ConferenceFeeId
        {
            get
            {
                if (ViewState["ConferenceFeeId"] == null)
                {
                    ViewState["ConferenceFeeId"] = 0;
                }
                return (int)ViewState["ConferenceFeeId"];
            }
            set { ViewState["ConferenceFeeId"] = value; }
        }

        public int ConferenceId
        {
            get
            {
                if (ViewState["ConferenceId"] == null)
                {
                    ViewState["ConferenceId"] = 0;
                }
                return (int)ViewState["ConferenceId"];
            }
            set { ViewState["ConferenceId"] = value; }
        }   

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ReloadControl()
        {
            LoadDdlAdjustmenType();
            LoadDdlFeeTypes();

            if (UserControl_Mode == EnumUserControlMode.Edit)
            {
                LoadControlOnConferenceFeeId(ConferenceFeeId);
            }
        }

        private void LoadControlOnConferenceFeeId(int conferenceFeeId)
        {
            ConferenceFee fee = ConferenceFeeManager.Load(conferenceFeeId);

            ddlAdjustmentType.SelectedValue = fee.FeeAdjustment.ToString();
            ddlFeeType.SelectedValue = fee.FeeType.ToString();
            txtMultiplier.Value = (double)fee.Multiplier;
        }

        private void LoadDdlAdjustmenType()
        {
            ddlAdjustmentType.DataSource = EnumerationsHelper.GetEnumerationValues<EnumFeeAdjustment>(true);
            ddlAdjustmentType.DataBind();
            ddlAdjustmentType.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlAdjustmentType.SelectedIndex = 0;
        }

        private void LoadDdlFeeTypes()
        {
            ddlFeeType.DataSource = EnumerationsHelper.GetEnumerationValues<EnumFeeType>(true);
            ddlFeeType.DataBind();
            ddlFeeType.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlFeeType.SelectedIndex = 0;

        }

        public bool SaveControl()
        {
            bool isValid;

            ConferenceFee confFeeToSave = new ConferenceFee();
            confFeeToSave.ConferenceId = ConferenceId;
            if(UserControl_Mode == EnumUserControlMode.Edit)
            {
                confFeeToSave = ConferenceFeeManager.Load(ConferenceFeeId);
            }

            confFeeToSave.FeeAdjustment = EnumerationsHelper.ConvertFromString<EnumFeeAdjustment>(ddlAdjustmentType.SelectedValue);
            confFeeToSave.FeeType = EnumerationsHelper.ConvertFromString<EnumFeeType>(ddlFeeType.SelectedValue);
            confFeeToSave.Multiplier = (decimal)txtMultiplier.Value;



            string error;
            isValid = ConferenceFeeManager.Save(confFeeToSave, out error);
            lblError.Text = error;

            return isValid;
        }
    }
}