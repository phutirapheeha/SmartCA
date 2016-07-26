using System;
using System.Collections.Generic;
using System.Text;
using SmartCA.Model.Projects;
using SmartCA.Model;

namespace SmartCA.Application
{
    public static class UserSession
    {
        private static Project currentProject;
        private static OfficeLocation currentOffice;

        public static OfficeLocation CurrentOffice
        {
            get { return UserSession.currentOffice; }
            set { UserSession.currentOffice = value; }
        }

        public static Project CurrentProject
        {
            get { return UserSession.currentProject; }
            set { UserSession.currentProject = value; }
        }
    }
}
