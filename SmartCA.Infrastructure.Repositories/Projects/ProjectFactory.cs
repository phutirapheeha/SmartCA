using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Model.Projects;
using System.Data.Sql;
using System.Data;
using SmartCA.Model;
using SmartCA.Infrastructure.EntityFactoryFramework;

namespace SmartCA.Infrastructure.Repositories
{
    internal class ProjectFactory : IEntityFactory<Project>
    {
        #region Field Names

        internal static class FieldNames
        {
            public const string ProjectId = "ProjectID";
            public const string ProjectNumber = "ProjectNumber";
            public const string ProjectName = "ProjectName";
            public const string ConstructionAdministratorEmployeeId = "ConstructionAdministratorEmployeeID";
            public const string PrincipalEmployeeId = "PrincipalEmployeeID";
            public const string Street = "Street";
            public const string City = "City";
            public const string State = "State";
            public const string PostalCode = "PostalCode";
            public const string OwnerCompanyId = "OwnerCompanyID";
            public const string ContractDate = "ContractDate";
            public const string EstimatedStartDate = "EstimatedStartDate";
            public const string EstimatedCompletionDate = "EstimatedCompletionDate";
            public const string CurrentCompletionDate = "CurrentCompletionDate";
            public const string ActualCompletionDate = "ActualCompletionDate";
            public const string ContingencyAllowanceAmount = "ContingencyAllowanceAmount";
            public const string TestingAllowanceAmount = "TestingAllowanceAmount";
            public const string UtilityAllowanceAmount = "UtilityAllowanceAmount";
            public const string OriginalConstructionCost = "OriginalConstructionCost";
            public const string AeChangeOrderAmount = "AEChangeOrderAmount";
            public const string ContractReason = "ContractReason";
            public const string TotalSquareFeet = "TotalSquareFeet";
            public const string PercentComplete = "PercentComplete";
            public const string Remarks = "Remarks";
            public const string AgencyApplicationNumber = "AgencyApplicationNumber";
            public const string AgencyFileNumber = "AgencyFileNumber";
            public const string MarketSegmentId = "MarketSegmentID";
            public const string MarketSegmentCode = "Code";
            public const string MarketSegmentName = "MarketSegmentName";
            public const string AllowanceTitle = "AllowanceTitle";
            public const string AllowanceAmount = "Amount";
        }

        #endregion

        #region IEntityFactory<Project> Members

        public Project BuildEntity(IDataReader reader)
        {
            Project project = new Project(reader[FieldNames.ProjectId],
                              reader[FieldNames.ProjectNumber].ToString(),
                              reader[FieldNames.ProjectName].ToString());
            project.Address = new Address(reader[FieldNames.Street].ToString(),
                                  reader[FieldNames.City].ToString(),
                                  reader[FieldNames.State].ToString(),
                                  reader[FieldNames.PostalCode].ToString());
            project.ContractDate = DataHelper.GetNullableDateTime(reader[FieldNames.ContractDate]);
            project.EstimatedStartDate = DataHelper.GetNullableDateTime(reader[FieldNames.EstimatedStartDate]);
            project.EstimatedCompletionDate = DataHelper.GetNullableDateTime(reader[FieldNames.EstimatedCompletionDate]);
            project.CurrentCompletionDate = DataHelper.GetNullableDateTime(reader[FieldNames.CurrentCompletionDate]);
            project.ActualCompletionDate = DataHelper.GetNullableDateTime(reader[FieldNames.ActualCompletionDate]);
            project.ContingencyAllowanceAmount = DataHelper.GetDecimal(reader[FieldNames.ContingencyAllowanceAmount]);
            project.TestingAllowanceAmount = DataHelper.GetDecimal(reader[FieldNames.TestingAllowanceAmount]);
            project.UtilityAllowanceAmount = DataHelper.GetDecimal(reader[FieldNames.UtilityAllowanceAmount]);
            project.OriginalConstructionCost = DataHelper.GetDecimal(reader[FieldNames.OriginalConstructionCost]);
            project.TotalSquareFeet = DataHelper.GetInteger(reader[FieldNames.TotalSquareFeet]);
            project.PercentComplete = DataHelper.GetInteger(reader[FieldNames.PercentComplete]);
            project.Remarks = reader[FieldNames.Remarks].ToString();
            project.AeChangeOrderAmount = DataHelper.GetDecimal(reader[FieldNames.AeChangeOrderAmount]);
            project.ContractReason = reader[FieldNames.ContractReason].ToString();
            project.AgencyApplicationNumber = reader[FieldNames.AgencyApplicationNumber].ToString();
            project.AgencyFileNumber = reader[FieldNames.AgencyFileNumber].ToString();
            project.Segment = new MarketSegment(reader[FieldNames.MarketSegmentId],
                                  null,
                                  reader[FieldNames.MarketSegmentCode].ToString(),
                                  reader[FieldNames.MarketSegmentName].ToString());
            return project;
        }

        #endregion

        public static Allowance BuildAllowance(IDataReader reader)
        {
            return new Allowance(reader[FieldNames.AllowanceTitle].ToString(),
                       DataHelper.GetDecimal(reader[FieldNames.AllowanceAmount]));
        }
    }
}
