using System;
using Concepts;
using System.Collections.Generic;

namespace Domain.StaffUser
{
    public enum RoleType
    {
        Admin,
        SystemConfigurator,
        DataCooridinator,
        DataOwner,
        StaffDataVerifier,
        AffiliateDataVerifier,
        StaffDataConsumer,
        AffiliateDataConsumer
    }
}