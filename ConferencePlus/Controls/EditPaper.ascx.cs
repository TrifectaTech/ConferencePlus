using System;
using System.Collections.Generic;
using System.Linq;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using Telerik.Web.UI;

namespace ConferencePlus.Controls
{
    public partial class EditPaper : BaseControl
    {
        public EnumUserControlMode ControlMode
        {
            get
            {
                if (ViewState["ControlMode"] == null)
                {
                    ViewState["ControlMode"] = EnumUserControlMode.PerformInsert;
                }
                return (EnumUserControlMode)ViewState["ControlMode"];
            }
            set
            {
                ViewState["ControlMode"] = value;
            }
        }

        public int? PaperId
        {
            get
            {
                return ViewState["PaperId"] as int?;
            }
            set
            {
                ViewState["PaperId"] = value;
            }
        }

        public string PaperName
        {
            get
            {
                return txtPaperName.Text;
            }
            set
            {
                txtPaperName.Text = value;
            }
        }

        public string PaperDescription
        {
            get
            {
                return txtPaperDescription.Text;
            }
            set
            {
                txtPaperDescription.Text = value;
            }
        }

        public string Author
        {
            get
            {
                return txtAuthor.Text;
            }
            set
            {
                txtAuthor.Text = value;
            }
        }

        public EnumPaperCategory Category
        {
            get
            {
                return EnumerationsHelper.ConvertFromString<EnumPaperCategory>(ddlPaperCategory.SelectedValue);
            }
            set
            {
                EnumPaperCategory category = value;

                RadComboBoxItem item = ddlPaperCategory.Items.FindItemByValue(category.ToString());

                if (item != null)
                {
                    ddlPaperCategory.SelectedValue = category.ToString();
                }
                else
                {
                    ddlPaperCategory.ClearSelection();
                }
            }
        }

        public bool Save(out string errorMessage)
        {
            Paper paper = GetPaperFromForm();

            bool isValid = PaperManager.Save(paper, out errorMessage);

            return isValid;
        }

        public void ShowErrorMessage(string message)
        {
            pnlError.Visible = true;

            lblError.Text = string.Empty;
        }

        public void HideErrorMessage()
        {
            pnlError.Visible = false;

            lblError.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            HideErrorMessage();
        }

        private void LoadDllPaperCategory()
        {
            ddlPaperCategory.Items.Clear();

            List<EnumPaperCategory> categories =
                EnumerationsHelper.GetEnumerationValues<EnumPaperCategory>()
                    .Where(dd => dd != EnumPaperCategory.None)
                    .ToList();

            foreach (EnumPaperCategory category in categories)
            {
                ddlPaperCategory.Items.Add(new RadComboBoxItem(category.ToFormattedString(), category.ToString()));
            }
        }

        public void ReloadControl()
        {
            LoadDllPaperCategory();

            if (ControlMode == EnumUserControlMode.Edit)
            {
                Paper paper = PaperManager.Load(PaperId.GetValueOrDefault());

                LoadControlFromPaper(paper);
            }
        }
 
        private void LoadControlFromPaper(Paper paper)
        {
            PaperName = paper.Name;

            PaperDescription = paper.Description;

            Category = paper.PaperCategory;

            Author = paper.Author;

            PaperId = paper.PaperId;
        }

        private Paper GetPaperFromForm()
        {
            Paper paper = new Paper
            {
                Author = Author,
                Description = PaperDescription,
                IsItemModified = true,
                Name = PaperName,
                UserId = UserId,
                PaperId = ControlMode == EnumUserControlMode.Add ? null : PaperId,
                PaperCategory = Category
            };

            return paper;
        }


    }
}