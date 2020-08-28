﻿namespace SmartHub.Domain.Common.Constants
{
    public static class ApiRoutes
    {
        public const string ApiControllerBase = "api/[controller]/";

        public static class InitRoutes
        {
            public const string InitHome = "init";
        }

        public static class PluginRoutes
        {
            public const string FindAll = "findAll";
            public const string FindNew = "findNew";
            public const string LoadNewByPath = "loadNewByPath";
            public const string LoadOnlyNew = "loadAllNew";
        }
        public static class NetworkScanRoutes
        {
            public const string Search = "search";
        }

        public static class IdentityRoutes
        {
            public const string Login = "login";
            public const string Registration = "registration";
        }

        public static class DeviceStateRoutes
        {
            public const string SetLightByDevice = "light/{deviceId}";
        }
    }
}