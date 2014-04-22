using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using System.Configuration;

namespace mvc4_template
{
    public class Keystone
    {
        public static UserAccess Authenticate(string token)
        {
            var identityProvider = new CloudIdentityProvider(new Uri(ConfigurationManager.AppSettings["Keystone.Uri"]));
            var identity = new ExtendedCloudIdentity()
            {
                TenantName = ConfigurationManager.AppSettings["Keystone.AdminTenant"],
                Username = ConfigurationManager.AppSettings["Keystone.AdminUser"],
                Password = ConfigurationManager.AppSettings["Keystone.AdminPassword"],
            };
            var userAccess = identityProvider.ValidateToken(token, null, identity);
            return userAccess;
        }
    }
}