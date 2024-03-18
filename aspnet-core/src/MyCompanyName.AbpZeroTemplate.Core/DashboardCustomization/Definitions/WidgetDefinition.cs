using System.Collections.Generic;
using Abp.MultiTenancy;

namespace MyCompanyName.AbpZeroTemplate.DashboardCustomization.Definitions
{
    public class WidgetDefinition
    {
        public string Id { get; }

        public string Name { get; }

        public MultiTenancySides Side { get; }

        public List<string> Permissions { get; }

        public List<string> UsedWidgetFilters { get; }

        public string Description { get; }

        public bool AllowMultipleInstanceInSamePage { get; }

        public WidgetDefinition(
            string id,
            string name,
            MultiTenancySides side = MultiTenancySides.Tenant | MultiTenancySides.Host,
            List<string> usedWidgetFilters = null,
            List<string> permissions = null,
            string description = null,
            bool allowMultipleInstanceInSamePage = true)
        {
            Id = id;
            Name = name;
            Side = side;
            Permissions = permissions ?? new List<string>();
            UsedWidgetFilters = usedWidgetFilters;
            Description = description;
            AllowMultipleInstanceInSamePage = allowMultipleInstanceInSamePage;
        }
    }
}
