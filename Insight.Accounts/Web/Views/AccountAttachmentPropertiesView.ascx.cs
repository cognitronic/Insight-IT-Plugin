﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Accounts.Presenters;
using Insight.Accounts.Presenters.ViewInterfaces;
using IdeaSeed.Web.UI;
using Insight.Web.Bases;
using Insight.Accounts.Core.Domain;
using Insight.Core.Domain;
using System.Configuration;

namespace Insight.Accounts.Web.Views
{
    [PresenterType(typeof(AccountAttachmentPropertiesPresenter))]
    public partial class AccountAttachmentPropertiesView : BaseWebUserControl, IAccountAttachmentPropertiesView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (!IsPostBack)
            {
                if (this.LoadView != null)
                {
                    this.LoadView(this, EventArgs.Empty);
                }
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (this.UnloadView != null)
            {
                this.UnloadView(this, EventArgs.Empty);
            }
        }

        #region IAccountAttachmentPropertiesView Members
        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;

        public void LoadAttachment(AccountAttachment attachment)
        {
            if (attachment == null || attachment.ID == 0)
            {
                ddlAccount.SelectedValue = this.AccountID.ToString();
            }
            else
            {
                ddlAccount.SelectedValue = attachment.AccountID.ToString();
            }
            lblDateCreated.Text = attachment.DateCreated.ToString();
            lblID.Text = attachment.ID.ToString();
            lblLastUpdated.Text = attachment.LastUpdated.ToString();
            tbDescription.Text = attachment.Description;
            tbTitle.Text = attachment.Title;
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        #endregion

        #region IAccountAttachment Members

        public string ViewTitle
        {
            get
            {
                return lblPropertiesTitle.Text;
            }
            set
            {
                lblPropertiesTitle.Text = value;
            }
        }

        public string Title
        {
            get
            {
                return tbTitle.Text;
            }
            set
            {
                tbTitle.Text = value;
            }
        }

        public int AccountID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlAccount.SelectedValue, out i))
                    return i;
                return i;
            }
            set
            {
                int i = (int)value;
                if (i == 0)
                    ddlAccount.SelectedValue = "";
                else
                    ddlAccount.SelectedValue = i.ToString();
            }
        }

        public Account AttachmentAccount
        {
            get;
            set;
        }

        #endregion

        #region IBaseAttachment Members

        public string FileName
        {
            get
            {
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    return file.FileName;
                }
                return "";
            }
            set
            {
                
            }
        }

        public string FullPath
        {
            get
            {
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["EVENTIMAGEPATH"]) + filePath, false);
                    //e.DefaultPhoto = ConfigurationManager.AppSettings["EVENTIMAGEPATH"] + filePath;
                }
                return "";
            }
            set
            {

            }
        }

        #endregion

        #region IAuditable Members

        public int ChangedBy
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get
            {
                return DateTime.Parse(lblDateCreated.Text);
            }
            set
            {
                lblDateCreated.Text = value.ToString();
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return DateTime.Parse(lblLastUpdated.Text);
            }
            set
            {
                lblLastUpdated.Text = value.ToString();
            }
        }

        public bool MarkedForDeletion
        {
            get;
            set;
        }

        public object ItemReference
        {
            get;
            set;
        }

        public int EnteredBy
        {
            get;
            set;
        }

        #endregion

        #region IItem Members

        public string Description
        {
            get
            {
                return tbDescription.Text;
            }
            set
            {
                tbDescription.Text = value;
            }
        }

        public new int ID
        {
            get
            {
                int i = 0;
                if (int.TryParse(lblID.Text, out i))
                    return i;
                return i;
            }
            set
            {
                int i = value;
                lblID.Text = i.ToString();
            }
        }

        public string Name
        {
            get;
            set;
        }

        public ItemType TypeOfItem
        {
            get { return ItemType.ATTACHMENT; }
        }

        public string URL
        {
            get;
            set;
        }

        #endregion
    }
}