using SmartCA.Infrastructure.DomainBase;
using SmartCA.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Model.Projects
{
    public class ProjectContact : EntityBase
    {
        private Project project;
        private bool onFinalDistributionList;
        private Contact contact;

        public ProjectContact(Project project, object key,
            Contact contact)
            : base(key)
        {
            this.project = project;
            this.contact = contact;
            this.onFinalDistributionList = false;
        }

        public Project Project
        {
            get { return this.project; }
        }

        public Contact Contact
        {
            get { return this.contact; }
        }

        public bool OnFinalDistributionList
        {
            get { return this.onFinalDistributionList; }
            set { this.onFinalDistributionList = value; }
        }
    }
}
